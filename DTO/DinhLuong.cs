using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DinhLuong
    {
        private string MaSp, MaNL;
        private int SoLuong;

        public string _MaSp { get; set; }
        public string _MaNL { get; set; }
        public int _SoLuong { get; set; }

        public DinhLuong(string masp, string manl, int soluong)
        {
            this._MaSp = masp;
            this._MaNL = manl;
            this._SoLuong = soluong;
        }
    }
}
