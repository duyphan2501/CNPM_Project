using System;
using System.Collections.Generic;
using System.Data;
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

        public void AddIngredients_type(string maloainl, string tenloai)
        {
            loainguyenlieudal.AddIngredients_type(maloainl, tenloai);
        }

        public DataTable LoadIngredients_type()
        {
            return loainguyenlieudal.LoadIngredients_type();
        }
        public string GenerateID()
        {
            string maxMaloai = loainguyenlieudal.MaxID();
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
