using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_TonKho
    {
        DTO_TonKho tonkhodto;

        public DAL_TonKho(string maton, string manl, int soluongton, int muctoithieu, int mucondinh)
        {
            tonkhodto = new DTO_TonKho(maton,manl,soluongton,muctoithieu,mucondinh);
        }

        //Thêm thông tin tồn kho
        public void AddInventory(string maton, string manl, int muctoithieu, int mucondinh)
        {
            string query = "insert into TonKho (MaTon,MaNL,MucToiThieu,MucOnDinh) values (@MaTon,@MaNL,@MucToiThieu,@MucOnDinh)";
            object[] parem = new object[] {maton,manl,muctoithieu,mucondinh };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        public void UpdateInventory(string manl, int muctoithieu, int mucondinh)
        {
            string query = "update TonKho set muctoithieu = @MucToiThieu, mucondinh = @MucOnDinh where manl = @MaNL";
            object[] parem = new object[] {muctoithieu, mucondinh, manl };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        public DataTable LoadWarehouse()
        {
            string query = " select nl.TenNL as 'Nguyên liệu', tk.SoLuongTon as 'Số lượng tồn',tk.MucToiThieu as 'Mức tối thiểu',tk.MucOnDinh as 'Mức ổn định' from  NguyenLieu nl, TonKho tk where tk.MaNL = nl.MaNL";
            return DataProvider.ExecuteQuery(query);
        }

        // lấy mã tồn kho lớn nhất
        public string MatonLonNhat()
        {
            string query = "select top 1 MaTon from TonKho order by MaTon desc";
            string maxMaton = (string)DataProvider.ExecuteScalar(query);
            return maxMaton;
        }
    }
}
