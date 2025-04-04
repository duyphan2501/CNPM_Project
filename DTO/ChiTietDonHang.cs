using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietDonHang
    {
        private string MaDonHang, MaSp;
        private int DonGia, SoLuong;

        public string _MaDonHang { get; set; }
        public string _MaSp { get; set; }
        public int _DonGia { get; set; }
        public int _SoLuong { get; set; }
        public ChiTietDonHang(string madonhang, string masp, int dongia, int soluong)
        {
            this.MaDonHang = madonhang;
            this.MaSp = masp;
            this.DonGia = dongia;
            this.SoLuong = soluong;

        }
    }
}
