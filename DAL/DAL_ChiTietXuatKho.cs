using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DAL
{
    public class DAL_ChiTietXuatKho
    {
        DTO_ChiTietXuatKho chitietxuatdto;

        public DAL_ChiTietXuatKho(string maphieuxuat, string manl, int soluong)
        {
            chitietxuatdto = new DTO_ChiTietXuatKho(maphieuxuat,manl,soluong);
        }

        public DAL_ChiTietXuatKho()
        {
            chitietxuatdto = new DTO_ChiTietXuatKho();
        }

        //Thêm chi tiết xuất kho
        public void AddExportDetail(string maphieuxuat, string manl, int soluong)
        {
            string query = "insert into ChiTietXuatKho values (@_MaPhieuXuat,@_MaNL,@_SoLuong)";
            object[] parem = new object[] { maphieuxuat, manl, soluong };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        public void UpdateDetailst(string maphieuxuat, string manl, int soluong)
        {
            string query = "update ChiTietXuatKho set manl = dbo.LayMaNlTheoTenNl(@_MaNL), soluong = @_SoLuong where maphieuxuat = @_MaPhieuXuat";
            object[] parem = new object[] { manl, soluong, maphieuxuat };
            DataProvider.ExecuteNonQuery(query, parem);
        }
    }
}
