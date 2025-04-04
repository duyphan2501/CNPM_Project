using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan taikhoandal;

        public BUS_TaiKhoan(string tendangnhap, string matkhau, string trangthai, string vaitro, string hoten, string email)
        {
            taikhoandal = new DAL_TaiKhoan(tendangnhap, matkhau, trangthai, vaitro, hoten, email);
        }

        public DataTable TaiTK()
        {
            return taikhoandal.TaiTK();
        }

        public DataTable TaiTK1()
        {
            return taikhoandal.TaiTK1();
        }

        public void ThemTaiKhoan(string tendangnhap, string matkhau, string trangthai, string vaitro, string hoten, string email) 
        {
            taikhoandal.ThemTK(tendangnhap, matkhau, trangthai, vaitro, hoten, email); 
        }

        public void SuaTaiKhoan(string tendangnhap, string trangthai, string vaitro, string hoten, string email)
        {
            taikhoandal.SuaTK(tendangnhap, trangthai, vaitro, hoten, email);
        }

    }
}
