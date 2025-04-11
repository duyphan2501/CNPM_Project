using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        DTO_TaiKhoan taikhoandto;
        public DAL_TaiKhoan(string tendangnhap, string matkhau, string trangthai, string vaitro, string hoten, string email)
        {
            taikhoandto = new DTO_TaiKhoan(tendangnhap, matkhau, trangthai, vaitro, hoten, email);
        }

        public DAL_TaiKhoan(string tendangnhap, string matkhau)
        {
            taikhoandto = new DTO_TaiKhoan(tendangnhap, matkhau);
        }

        //Tải danh sách tài khoản có hiệu lực 
        public DataTable TaiTK()
        {
            string query = "select HoTen as 'Họ tên', TenDangNhap as 'Tên đăng nhập', TrangThai as 'Trạng thái', VaiTro as 'Vai trò',  Email from TaiKhoan where TrangThai = '1'";
            return DataProvider.ExecuteQuery(query);
        }

        //Tải danh sách tài khoản vô hiệu hóa
        public DataTable TaiTK1()
        {
            string query = "select HoTen as 'Họ tên', TenDangNhap as 'Tên đăng nhập', TrangThai as 'Trạng thái', VaiTro as 'Vai trò',  Email from TaiKhoan where TrangThai = '0'";
            return DataProvider.ExecuteQuery(query);
        }


        //Thêm tài khoản
        public void ThemTK(string tendangnhap, string matkhau, string trangthai, string vaitro, string hoten, string email)
        {
            string query = "INSERT INTO TaiKhoan VALUES (@_TenDangNhap, @_MatKhau, @_TrangThai, @_VaiTro, @_HoTen, @_Email)";
            object[] parem = new object[] { tendangnhap, matkhau, trangthai, vaitro, hoten, email };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        public void SuaTK(string tendangnhap, string trangthai, string vaitro, string hoten, string email)
        {
            string query = "UPDATE TaiKhoan SET trangthai = @_TrangThai, vaitro = @_VaiTro, hoten = @_HoTen, email = @_Email WHERE tendangnhap = @_TenDangNhap";
            object[] parem = new object[] {trangthai, vaitro, hoten, email, tendangnhap };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        // Lấy tài khoản để kiểm tra 
        public DataTable SelectOneAccount()
        {
            string tenDangNhap = taikhoandto.TenDangNhap;
            string query = "select * from TaiKhoan where TenDangNhap = @TenDangNhap and TrangThai != 0";
            return DataProvider.ExecuteQuery(query, new object[] { tenDangNhap });
        }


    }
}
