using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_LoaiNguyenLieu
    {
        DTO_LoaiNguyenLieu loainguyenlieudto;

        public DAL_LoaiNguyenLieu(string maloainl, string tenloai)
        {
            loainguyenlieudto = new DTO_LoaiNguyenLieu(maloainl, tenloai);
        }


        public void ThemLoaiNguyenLieu(string maloainl, string tenloai)
        {
            string query = "insert into LoaiNguyenLieu values (@_MaLoaiNL,@_TenLoai)";
            object[] parem = new object[] { maloainl, tenloai, };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã loại lớn nhất trong bảng loại nguyên liệu
        public string MaloaiNLLonNhat()
        {
            string query = "select top 1 MaLoaiNL from LoaiNguyenLieu order by MaloaiNL desc";
            string maxMaloaiNL = (string)DataProvider.ExecuteScalar(query);
            return maxMaloaiNL;
        }
    }
}
