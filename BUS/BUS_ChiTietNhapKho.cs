using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_ChiTietNhapKho
    {
        DAL_ChiTietNhapKho chitietnhap;

        public BUS_ChiTietNhapKho(string maphieunhap, string manl, int gianhap, int soluong)
        {
            chitietnhap = new DAL_ChiTietNhapKho(maphieunhap, manl, gianhap, soluong);
        }

        public void ThemChiTietNhap(string maphieunhap, string manl, int gianhap, int soluong)
        {
            chitietnhap.ThemChiTietNhap(maphieunhap, manl, gianhap, soluong);
        }

        public void UpdateDetailst(string maphieunhap, string manl, int gianhap, int soluong)
        {
            chitietnhap.UpdateDetailst(maphieunhap, manl, gianhap, soluong);
        }
    }
}
