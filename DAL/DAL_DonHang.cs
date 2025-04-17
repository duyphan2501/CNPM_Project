using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DonHang
    {
        DTO_DonHang donhang;
        public DAL_DonHang(string maDonHang, string tenDangNhap, string maCaLam, DateTime ngayLap,
                           string trangThai, string loaiThanhToan, DateTime tgCapNhat, string ghiChu)
        {
            donhang = new DTO_DonHang(maDonHang, tenDangNhap, maCaLam, ngayLap, trangThai, loaiThanhToan, tgCapNhat, ghiChu);
        }

        public DAL_DonHang() { donhang = new DTO_DonHang(); }

        public string LayMaDonHangLonNhat()
        {
            string query = "select top 1 madonhang from donhang order by madonhang desc";
            object result = DataProvider.ExecuteScalar(query);
            return result != null ? result.ToString() : "DH00001";
        }
    }
}
