﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DTO;
using System.Collections;
using Microsoft.Data.SqlClient;
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
        public DataTable LoadProduct()
        {
            string query = "select MaSp as 'Mã món',TenLoai as 'Tên loại',TenSp as 'Tên món',HinhAnh as 'Hình ảnh',GiaBan as 'Giá bán',TrangThai as 'Trạng thái' " +
                           "from SanPham,LoaiSanPham " +
                           "where SanPham.MaLoai=LoaiSanPham.MaLoai";
            return DataProvider.ExecuteQuery(query);
        }

        //Tải danh sách các tên loại lên combobox
        public DataTable LoadProduct_type()
        {
            string query = "select * from LoaiSanPham";
            return DataProvider.ExecuteQuery(query);
        }

        // Thêm sản phẩm mới vào database (Ảnh có thể NULL)
        public void AddProduct(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            string query = "INSERT INTO SanPham (MaSp, MaLoai, TenSp, HinhAnh, GiaBan, TrangThai) " +
                           "VALUES (@MaSP, @MaLoai, @TenSp, @HinhAnh, @GiaBan, @TrangThai)";

            object[] parem = new object[] { masp, maloai, tensp, hinhanh ?? (object)DBNull.Value, giaban, trangthai };

            DataProvider.ExecuteNonQuery(query, parem);
        }

        // Sửa thông tin sản phẩm (Ảnh có thể NULL)
        public void UpdateProduct(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            string query = "UPDATE SanPham SET MaLoai = @MaLoai, TenSp = @TenSp, HinhAnh = @HinhAnh, GiaBan = @GiaBan, " +
                           "TrangThai = @TrangThai WHERE MaSp = @MaSp";

            object[] parem = new object[] { maloai, tensp, hinhanh ?? (object)DBNull.Value, giaban, trangthai, masp };

            DataProvider.ExecuteNonQuery(query, parem);
        }


        // lấy mã sp lớn nhất
        public string MaxID()
        {
            string query = "select top 1 MaSp from SanPham order by Masp desc";
            string maxMasp = (string)DataProvider.ExecuteScalar(query);
            return maxMasp;
        }

        // Lấy sản phẩm load lên pnlThucDon
        public DataTable SelectOnSaleProduct()
        {
            string query = "select * from SanPham where TrangThai like '%Còn bán%'";
            return DataProvider.ExecuteQuery(query);
        }

        //Lọc n sản phẩm bán chạy nhất
        public DataTable GetBestSellingProductst(int soluong, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            string query = "SELECT TOP (@SoLuong) TenSp AS 'Tên sản phẩm', SUM(SoLuong) AS 'Tổng số lượng bán'" +
                           "FROM vw_HoaDonChiTiet " +
                           "WHERE NgayLap BETWEEN @TuNgay AND @DenNgay " +
                           "GROUP BY TenSp, DonGia " +
                           "ORDER BY SUM(SoLuong) DESC";

            object[] parem = new object[] { soluong, ngaybatdau, ngayketthuc };
            return DataProvider.ExecuteQuery(query, parem);
        }

    }
}
