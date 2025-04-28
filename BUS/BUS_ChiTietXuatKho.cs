using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BUS
{
    public class BUS_ChiTietXuatKho
    {
        DAL_ChiTietXuatKho chitietxuat;

        public BUS_ChiTietXuatKho(string maphieuxuat, string manl, int soluong)
        {
            chitietxuat = new DAL_ChiTietXuatKho(maphieuxuat, manl, soluong);
        }

        public BUS_ChiTietXuatKho()
        {
            chitietxuat = new DAL_ChiTietXuatKho();
        }

        public void AddExportDetail(string maphieuxuat, string manl, int soluong)
        {
            chitietxuat.AddExportDetail(maphieuxuat, manl, soluong);
        }

        public void UpdateDetailst(string maphieuxuat, string manl, int soluong)
        {
            chitietxuat.UpdateDetailst(maphieuxuat, manl, soluong);
        }
    }
}
