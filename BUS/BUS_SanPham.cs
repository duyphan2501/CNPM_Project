using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Guna.UI2.WinForms;

namespace BUS
{
    public class BUS_SanPham
    {
        DAL_SanPham sanphamdal;
        public BUS_SanPham(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal = new DAL_SanPham(masp, maloai, tensp, hinhanh, giaban, trangthai);
        }

       
        //Tải sản phẩm lên datagridview
        public DataTable TaiSp()
        {
            return sanphamdal.TaiSp();
        }

        //Tải tên loại lên combobox
        public DataTable TaiTenloai()
        {
            return sanphamdal.TaiTenLoai();
        }
        

        //Thêm sản phẩm mới
        public void ThemSp(string masp, string tenloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal.ThemSp(masp, tenloai, tensp, hinhanh, giaban, trangthai);
        }

        // phát sinh mã sp
        public string PhatSinhMaSp()
        {
            // lấy mã sp lớn nhất
            string masp = sanphamdal.MaspLonNhat();
            // nếu mã sp lớn nhất là null thì gán mã sp đầu tiên là SP0001
            if (masp == null)
            {
                return "SP0001";
            }
            else
            {
                // lấy số sau SP
                int num = int.Parse(masp.Substring(2)) + 1;
                return "SP" + num.ToString("D4");
            }
        }

        public void SuaSp(string masp, string tenloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal.SuaSp(masp, tenloai, tensp, hinhanh, giaban, trangthai);
        }

    }
}
