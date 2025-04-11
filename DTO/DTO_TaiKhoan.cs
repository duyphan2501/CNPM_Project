public class DTO_TaiKhoan
{
    public string TenDangNhap { get; set; }
    public string MatKhau { get; set; }
    public string TrangThai { get; set; }
    public string VaiTro { get; set; }
    public string HoTen { get; set; }
    public string Email { get; set; }

    public DTO_TaiKhoan(string tendangnhap, string matkhau, string trangthai, string vaitro, string hoten, string email)
    {
        TenDangNhap = tendangnhap;
        MatKhau = matkhau;
        TrangThai = trangthai;
        VaiTro = vaitro;
        HoTen = hoten;
        Email = email;
    }

    public DTO_TaiKhoan(string tendangnhap, string matkhau)
    {
        TenDangNhap = tendangnhap;
        MatKhau = matkhau;
    }

    public DTO_TaiKhoan() { }
}
