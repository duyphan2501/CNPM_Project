using System;

namespace DTO
{
    public class DTO_DonHang
    {
        public string MaDonHang { get; set; }
        public string MaCaLap { get; set; }
        public string MaCaThanhToan { get; set; }
        public int TrangThai { get; set; }
        public int GiamGia { get; set; }
        public int TongTien { get; set; }
        public string MaThe { get; set; }   
        public int LoaiThanhToan { get; set; }
        public string GhiChu { get; set; }

        public DTO_DonHang(string maDonHang, string maCaLap,
                           int trangThai, string maThe, int giamGia, int tongTien, string ghiChu)
        {
            MaDonHang = maDonHang;
            MaCaLap = maCaLap;
            TrangThai = trangThai;
            MaThe = maThe;
            GiamGia = giamGia;
            TongTien = tongTien;
            GhiChu = ghiChu;
        }

        public DTO_DonHang(string maDonHang, string maCaThanhToan, int giamGia, int tongTien, int loaiThanhToan)
        {
            MaDonHang = maDonHang;
            MaCaThanhToan = maCaThanhToan;
            GiamGia = giamGia;
            TongTien = tongTien;
            LoaiThanhToan = loaiThanhToan;
        }


        public DTO_DonHang() { } // constructor rỗng nếu cần khởi tạo không tham số
    }
}
