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
        public void TaiTenloai(Guna2ComboBox cbo)
        {
            sanphamdal.TaiTenLoai(cbo);
        }

        //Thêm sản phẩm mới
        public void ThemSp(string masp, string tenloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal.ThemSp(masp, tenloai, tensp, hinhanh, giaban, trangthai);
        }

        public void SuaSp(string masp, string tenloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal.SuaSp(masp, tenloai, tensp, hinhanh, giaban, trangthai);
        }

    }
}
