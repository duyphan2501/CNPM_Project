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
        public void ThemDinhluong(string masp, string manl, int soluong)
        {
            dinhluongbus.ThemDinhluong(masp,manl, soluong);
        }

        //Tải danh sách định lượng
        public DataTable TaiDsDinhluong(string tensp)
        {
            return dinhluongbus.TaiDsDinhluong(tensp);
        }

        //Tải tên sản phẩm lên combobox
        public DataTable TaiTenSp()
        {
            return dinhluongbus.TaiTenSp();
        }
    }
}
