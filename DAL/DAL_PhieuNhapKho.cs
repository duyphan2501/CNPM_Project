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
            string query = "SELECT ph.MaPhieuNhap AS N'Mã phiếu', tk.TenDangNhap AS N'Người lập', nl.TenNL AS N'Nguyên liệu',ct.GiaNhap AS N'Giá nhập',    ct.SoLuong AS N'Số lượng nhập',    ph.NgayNhap AS N'Ngày lập',    ph.GhiChu AS N'Ghi chú'" +
                            " FROM PhieuNhapKho ph " +
                            "JOIN TaiKhoan tk ON ph.TenDangNhap = tk.TenDangNhap " +
                            "JOIN ChiTietNhapKho ct ON ph.MaPhieuNhap = ct.MaPhieuNhap " +
                            "JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL;";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
