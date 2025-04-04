using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiThuChi
    {
        private string MaLoaiThuChi, TenLoai;

        public string _MaLoaiThuChi { get; set; }
        public string _TenLoai { get; set; }

        public LoaiThuChi(string maloaithuchi, string tenloai)
        {
            this.MaLoaiThuChi = maloaithuchi;
            this.TenLoai = tenloai;
        }
    }
}
