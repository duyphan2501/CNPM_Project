using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_TheRung
    {
        DAL_TheRung therung;
        public BUS_TheRung(string mathe, string sothe, int trangthai) 
        { 
            therung = new DAL_TheRung(mathe, sothe, trangthai); 
        }  

        public BUS_TheRung()
        {
            therung = new DAL_TheRung();
        }
        
        public DataTable SelectALlTheRung()
        {
            return therung.SelectAllTheRung();
        }

        public int InsertTheRung()
        {
            return therung.InsertTheRung(); 
        }

        public string PhatSinhMaThe()
        {
            string maTheHienTai = therung.LayMaTheLonNhat();
            if (maTheHienTai == null)
                return "T001";
            // Lấy phần số sau chữ T
            int so = int.Parse(maTheHienTai.Substring(1));
            // Tăng lên 1
            so++;
            // Trả về mã mới với định dạng T + 2 chữ số
            return "T" + so.ToString("D3");
        }

        public int UpdateTheRung()
        {
            return therung.UpdateTheRung();
        }

        public int DeleteTheRung(string mathe)
        {
            return therung.DeleteTheRung(mathe);
        }
    }
}
