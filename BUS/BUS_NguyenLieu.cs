using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
   public class BUS_NguyenLieu
    {
        DAL_NguyenLieu nguyenlieudal;
        
        public BUS_NguyenLieu(string manl, string maloainl, string tennl, string donvi, int soluong)
        {
            nguyenlieudal = new DAL_NguyenLieu(manl,maloainl,tennl,donvi,soluong);
        }
        public DataTable TaiNguyenlieu()
        {
            return nguyenlieudal.Tainguyenlieu();
        }

        public DataTable TaiLoaiNguyenLieu()
        {
            return nguyenlieudal.TaiLoaiNguyenlieu();
        }

        public void ThemNguyenLieu(string manl, string tenloainl, string tennl, string donvi, int soluong)
        {
            nguyenlieudal.ThemNguyenlieu(manl,tenloainl,tennl,donvi,soluong);
        }

        public void SuathongtinNL(string manl, string maloainl, string tennl, string donvi, int soluong)
        {
            nguyenlieudal.SuathongtinNL(manl,maloainl,tennl,donvi,soluong);
        }
        // phát sinh mã nguyên liệu
        public string PhatSinhMaNL()
        {
            // lấy mã nguyên liệu lớn nhất
            string manl = nguyenlieudal.ManlLonNhat();
            // nếu mã sp lớn nhất là null thì gán mã nguyên liệu đầu tiên là NL001
            if (manl == null)
            {
                return "NL001";
            }
            else
            {
                // lấy số sau SP
                int num = int.Parse(manl.Substring(2)) + 1;
                return "NL" + num.ToString("D3");
            }
        }
    }
}
