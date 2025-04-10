using GUI;

namespace cnpm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // tải biến môi trường từ file .env
            //Env.Load();
            //Application.Run(new frmConfig());
            //Application.Run(new frmLogin());
            //Application.Run(new frmTaiKhoan());
            //Application.Run(new frmAdmin());
            //Application.Run(new frmThemLoaiSanPham());
            //Application.Run(new frmThucdon());
            ////Application.Run(new frmXuatNhapKho());
            //Application.Run(new frmBanHang());
            //Application.Run(new frmDinhLuong());
            //Application.Run(new frmKho());
            Application.Run(new frmXuatNhapKho());
        }
    }
}