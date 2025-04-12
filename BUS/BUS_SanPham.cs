using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_SanPham
    {
        DAL_SanPham sanphamdal;
        public BUS_SanPham(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal = new DAL_SanPham(masp, maloai, tensp, hinhanh, giaban, trangthai);
        }
        public BUS_SanPham() { sanphamdal = new DAL_SanPham(); }
       
        //Tải sản phẩm lên datagridview
        public DataTable TaiSp()
        {
            return sanphamdal.TaiSp();
        }

        //Tải tên loại lên combobox
        public DataTable TaiLoaiSP()
        {
            return sanphamdal.TaiLoaiSP();
        }
        

        //Thêm sản phẩm mới
        public void ThemSp(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal.ThemSp(masp, maloai, tensp, hinhanh, giaban, trangthai);
        }

        // phát sinh mã sản phẩm
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

        public void SuaSp(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal.SuaSp(masp, maloai, tensp, hinhanh, giaban, trangthai);
        }

        // Lấy sản phẩm còn bán
        public DataTable SelectOnSaleProduct()
        {
            return sanphamdal.SelectOnSaleProduct();
        }

    }
}
