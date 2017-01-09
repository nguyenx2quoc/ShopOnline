using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class SanPham
    {
        public int MH_ID { get; set; }
        public string MH_TenMH { get; set; }
        public int MH_IDSubLoaiHang { get; set; }
        public string MH_URLHinhAnh1 { get; set; }
        public string MH_URLHinhAnh2 { get; set; }
        public string MH_URLHinhAnh3 { get; set; }
        public bool? MH_Status { get; set; }
        public int CT_ID { get; set; }
        public string CT_MoTa { get; set; }
        public string CT_MauSac { get; set; }
        public string CT_Size { get; set; }
        public int? CT_Gia { get; set; }
        public string CT_Loai { get; set; }
        public int? CT_SoLuong { get; set; }
        public bool? CT_Status { get; set; }

    }
}