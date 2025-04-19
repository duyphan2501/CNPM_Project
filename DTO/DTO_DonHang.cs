using System;

namespace DTO
{
    public class DTO_DonHang
    {
        public string MaDonHang { get; set; }
        public string NguoiLap { get; set; }
        public string MaCaLap { get; set; }

        public string NguoiThanhToan { get; set; }
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
            NguoiLap = tenDangNhap;
            MaCaLap = maCaLam;
            TrangThai = trangThai;
            MaThe = maThe;
            GhiChu = ghiChu;
        }

        public DTO_DonHang(string maDonHang, string tenDangNhap, string maCaThanhToan, int giamGia,
                           int loaiThanhToan)
        {
            
            MaDonHang = maDonHang;
            NguoiThanhToan = tenDangNhap;
            MaCaThanhToan = maCaThanhToan;
            GiamGia = giamGia;
            LoaiThanhToan = loaiThanhToan;
        }

        public DTO_DonHang() { } // constructor rỗng nếu cần khởi tạo không tham số
    }
}
