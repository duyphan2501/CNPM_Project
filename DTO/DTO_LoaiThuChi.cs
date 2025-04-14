using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiThuChi
    {
        private string MaLoaiThuChi, TenLoai, Loai;

        public string _MaLoaiThuChi { get; set; }
        public string _TenLoai { get; set; }
        public string _Loai { get; set; }

        public DTO_LoaiThuChi(string maloaithuchi, string tenloai, string loai)
        {
            this.MaLoaiThuChi = maloaithuchi;
            this.TenLoai = tenloai;
            this.Loai = loai;
        }
    }
}
