using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
namespace DAL
{
    public class DAL_ChiTietDonHang
    {
        DTO_ChiTietDonHang ctDonHang;
        public DAL_ChiTietDonHang(string maDonHang, string maSp, int donGia, int soLuong)
        {
            ctDonHang = new DTO_ChiTietDonHang(maDonHang, maSp, donGia, soLuong);
        }

        public DAL_ChiTietDonHang() { ctDonHang = new DTO_ChiTietDonHang(); }   

        // InsertOrderDetail: Chèn chi tiết đơn hàng vào cơ sở dữ liệu
        public int InsertOrderDetail()
        {
            // Tạo câu truy vấn SQL
            string query = "INSERT INTO ChiTietDonHang (MaDonHang, MaSp, DonGia, SoLuong) " +
                           "VALUES (@MaDonHang, @MaSp, @DonGia, @SoLuong)";

            // Khai báo tham số
            object[] parameters = new object[]
            {
                ctDonHang.MaDonHang,
                ctDonHang.MaSp,
                ctDonHang.DonGia,
                ctDonHang.SoLuong,
            };

            // Thực thi câu lệnh SQL và trả về số dòng bị ảnh hưởng
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public int TinhTongTien(string maHoaDon)
        {
            string query = "SELECT SUM(SoLuong * DonGia) AS TongTien FROM ChiTietDonHang WHERE MaDonHang = @MaDonHang";
            return (int)DataProvider.ExecuteScalar(query, new object[] { maHoaDon });
        }

        public DataTable SelectChiTietByMaDon(string maDonHang)
        {
            string query = @"SELECT ct.MaSp, sp.TenSp, ct.SoLuong, ct.DonGia
                     FROM ChiTietDonHang ct
                     JOIN SanPham sp ON ct.MaSp = sp.MaSp
                     WHERE ct.MaDonHang = @MaDonHang";
            return DataProvider.ExecuteQuery(query, new object[] { maDonHang });
        }

    }
}
