using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietDonHang
    {
        public string MaDonHang { get; set; }  
        public string MaSp { get; set; }      
        public int DonGia { get; set; }      
        public int SoLuong { get; set; }       

        // Constructor
        public DTO_ChiTietDonHang(string maDonHang, string maSp, int donGia, int soLuong)
        {
            MaDonHang = maDonHang;
            MaSp = maSp;
            DonGia = donGia;
            SoLuong = soLuong;
        }
    }

}
