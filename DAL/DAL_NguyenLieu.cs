using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NguyenLieu
    {
        DTO_NguyenLieu nguyenlieudto;

        public DAL_NguyenLieu(string manl, string maloainl, string tennl, string donvi, int soluong,int muctoithieu,int mucondinh)
        {
            nguyenlieudto = new DTO_NguyenLieu(manl,maloainl,tennl,donvi,soluong,muctoithieu,mucondinh);
        }

        //Tải nguyên liệu lên datagridview
        public DataTable LoadIngredients()
        {
            string query = "select nl.MaNL as 'Mã nguyên liệu',lnl.TenLoai as 'Tên loại',nl.TenNL as 'Tên nguyên liệu',nl.DonVi as 'Đơn vị tính',nl.SoLuongTon as 'Số lượng tồn',nl.MucToiThieu as 'Mức tối thiểu', nl.MucOnDinh as 'Mức ổn định' from NguyenLieu nl,LoaiNguyenLieu lnl " +
                            "where nl.MaLoaiNL = lnl.MaLoaiNL";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable TaiLoaiNguyenlieu() {
            string query = "select distinct TenLoai from LoaiNguyenLieu";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable LoadIngredients_name()
        {
            string query = "select distinct TenNL from NguyenLieu";
            return DataProvider.ExecuteQuery(query);
        }

        public void AddIngredients(string manl, string tenloainl, string tennl, string donvi, int muctoithieu, int mucondinh)
        {
            string query = "insert into NguyenLieu values (@MaNL,dbo.LayMaloaiNLTheoTenloaiNL(@MaLoaiNL),@TenNL,@DonVi,0,@MucToiThieu,@MucOnDinh)";
            object[] parem = new object[] { manl, tenloainl, tennl, donvi,muctoithieu,mucondinh};
            DataProvider.ExecuteNonQuery(query, parem);
        }

        //Sửa thông tin nguyên liệu
        public void UpdateIngredients(string manl, string maloainl, string tennl, string donvi, int muctoithieu, int mucondinh)
        {
            string query = "update NguyenLieu set maloainl = dbo.LayMaloaiNLTheoTenloaiNL(@MaLoaiNL), tennl = @TenNL, donvi = @DonVi, muctoithieu = @MucToiThieu, mucondinh = @MucOnDinh where manl = @_MaNL";
            object[] parem = new object[] { maloainl, tennl, donvi,muctoithieu, mucondinh ,manl };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        // lấy mã sp lớn nhất
        public string ManlLonNhat()
        {
            string query = "select top 1 MaNL from NguyenLieu order by MaNL desc";
            string maxMaNL = (string)DataProvider.ExecuteScalar(query);
            return maxMaNL;
        }

    }
}
