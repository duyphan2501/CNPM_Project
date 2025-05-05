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

        public BUS_PhieuThuChi(string maphieuthuchi, string tendangnhap, int sotien, string maloaithuchi, string ghichu)
        {
            phieuthuchidal = new DAL_PhieuThuChi(maphieuthuchi, tendangnhap, sotien, maloaithuchi, ghichu);
        }

        public BUS_PhieuThuChi()
        {
            this.phieuthuchidal = new DAL_PhieuThuChi();
        }

        public DataTable LoadReceipt()
        {
            return phieuthuchidal.LoadReceipt();
        }

        public int AddReceipt(string maphieuthuchi, string tendangnhap, int sotien, string loai, string ghichu)
        {
            return phieuthuchidal.AddReceipt(maphieuthuchi,tendangnhap,sotien,loai,ghichu);
        }

        //Phát sinh mã phiếu tự động
        public string GenerateID(bool isExpense)
        {
            string maphieu = phieuthuchidal.MaxID(isExpense);
            string start = isExpense ? "PC" : "PT";

            if (maphieu != null && int.TryParse(maphieu.Substring(2), out int num))
            {
                num++;
                return start + num.ToString("D8");
            }
            return start + "00000001";
        }


        public DataTable LayDoanhThuTheoThang()
        {
            return phieuthuchidal.LayDoanhThuTheoThang();
        }

        public DataTable LayDuLieuThongKe(string kieu, DateTime tuNgay, DateTime denNgay)
        {
            return phieuthuchidal.LayDuLieuThongKe(kieu, tuNgay, denNgay);
        }

        public DataTable SelectThuChiTrongNgay()
        {
            return phieuthuchidal.SelectThuChiTrongNgay();
        }

    }
}
