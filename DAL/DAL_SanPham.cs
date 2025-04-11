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
namespace DAL
{
    public class DAL_SanPham
    {
        DTO_SanPham sanphamdto;

        public DAL_SanPham(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdto = new DTO_SanPham(masp,maloai,tensp,hinhanh,giaban,trangthai);
        }

        public DAL_SanPham()
        {
            sanphamdto = new DTO_SanPham();
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
        public DataTable TaiTenLoai()
        {
            string query = "select distinct TenLoai from LoaiSanPham";
            return DataProvider.ExecuteQuery(query);
        }

        //Thêm sản phẩm mới vào database
        public void ThemSp(string masp, string tenloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            string query = "insert into SanPham values (@_MaSp,dbo.LayMaloaiTheoTenloai(@_MaLoai),@_TenSp,@_HinhAnh,@_GiaBan,@_TrangThai)";
            object[] parem = new object[] { masp, tenloai, tensp, hinhanh, giaban, trangthai };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        //Sửa thông tin sản phẩm
        public void SuaSp(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            string query = "update SanPham set maloai = dbo.LayMaloaiTheoTenloai(@_MaLoai), tensp = @_TenSp, hinhanh = @_HinhAnh, giaban = @_GiaBan, trangthai = @_TrangThai where masp = @_MaSp";
            object[] parem = new object[] { maloai, tensp, hinhanh, giaban, trangthai, masp};
            DataProvider.ExecuteNonQuery(query, parem);
        }


        // lấy mã sp lớn nhất
        public string MaspLonNhat()
        {
            string query = "select top 1 MaSp from SanPham order by Masp desc";
            string maxMasp = (string)DataProvider.ExecuteScalar(query);
            return maxMasp;
        }

        // Lấy sản phẩm load lên pnlThucDon
        public DataTable SelectOnSaleProduct()
        {
            string query = "select TenSp, HinhAnh, GiaBan from SanPham where TrangThai like '%Còn bán%'";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
