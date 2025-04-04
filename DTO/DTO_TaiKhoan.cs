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
            this.TenDangNhap = tendangnhap;
            this.MatKhau = matkhau;
            this.TrangThai = trangthai;
            this.VaiTro = vaitro;
            this.HoTen = hoten;
            this.Email = email;
        }
    }
}
