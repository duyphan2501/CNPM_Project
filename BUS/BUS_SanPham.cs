﻿using System;
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
        public DataTable LoadProduct()
        {
            return sanphamdal.LoadProduct();
        }

        //Tải tên loại lên combobox
        public DataTable LoadProduct_type()
        {
            return sanphamdal.LoadProduct_type();
        }


        //Thêm sản phẩm mới
        public void AddProduct(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal.AddProduct(masp, maloai, tensp, hinhanh, giaban, trangthai);
        }

        //sửa sản phẩm
        public void UpdateProduct(string masp, string maloai, string tensp, byte[] hinhanh, int giaban, string trangthai)
        {
            sanphamdal.UpdateProduct(masp, maloai, tensp, hinhanh, giaban, trangthai);
        }

        // phát sinh mã sản phẩm
        public string PhatSinhMaSp()
        {
            // lấy mã sp lớn nhất
            string masp = sanphamdal.MaxID();
            // nếu mã sp lớn nhất là null thì gán mã sp đầu tiên là SP001
            if (masp == null)
            {
                return "SP001";
            }
            else
            {
                // lấy số sau SP
                int num = int.Parse(masp.Substring(2)) + 1;
                return "SP" + num.ToString("D3");
            }
        }



        // Lấy sản phẩm còn bán
        public DataTable SelectOnSaleProduct()
        {
            return sanphamdal.SelectOnSaleProduct();
        }

        //Lọc n sản phẩm bán chạy nhất
        public DataTable GetBestSellingProductst(int soluong,DateTime ngaybatdau, DateTime ngayketthuc)
        {
            return sanphamdal.GetBestSellingProductst(soluong, ngaybatdau,ngayketthuc);
        }
    }
}
