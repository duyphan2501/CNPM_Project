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
        
        public BUS_NguyenLieu(string manl, string maloainl, string tennl, string donvi, int soluong, int muctoithieu, int mucondinh)
        {
            nguyenlieudal = new DAL_NguyenLieu(manl,maloainl,tennl,donvi,soluong, muctoithieu, mucondinh);
        }
        public DataTable LoadIngredients()
        {
            return nguyenlieudal.LoadIngredients();
        }

        public DataTable TaiLoaiNguyenLieu()
        {
            return nguyenlieudal.TaiLoaiNguyenlieu();
        }

        //Tải tên nguyên liệu
        public DataTable LoadIngredients_name()
        {
            return nguyenlieudal.LoadIngredients_name();
        }

        public void AddIngredients(string manl, string tenloainl, string tennl, string donvi, int muctoithieu, int mucondinh)
        {
            nguyenlieudal.AddIngredients(manl, tenloainl, tennl, donvi,muctoithieu,mucondinh);
        }

        public void UpdateIngredients(string manl, string maloainl, string tennl, string donvi, int muctoithieu, int mucondinh)
        {
            nguyenlieudal.UpdateIngredients(manl,maloainl,tennl,donvi, muctoithieu, mucondinh);
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
