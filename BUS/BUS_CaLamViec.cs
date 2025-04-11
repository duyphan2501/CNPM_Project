using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_CaLamViec
    {
        DAL_CaLamViec calamViec;

        public BUS_CaLamViec(string maCalam, DateTime tgBatDau, DateTime tgKetThuc, string ghiChu, int tienDauCa, int tienCuoiCa)
        {
            calamViec = new DAL_CaLamViec(maCalam, tgBatDau, tgKetThuc, ghiChu, tienDauCa, tienCuoiCa);
        }

        public BUS_CaLamViec()
        {
            calamViec = new DAL_CaLamViec();
        }
    }
}
