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

        public void ThemLoai(string maloaithuchi, string tenloai, string loai)
        {
            loaithuchidal.ThemLoai(maloaithuchi, tenloai, loai);
        }

        public DataTable TaiLoaiPhieu()
        {
            return loaithuchidal.TaiLoaiPhieu();
        }

        //Phát sinh mã loại thu chi
        public string PhatSinhMaLoai()
        {
            string maxMaloai = loaithuchidal.MaloaiLonNhat();
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
