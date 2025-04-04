using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_LoaiSanPham
    {
        DTO_LoaiSanPham loaisanphamdal;
        public DAL_LoaiSanPham(string maloai, string tenloai)
        {
            loaisanphamdal = new DTO_LoaiSanPham(maloai, tenloai);
        }

        //Thêm loại sản phẩm
        public void ThemLoaiSp(string maloai, string tenloai)
        {
            string query = "insert into LoaiSanPham values (@_MaLoai,@_TenLoai)";
            object[] parem = new object[] { maloai, tenloai, };
            DataProvider.ExecuteNonQuery(query, parem);
        }
    }
}
