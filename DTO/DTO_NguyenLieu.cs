using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NguyenLieu
    {
        private string MaNL, MaLoaiNL, TenNL, DonVi;
        private int SoLuong, MucToiThieu;

        public string _MaNL { get; set; }
        public string _MaLoaiNL { get; set; }
        public string _TenNL { get; set; }
        public string _DonVi { get; set; }
        public int _SoLuong { get; set; }
        public int _MucToiThieu { get; set; }

        public DTO_NguyenLieu(string manl, string maloainl, string tennl, string donvi, int soluong, int mucToiThieu)
        {
            MaNL = manl;
            MaLoaiNL = maloainl;
            TenNL = tennl;
            DonVi = donvi;
            SoLuong = soluong;
            _MucToiThieu = mucToiThieu;
        }
    }
}
