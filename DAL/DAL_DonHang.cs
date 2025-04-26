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
        public DAL_DonHang(string maDonHang, string maCaLap,
                           int trangThai, string maThe, int giamGia, int tongTien, string ghiChu)
        {
            donhang = new DTO_DonHang(maDonHang, maCaLap, trangThai, maThe, giamGia, tongTien, ghiChu);
        }
        // Thanh toán đơn hàng
        public DAL_DonHang(string maDonHang, string maCaThanhToan, int giamGia, int tongTien,
                           int loaiThanhToan)
        {
            donhang = new DTO_DonHang(maDonHang, maCaThanhToan, giamGia, tongTien, loaiThanhToan);
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
            string query = "INSERT INTO DonHang (MaDonHang, MaCaLap, TrangThai, MaThe, GiamGia, TongTien, GhiChu) " +
                           "VALUES (@MaDonHang, @MaCaLam, @TrangThai, @MaThe, @GiamGia, @TongTien, @GhiChu)";

            object[] parameters = new object[]
            {
                donhang.MaDonHang,
                donhang.MaCaLap,
                donhang.TrangThai,
                donhang.MaThe,
                donhang.GiamGia,
                donhang.TongTien,
                donhang.GhiChu
            };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public int ThanhToanDonHang()
        {
            string query = "UPDATE DonHang SET MaCaThanhToan = @MaCaThanhToan, GiamGia = @GiamGia, TongTien = @TongTien, LoaiThanhToan = @LoaiThanhToan WHERE MaDonHang = @MaDonHang";
            object[] parameters = new object[]
            {
                donhang.MaCaThanhToan,
                donhang.GiamGia,
                donhang.TongTien,
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
            string query = "select * from DonHang where MaCaLap = @MaCaLap or MaCaThanhToan is null order by madonhang desc";
            return DataProvider.ExecuteQuery(query, new object[] { maCaLam });
        }

        public int TinhTongTien(string maDonHang)
        {
            string query = @"
                    SELECT 
                        ISNULL(SUM(ct.DonGia * ct.SoLuong), 0) AS TongTien,
                        ISNULL(dh.GiamGia, 0) AS GiamGia
                    FROM ChiTietDonHang ct
                    JOIN DonHang dh ON ct.MaDonHang = dh.MaDonHang
                    WHERE ct.MaDonHang = @maDon
                    GROUP BY dh.GiamGia
                ";

            DataTable dt = DataProvider.ExecuteQuery(query, new object[] { maDonHang });
            if (dt.Rows.Count == 0) return 0;

            int tongTien = Convert.ToInt32(dt.Rows[0]["TongTien"]);
            int giamGia = Convert.ToInt32(dt.Rows[0]["GiamGia"]);

            // Tính tổng tiền sau khi trừ phần trăm giảm giá
            int tongTienSauGiam = tongTien - (tongTien * giamGia / 100);
            return tongTienSauGiam;
        }

        public int UpdateDonHang(string maDonHang, int giamGia, int tongTien, string ghiChu)
        {
            string query = "update donhang set GiamGia = @GiamGia, TongTien = @TongTien, GhiChu = @GhiChu where madonhang = @madonhang";
            object[] objects = { giamGia, tongTien, ghiChu, maDonHang };
            return DataProvider.ExecuteNonQuery(query, objects);
        }

        public string LayGhiChu(string maDonHang)
        {
            string query = "SELECT GhiChu FROM DonHang WHERE MaDonHang = @MaDonHang";
            object result = DataProvider.ExecuteScalar(query, new object[] { maDonHang });
            return result != null ? result.ToString() : "";
        }

        public DataTable SelectDonHang(string maDonHang)
        {
            string query = "select * from donhang where madonhang = @madonhang";
            return DataProvider.ExecuteQuery(query, new object[] { maDonHang });
        }

        public int UpdateStateDonHang(string maDonHang, int trangThai)
        {
            string query = "update donhang set trangthai = @trangthai where madonhang = @madonhang";
            object[] objects = { trangThai, maDonHang };
            return DataProvider.ExecuteNonQuery(query, objects);
        }

        public int LayLoaiThanhToan(string maDonHang)
        {
            string query = "SELECT LoaiThanhToan FROM DonHang WHERE MaDonHang = @MaDonHang";
            object result = DataProvider.ExecuteScalar(query, new object[] { maDonHang });
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public DataTable SelectDonHangOnPage(int page, int pageSize)
        {
            string query = "SELECT * FROM DonHang ORDER BY MaDonHang desc OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
            int offset = (page - 1) * pageSize;
            return DataProvider.ExecuteQuery(query, new object[] { offset, pageSize });
        }

        public int GetToTalNumberDonHang()
        {
            string query = "SELECT COUNT(MaDonHang) FROM DonHang";
            object result = DataProvider.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public DataTable SelectHoaDon(string maDonHang)
        {
            string query = "SELECT * FROM vw_HoaDonChiTiet WHERE MaDonHang = @MaDonHang";
            return DataProvider.ExecuteQuery(query, new object[] { maDonHang });
        }
    }
}
