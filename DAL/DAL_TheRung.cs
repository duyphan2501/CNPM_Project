using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TheRung
    {
        DTO_TheRung theRung;
        public DAL_TheRung(string mathe, string sothe, int trangthai) 
        { 
            theRung = new DTO_TheRung(mathe, sothe, trangthai); 
        }

        public DAL_TheRung()
        {
            theRung = new DTO_TheRung();
        }

        public DataTable SelectAllTheRung()
        {
            string query = "select * from TheRung where trangthai < 4";
            return DataProvider.ExecuteQuery(query);
        }

        public int InsertTheRung()
        {
            string query = "insert into TheRung values(@mathe, @sothe, @trangthai)";
            object[] parameters = new object[] { theRung.MaThe, theRung.SoThe, theRung.TrangThai };
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public string LayMaTheLonNhat()
        {
            string query = "select top 1 MaThe from TheRung order by mathe desc";
            return DataProvider.ExecuteScalar(query).ToString();
        }

        public int UpdateTheRung()
        {
            string query = "update therung set sothe = @sothe, trangthai = @trangthai where mathe = @mathe";
            object[] parameters = new object[] { theRung.SoThe, theRung.TrangThai, theRung.MaThe };
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public int DeleteTheRung(string mathe)
        {
            string query = "delete from therung where mathe = "+mathe;
            return DataProvider.ExecuteNonQuery(query);
        }
    }
}
