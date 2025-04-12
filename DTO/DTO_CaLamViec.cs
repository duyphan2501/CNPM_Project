using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CaLamViec
    {
        private string MaCaLam, GhiChu;
        private int TienDauCa, TienCuoiCa;
        private DateTime TgBatDau, TgKetThuc;

        public string _MaCaLam { get; set; }
        public string _GhiChu { get; set; }
        public int _TienDauCa { get; set; }
        public int _TienCuoiCa { get; set; }
        public DateTime _TgBatDau { get; set; }
        public DateTime _TGKetThuc { get; set; }

        public DTO_CaLamViec(string maCaLam, DateTime tgBatDau, DateTime tgKetThuc, string ghiChu, int tienDauCa, int tienCuoiCa)
        {
            this.MaCaLam = maCaLam;
            this.GhiChu = ghiChu;
            this.TienDauCa = tienDauCa;
            this.TienCuoiCa = tienCuoiCa;
            this.TgBatDau = tgBatDau;
            this.TgKetThuc = tgKetThuc;
        }

        public DTO_CaLamViec() { }
    }
}
