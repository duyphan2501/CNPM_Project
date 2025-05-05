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
        public void AddProduct_type(string maloai, string tenloai)
        {
            loaiSanPham.AddProduct_type(maloai, tenloai);
        }

        public DataTable LoadProduct_type()
        {
            return loaiSanPham.LoadProduct_type();
        }
        public string GenerateID()
        {
            string maxMaloai = loaiSanPham.MaxID();
            if (maxMaloai != null)
            {
                int ma = int.Parse(maxMaloai.Substring(1)) + 1;
                string maloai = "L" + ma.ToString("D3");
                return maloai;
            }
            else
            {
                return "L001";
            }
        }

        public DataTable SelectAllCategoryProduct()
        {
            // Tải dữ liệu loại sản phẩm từ DAL
           return loaiSanPham.SelectAllCategory();
        }

    }
}
