using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_ChiTietXuatKho
    {
        DTO_ChiTietXuatKho chitietxuatdto;

        public DAL_ChiTietXuatKho(string maphieuxuat, string manl, int soluong)
        {
            chitietxuatdto = new DTO_ChiTietXuatKho(maphieuxuat,manl,soluong);
        }

        public void ThemChiTietXuat(string maphieuxuat, string manl, int soluong)
        {
            string query = "insert into ChiTietXuatKho values (@_MaPhieuXuat,dbo.LayMaNlTheoTenNl(@_MaNL),@_SoLuong)";
            object[] parem = new object[] { maphieuxuat, manl, soluong };
            DataProvider.ExecuteNonQuery(query, parem);
        }
    }
}
