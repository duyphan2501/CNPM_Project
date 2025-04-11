using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TaiKhoan
    {
        private string TenDangNhap, MatKhau, TrangThai, VaiTro, HoTen, Email;

        public string _TenDangNhap { get; set; }
        public string _MatKhau { get; set; }
        public string _TrangThai { get; set; }
        public string _VaiTro { get; set; }
        public string _HoTen { get; set; }
        public string _Email { get; set; }

        public DTO_TaiKhoan(string tendangnhap, string matkhau, string trangthai, string vaitro, string hoten, string email)
        {
            this._TenDangNhap = tendangnhap;
            this._MatKhau = matkhau;
            this._TrangThai = trangthai;
            this._VaiTro = vaitro;
            this._HoTen = hoten;
            this._Email = email;
        }
    }
}
