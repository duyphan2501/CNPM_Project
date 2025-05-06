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

        public BUS_TaiKhoan(string tendangnhap, string matkhau) {
            taikhoandal = new DAL_TaiKhoan(tendangnhap, matkhau);
        }

        public BUS_TaiKhoan(string tendangnhap)
        {
            taikhoandal = new DAL_TaiKhoan(tendangnhap);
        }
        public BUS_TaiKhoan()
        {
            taikhoandal = new DAL_TaiKhoan();
        }

        //Tải tài khoản có hiệu lực
        public DataTable LoadAccount()
        {
            return taikhoandal.LoadAccount();
        }

        public DataTable LoadActiveAccount()
        {
            return taikhoandal.LoadActiveAccount();
        }

        //Tải tài khoản vô hiệu hóa
        public DataTable LoadDisabledAccounts()
        {
            return taikhoandal.LoadDisabledAccounts();
        }

        //Thêm tài khaonr
        public void AddAccount(string tendangnhap, string matkhau, string trangthai, string vaitro, string hoten, string email) 
        {
            matkhau = General.HashPassword(matkhau);
            taikhoandal.AddAccount(tendangnhap, matkhau, trangthai, vaitro, hoten, email); 
        }

        //Sửa tài khoản
        public void UpdateAccount(string tendangnhap, string trangthai, string vaitro, string hoten, string email)
        {
            taikhoandal.UpdateAccount(tendangnhap, trangthai, vaitro, hoten, email);
        }

        public DataTable SelectOneAccount()
        {
            return taikhoandal.SelectOneAccount();
        }

        public DataTable ValidateLoginAccount(string password)
        {
            // lấy tài khoản
            DataTable account = SelectOneAccount();
            // kiểm tra tài khoản có tồn tại
            if (account != null && account.Rows.Count > 0)
            {
                // password từ db
                string hashedPasswordFromDb = account.Rows[0]["MatKhau"].ToString();
                // Hash mật khẩu người dùng nhập vào
                string hashedInputPassword = General.HashPassword(password);
                // So sánh
                if (hashedPasswordFromDb == hashedInputPassword)
                {
                    return account;
                }
            }
            return null; // Sai username hoặc password
        }

        public void UpdatePassword(string username, string password)
        {
            string hashPassword = General.HashPassword(password);
            taikhoandal = new DAL_TaiKhoan(username, hashPassword);
            taikhoandal.UpdatePassword();
        }

        public string GetUserNameByShiftID(string shiftID)
        {
            return taikhoandal.GetUserNameByShiftID(shiftID);
        }
    }
}
