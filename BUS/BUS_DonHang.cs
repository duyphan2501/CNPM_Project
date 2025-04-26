using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using DTO;
namespace BUS
{
    public class BUS_DonHang
    {
        DAL_DonHang donhang;

        // Lập đơn hàng
        public BUS_DonHang(string maDonHang, string maCaLap,
                           int trangThai, string maThe, int giamGia, int tongTien, string ghiChu)
        {
            donhang = new DAL_DonHang(maDonHang, maCaLap, trangThai, maThe, giamGia, tongTien, ghiChu);
        }

        // Thanh toán đơn hàng
        public BUS_DonHang(string maDonHang, string maCaThanhToan, int giamGia, int tongTien,
                           int loaiThanhToan)
        {
            donhang = new DAL_DonHang(maDonHang, maCaThanhToan, giamGia, tongTien, loaiThanhToan);
        }

        public BUS_DonHang() { donhang = new DAL_DonHang(); }

        public string PhatSinhMaDonHang()
        {
            string maDonHienTai = donhang.LayMaDonHangLonNhat();
            // Lấy phần số sau chữ DH
            if (maDonHienTai == "")
            {
                return "DH00001";
            }
            int so = int.Parse(maDonHienTai.Substring(2));
            // Tăng lên 1
            so++;
            // Trả về mã mới với định dạng DH + 5 chữ số
            return "DH" + so.ToString("D5");
        }

        public int InsertNewOrder()
        {
            return donhang.InsertNewOrder();
        }

        public int ThanhToanDonHang()
        {
            return donhang.ThanhToanDonHang();
        }

        public bool isExistedOrder(string maDonHang)
        {
            return donhang.isExistedOrder(maDonHang);
        }

        public DataTable SelectOrderForCashier(string maCaLam)
        {
            return donhang.SelectOrderForCashier(maCaLam);
        }

        public int TinhTongTien(string maDonHang)
        {
            return donhang.TinhTongTien(maDonHang);
        }

        public string LayGhiChu(string maDonHang)
        {
            return donhang.LayGhiChu(maDonHang);
        }   

        public DataTable SelectDonHang(string maDonHang)
        {
            return donhang.SelectDonHang(maDonHang);
        }

        public int UpdateDonHang(string maDonHang, int giamGia, int tongTien, string ghiChu)
        {
            return donhang.UpdateDonHang(maDonHang, giamGia, tongTien, ghiChu);
        }

        public int UpdateStateDonHang(string maDonHang, int trangThai)
        {
            return donhang.UpdateStateDonHang(maDonHang, trangThai);
        }

        public int LayLoaiThanhToan(string maDonHang)
        {
            return donhang.LayLoaiThanhToan(maDonHang);
        }

        public DataTable SelectDonHangOnPage(int page, int pageSize)
        {
            return donhang.SelectDonHangOnPage(page, pageSize);
        }

        public int GetToTalNumberDonHang()
        {
            return donhang.GetToTalNumberDonHang();
        }

        public DataTable SelectHoaDon(string maDonHang)
        {
            return donhang.SelectHoaDon(maDonHang);
        }
    } 
}
