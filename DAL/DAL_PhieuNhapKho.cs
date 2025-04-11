using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_PhieuNhapKho
    {
        DTO_PhieuNhapKho phieunhapkhodto;

        public DAL_PhieuNhapKho(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            phieunhapkhodto = new DTO_PhieuNhapKho(maPhieuNhap,tenDangNhap,ngayNhap,ghiChu);
        }

        public DataTable TaiPhieunhap()
        {
            string query = "SELECT ph.MaPhieuNhap AS N'Mã phiếu nhập', nl.TenNL AS N'Nguyên liệu',ct.GiaNhap AS N'Giá nhập',    ct.SoLuong AS N'Số lượng nhập',    ph.NgayNhap AS N'Ngày lập',    ph.GhiChu AS N'Ghi chú'" +
                            " FROM PhieuNhapKho ph " +
                            "JOIN ChiTietNhapKho ct ON ph.MaPhieuNhap = ct.MaPhieuNhap " +
                            "JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL;";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable TaiMaPhieuNhap()
        {
            string query = "select distinct MaPhieuNhap from PhieuNhapKho";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable TaiTenNguyenLieu()
        {
            string query = "select distinct TenNL from NguyenLieu";
            return DataProvider.ExecuteQuery(query);
        }

        public void ThemPhieuNhap(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            string query = "insert into PhieuNhapKho values (@_MaPhiepNhap,@_TenDangNhap,@_NgayNhap,@_GhiChu)";
            object[] parem = new object[] {maPhieuNhap,tenDangNhap,ngayNhap,ghiChu};
            DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã phiếu nhập lớn nhất
        public string MaphieuLonNhat()
        {
            string query = "select top 1 MaPhieuNhap from PhieuNhapKho order by MaPhieuNhap desc";
            string maxMaphieu = (string)DataProvider.ExecuteScalar(query);
            return maxMaphieu;
        }
    }
}
