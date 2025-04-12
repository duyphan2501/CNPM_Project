using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhieuNhapKho
    {
        private string MaPhieuNhap, TenDangNhap, GhiChu;
        private DateTime NgayNhap;

        public string _MaPhieuNhap { get; set; }
        public string _TenDangNhap { get; set; }
        public string _GhiChu { get; set; }
        public DateTime _NgayNhap { get; set; }

        public DTO_PhieuNhapKho(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            this.MaPhieuNhap = maPhieuNhap;
            this.TenDangNhap = tenDangNhap;
            this.GhiChu = ghiChu;
            this.NgayNhap = ngayNhap;
        }
    }
}
