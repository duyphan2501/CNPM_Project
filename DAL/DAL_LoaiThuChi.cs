using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_LoaiThuChi
    {
        DTO_LoaiThuChi loaithuchidto;

        public DAL_LoaiThuChi(string maloaithuchi, string tenloai, string loai)
        {
            loaithuchidto = new DTO_LoaiThuChi(maloaithuchi,tenloai,loai);
        }

        public void ThemLoai(string maloaithuchi, string tenloai, string loai)
        {
            string query = "insert into LoaiThuChi values (@_MaLoaiThuChi, @_TenLoai,@_Loai)";
            object[] parem = new object[] {maloaithuchi,tenloai,loai };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        public DataTable TaiLoaiPhieu()
        {
            string query = "select * from LoaiThuChi";
            return DataProvider.ExecuteQuery(query);
        }

        // lấy mã loại thu chi lớn nhất
        public string MaloaiLonNhat()
        {
            string query = "select top 1 MaLoaiThuChi from LoaiThuChi order by MaLoaiThuChi desc";
            string maxMaloai = (string)DataProvider.ExecuteScalar(query);
            return maxMaloai;
        }
    }
}
