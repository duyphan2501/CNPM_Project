using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_PhieuNhapKho
    {
        DAL_PhieuNhapKho phieunhapkhodal;

        public BUS_PhieuNhapKho(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            phieunhapkhodal = new DAL_PhieuNhapKho(maPhieuNhap, tenDangNhap, ngayNhap, ghiChu);
        }

        public DataTable TaiPhieunhap()
        {
            return phieunhapkhodal.TaiPhieunhap();
        }
    }
}
