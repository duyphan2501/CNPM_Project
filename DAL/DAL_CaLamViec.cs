using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CaLamViec
    {
        DTO_CaLamViec calamViec;

        public DAL_CaLamViec(string maCaLam, DateTime tgBatDau, DateTime tgKetThuc, string ghiChu, int tienDauCa, int tienCuoiCa)
        {
            calamViec = new DTO_CaLamViec(maCaLam, tgBatDau, tgKetThuc, ghiChu, tienDauCa, tienCuoiCa);
        }

        public DAL_CaLamViec()
        {
            calamViec = new DTO_CaLamViec();
        }
    }
}
