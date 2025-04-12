using System;

namespace DTO
{
    public class DTO_CaLamViec
    {
        public string GhiChu { get; set; }
        public int TienDauCa { get; set; }
        public int TienCuoiCa { get; set; }
        public DateTime TgBatDau { get; set; }
        public DateTime? TgKetThuc { get; set; }
        public string TenDangNhap { get; set; }

        public DTO_CaLamViec(DateTime tgBatDau, DateTime? tgKetThuc, string ghiChu, int tienDauCa, int tienCuoiCa, string tenDangNhap)
        {
            GhiChu = ghiChu;
            TienDauCa = tienDauCa;
            TienCuoiCa = tienCuoiCa;
            TgBatDau = tgBatDau;
            TgKetThuc = tgKetThuc;
            TenDangNhap = tenDangNhap;
        }

        public DTO_CaLamViec() { }
    }
}
