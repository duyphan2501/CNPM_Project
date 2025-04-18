using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietKiemKho
    {
        private string MaPhieuKiemKho, MaNL;
        private int SoLuong;

        public string _MaPhieuKiemKho { get; set; }
        public string _MaNL { get; set; }
        public int _SoLuong { get; set; }
        public DTO_ChiTietKiemKho(string maphieukiemkho, string manl, int soluong)
        {
            this.MaPhieuKiemKho = maphieukiemkho;
            this.MaNL = manl;
            this._SoLuong = soluong;
        }
    }
}
