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
        //0. Lấy thông tin chi tiết mặt hàng theo IDMH
        [Route("getctmh")]
        [HttpGet]
        public List<P_SanPham> get_CT_Theo_ID(int IDMH)
        {

            var item = (from i in db.CHITIETMATHANGs
                        join u in db.MATHANGs on i.IDMatHang equals u.ID
                        join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                        join n in db.LOAIHANGs on m.IDLoaiHang equals n.ID
                        where (u.STATUS != false && i.STATUS != false && i.IDMatHang == IDMH)
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

        //1. Lấy thông tin tất cả sản phẩm chi tiết mặt hàng
        [Route("getsp")]
        [HttpGet]
        public List<SanPham> get_San_Pham()
        {
            try
            {

                var item = (from i in db.CHITIETMATHANGs
                            join u in db.MATHANGs on i.IDMatHang equals u.ID
                            join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                            where (u.STATUS != false && i.STATUS != false)
                            select new SanPham
                            {
                                MH_ID = u.ID,
                                MH_TenMH = u.TenMH,
                                MH_IDSubLoaiHang = m.ID,
                                MH_Status = u.STATUS,
                                MH_URLHinhAnh1 = u.URLHinhAnh1,
                                MH_URLHinhAnh2 = u.URLHinhAnh2,
                                MH_URLHinhAnh3 = u.URLHinhAnh3,

                                CT_ID = i.ID,
                                CT_Gia = i.Gia,
                                CT_Loai = i.Loai,
                                CT_MauSac = i.MauSac,
                                CT_MoTa = i.MoTa,
                                CT_Size = i.Size,
                                CT_SoLuong = i.SoLuong,
                                CT_Status = i.STATUS,

                            }).ToList();
                return item;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }

        //2. Lấy thông tin sản phẩm CTMH theo ID
        [Route("getsptheoid")]
        [HttpGet]
        public List<SanPham> get_San_Pham_ID(string IDCTMH)
        {
            try
            {

                var item = (from i in db.CHITIETMATHANGs
                            join u in db.MATHANGs on i.IDMatHang equals u.ID
                            where (u.STATUS != false && i.STATUS != false && i.ID.ToString() == IDCTMH)
                            select new SanPham
                            {
                                MH_ID = u.ID,
                                MH_TenMH = u.TenMH,
                                MH_IDSubLoaiHang = u.IDSubLoaiHang,
                                MH_Status = u.STATUS,
                                MH_URLHinhAnh1 = u.URLHinhAnh1,
                                MH_URLHinhAnh2 = u.URLHinhAnh2,
                                MH_URLHinhAnh3 = u.URLHinhAnh3,

                                CT_ID = i.ID,
                                CT_Gia = i.Gia,
                                CT_Loai = i.Loai,
                                CT_MauSac = i.MauSac,
                                CT_MoTa = i.MoTa,
                                CT_Size = i.Size,
                                CT_SoLuong = i.SoLuong,
                                CT_Status = i.STATUS,

                            }).ToList();
                return item;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
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

        //5. Lấy tất cả subloaihang
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

        //6. Lấy tất cả Mặt hàng và sub loại hàng
        [Route("getmhvasub")]
        [HttpGet]
        public List<MH_Sub> get_MH_Sub()
        {
            try
            {

                var item = (from u in db.MATHANGs
                            join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                            where (u.STATUS != false)
                            select new MH_Sub
                            {
                                MH_ID = u.ID,
                                MH_TenMH = u.TenMH,
                                MH_IDSubLoaiHang = m.ID,
                                MH_Status = u.STATUS,
                                MH_URLHinhAnh1 = u.URLHinhAnh1,
                                MH_URLHinhAnh2 = u.URLHinhAnh2,
                                MH_URLHinhAnh3 = u.URLHinhAnh3,

                                S_ID = m.ID,
                                S_IDLoaiHang = m.ID,
                                S_MoTa = m.MoTa,
                                S_TenLoai = m.TenLoai,

                            }).ToList();
                return item;
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
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
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
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }

      
        #endregion

        #region --PUT--
        //1. Chỉnh sửa 1 mặt hàng
        [Route("putmh")]
        [HttpPut]
        public bool putMat_Hang(MATHANG a)
        {
            try
            {
                var u = db.MATHANGs.Where(c => c.ID.Equals(a.ID)).FirstOrDefault();
                u.TenMH = a.TenMH;
                u.IDSubLoaiHang = a.IDSubLoaiHang;
                u.STATUS = a.STATUS;
                u.URLHinhAnh1 = a.URLHinhAnh1;
                u.URLHinhAnh2 = a.URLHinhAnh2;
                u.URLHinhAnh3 = a.URLHinhAnh3;

                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }


        //2. Chỉnh sửa 1 chi tiêt mat hang
        [Route("putCTMH")]
        [HttpPut]
        public bool put_CTMH(CHITIETMATHANG a)
        {
            try
            {
                var b = db.CHITIETMATHANGs.Where(c => c.ID.Equals(a.ID)).FirstOrDefault();
                b.IDMatHang = a.IDMatHang;
                b.Loai = a.Loai;
                b.MauSac = a.MauSac;
                b.Gia = a.Gia;
                b.Size = a.Size;
                b.SoLuong = a.SoLuong;
                b.STATUS = a.STATUS;

                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
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

        //0. Xóa 1 mặt hàng
        [Route("xoaMH")]
        [HttpDelete]
        public bool deleteMatHang(int IDMH)
        {

            try
            {
                var ct = db.MATHANGs.Where(c => c.ID.Equals(IDMH)).FirstOrDefault();
                ct.STATUS = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }

        //1. Xóa 1 chi tiết mặt hàng
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
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
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

        #region --GET--
        //001. Lấy chi tiet mat hang theo mau cua phuoc
        [Route("getallctmh")]
        [HttpGet]
        public List<P_SanPham> get_all_CTMH()
        {

            var item = (from i in db.CHITIETMATHANGs
                        join u in db.MATHANGs on i.IDMatHang equals u.ID
                        join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                        join n in db.LOAIHANGs on m.IDLoaiHang equals n.ID
                        where (u.STATUS != false && i.STATUS != false)
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


        //0. Lấy chi tiet mat hang theo id của nó
        [Route("getctmhtheoid")]
        [HttpGet]
        public List<P_SanPham> get_CTMH(int IDCTMH)
        {

            var item = (from i in db.CHITIETMATHANGs
                        join u in db.MATHANGs on i.IDMatHang equals u.ID
                        join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                        join n in db.LOAIHANGs on m.IDLoaiHang equals n.ID
                        where (u.STATUS != false && i.STATUS != false && i.ID == IDCTMH)
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
        //1. Tất cả sản phẩm: dung api ở trên
        [Route("getmathang")]
        [HttpGet]
        public List<_MatHang> get_Mat_Hang()
        {
            try
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
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }

        //2. Lọc sản phẩm theo id: dùng api ở trên
        [Route("getmathangtheoid")]
        [HttpGet]
        public List<_MatHang> get_Mat_Hang_ID(string IDMH)
        {
            try
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
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }
        //3. Lọc theo quần/áo/đầm
        [Route("getsptheoloai")]
        [HttpGet]
        public List<P_SanPham> get_San_Pham_Loai(string LH)
        {
            try
            {
                var item = (from i in db.CHITIETMATHANGs
                            join u in db.MATHANGs on i.IDMatHang equals u.ID
                            join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                            join n in db.LOAIHANGs on m.IDLoaiHang equals n.ID
                            where (u.STATUS != false && i.STATUS != false && n.TenLoai == LH)
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
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }

        //4. Lọc theo nam/nữ
        [Route("getsptheogt")]
        [HttpGet]
        public List<P_SanPham> get_San_Pham_GT(string GT)
        {
            try
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
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }


        //5. Lọc theo đồ của nam
        [Route("getspnam")]
        [HttpGet]
        public List<P_SanPham> get_San_Pham_Nam(string LH)
        {
            try
            {
                var item = (from i in db.CHITIETMATHANGs
                            join u in db.MATHANGs on i.IDMatHang equals u.ID
                            join m in db.SUBLOAIHANGs on u.IDSubLoaiHang equals m.ID
                            join n in db.LOAIHANGs on m.IDLoaiHang equals n.ID
                            where (u.STATUS != false && i.STATUS != false && n.TenLoai == LH && i.Loai == "NAM")
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
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }

        //6. Lọc theo đồ của nữ
        [Route("getspnu")]
        [HttpGet]
        public List<P_SanPham> get_San_Pham_Nu(string LH)
        {
            try
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
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }
        #endregion

        #region --POST--
        //POST. Thêm hoa don và chi tiết hoa don cùng 1 lần
        [Route("themhoadon")]
        [HttpPost]
        public bool postHoaDon(P_HoaDon a)
        {
            try
            {
                HOADON h = new HOADON();
                CHITIETHOADON c = new CHITIETHOADON();

                h.EMAIL = a.H_EMAIL;
                h.SDT = a.H_SDT;
                h.TongTien = a.H_TongTien;
                h.TinhTrang = "Đã đặt hàng";
                h.STATUS = true;
                DateTime today = DateTime.Today;
                h.Ngay = today;
                db.HOADONs.Add(h);
                db.SaveChanges();

                int id = h.ID;

                c.IDChiTietMatHang = a.C_IDCTMH;
                c.IDHoaDon = id;
                c.SoLuong = 1;
                c.STATUS = true;
                db.CHITIETHOADONs.Add(c);
                db.SaveChanges();

                var u = db.CHITIETMATHANGs.Where(t => t.ID.Equals(a.C_IDCTMH)).FirstOrDefault();
                u.SoLuong = u.SoLuong - 1;
                db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, false));
            }
        }
        #endregion


        #endregion



    }
}
