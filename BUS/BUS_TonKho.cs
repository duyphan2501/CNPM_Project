using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_TonKho
    {
        DAL_TonKho tonkhodal;

        public BUS_TonKho(string maton, string manl, int soluongton, int muctoithieu, int mucondinh)
        {
            tonkhodal = new DAL_TonKho(maton, manl, soluongton, muctoithieu, mucondinh);
        }

        public void AddInventory(string maton, string manl, int muctoithieu, int mucondinh)
        {
            tonkhodal.AddInventory(maton,manl,muctoithieu,mucondinh);
        }

        // phát sinh mã tồn kho
        public string PhatSinhMaTon()
        {
            // lấy mã tồn kho lớn nhất
            string maton = tonkhodal.MatonLonNhat();
            // nếu mã tồn lớn nhất là null thì gán mã tồn đầu tiên là MT001
            if (maton == null)
            {
                return "MT001";
            }
            else
            {
                // lấy số sau MT
                int num = int.Parse(maton.Substring(2)) + 1;
                return "MT" + num.ToString("D3");
            }
        }
    }
}
