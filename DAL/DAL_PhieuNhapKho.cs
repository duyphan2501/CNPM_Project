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
        public DAL_PhieuNhapKho()
        {
            phieunhapkhodto = new DTO_PhieuNhapKho("", "", DateTime.Now, "");
        }

        //Tải phiếu nhập
        public DataTable LoadGoodsReceipt()
        {
            string query = "SELECT ph.MaPhieuNhap AS N'Mã phiếu nhập', nl.TenNL AS N'Nguyên liệu',ct.GiaNhap AS N'Giá nhập',    ct.SoLuong AS N'Số lượng nhập',    ph.NgayLap AS N'Ngày lập',    ph.GhiChu AS N'Ghi chú'" +
                            " FROM PhieuNhapKho ph " +
                            "JOIN ChiTietNhapKho ct ON ph.MaPhieuNhap = ct.MaPhieuNhap " +
                            "JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL;";
            return DataProvider.ExecuteQuery(query);
        }

        public void SuaPhieuNhap(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            string query = "update PhieuNhapKho set tenDangNhap = @_TenDangNhap, ngayNhap = @_NgayNhap, ghiChu = @_GhiChu where maPhieuNhap = @_MaPhieuNhap";
            object[] parem = new object[] {tenDangNhap, ngayNhap, ghiChu, maPhieuNhap};
            DataProvider.ExecuteNonQuery(query, parem);
        }

        public DataTable TaiMaPhieuNhap()
        {
            string query = "select distinct MaPhieuNhap from PhieuNhapKho";
            return DataProvider.ExecuteQuery(query);
        }

        public string TaiDonvi(string tennl)
        {
            string query = "SELECT DonVi FROM NguyenLieu WHERE TenNL = @TenNL";
            DataTable result = DataProvider.ExecuteQuery(query, new object[] { tennl });

            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["DonVi"].ToString();
            }
            else
            {
                return null;
            }
        }

        // lấy số lượng cần nhập thêm để đạt ổn định
        public int Restocking(string tennl)
        {
            string query = "select * from NguyenLieu where TenNL = @TenNL";
            DataTable result = DataProvider.ExecuteQuery(query, new object[] { tennl });

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["MucOnDinh"]) - Convert.ToInt32(result.Rows[0]["SoLuongTon"]);
            }
            else
            {
                return 0;
            }
        }

        public DataTable LoadIngredients_name()
        {
            string query = "select * from NguyenLieu";
            return DataProvider.ExecuteQuery(query);
        }

        //Thêm phiếu nhập kho
        public int AddGoodsReceipt(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            string query = "insert into PhieuNhapKho values (@_MaPhiepNhap,@_TenDangNhap,@_NgayNhap,@_GhiChu)";
            object[] parem = new object[] {maPhieuNhap,tenDangNhap,ngayNhap,ghiChu};
            return DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã phiếu nhập lớn nhất
        public string MaxID()
        {
            string query = "select top 1 MaPhieuNhap from PhieuNhapKho order by MaPhieuNhap desc";
            string maxMaphieu = (string)DataProvider.ExecuteScalar(query);
            return maxMaphieu;
        }
    }
}
