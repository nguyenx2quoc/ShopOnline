using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApplication2.Models;
using WebApplication2.ServiceDB; 

namespace WebApplication2.Controllers
{

    [RoutePrefix("api/Server")]

    public class ServerAPIController : ApiController
    {
        private ShopEntities1 db = new ShopEntities1();
        private ServiceDB.Service Service = new ServiceDB.Service();

       
        #region --Đăng nhập--
        [Authorize]
        [HttpGet]
        [Route("accInfor")]

        public AccInfor getAccInfor(string UseName, string PassWord)
        {

            AccInfor result = Service.getAccInfor(UseName, PassWord);
            if (result != null)
            {
                return result;
            }
            else
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, "invalid account"));
        }
        #endregion

        #region --Quốc--

        #region --GET--
        //1. Lấy thông tin tất cả sản phẩm
        [Route("getsp")]
        [HttpGet]
        public List<SanPham> get_San_Pham()
        {

            var item = (from i in db.CHITIETMATHANGs
                        join u in db.MATHANGs on i.IDMatHang equals u.ID
                        join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                        where (u.STATUS != false && i.STATUS != false)
                        select new SanPham
                        {
                            MH_ID = u.ID.ToString(),
                            MH_TenMH = u.TenMH,
                            MH_IDSubLoaiHang = m.ID.ToString(),
                            MH_Status = u.STATUS.ToString(),
                            MH_URLHinhAnh1 = u.URLHinhAnh1,
                            MH_URLHinhAnh2 = u.URLHinhAnh2,
                            MH_URLHinhAnh3 = u.URLHinhAnh3,

                            CT_ID = i.ID.ToString(),
                            CT_Gia = i.Gia.ToString(),
                            CT_Loai = i.Loai,
                            CT_MauSac = i.MauSac,
                            CT_MoTa = i.MoTa,
                            CT_Size = i.Size,
                            CT_SoLuong = i.SoLuong.ToString(),
                            CT_Status = i.STATUS.ToString(),

                        }).ToList();
            return item;
        }

        //2. Lấy thông tin sản phẩm theo ID
        [Route("getsptheoid")]
        [HttpGet]
        public List<SanPham> get_San_Pham_ID(string IDCTMH)
        {

            var item = (from i in db.CHITIETMATHANGs
                        join u in db.MATHANGs on i.IDMatHang equals u.ID
                        where (u.STATUS != false && i.STATUS != false && i.ID.ToString() == IDCTMH)
                        select new SanPham
                        {
                            MH_ID = u.ID.ToString(),
                            MH_TenMH = u.TenMH,
                            MH_IDSubLoaiHang = u.IDSubLoaiHang.ToString(),
                            MH_Status = u.STATUS.ToString(),
                            MH_URLHinhAnh1 = u.URLHinhAnh1,
                            MH_URLHinhAnh2 = u.URLHinhAnh2,
                            MH_URLHinhAnh3 = u.URLHinhAnh3,

                            CT_ID = i.ID.ToString(),
                            CT_Gia = i.Gia.ToString(),
                            CT_Loai = i.Loai,
                            CT_MauSac = i.MauSac,
                            CT_MoTa = i.MoTa,
                            CT_Size = i.Size,
                            CT_SoLuong = i.SoLuong.ToString(),
                            CT_Status = i.STATUS.ToString(),

                        }).ToList();
            return item;
        }

        //3. Lấy tất cả hóa đơn
        [HttpGet]
        [Route("hoadon")]
        public List<HoaDonKH> GetHoaDon()
        {
            try
            {
                var f = (from u in db.HOADONs
                         where u.STATUS == true
                         select new HoaDonKH
                         {
                             ID = u.ID,
                             SDT = u.SDT,
                             Email = u.EMAIL,
                             Ngay = u.Ngay.ToString(),
                             TinhTrang = u.TinhTrang,
                             TongTien = u.TongTien
                         }).ToList();
                return f;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }

        }


        //4. Lấy hóa đơn theo ID
        [HttpGet]
        [Route("hoadon")]
        public List<HoaDonKH> GetHoaDon(int ID)
        {
            try
            {
                var f = (from u in db.HOADONs
                         where u.STATUS == true && u.ID == ID
                         select new HoaDonKH
                         {
                             ID = u.ID,
                             SDT = u.SDT,
                             Email = u.EMAIL,
                             Ngay = u.Ngay.ToString(),
                             TinhTrang = u.TinhTrang,
                             TongTien = u.TongTien
                         }).ToList();
                return f;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }

        }

        //3. Lấy tất cả hóa đơn
        [HttpGet]
        [Route("getsub")]
        public List<_SubLH> GetSub()
        {
            try
            {
                var f = (from u in db.SUBLOAIHANGs
                         select new _SubLH
                         {
                             ID = u.ID.ToString(),
                             IDLH = u.IDLoaiHang.ToString(),
                             TenLoai = u.TenLoai,
                             Mota = u.MoTa,
                         }).ToList();
                return f;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }

        }
        #endregion

        #region --POST--
        //1. Thêm 1 mặt hàng
        [Route("themMH")]
        [HttpPost]
        public bool postMatHang(MATHANG a)
        {
            try
            {
                db.MATHANGs.Add(a);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //2. Thêm 1 chi tiết mặt hàng
        [Route("themCTMH")]
        [HttpPost]
        public bool postChiTietMatHang(CHITIETMATHANG a)
        {
            try
            {
                db.CHITIETMATHANGs.Add(a);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region --PUT--
        //1. Cap nhat 1 mặt hàng
        [Route("capnhatMH")]
        [HttpPut]
        public bool putMatHang(MATHANG a)
        {
            try
            {
                var ct = db.MATHANGs.Where(c => c.ID.Equals(a.ID)).FirstOrDefault();
                ct.ID = a.ID;
                ct.TenMH = a.TenMH;
                ct.IDSubLoaiHang = a.IDSubLoaiHang;
                ct.STATUS = a.STATUS;
                ct.URLHinhAnh1 = a.URLHinhAnh1;
                ct.URLHinhAnh2 = a.URLHinhAnh2;
                ct.URLHinhAnh3 = a.URLHinhAnh3;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //2. Cap nhat chi tiết mặt hàng
        [Route("capnhatCTMH")]
        [HttpPut]
        public bool putChiTietMatHang(CHITIETMATHANG a)
        {
            try
            {
                var ct = db.CHITIETMATHANGs.Where(c => c.ID.Equals(a.ID)).FirstOrDefault();
                ct.ID = a.ID;
                ct.IDMatHang = a.IDMatHang;
                ct.MoTa = a.MoTa;
                ct.MauSac = a.MauSac;
                ct.Size = a.Size;
                ct.Gia = a.Gia;
                ct.Loai = a.Loai;
                ct.SoLuong = a.SoLuong;
                ct.STATUS = a.STATUS;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //3. Chỉnh sửa hóa đơn
        [HttpPut]
        [Route("hoadon")]
        public bool PutHoaDon(int ID, string TrangThai)
        {
            try
            {
                var staff = db.HOADONs.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (staff != null)
                {
                    staff.TinhTrang = TrangThai;
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }

        }
        #endregion

        #region --DELETE--
        //1. Thêm 1 chi tiết mặt hàng
        [Route("xoaCTMH")]
        [HttpDelete]
        public bool deleteChiTietMatHang(int IDCTMH)
        {

            try
            {
                var ct = db.CHITIETMATHANGs.Where(c => c.ID.Equals(IDCTMH)).FirstOrDefault();
                ct.STATUS = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //2. Xóa hóa đơn khỏi csdl
        [HttpDelete]
        [Route("xoahoadon")]
        public bool DeleteHoaDon(int ID)
        {
            try
            {
                var staff = db.HOADONs.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (staff != null)
                {
                    staff.STATUS = false;
                    //Tìm trong bảng chi tiết hóa đơn và xóa nó đi(set thuộc tính ẩn cho trường dữ liệu)
                    var staff1 = db.CHITIETHOADONs.Where(s => s.ID.Equals(ID)).ToList();
                    foreach (var item in staff1)
                    {
                        item.STATUS = false;
                    }
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }

        }

        #endregion

        #endregion

        #region --Phước--
        //1. Tất cả sản phẩm: dung api ở trên
        [Route("getmathang")]
        [HttpGet]
        public List<_MatHang> get_Mat_Hang()
        {

            var item = (from u in db.MATHANGs
                        where (u.STATUS != false)
                        select new _MatHang
                        {
                            MH_ID = u.ID.ToString(),
                            MH_TenMH = u.TenMH,
                            MH_IDSubLoaiHang = u.ID.ToString(),
                            MH_Status = u.STATUS.ToString(),
                            MH_URLHinhAnh1 = u.URLHinhAnh1,
                            MH_URLHinhAnh2 = u.URLHinhAnh2,
                            MH_URLHinhAnh3 = u.URLHinhAnh3,

                        }).ToList();
            return item;
        }

        //2. Lọc sản phẩm theo id: dùng api ở trên
        [Route("getmathangtheoid")]
        [HttpGet]
        public List<_MatHang> get_Mat_Hang_ID(string IDMH)
        {

            var item = (from u in db.MATHANGs
                        where (u.STATUS != false && u.ID.ToString() == IDMH)
                        select new _MatHang
                        {
                            MH_ID = u.ID.ToString(),
                            MH_TenMH = u.TenMH,
                            MH_IDSubLoaiHang = u.ID.ToString(),
                            MH_Status = u.STATUS.ToString(),
                            MH_URLHinhAnh1 = u.URLHinhAnh1,
                            MH_URLHinhAnh2 = u.URLHinhAnh2,
                            MH_URLHinhAnh3 = u.URLHinhAnh3,

                        }).ToList();
            return item;
        }
        //3. Lọc theo quần/áo/đầm
        [Route("getsptheoloai")]
        [HttpGet]
        public List<P_SanPham> get_San_Pham_Loai(string LH)
        {

            var item = (from i in db.CHITIETMATHANGs
                        join u in db.MATHANGs on i.IDMatHang equals u.ID
                        join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                        join n in db.LOAIHANGs on m.IDLoaiHang equals n.ID
                        where (u.STATUS != false && i.STATUS != false && n.TenLoai == LH )
                        select new P_SanPham
                        {
                           IDCT = i.ID.ToString(),
                           TenMH = u.TenMH,
                           Mota = i.MoTa,
                           MauSac = i.MauSac,
                           Gia = i.Gia.ToString(),
                           Size = i.Size,
                           HinhAnh = u.URLHinhAnh1,
                        }).ToList();
            return item;
        }

        //4. Lọc theo nam/nữ
        [Route("getsptheogt")]
        [HttpGet]
        public List<P_SanPham> get_San_Pham_GT(string GT)
        {

            var item = (from i in db.CHITIETMATHANGs
                        join u in db.MATHANGs on i.IDMatHang equals u.ID
                        join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                        join n in db.LOAIHANGs on m.IDLoaiHang equals n.ID
                        where (u.STATUS != false && i.STATUS != false && i.Loai == GT)
                        select new P_SanPham
                        {
                            IDCT = i.ID.ToString(),
                            TenMH = u.TenMH,
                            Mota = i.MoTa,
                            MauSac = i.MauSac,
                            Gia = i.Gia.ToString(),
                            Size = i.Size,
                            HinhAnh = u.URLHinhAnh1,
                        }).ToList();
            return item;
        }


        //5. Lọc theo đồ của nam
        [Route("getspnam")]
        [HttpGet]
        public List<P_SanPham> get_San_Pham_Nam(string LH)
        {

            var item = (from i in db.CHITIETMATHANGs
                        join u in db.MATHANGs on i.IDMatHang equals u.ID
                        join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                        join n in db.LOAIHANGs on m.IDLoaiHang equals n.ID
                        where (u.STATUS != false && i.STATUS != false && n.TenLoai== LH && i.Loai =="NAM")
                        select new P_SanPham
                        {
                            IDCT = i.ID.ToString(),
                            TenMH = u.TenMH,
                            Mota = i.MoTa,
                            MauSac = i.MauSac,
                            Gia = i.Gia.ToString(),
                            Size = i.Size,
                            HinhAnh = u.URLHinhAnh1,
                        }).ToList();
            return item;
        }

        //6. Lọc theo đồ của nữ
        [Route("getspnu")]
        [HttpGet]
        public List<P_SanPham> get_San_Pham_Nu(string LH)
        {

            var item = (from i in db.CHITIETMATHANGs
                        join u in db.MATHANGs on i.IDMatHang equals u.ID
                        join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                        join n in db.LOAIHANGs on m.IDLoaiHang equals n.ID
                        where (u.STATUS != false && i.STATUS != false && n.TenLoai == LH && i.Loai != "NAM")
                        select new P_SanPham
                        {
                            IDCT = i.ID.ToString(),
                            TenMH = u.TenMH,
                            Mota = i.MoTa,
                            MauSac = i.MauSac,
                            Gia = i.Gia.ToString(),
                            Size = i.Size,
                            HinhAnh = u.URLHinhAnh1,
                        }).ToList();
            return item;
        }

        #endregion

    }
}
