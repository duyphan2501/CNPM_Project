using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHang
    {
        private string MaDonHang, TenDangNhap, MaCaLam, TrangThai, LoaiThanhToan, GhiChu;
        private DateTime NgayLap, TgCapNhat;

        public string _MaDonHang { get; set; }
        public string _TenDangNhap { get; set; }
        public string _MaCaLam { get; set; }
        public string _TrangThai { get; set; }
        public string _LoaiThanhToan { get; set; }
        public string _GhiChu { get; set; }

        public DateTime _NgayLap { get; set; }
        public DateTime _TgCapNhat { get; set; }

        public DonHang(string madonhang, string tendangnhap, string macalam, DateTime ngaylap, string trangthai, string loaithanhtoan, DateTime tgcapnhat, string ghichu)
        {
            this.MaDonHang = madonhang;
            this._TenDangNhap = tendangnhap;
            this._MaCaLam = macalam;
            this._NgayLap = ngaylap;
            this.TrangThai = trangthai;
            this.LoaiThanhToan = loaithanhtoan;
            this.TgCapNhat = tgcapnhat;
            this.GhiChu = ghichu;
        }
    }
}
