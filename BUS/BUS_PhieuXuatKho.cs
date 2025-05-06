using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_PhieuXuatKho
    {
        DAL_PhieuXuatKho phieuxuatdal;

        public BUS_PhieuXuatKho(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            phieuxuatdal = new DAL_PhieuXuatKho(maPhieuXuat,tenDangNhap,ngayXuat,ghiChu);
        }

        public BUS_PhieuXuatKho()
        {
            phieuxuatdal = new DAL_PhieuXuatKho();
        }

        public DataTable LoadDeliveryReceipt()
        {
            return phieuxuatdal.LoadDeliveryReceipt();
        }

        public DataTable TaiMaPhieuXuat()
        {
            return phieuxuatdal.TaiMaPhieuXuat();
        }

        public int AddDeliveryReceip(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            return phieuxuatdal.AddDeliveryReceip(maPhieuXuat, tenDangNhap, ngayXuat, ghiChu);
        }

        public void SuaPhieuXuat(string maPhieuXuat, string tenDangNhap, DateTime ngayXuat, string ghiChu)
        {
            phieuxuatdal.SuaPhieuXuat(maPhieuXuat, tenDangNhap, ngayXuat, ghiChu);
        }

        public string GenerateID()
        {
            // lấy mã phiếu xuất lớn nhất
            string maphieu = phieuxuatdal.MaxID();
            // nếu mã phiếu lớn nhất là null thì gán mã phiếu đầu tiên là PX0001
            if (maphieu == null)
            {
                return "PX0001";
            }
            else
            {
                // lấy số sau PX
                int num = int.Parse(maphieu.Substring(2)) + 1;
                return "PX" + num.ToString("D4");
            }
        }

        public string GetMaPhieuXuat(string maDonHang)
        {
            return phieuxuatdal.GetMaPhieuXuat(maDonHang);
        }

        public Dictionary<string, decimal> GetRecipeFromPhieuXuat(string maPhieuXuat)
        {
            Dictionary<string, decimal> recipe = new Dictionary<string, decimal>();

            DataTable dt = phieuxuatdal.SelectCtPhieuXuat(maPhieuXuat);

            foreach (DataRow row in dt.Rows)
            {
                string maNL = row["MaNL"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);

                if (!recipe.ContainsKey(maNL))
                {
                    recipe.Add(maNL, soLuong);
                }
            }

            return recipe;
        }

    }
}
