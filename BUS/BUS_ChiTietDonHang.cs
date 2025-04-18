using DAL;
using System.Data;

namespace BUS
{
    public class BUS_ChiTietDonHang
    {
        DAL_ChiTietDonHang ctDonHang;
        public BUS_ChiTietDonHang(string maDonHang, string maSp, int donGia, int soLuong)
        {
            ctDonHang = new DAL_ChiTietDonHang(maDonHang, maSp, donGia, soLuong);
        }

        public BUS_ChiTietDonHang() { ctDonHang = new DAL_ChiTietDonHang(); }

        public int InsertOrderDetail()
        {
            return ctDonHang.InsertOrderDetail();
        }

        public int TinhTongTien(string maDonHang)
        {
            return ctDonHang.TinhTongTien(maDonHang);
        }

        public DataTable SelectChiTietByMaDon(string maDonHang)
        {
            return ctDonHang.SelectChiTietByMaDon(maDonHang);
        }
    }
}
