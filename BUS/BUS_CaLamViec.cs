using DAL;
using DTO;
using Microsoft.Identity.Client;
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

        public DataTable SelectOpenShift(string tenDangNhap)
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

        public string GetUserNameOfShift(string maCa)
        {
            return calamViec.GetUserNameOfShift(maCa);
        }

        public int ChotCaLamViec(string maCaLam, int tienCuoiCa, string ghiChu)
        {
            return calamViec.ChotCaLamViec(maCaLam, tienCuoiCa, ghiChu);
        }

        public DataTable SelectAllShift()
        {
            return calamViec.SelectAllShift();
        }

        public int GetToTalShifts()
        {
            return calamViec.GetToTalShifts();
        }

        public DataTable SelectCaLamOnPage(int page, int pageSize)
        {
            return calamViec.SelectCaLamOnPage(page, pageSize);
        }

        public int GetTienDauCa(string maCa)
        {
            return calamViec.GetTienDauCa(maCa);
        }

        public DataTable GetInformationShift(string maCa)
        {
            return calamViec.GetInformationShift(maCa);
        }
    }
}
