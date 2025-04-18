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
        public DAL_DonHang(string maDonHang, string tenDangNhap, string maCaLam,
                           int trangThai, string maThe, string ghiChu)
        {
            donhang = new DTO_DonHang(maDonHang, tenDangNhap, maCaLam, trangThai, maThe, ghiChu);
        }

        public DAL_DonHang(string maDonHang, string maCaThanhToan, int giamGia,
                           int loaiThanhToan)
        {
            donhang = new DTO_DonHang(maDonHang, maCaThanhToan, giamGia, loaiThanhToan);
        }

        public DAL_DonHang() { donhang = new DTO_DonHang(); }

        public string LayMaDonHangLonNhat()
        {
            string query = "select top 1 madonhang from donhang order by madonhang desc";
            object result = DataProvider.ExecuteScalar(query);
            return result != null ? result.ToString() : "DH00001";
        }

        public int InsertNewOrder()
        {
            string query = "INSERT INTO DonHang (MaDonHang, TenDangNhap, MaCaLam, TrangThai, MaThe, GhiChu) " +
                           "VALUES (@MaDonHang, @TenDangNhap, @MaCaLam, @TrangThai, @MaThe, @GhiChu)";

            object[] parameters = new object[]
            {
                donhang.MaDonHang,
                donhang.TenDangNhap,
                donhang.MaCaLam,
                donhang.TrangThai,
                donhang.MaThe,
                donhang.GhiChu
            };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public int ThanhToanDonHang()
        {
            string query = "UPDATE DonHang SET MaCaThanhToan = @MaCaThanhToan, GiamGia = @GiamGia, LoaiThanhToan = @LoaiThanhToan WHERE MaDonHang = @MaDonHang";
            object[] parameters = new object[]
            {
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
            string query = "select * from DonHang where MaCaLam = @MaCaLam or MaCaThanhToan is null";
            return DataProvider.ExecuteQuery(query, new object[] { maCaLam });
        }
    }
}
