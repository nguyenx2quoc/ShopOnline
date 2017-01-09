using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class MH_Sub
    {
        public int MH_ID { get; set; }
        public string MH_TenMH { get; set; }
        public int MH_IDSubLoaiHang { get; set; }
        public string MH_URLHinhAnh1 { get; set; }
        public string MH_URLHinhAnh2 { get; set; }
        public string MH_URLHinhAnh3 { get; set; }
        public bool? MH_Status { get; set; }

        public int S_ID { get; set; }
        public Nullable<int> S_IDLoaiHang { get; set; }
        public string S_TenLoai { get; set; }
        public string S_MoTa { get; set; }

    }
}