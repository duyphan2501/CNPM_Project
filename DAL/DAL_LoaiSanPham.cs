using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_LoaiSanPham
    {
        DTO_LoaiSanPham loaisanphamdal;

        public DAL_LoaiSanPham()
        {
            loaisanphamdal = new DTO_LoaiSanPham();
        }
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

        // lấy mã loại lớn nhất trong bảng LoaiSanPham
        public string MaloaiSPLonNhat()
        {
            string query = "select top 1 MaLoai from LoaiSanPham order by Maloai desc";
            string maxMaloaiSP = (string)DataProvider.ExecuteScalar(query);
            return maxMaloaiSP;
        }

        public DataTable SelectAllCategory()
        {
            string query = "select * from LoaiSanPham";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
