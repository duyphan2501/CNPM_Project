using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_PhieuThuChi
    {
        DAL_PhieuThuChi phieuthuchidal;

        public BUS_PhieuThuChi(string maphieuthuchi, string tendangnhap, long sotien, string maloaithuchi, string ghichu)
        {
            phieuthuchidal = new DAL_PhieuThuChi(maphieuthuchi, tendangnhap, sotien, maloaithuchi, ghichu);
        }

        public DataTable TaiPhieu()
        {
            return phieuthuchidal.TaiPhieu();
        }

        public void ThemThuChi(string maphieuthuchi, string tendangnhap, long sotien, string maloaithuchi, string ghichu)
        {
            phieuthuchidal.ThemThuChi(maphieuthuchi,tendangnhap,sotien,maloaithuchi,ghichu);
        }

        //Phát sinh mã phiếu tự động
        public string PhatSinhMaPhieu()
        {
            // lấy mã phiếu lớn nhất
            string maphieu = phieuthuchidal.MaphieuLonNhat();
            // nếu mã phiếu lớn nhất là null thì gán mã phiếu đầu tiên là PH0001
            if (maphieu == null)
            {
                return "PH0001";
            }
            else
            {
                // lấy số sau SP
                int num = int.Parse(maphieu.Substring(2)) + 1;
                return "PH" + num.ToString("D4");
            }
        }
    }
}
