using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_CaLamViec
    {
        DAL_CaLamViec calamViec;

        public BUS_CaLamViec(DateTime tgBatDau, DateTime? tgKetThuc, string ghiChu, int tienDauCa, int tienCuoiCa, string tenDangNhap)
        {
            calamViec = new DAL_CaLamViec(tgBatDau, tgKetThuc, ghiChu, tienDauCa, tienCuoiCa, tenDangNhap);
        }

        public BUS_CaLamViec()
        {
            calamViec = new DAL_CaLamViec();
        }

        public DataTable selectOpenShift(string tenDangNhap)
        {
            return calamViec.SelectOpenShift(tenDangNhap);
        }

        public string PhatSinhMaCaLam()
        {
            string maCaHienTai = calamViec.LayMaCaLonNhat();
            if (string.IsNullOrEmpty(maCaHienTai))
                return "CA0001"; // Trường hợp chưa có dữ liệu

            string so = maCaHienTai.Substring(2);
            int soMoi = int.Parse(so) + 1;
            return "CA" + soMoi.ToString("D4");
        }

        public void InsertCaLamViec()
        {
            string maCaMoi = PhatSinhMaCaLam();
            int result = calamViec.InsertCaLamViec(maCaMoi);
            if (result == 0)
            {
                MessageBox.Show("Không thể thêm ca mới");
            }
        }
    }
}
