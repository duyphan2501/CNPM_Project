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

        public DataTable LoadReceipt()
        {
            string query = "select ptc.TenDangNhap as 'Tài khoản lập phiếu', ltc.Loai as 'Loại phiếu', ltc.TenLoai as 'Loại thu chi', ptc.SoTien as 'Số tiền', ptc.GhiChu as 'Ghi chú', ptc.NgayLap as 'Ngày lập' " +
                            "from PhieuThuChi ptc, LoaiThuChi ltc " +
                            "where ptc.MaLoaiThuChi = ltc.MaLoaiThuChi";
            return DataProvider.ExecuteQuery(query);
        }

        public void AddReceipt(string maphieuthuchi, string tendangnhap, long sotien, string maloaithuchi, string ghichu)
        {
            string query = "insert into PhieuThuChi (MaPhieu, TenDangNhap, SoTien, MaLoaiThuChi, GhiChu) values (@_MaPhieuThuChi,@_TenDangNhap,@_SoTien,@_MaLoaiThuChi,@_GhiChu)";
            object[] parem = new object[] {maphieuthuchi,tendangnhap,sotien,maloaithuchi,ghichu };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã phiếu thu cho lớn nhất
        public string MaxID()
        {
            string query = "select top 1 MaPhieu from PhieuThuChi order by MaPhieu desc";
            string maxMaphieu = (string)DataProvider.ExecuteScalar(query);
            return maxMaphieu;
        }

    }
}
