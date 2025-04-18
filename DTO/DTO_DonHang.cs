using System;

namespace DTO
{
    public class DTO_DonHang
    {
        public string MaDonHang { get; set; }
        public string TenDangNhap { get; set; }
        public string MaCaLam { get; set; }
        public string MaCaThanhToan { get; set; }
        public int TrangThai { get; set; }
        public int GiamGia { get; set; }
        public string MaThe { get; set; }   
        public int LoaiThanhToan { get; set; }
        public string GhiChu { get; set; }

        public DTO_DonHang(string maDonHang, string tenDangNhap, string maCaLam,
                           int trangThai, string maThe, string ghiChu)
        {
            MaDonHang = maDonHang;
            TenDangNhap = tenDangNhap;
            MaCaLam = maCaLam;
            TrangThai = trangThai;
            MaThe = maThe;
            GhiChu = ghiChu;
        }

        public DTO_DonHang(string maDonHang, string maCaThanhToan, int giamGia,
                           int loaiThanhToan)
        {
            MaDonHang = maDonHang;
            MaCaThanhToan = maCaThanhToan;
            GiamGia = giamGia;
            LoaiThanhToan = loaiThanhToan;
        }

        public DTO_DonHang() { } // constructor rỗng nếu cần khởi tạo không tham số
    }
}
