using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_PhieuXuatKho
    {
        DAL_PhieuXuatKho phieuxuatdal;

        public BUS_PhieuXuatKho(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            phieuxuatdal = new DAL_PhieuXuatKho(maPhieuXuat,tenDangNhap,ngayXuat,ghiChu);
        }

        public DataTable LoadDeliveryReceipt()
        {
            return phieuxuatdal.LoadDeliveryReceipt();
        }

        public DataTable TaiMaPhieuXuat()
        {
            return phieuxuatdal.TaiMaPhieuXuat();
        }

        public void AddDeliveryReceip(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            phieuxuatdal.AddDeliveryReceip(maPhieuXuat, tenDangNhap, ngayXuat, ghiChu);
        }

        public void SuaPhieuXuat(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            phieuxuatdal.SuaPhieuXuat(maPhieuXuat, tenDangNhap, ngayXuat, ghiChu);
        }

        public string GenerateID()
        {
            // lấy mã phiếu xuất lớn nhất
            string maphieu = phieuxuatdal.MaxID();
            // nếu mã phiếu lớn nhất là null thì gán mã phiếu đầu tiên là PX0001
            if (maphieu == null)
            {
                return "PX0001";
            }
            else
            {
                // lấy số sau PX
                int num = int.Parse(maphieu.Substring(2)) + 1;
                return "PX" + num.ToString("D4");
            }
        }
    }
}
