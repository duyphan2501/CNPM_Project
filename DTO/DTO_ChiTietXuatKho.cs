using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietXuatKho
    {
        private string MaPhieuXuat, MaNL;
        private int SoLuong;

        public string _MaPhieuXuat { get; set; }
        public string _MaNL { get; set; }
        public int _SoLuong { get; set; }
        public DTO_ChiTietXuatKho(string maphieuxuat, string manl, int soluong)
        {
            this.MaPhieuXuat = maphieuxuat;
            this.MaNL = manl;
            this._SoLuong = soluong;
        }
    }
}
