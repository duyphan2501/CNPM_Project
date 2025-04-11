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

        public DAL_PhieuXuatKho(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            phieuxuatdto = new DTO_PhieuXuatKho(maPhieuXuat,tenDangNhap,ngayXuat,ghiChu);
        }

        public DataTable TaiPhieuxuat()
        {
            string query = "SELECT ph.MaPhieuXuat AS N'Mã phiếu xuất', tk.TenDangNhap AS N'Người lập', nl.TenNL AS N'Nguyên liệu',    ct.SoLuong AS N'Số lượng xuất',    ph.NgayXuat AS N'Ngày lập',    ph.GhiChu AS N'Ghi chú'" +
                            " FROM PhieuXuatKho ph " +
                            "JOIN TaiKhoan tk ON ph.TenDangNhap = tk.TenDangNhap " +
                            "JOIN ChiTietXuatKho ct ON ph.MaPhieuXuat = ct.MaPhieuXuat " +
                            "JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL;";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable TaiMaPhieuXuat()
        {
            string query = "select distinct MaPhieuXuat from PhieuXuatKho";
            return DataProvider.ExecuteQuery(query);
        }

        public void ThemPhieuXuat(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            string query = "insert into PhieuXuatKho values (@_MaPhiepXuat,@_TenDangNhap,@_NgayXuat,@_GhiChu)";
            object[] parem = new object[] { maPhieuXuat, tenDangNhap, ngayXuat, ghiChu };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã phiếu xuất lớn nhất
        public string MaphieuLonNhat()
        {
            string query = "select top 1 MaPhieuXuat from PhieuXuatKho order by MaPhieuXuat desc";
            string maxMaphieu = (string)DataProvider.ExecuteScalar(query);
            return maxMaphieu;
        }
    }
}
