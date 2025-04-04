using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DTO;
using Guna.UI2.WinForms;    
namespace DAL
{
    public class DAL_SanPham
    {
        DTO_SanPham sanphamdto;

        public DAL_SanPham(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdto = new DTO_SanPham(masp,maloai,tensp,hinhanh,giaban,trangthai);
        }

        //Tải danh sách sản phẩm lên gridview
        public DataTable TaiSp()
        {
            string query = "select MaSp as 'Mã món',TenLoai as 'Tên loại',TenSp as 'Tên món',HinhAnh as 'Hình ảnh',GiaBan as 'Giá bán',TrangThai as 'Trạng thái' " +
                           "from SanPham,LoaiSanPham " +
                           "where SanPham.MaLoai=LoaiSanPham.MaLoai";
            return DataProvider.ExecuteQuery(query);
        }

        //Tải danh sách các tên loại lên combobox
        public void TaiTenLoai(Guna2ComboBox cbo)
        {
            string query = "SELECT TenLoai FROM LoaiSanPham";
            DataTable dt = DataProvider.ExecuteQuery(query);
            cbo.DataSource = dt;
            cbo.DisplayMember = "TenLoai";  // Hiển thị tên loại
        }

        //Thêm sản phẩm mới vào database
        public void ThemSp(string masp, string tenloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            string query = "insert into SanPham values (@_MaSp,dbo.LayMaloaiTheoTenloai(@_MaLoai),@_TenSp,@_HinhAnh,@_GiaBan,@_TrangThai)";
            object[] parem = new object[] { masp, tenloai, tensp, hinhanh, giaban, trangthai };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        public void SuaSp(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            string query = "UPDATE SanPham SET maloai = dbo.LayMaloaiTheoTenloai(@_MaLoai), tensp = @_TenSp, hinhanh = @_HinhAnh, giaban = @_GiaBan, trangthai = @_TrangThai where masp = @_MaSp";
            object[] parem = new object[] { maloai, tensp, hinhanh, giaban, trangthai, masp};
            DataProvider.ExecuteNonQuery(query, parem);
        }

        
    }

}
