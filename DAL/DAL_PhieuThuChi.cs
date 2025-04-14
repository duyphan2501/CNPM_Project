using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_PhieuThuChi
    {
        DTO_PhieuThuChi phieuthuchidto;

        public DAL_PhieuThuChi(string maphieuthuchi, string tendangnhap, long sotien, string maloaithuchi, string ghichu)
        {
            phieuthuchidto = new DTO_PhieuThuChi(maphieuthuchi,tendangnhap,sotien,maloaithuchi,ghichu);
        }

        public DataTable TaiPhieu()
        {
            string query = "select ptc.TenDangNhap as 'Tài khoản lập phiếu', ltc.Loai as 'Loại phiếu', ltc.TenLoai as 'Loại thu chi', ptc.SoTien as 'Số tiền', ptc.GhiChu as 'Ghi chú' " +
                            "from PhieuThuChi ptc, LoaiThuChi ltc " +
                            "where ptc.MaLoaiThuChi = ltc.MaLoaiThuChi";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
