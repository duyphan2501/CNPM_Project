using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NguyenLieu
    {
        //private string MaNL, MaLoaiNL, TenNL, DonVi;
        //private int SoLuong, MucToiThieu, MucOnDinh;

        public string MaNL { get; set; }
        public string MaLoaiNL { get; set; }
        public string TenNL { get; set; }
        public string DonVi { get; set; }
        public int SoLuong { get; set; }
        public int MucToiThieu { get; set; }

        public int MucOnDinh { get; set; }

        public DTO_NguyenLieu(string manl, string maloainl, string tennl, string donvi, int soluong, int mucToiThieu, int mucOnDinh)
        {
            MaNL = manl;
            MaLoaiNL = maloainl;
            TenNL = tennl;
            DonVi = donvi;
            SoLuong = soluong;
            MucToiThieu = mucToiThieu;
            MucOnDinh = mucOnDinh;
        }
    }
}
