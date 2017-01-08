using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class SanPham
    {
        public string MH_ID { get; set; }
        public string MH_TenMH { get; set; }
        public string MH_IDSubLoaiHang { get; set; }
        public string MH_URLHinhAnh1 { get; set; }
        public string MH_URLHinhAnh2 { get; set; }
        public string MH_URLHinhAnh3 { get; set; }
        public string MH_Status { get; set; }
        public string CT_ID { get; set; }
        public string CT_MoTa { get; set; }
        public string CT_MauSac { get; set; }
        public string CT_Size { get; set; }
        public string CT_Gia { get; set; }
        public string CT_Loai { get; set; }
        public string CT_SoLuong { get; set; }
        public string CT_Status { get; set; }

    }
}