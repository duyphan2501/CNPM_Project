﻿using GUI;
using System.Data;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static DataTable account;
        public static DataTable shift;

        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ////Application.Run(new frmConfig());
            //Application.Run(new frmTaiKhoan());
            Application.Run(new frmLogin());
            //Application.Run(new frmBaoCaoChotCa());
            //Application.Run(new frmLoiNhuan());
            //Application.Run(new frmHangBanChay());
            //Application.Run(new frmAdmin());
            //Application.Run(new frmThemLoaiSanPham());
            //Application.Run(new frmThucdon());
            //Application.Run(new frmAdmin());
            //Application.Run(new frmXuatNhapKho());
            //Application.Run(new frmDinhLuong());
            //Application.Run(new frmKho());
            //Application.Run(new frmXuatNhapKho());
            //Application.Run(new frmTheRung());
            //Application.Run(new frmTonKho());
        }
    }
}