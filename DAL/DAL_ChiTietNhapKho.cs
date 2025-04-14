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
            string query = "insert into ChiTietNhapKho values (@_MaPhieuNhap,@_MaNL,@_GiaNhap,@_SoLuong)";
            object[] parem = new object[] { maphieunhap, manl, gianhap, soluong};
            DataProvider.ExecuteNonQuery(query, parem);
        }

        public void UpdateDetailst(string maphieunhap, string manl, int gianhap, int soluong)
        {
            string query = "update ChiTietNhapKho set manl = dbo.LayMaNlTheoTenNl(@_MaNL), gianhap = @_GiaNhap, soluong = @_SoLuong where maphieunhap = @_MaPhieuNhap";
            object[] parem = new object[] {manl, gianhap, soluong, maphieunhap};
            DataProvider.ExecuteNonQuery(query, parem);
        }
    }
}
