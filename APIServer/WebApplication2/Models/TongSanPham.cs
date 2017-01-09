using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TongSanPham
    {
        public int MH_ID { get; set; }
        public string MH_TenMH { get; set; }
        public int MH_IDSubLoaiHang { get; set; }
        public string MH_URLHinhAnh1 { get; set; }
        public string MH_URLHinhAnh2 { get; set; }
        public string MH_URLHinhAnh3 { get; set; }
        public bool? MH_Status { get; set; }

        public int CT_ID { get; set; }
        public int CT_IDMH { get; set; }
        public string CT_MoTa { get; set; }
        public string CT_MauSac { get; set; }
        public string CT_Size { get; set; }
        public int? CT_Gia { get; set; }
        public string CT_Loai { get; set; }
        public int? CT_SoLuong { get; set; }
        public bool? CT_Status { get; set; }

        public int CT1_ID { get; set; }
        public int CT1_IDMH { get; set; }
        public string CT1_MoTa { get; set; }
        public string CT1_MauSac { get; set; }
        public string CT1_Size { get; set; }
        public int? CT1_Gia { get; set; }
        public string CT1_Loai { get; set; }
        public int? CT1_SoLuong { get; set; }
        public bool? CT1_Status { get; set; }

        public int CT2_ID { get; set; }
        public int CT2_IDMH { get; set; }
        public string CT2_MoTa { get; set; }
        public string CT2_MauSac { get; set; }
        public string CT2_Size { get; set; }
        public int? CT2_Gia { get; set; }
        public string CT2_Loai { get; set; }
        public int? CT2_SoLuong { get; set; }
        public bool? CT2_Status { get; set; }
    }
}