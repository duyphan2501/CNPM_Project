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
            phieuthuchidal = new DAL_PhieuThuChi(maphieuthuchi,tendangnhap,sotien,maloaithuchi,ghichu);
        }

        public DataTable TaiPhieu()
        {
            return phieuthuchidal.TaiPhieu();
        }
    }
}
