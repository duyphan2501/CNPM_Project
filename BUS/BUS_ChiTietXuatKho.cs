using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_ChiTietXuatKho
    {
        DAL_ChiTietXuatKho chitietxuat;

        public BUS_ChiTietXuatKho(string maphieuxuat, string manl, int soluong)
        {
            chitietxuat = new DAL_ChiTietXuatKho(maphieuxuat, manl, soluong);
        }

        public void ThemChiTietXuat(string maphieuxuat, string manl, int soluong)
        {
            chitietxuat.ThemChiTietXuat(maphieuxuat,manl, soluong);
        }
    }
}
