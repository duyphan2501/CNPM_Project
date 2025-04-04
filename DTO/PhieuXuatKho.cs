using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuXuatKho
    {
        private string MaPhieuXuat, TenDangNhap, GhiChu;
        private DateTime NgayXuat;

        public string _MaPhieuXuat { get; set; }
        public string _TenDangNhap { get; set; }
        public string _GhiChu { get; set; }
        public DateTime _NgayXuat { get; set; }

        public PhieuXuatKho(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            this.MaPhieuXuat = maPhieuXuat;
            this.TenDangNhap = tenDangNhap;
            this.GhiChu = ghiChu;
            this.NgayXuat = ngayXuat;
        }

    }
}
