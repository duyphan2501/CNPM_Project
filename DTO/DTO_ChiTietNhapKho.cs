using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietNhapKho
    {
        private string MaPhieuNhap, MaNL;
        private int GiaNhap, SoLuong;

        public string _MaPhieuNhap { get; set; }
        public string _MaNL { get; set; }
        public int _GiaNhap { get; set; }
        public int _SoLuong { get; set; }
        public DTO_ChiTietNhapKho(string maphieunhap, string manl, int gianhap, int soluong)
        {
            this.MaPhieuNhap = maphieunhap;
            this.MaNL = manl;
            this.GiaNhap = gianhap;
            this.SoLuong = soluong;
        }

    }
}
