using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SanPham
    {
        private string MaSp, MaLoai, TenSp, TrangThai;
        private byte[] HinhAnh;
        private int GiaBan;

        public string _MaSp { get; set; }
        public string _MaLoai { get; set; }
        public string _TenSp { get; set; }
        public string _TrangThai { get; set; }
        public byte[] _HinhAnh { get; set; }
        public int _GiaBan { get; set; }

        public DTO_SanPham(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            this.MaSp = masp;
            this.MaLoai = maloai;
            this.TenSp = tensp;
            this.TrangThai = trangthai;
            this.HinhAnh = hinhanh;
            this.GiaBan = giaban;
        }


    }
}
