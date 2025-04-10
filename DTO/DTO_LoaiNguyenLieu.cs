using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiNguyenLieu
    {
        private string MaLoaiNL, TenLoai;

        public string _MaLoaiNL { get; set; }
        public string _TenLoai { get; set; }
        public DTO_LoaiNguyenLieu(string maloainl, string tenloai)
        {
            this.MaLoaiNL = maloainl;
            this.TenLoai = tenloai;
        }
    }
}
