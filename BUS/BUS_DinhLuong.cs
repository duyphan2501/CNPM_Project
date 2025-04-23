using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_DinhLuong
    {
        DAL_DinhLuong dinhluongbus;
        public BUS_DinhLuong(string masp, string manl, int soluong)
        {
            dinhluongbus = new DAL_DinhLuong(masp, manl, soluong);
        }

        //Thêm định lượng
        public void AddRecipe(string masp, string manl, int soluong)
        {
            dinhluongbus.AddRecipe(masp, manl, soluong);
        }

        public void UpdateRecipe(string masp, string manl, int soluong)
        {
            dinhluongbus.UpdateRecipe(masp, manl, soluong);
        }

        //Tải danh sách định lượng
        public DataTable LoadRecipe(string tensp)
        {
            return dinhluongbus.LoadRecipe(tensp);
        }

        //Tải tên nguyên liêu lên combobox
        public DataTable LoadRecipe_name()
        {
            return dinhluongbus.LoadRecipe_name();
        }

        public void DeleteRecipe(string masp, string manl)
        {
            dinhluongbus.DeleteRecipe(masp , manl);
        }
    }
}
