using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_LoaiNguyenLieu
    {
        DAL_LoaiNguyenLieu loainguyenlieudal;

        public BUS_LoaiNguyenLieu(string maloainl, string tenloai)
        {
            loainguyenlieudal = new DAL_LoaiNguyenLieu(maloainl,tenloai);
        }

        public void ThemLoaiNguyenLieu(string maloainl, string tenloai)
        {
            loainguyenlieudal.ThemLoaiNguyenLieu(maloainl, tenloai);
        }

        public string PhatSinhMaLoaiNL()
        {
            string maxMaloai = loainguyenlieudal.MaloaiNLLonNhat();
            if (maxMaloai != null)
            {
                int ma = int.Parse(maxMaloai.Substring(2)) + 1;
                string maloai = "ML" + ma.ToString("D3");
                return maloai;
            }
            else
            {
                return "ML001";
            }
        }
    }
}
