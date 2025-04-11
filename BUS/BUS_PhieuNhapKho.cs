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

        public DataTable TaiTenNguyenLieu()
        {
            return phieunhapkhodal.TaiTenNguyenLieu();
        }

        public DataTable TaiMaPhieuNhap()
        {
            return phieunhapkhodal.TaiMaPhieuNhap();
        }

        public void ThemPhieuNhap(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            phieunhapkhodal.ThemPhieuNhap(maPhieuNhap, tenDangNhap, ngayNhap, ghiChu);
        }


        // phát sinh mã phiếp nhập
        public string PhatSinhMaPhieuNhap()
        {
            // lấy mã phiếu nhập lớn nhất
            string maphieu = phieunhapkhodal.MaphieuLonNhat();
            // nếu mã phiếu lớn nhất là null thì gán mã phiếu đầu tiên là PN0001
            if (maphieu == null)
            {
                return "PN0001";
            }
            else
            {
                // lấy số sau PN
                int num = int.Parse(maphieu.Substring(2)) + 1;
                return "PN" + num.ToString("D4");
            }
        }
    }
}
