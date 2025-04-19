using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DonHang
    {
        DTO_DonHang donhang;
        // Lập đơn hàng
        public DAL_DonHang(string maDonHang, string tenDangNhap, string maCaLam,
                           int trangThai, string maThe, string ghiChu)
        {
            donhang = new DTO_DonHang(maDonHang, tenDangNhap, maCaLam, trangThai, maThe, ghiChu);
        }
        // Thanh toán đơn hàng
        public DAL_DonHang(string maDonHang, string tenDangNhap, string maCaThanhToan, int giamGia,
                           int loaiThanhToan)
        {
            donhang = new DTO_DonHang(maDonHang, tenDangNhap, maCaThanhToan, giamGia, loaiThanhToan);
        }

        public DAL_DonHang() { donhang = new DTO_DonHang(); }

        public string LayMaDonHangLonNhat()
        {
            string query = "select top 1 madonhang from donhang order by madonhang desc";
            object result = DataProvider.ExecuteScalar(query);
            return result != null ? result.ToString() : "";
        }

        public int InsertNewOrder()
        {
            string query = "INSERT INTO DonHang (MaDonHang, NguoiLap, MaCaLap, TrangThai, MaThe, GhiChu) " +
                           "VALUES (@MaDonHang, @TenDangNhap, @MaCaLam, @TrangThai, @MaThe, @GhiChu)";

            object[] parameters = new object[]
            {
                donhang.MaDonHang,
                donhang.NguoiLap,
                donhang.MaCaLap,
                donhang.TrangThai,
                donhang.MaThe,
                donhang.GhiChu
            };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public int ThanhToanDonHang()
        {
            string query = "UPDATE DonHang SET NguoiThanhToan = @TenDangNhap, MaCaThanhToan = @MaCaThanhToan, GiamGia = @GiamGia, LoaiThanhToan = @LoaiThanhToan WHERE MaDonHang = @MaDonHang";
            object[] parameters = new object[]
            {
                donhang.NguoiThanhToan,
                donhang.MaCaThanhToan,
                donhang.GiamGia,
                donhang.LoaiThanhToan,
                donhang.MaDonHang
            };
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        // kiểm tra tồn tại của đơn hàng
        public bool isExistedOrder(string maDonHang)
        {
            string query = "SELECT 1 FROM DonHang WHERE MaDonHang = @MaDonHang";
            object result = DataProvider.ExecuteScalar(query, new object[] { maDonHang });
            return result != null;
        }

        // lấy đơn hàng cho thu ngân
        public DataTable SelectOrderForCashier(string maCaLam)
        {
            string query = "select * from DonHang where MaCaLap = @MaCaLap or MaCaThanhToan is null";
            return DataProvider.ExecuteQuery(query, new object[] { maCaLam });
        }

        public int UpdateTongTien(string maDonHang)
        {
            string query = "UPDATE DonHang SET TongTien = (SELECT SUM(SoLuong * DonGia) FROM ChiTietDonHang WHERE MaDonHang = @MaDonHang) WHERE MaDonHang = @MaDon";
            object[] parameters = new object[]
            {
                maDonHang,
                maDonHang
            };
            return (int)DataProvider.ExecuteNonQuery(query, parameters);
        }

        public string LayGhiChu(string maDonHang)
        {
            string query = "SELECT GhiChu FROM DonHang WHERE MaDonHang = @MaDonHang";
            object result = DataProvider.ExecuteScalar(query, new object[] { maDonHang });
            return result != null ? result.ToString() : "";
        }
    }
}
