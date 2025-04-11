using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{

    public class DAL_ChiTietNhapKho
    {
        DTO_ChiTietNhapKho chitietnhap;

        public DAL_ChiTietNhapKho(string maphieunhap, string manl, int gianhap, int soluong)
        {
            chitietnhap = new DTO_ChiTietNhapKho(maphieunhap,manl,gianhap,soluong);
        }

        public void ThemChiTietNhap(string maphieunhap, string manl, int gianhap, int soluong)
        {
            string query = "insert into ChiTietNhapKho values (@_MaPhieuNhap,dbo.LayMaNlTheoTenNl(@_MaNL),@_GiaNhap,@_SoLuong)";
            object[] parem = new object[] { maphieunhap, manl, gianhap, soluong};
            DataProvider.ExecuteNonQuery(query, parem);
        }
    }
}
