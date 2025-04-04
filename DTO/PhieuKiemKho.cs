using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuKiemKho
    {
        private string MaPhieuKiemKho, TenDangNhap, GhiChu;
        private DateTime NgayLap;

        public string _MaPhieuKiemKho { get; set; }
        public string _TenDangNhap { get; set; }
        public string _GhiChu { get; set; }
        public DateTime _NgayLap { get; set; }

        public PhieuKiemKho(string maPhieuKiemKho, string tenDangNhap, DateTime ngayLap, string ghiChu)
        {
            this.MaPhieuKiemKho = maPhieuKiemKho;
            this.TenDangNhap = tenDangNhap;
            this.GhiChu = ghiChu;
            this.NgayLap = ngayLap;
        }
    }
}
