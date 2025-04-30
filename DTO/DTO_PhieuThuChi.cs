using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DTO
{
    public class DTO_PhieuThuChi
    {
        private string MaPhieuThuChi, TenDangNhap, MaLoaiThuChi, GhiChu;
        private long SoTien;

        public string _MaPhieuThuChi { get; set; }
        public string _TenDangNhap { get; set; }
        public int _SoTien { get; set; }
        public string _MaLoaiThuChi { get; set; }
        public string _GhiChu { get; set; }

        public DTO_PhieuThuChi(string maphieuthuchi, string tendangnhap, int sotien, string maloaithuchi, string ghichu)
        {
            this.MaPhieuThuChi = maphieuthuchi;
            this.TenDangNhap = tendangnhap;
            this.SoTien = sotien;
            this._MaLoaiThuChi = maloaithuchi;
            this._GhiChu = ghichu;

        }

        public DTO_PhieuThuChi() { }    

    }
}
