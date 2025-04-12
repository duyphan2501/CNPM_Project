using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_LoaiSanPham
    {
        DAL_LoaiSanPham loaiSanPham;
        public BUS_LoaiSanPham()
        {
            loaiSanPham = new DAL_LoaiSanPham();
        }
        public BUS_LoaiSanPham(string maloai, string tenloai)
        {
            loaiSanPham = new DAL_LoaiSanPham(maloai, tenloai);
        }
        public void ThemLoaiSp(string maloai, string tenloai)
        {
            loaiSanPham.ThemLoaiSp(maloai, tenloai);
        }

        public string PhatSinhMaLoai()
        {
            string maxMaloai = loaiSanPham.MaloaiSPLonNhat();
            if (maxMaloai != null)
            {
                int ma = int.Parse(maxMaloai.Substring(2)) + 1;
                string maloai = "ML" + ma.ToString("D3");
                return maloai;
            }
            else
            {
                return "ML001";
            }
        }

        public DataTable SelectAllCategoryProduct()
        {
            // Tải dữ liệu loại sản phẩm từ DAL
           return loaiSanPham.SelectAllCategory();
        }

    }
}
