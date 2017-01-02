using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Server_SHOP.Models
{
    public class MH_GioiTinh
    {
        private string iD;
        private string tenMH;
        private string Mau;
        private string Gia;
        private string uRLHinhAnh1;

        public string ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public string TenMH
        {
            get
            {
                return tenMH;
            }

            set
            {
                tenMH = value;
            }
        }

        public string Mau1
        {
            get
            {
                return Mau;
            }

            set
            {
                Mau = value;
            }
        }

        public string Gia1
        {
            get
            {
                return Gia;
            }

            set
            {
                Gia = value;
            }
        }

        public string URLHinhAnh1
        {
            get
            {
                return uRLHinhAnh1;
            }

            set
            {
                uRLHinhAnh1 = value;
            }
        }
    }
}