﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_PhieuNhapKho
    {
        DAL_PhieuNhapKho phieunhapkhodal;

        public BUS_PhieuNhapKho(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            phieunhapkhodal = new DAL_PhieuNhapKho(maPhieuNhap, tenDangNhap, ngayNhap, ghiChu);
        }
        public BUS_PhieuNhapKho()
        {
            phieunhapkhodal = new DAL_PhieuNhapKho();
        }

        //Tải phiếu nhập
        public DataTable LoadGoodsReceipt()
        {
            return phieunhapkhodal.LoadGoodsReceipt();
        }

      
        public DataTable LoadIngredients_name()
        {
            return phieunhapkhodal.LoadIngredients_name();
        }

        public DataTable TaiMaPhieuNhap()
        {
            return phieunhapkhodal.TaiMaPhieuNhap();
        }

        public int Restocking(string tennl, int trangthai)
        {
            return phieunhapkhodal.Restocking(tennl, trangthai);
        }

        public int AddGoodsReceipt(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            return phieunhapkhodal.AddGoodsReceipt(maPhieuNhap, tenDangNhap, ngayNhap, ghiChu);
        }

        public void SuaPhieuNhap(string maPhieuNhap, string tenDangNhap, DateTime ngayNhap, string ghiChu)
        {
            phieunhapkhodal.SuaPhieuNhap(maPhieuNhap, tenDangNhap, ngayNhap, ghiChu);
        }

        public string TaiDonvi(string tennl)
        {
            return phieunhapkhodal.TaiDonvi(tennl);
        }


        // phát sinh mã phiếp nhập
        public string GenerateID()
        {
            // lấy mã phiếu nhập lớn nhất
            string maphieu = phieunhapkhodal.MaxID();
            // nếu mã phiếu lớn nhất là null thì gán mã phiếu đầu tiên là PN0001
            if (maphieu == null)
            {
                return "PN0001";
            }
            else
            {
                // lấy số sau PN
                int num = int.Parse(maphieu.Substring(2)) + 1;
                return "PN" + num.ToString("D4");
            }
        }
    }
}
