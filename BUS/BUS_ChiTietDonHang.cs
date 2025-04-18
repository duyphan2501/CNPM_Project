using DAL;

namespace BUS
{
    public class BUS_ChiTietDonHang
    {
        DAL_ChiTietDonHang ctDonHang;
        public BUS_ChiTietDonHang(string maDonHang, string maSp, int donGia, int soLuong)
        {
            ctDonHang = new DAL_ChiTietDonHang(maDonHang, maSp, donGia, soLuong);
        }

        public int InsertOrderDetail()
        {
            return ctDonHang.InsertOrderDetail();
        }
    }
}
