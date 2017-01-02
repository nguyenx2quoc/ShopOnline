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

      

    }
}
