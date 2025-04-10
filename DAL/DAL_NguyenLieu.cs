using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NguyenLieu
    {
        DTO_NguyenLieu nguyenlieudto;

        public DAL_NguyenLieu(string manl, string maloainl, string tennl, string donvi, int soluong)
        {
            nguyenlieudto = new DTO_NguyenLieu(manl,maloainl,tennl,donvi,soluong);
        }

        //Tải nguyên liệu lên datagridview
        public DataTable Tainguyenlieu()
        {
            string query = "select nl.MaNL as 'Mã nguyên liệu',lnl.TenLoai as 'Tên loại',nl.TenNL as 'Tên nguyên liệu',nl.DonVi as 'Đơn vị tính',nl.SoLuong as 'Số lượng' from NguyenLieu nl,LoaiNguyenLieu lnl " +
                            "where nl.MaLoaiNL = lnl.MaLoaiNL";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable TaiLoaiNguyenlieu() {
            string query = "select distinct TenLoai from LoaiNguyenLieu";
            return DataProvider.ExecuteQuery(query);
        }

        public void ThemNguyenlieu(string manl, string tenloainl, string tennl, string donvi, int soluong)
        {
            string query = "insert into NguyenLieu values (@_MaNL,dbo.LayMaloaiNLTheoTenloaiNL(@_MaLoaiNL),@_TenNL,@_DonVi,@_SoLuong)";
            object[] parem = new object[] { manl, tenloainl, tennl, donvi, soluong};
            DataProvider.ExecuteNonQuery(query, parem);
        }

        //Sửa thông tin nguyên liệu
        public void SuathongtinNL(string manl, string maloainl, string tennl, string donvi, int soluong)
        {
            string query = "update NguyenLieu set maloainl = dbo.LayMaloaiNLTheoTenloaiNL(@_MaLoaiNL), tennl = @_TenNL, donvi = @_DonVi, soluong = @_SoLuong  where manl = @_MaNL";
            object[] parem = new object[] { maloainl, tennl, donvi, soluong, manl };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã sp lớn nhất
        public string ManlLonNhat()
        {
            string query = "select top 1 MaNL from NguyenLieu order by MaNL desc";
            string maxMaNL = (string)DataProvider.ExecuteScalar(query);
            return maxMaNL;
        }
    }
}
