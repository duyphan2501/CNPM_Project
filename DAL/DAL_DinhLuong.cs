using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_DinhLuong
    {
        DTO_DinhLuong dinhluongdal;
        public DAL_DinhLuong(string masp, string manl, int soluong)
        {
            dinhluongdal = new DTO_DinhLuong(masp, manl, soluong);
        }

        //Thêm định lượng vào database
        public void ThemDinhluong(string masp, string manl, int soluong)
        {
            string query = "insert into DinhLuong values (@_MaSp,dbo.LayMaNlTheoTenNl(@_MaNL),@_SoLuong)";
            object[] parem = new object[] { masp, manl, soluong };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        //Sửa thông tin định lượng
        public void SuaDinhluong(string masp, string manl, int soluong)
        {
            string query = "update DinhLuong set soluong = @_SoLuong where masp = dbo.LayMaSpTheoTenSp(@_MaSp) and manl = dbo.LayMaNlTheoTenNl(@_MaNL)"; 
            object[] parem = new object[] {soluong, masp, manl};
            DataProvider.ExecuteNonQuery(query,parem);
        }

        //Xóa định lượng
        public void XoaDinhLuong(string masp, string manl)
        {
            string query = "delete from DinhLuong where masp = dbo.LayMaSpTheoTenSp(@_MaSp) and manl = dbo.LayMaNlTheoTenNl(@_MaNL)";
            object[] parem = new object[] {masp, manl };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        //Tải danh sách định lượng theo tên sản phẩm lên gridview theo tên sản phẩm
        public DataTable TaiDsDinhluong(string tensp)
        {
            string query = "select NguyenLieu.TenNL as 'Tên nguyên liệu', DinhLuong.SoLuong as 'Số lượng' " +
                            "from DinhLuong, NguyenLieu,SanPham " +
                            "where DinhLuong.MaSp = SanPham.MaSp and DinhLuong.MaNL = NguyenLieu.MaNL " +
                            "and SanPham.TenSp = @_TenSp";
            object[] parem = new object[] {tensp};
            return DataProvider.ExecuteQuery(query,parem);
        }

        //Tải tên sản phẩm lên combobox
        public DataTable TaiTenNL()
        {
            string query = "select distinct TenNL from NguyenLieu";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
