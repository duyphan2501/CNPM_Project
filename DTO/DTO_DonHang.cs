using System;

namespace DTO
{
    public class DTO_DonHang
    {
        public string MaDonHang { get; set; }
        public string TenDangNhap { get; set; }
        public string MaCaLam { get; set; }
        public string TrangThai { get; set; }
        public string LoaiThanhToan { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime TgCapNhat { get; set; }

        public DTO_DonHang(string maDonHang, string tenDangNhap, string maCaLam, DateTime ngayLap,
                           string trangThai, string loaiThanhToan, DateTime tgCapNhat, string ghiChu)
        {
            MaDonHang = maDonHang;
            TenDangNhap = tenDangNhap;
            MaCaLam = maCaLam;
            NgayLap = ngayLap;
            TrangThai = trangThai;
            LoaiThanhToan = loaiThanhToan;
            TgCapNhat = tgCapNhat;
            GhiChu = ghiChu;
        }

        public DTO_DonHang() { } // constructor rỗng nếu cần khởi tạo không tham số
    }
}
