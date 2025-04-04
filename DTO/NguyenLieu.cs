using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguyenLieu
    {
        private string MaNL, MaLoaiNL, TenNL, DonVi;
        private int SoLuong;

        public string _MaNL { get; set; }
        public string _MaLoaiNL { get; set; }
        public string _TenNL { get; set; }
        public string _DonVi { get; set; }
        public int _SoLuong { get; set; }

        public NguyenLieu(string manl, string maloainl, string tennl, string donvi, int soluong)
        {
            MaNL = manl;
            MaLoaiNL = maloainl;
            TenNL = tennl;
            DonVi = donvi;
            SoLuong = soluong;
        }
    }
}
