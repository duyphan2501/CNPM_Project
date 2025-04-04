using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_LoaiSanPham
    {
        DAL_LoaiSanPham loaisanphambus;

        public BUS_LoaiSanPham(string maloai, string tenloai)
        {
            loaisanphambus = new DAL_LoaiSanPham(maloai, tenloai);
        }
        public void ThemLoaiSp(string maloai, string tenloai)
        {
            loaisanphambus.ThemLoaiSp(maloai, tenloai);
        }
    }
}
