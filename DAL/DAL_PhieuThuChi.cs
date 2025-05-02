using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_PhieuThuChi
    {
        DTO_PhieuThuChi phieuthuchidto;

        public DAL_PhieuThuChi(string maphieuthuchi, string tendangnhap, int sotien, string maloaithuchi, string ghichu)
        {
            phieuthuchidto = new DTO_PhieuThuChi(maphieuthuchi,tendangnhap,sotien,maloaithuchi,ghichu);
        }

        public DAL_PhieuThuChi()
        {
            phieuthuchidto = new DTO_PhieuThuChi();
        }

        public DataTable LoadReceipt()
        {
            string query =
                "SELECT ptc.TenDangNhap AS N'Tài khoản lập phiếu', " +
                "ltc.Loai AS N'Loại phiếu', " +
                "ltc.TenLoai AS N'Loại thu chi', " +
                "ptc.SoTien AS N'Số tiền', " +
                "ptc.GhiChu AS N'Ghi chú', " +
                "FORMAT(ptc.NgayLap, 'dd/MM/yyyy HH:mm:ss') AS N'Ngày lập' " + // Định dạng ngày
                "FROM PhieuThuChi ptc " +
                "JOIN LoaiThuChi ltc ON ptc.MaLoaiThuChi = ltc.MaLoaiThuChi " +
                "ORDER BY ptc.NgayLap DESC";
            return DataProvider.ExecuteQuery(query);
        }

        public int AddReceipt(string maphieuthuchi, string tendangnhap, int sotien, string maloaithuchi, string ghichu)
        {
            string query = "insert into PhieuThuChi (MaPhieu, TenDangNhap, SoTien, MaLoaiThuChi, GhiChu) values (@_MaPhieuThuChi,@_TenDangNhap,@_SoTien,@_Loai,@_GhiChu)";
            object[] parem = new object[] {maphieuthuchi,tendangnhap,sotien, maloaithuchi,ghichu };
            return DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã phiếu thu cho lớn nhất
        public string MaxID(bool isExpense)
        {
            string prefix = isExpense ? "PC" : "PT";
            string query = $"SELECT TOP 1 MaPhieu FROM PhieuThuChi WHERE MaPhieu LIKE '{prefix}%' ORDER BY MaPhieu DESC";
            return (string)DataProvider.ExecuteScalar(query);
        }


        public DataTable LayDoanhThuTheoThang()
        {
            string query = @"
                SELECT 
                    YEAR(NgayLap) AS Nam,
                    MONTH(NgayLap) AS Thang,
                    SUM(CASE WHEN L.Loai = 'Thu' THEN P.SoTien ELSE 0 END) AS DoanhThu,
                    SUM(CASE WHEN L.Loai = 'Chi' THEN P.SoTien ELSE 0 END) AS ChiPhi
                FROM PhieuThuChi P
                JOIN LoaiThuChi L ON P.MaLoaiThuChi = L.MaLoaiThuChi
                GROUP BY YEAR(NgayLap), MONTH(NgayLap)
                ORDER BY Nam, Thang;
            ";

            return DataProvider.ExecuteQuery(query);
        }

        public DataTable LayDuLieuThongKe(string kieu, DateTime tuNgay, DateTime denNgay)
        {
            string groupField = "";

            // Xác định groupField dựa trên kiểu thống kê
            switch (kieu)
            {
                case "Tháng":
                    groupField = "FORMAT(NgayLap, 'MM/yyyy')";
                    break;
                case "Quý":
                    groupField = "CONCAT('Q', DATEPART(QUARTER, NgayLap), '/', YEAR(NgayLap))";
                    break;
                case "Năm":
                    groupField = "YEAR(NgayLap)";
                    break;
                default:
                    throw new ArgumentException("Kiểu thống kê không hợp lệ.");
            }

            string query = string.Format(
            "SELECT {0} AS ThoiGian, " +
            "SUM(CASE WHEN ltc.Loai = 'Thu' AND ltc.TenLoai = N'Thu từ đơn hàng' THEN ptc.SoTien ELSE 0 END) AS DoanhThuDonHang, " +
            "SUM(CASE WHEN ltc.Loai = 'Thu' AND ltc.TenLoai != N'Thu từ đơn hàng' THEN ptc.SoTien ELSE 0 END) AS DoanhThuKhac, " +
            "SUM(CASE WHEN ltc.Loai = 'Chi' THEN ptc.SoTien ELSE 0 END) AS ChiPhi, " +
            "COUNT(CASE WHEN ltc.Loai = 'Thu' AND ltc.MaLoaiThuChi = 'T01' THEN 1 ELSE NULL END) AS SoHoaDon " +
            "FROM PhieuThuChi AS ptc " +
            "JOIN LoaiThuChi AS ltc ON ptc.MaLoaiThuChi = ltc.MaLoaiThuChi " +
            "WHERE ptc.NgayLap BETWEEN @TuNgay AND @DenNgay " +
            "GROUP BY {0} " +
            "ORDER BY MIN(ptc.NgayLap)", groupField);


            // Truyền tham số trực tiếp vào câu truy vấn mà không sử dụng SqlParameter
            object[] parameters = new object[]
            {
                tuNgay,
                denNgay
            };

            // Trả về dữ liệu kết quả
            return DataProvider.ExecuteQuery(query, parameters);
        }

        public DataTable SelectThuChiTrongNgay()
        {
            string query = @"
            SELECT
                SUM(CASE WHEN ltc.Loai = 'Thu' THEN ptc.SoTien ELSE 0 END) AS DoanhThu,
                SUM(CASE WHEN ltc.Loai = 'Chi' THEN ptc.SoTien ELSE 0 END) AS ChiPhi
            FROM PhieuThuChi ptc
            JOIN LoaiThuChi ltc ON ptc.MaLoaiThuChi = ltc.MaLoaiThuChi
            WHERE CONVERT(date, ptc.NgayLap) = CONVERT(date, GETDATE())";

            return DataProvider.ExecuteQuery(query);
        }
    }
}
