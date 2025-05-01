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
            string query = "select MaPhieu as 'Mã Phiếu', TenDangNhap as 'Tên đăng nhập', Loai as 'Loại phiếu', SoTien as 'Số tiền', GhiChu as 'Ghi chú', NgayLap as 'Ngày lập' from PhieuThuChi";
            return DataProvider.ExecuteQuery(query);
        }

        public int AddReceipt(string maphieuthuchi, string tendangnhap, int sotien, string loai, string ghichu)
        {
            string query = "insert into PhieuThuChi (MaPhieu, TenDangNhap, SoTien, Loai, GhiChu) values (@_MaPhieuThuChi,@_TenDangNhap,@_SoTien,@_Loai,@_GhiChu)";
            object[] parem = new object[] {maphieuthuchi,tendangnhap,sotien,loai,ghichu };
            return DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã phiếu thu cho lớn nhất theo từng loại mã
        public string MaxID(bool isExpense)
        {
            string prefix = isExpense ? "PC" : "PT";
            string query = $"select top 1 MaPhieu from PhieuThuChi where MaPhieu like '{prefix}%' order by MaPhieu desc";
            string maxMaphieu = (string)DataProvider.ExecuteScalar(query);
            return maxMaphieu;
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
            "COUNT(CASE WHEN ltc.Loai = 'Thu' AND ltc.TenLoai = N'Thu từ đơn hàng' THEN 1 ELSE NULL END) AS SoHoaDon " +
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


    }
}
