using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_PhieuXuatKho
    {
        DTO_PhieuXuatKho phieuxuatdto;

        public DAL_PhieuXuatKho(string maPhieuXuat, string tenDangXuat, DateTime ngayXuat, string ghiChu)
        {
            phieuxuatdto = new DTO_PhieuXuatKho(maPhieuXuat,tenDangXuat,ngayXuat,ghiChu);
        }

        public DAL_PhieuXuatKho()
        {
            phieuxuatdto = new DTO_PhieuXuatKho("", "", DateTime.Now, "");
        }

        public DataTable LoadDeliveryReceipt()
        {
            string query =
                "SELECT ph.MaPhieuXuat AS N'Mã phiếu xuất', " +
                "nl.TenNL AS N'Nguyên liệu', " +
                "ct.SoLuong AS N'Số lượng xuất', " +
                "nl.Donvi AS N'Đơn vị', " +
                "FORMAT(ph.NgayXuat, 'dd/MM/yyyy HH:mm:ss') AS N'Ngày lập', " +  // Định dạng ngày
                "ph.GhiChu AS N'Ghi chú' " +
                "FROM PhieuXuatKho ph " +
                "JOIN ChiTietXuatKho ct ON ph.MaPhieuXuat = ct.MaPhieuXuat " +
                "JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL " +
                "ORDER BY ph.NgayXuat DESC;";

            return DataProvider.ExecuteQuery(query);
        }


        public DataTable TaiMaPhieuXuat()
        {
            string query = "select distinct MaPhieuXuat from PhieuXuatKho";
            return DataProvider.ExecuteQuery(query);
        }

        //Thêm phiếu xuất
        public int AddDeliveryReceip(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            string query = "insert into PhieuXuatKho values (@_MaPhiepXuat,@_TenDangNhap,@_NgayXuat,@_GhiChu)";
            object[] parem = new object[] { maPhieuXuat, tenDangNhap, ngayXuat, ghiChu };
            return DataProvider.ExecuteNonQuery(query, parem);
        }

        public void SuaPhieuXuat(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            string query = "update PhieuXuatKho set tenDangNhap = @_TenDangNhap, ngayXuat = @_NgayXuat, ghiChu = @_GhiChu where maPhieuXuat = @_MaPhieuXuat";
            object[] parem = new object[] { tenDangNhap, ngayXuat, ghiChu, maPhieuXuat };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã phiếu xuất lớn nhất
        public string MaxID()
        {
            string query = "select top 1 MaPhieuXuat from PhieuXuatKho order by MaPhieuXuat desc";
            string maxMaphieu = (string)DataProvider.ExecuteScalar(query);
            return maxMaphieu;
        }

        public string GetMaPhieuXuat(string maDonHang)
        {
            string query = "SELECT MaPhieuXuat FROM PhieuXuatKho WHERE GhiChu LIKE @MaDonHang";
            object result = DataProvider.ExecuteScalar(query, new object[] { "%" + maDonHang + "%" });
            return result != null ? result.ToString() : null;
        }

        public DataTable GetAllExportDetailsOfOrder(string maDonHang)
        {
            string query =
                "SELECT cxk.MaNL, SUM(cxk.SoLuong) AS SoLuong " +
                "FROM PhieuXuatKho pxk " +
                "JOIN ChiTietXuatKho cxk ON pxk.MaPhieuXuat = cxk.MaPhieuXuat " +
                "WHERE pxk.GhiChu LIKE '%" + maDonHang + "%' " +  // Tìm kiếm trong GhiChu để liên kết với MaDonHang
                "GROUP BY cxk.MaNL";

            return DataProvider.ExecuteQuery(query);
        }
    }
}
