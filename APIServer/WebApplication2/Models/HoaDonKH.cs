using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class HoaDonKH
    {
        public int ID { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Ngay { get; set; }
        public int TongTien { get; set; }
        public string TinhTrang { get; set; }
    }
}