using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
    public class BUS_DonHang
    {
        DAL_DonHang donhang;

        public BUS_DonHang(string maDonHang, string tenDangNhap, string maCaLam, DateTime ngayLap,
                           string trangThai, string loaiThanhToan, DateTime tgCapNhat, string ghiChu)
        {
            donhang = new DAL_DonHang(maDonHang, tenDangNhap, maCaLam, ngayLap, trangThai, loaiThanhToan, tgCapNhat, ghiChu);
        }

        public BUS_DonHang() { donhang = new DAL_DonHang(); }

        public string PhatSinhMaDonHang()
        {
            string maDonHienTai = donhang.LayMaDonHangLonNhat();
            // Lấy phần số sau chữ DH
            int so = int.Parse(maDonHienTai.Substring(2));
            // Tăng lên 1
            so++;
            // Trả về mã mới với định dạng DH + 5 chữ số
            return "DH" + so.ToString("D5");
        }
    } 
}
