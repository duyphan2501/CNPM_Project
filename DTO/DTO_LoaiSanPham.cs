using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiSanPham
    {
        private string MaLoai, TenLoai;

        public string _MaLoai { get; set; }
        public string _TenLoai { get; set; }

        public DTO_LoaiSanPham(string maloai, string tenloai)
        {
            this.MaLoai = maloai;
            this.TenLoai = tenloai;
        }

        public DTO_LoaiSanPham() { }    
    }
}
