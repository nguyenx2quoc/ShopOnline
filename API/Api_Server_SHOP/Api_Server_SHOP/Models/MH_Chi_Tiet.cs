using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Server_SHOP.Models
{
    public class MH_Chi_Tiet
    {
        private string tenMH;
        private string gia;
        private string size;
        private string mota;
        private string mau;
        private string uRLHinhAnh1;
        private string uRLHinhAnh2;
        private string uRLHinhAnh3;

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

        public string Gia
        {
            get
            {
                return gia;
            }

            set
            {
                gia = value;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public string Mota
        {
            get
            {
                return mota;
            }

            set
            {
                mota = value;
            }
        }

        public string Mau
        {
            get
            {
                return mau;
            }

            set
            {
                mau = value;
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

        public string URLHinhAnh2
        {
            get
            {
                return uRLHinhAnh2;
            }

            set
            {
                uRLHinhAnh2 = value;
            }
        }

        public string URLHinhAnh3
        {
            get
            {
                return uRLHinhAnh3;
            }

            set
            {
                uRLHinhAnh3 = value;
            }
        }
    }
}