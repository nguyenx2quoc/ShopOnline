using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api_Server_SHOP.Models;
using System.Web.Http.Description;

namespace Api_Server_SHOP.Controllers
{
    [RoutePrefix("api")]
    public class APIController : ApiController
    {
        private SHOPEntities db = new SHOPEntities();

        #region +Lấy chi tiết thông tin mặt hàng
        [Route("mathangchitiet")]
        [HttpGet]
        public List<MH_Chi_Tiet> get_MH_Chi_Tiet(string IDMH)
        {

            var item = (from u in db.MATHANGs
                        join i in db.CHITIETMATHANGs on u.ID equals i.IDMatHang
                        join m in db.LOAIHANGs on u.IDLoaiHang equals m.ID
                        where u.ID == IDMH
                        select new MH_Chi_Tiet
                        {
                            TenMH = u.TenMH,
                            Gia = i.Gia.ToString(),
                            Size = i.Size,
                            Mota = m.MoTa,
                            Mau = i.MauSac,
                            URLHinhAnh1 = u.URLHinhAnh1,
                            URLHinhAnh2 = u.URLHinhAnh2,
                            URLHinhAnh3 = u.URLHinhAnh3,

                        }).ToList();
            return item;
        }
        #endregion

        #region +Lấy về danh sách mẫu theo giới tính
        [Route("mathanggt")]
        [HttpGet]
        public List<MH_GioiTinh> get_MH_Theo_GT(string GT)
        {

            var item = (from u in db.CHITIETMATHANGs
                        join i in db.MATHANGs on u.IDMatHang equals i.ID
                        join m in db.LOAIHANGs on i.IDLoaiHang equals m.ID
                        where u.Loai == GT
                        select new MH_GioiTinh
                        {
                            ID = i.ID,
                            TenMH = i.TenMH,
                            Mau1 = u.MauSac,
                            URLHinhAnh1 = i.URLHinhAnh1,
                            Gia1 = u.Gia.ToString(),

                        }).ToList();
            return item;
        }
        #endregion

        #region + Đồ nam
        //Lấy về danh sách mẫu đồ nam theo 2 loại: quần hoặc áo
        [Route("mathangnam")]
        [HttpGet]
        public List<MH_GioiTinh> get_MH_Nam_Theo_Loai(string Loai)
        {

            var item = (from u in db.CHITIETMATHANGs
                        join i in db.MATHANGs on u.IDMatHang equals i.ID
                        join m in db.LOAIHANGs on i.IDLoaiHang equals m.ID
                        where (u.Loai == "NAM" && m.TenLoai == Loai)
                        select new MH_GioiTinh
                        {
                            ID = i.ID,
                            TenMH = i.TenMH,
                            Mau1 = u.MauSac,
                            URLHinhAnh1 = i.URLHinhAnh1,
                            Gia1 = u.Gia.ToString(),

                        }).ToList();
            return item;
        }


        //Lấy về danh sách mẫu đồ nam theo chi tiết từng loại: quần hoặc áo => sơ mi tay dài, ngắn, quần kaki
        [Route("mathangnamct")]
        [HttpGet]
        public List<MH_GioiTinh> get_MH_Nam_Theo_Loai_Chi_Tiet(string Loai, string Chitiet)
        {

            var item = (from u in db.CHITIETMATHANGs
                        join i in db.MATHANGs on u.IDMatHang equals i.ID
                        join m in db.LOAIHANGs on i.IDLoaiHang equals m.ID
                        join s in db.SUBLOAIHANGs on i.IDSubLoaiHang equals s.ID
                        where (u.Loai == "NAM" && m.TenLoai == Loai && s.TenLoai == Chitiet)
                        select new MH_GioiTinh
                        {
                            ID = i.ID,
                            TenMH = i.TenMH,
                            Mau1 = u.MauSac,
                            URLHinhAnh1 = i.URLHinhAnh1,
                            Gia1 = u.Gia.ToString(),

                        }).ToList();
            return item;
        }
        #endregion

        #region +Đồ nữ
        //Lấy về danh sách mẫu đồ nữ theo 2 loại: quần hoặc áo
        [Route("mathangnu")]
        [HttpGet]
        public List<MH_GioiTinh> get_MH_Nu_Theo_Loai(string Loai)
        {

            var item = (from u in db.CHITIETMATHANGs
                        join i in db.MATHANGs on u.IDMatHang equals i.ID
                        join m in db.LOAIHANGs on i.IDLoaiHang equals m.ID
                        where (u.Loai != "NAM" && m.TenLoai == Loai)
                        select new MH_GioiTinh
                        {
                            ID = i.ID,
                            TenMH = i.TenMH,
                            Mau1 = u.MauSac,
                            URLHinhAnh1 = i.URLHinhAnh1,
                            Gia1 = u.Gia.ToString(),

                        }).ToList();
            return item;
        }

        //Lấy về danh sách mẫu đồ nữ theo chi tiết từng loại: quần hoặc áo => sơ mi tay dài, ngắn, quần kaki
        [Route("mathangnuct")]
        [HttpGet]
        public List<MH_GioiTinh> get_MH_Nu_Theo_Loai_Chi_Tiet(string Loai, string Chitiet)
        {

            var item = (from u in db.CHITIETMATHANGs
                        join i in db.MATHANGs on u.IDMatHang equals i.ID
                        join m in db.LOAIHANGs on i.IDLoaiHang equals m.ID
                        join s in db.SUBLOAIHANGs on i.IDSubLoaiHang equals s.ID
                        where (u.Loai != "NAM" && m.TenLoai == Loai && s.TenLoai == Chitiet)
                        select new MH_GioiTinh
                        {
                            ID = i.ID,
                            TenMH = i.TenMH,
                            Mau1 = u.MauSac,
                            URLHinhAnh1 = i.URLHinhAnh1,
                            Gia1 = u.Gia.ToString(),

                        }).ToList();
            return item;
        }
        #endregion

        #region + Ví dụ post 1 mặt hàng
        //    [ResponseType(typeof(MATHANG))]
        [Route("mathang")]
        [HttpPost]
        public bool postMatHang(string str)
        {
            MATHANG a = new MATHANG();
            a.ID = "";
            a.IDLoaiHang = "";
            a.IDSubLoaiHang = "";
            a.TenMH = "";
            a.URLHinhAnh1 = "";
            a.URLHinhAnh2 = "";
            a.URLHinhAnh3 = "";
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

        #endregion

    }
}
