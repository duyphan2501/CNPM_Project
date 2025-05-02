using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_LoaiThuChi
    {
        DAL_LoaiThuChi loaithuchidal;

        public BUS_LoaiThuChi(string maloaithuchi, string tenloai, string loai)
        {
            loaithuchidal = new DAL_LoaiThuChi(maloaithuchi,tenloai,loai);
        }

        public BUS_LoaiThuChi()
        {
            loaithuchidal = new DAL_LoaiThuChi();
        }

        public void AddType(string maloaithuchi, string tenloai, string loai)
        {
            loaithuchidal.AddType(maloaithuchi, tenloai, loai);
        }

        public DataTable LoadType(string loaiphieu)
        {
            return loaithuchidal.LoadType(loaiphieu);
        }

        //Phát sinh mã loại thu chi
        public string GenerateID()
        {
            string maxMaloai = loaithuchidal.MaxID();
            if (maxMaloai != null)
            {
                int ma = int.Parse(maxMaloai.Substring(2)) + 1;
                string maloai = "TC" + ma.ToString("D2");
                return maloai;
            }
            else
            {
                return "TC01";
            }
        }
    }
}
