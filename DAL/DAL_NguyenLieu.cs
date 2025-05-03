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

        public DAL_NguyenLieu()
        {
            nguyenlieudto = new DTO_NguyenLieu();
        }

        //Tải nguyên liệu lên datagridview
        public DataTable LoadIngredients()
        {
            string query = "select nl.MaNL as 'Mã nguyên liệu',lnl.TenLoai as 'Tên loại',nl.TenNL as 'Tên nguyên liệu',nl.DonVi as 'Đơn vị tính',nl.SoLuongTon as 'Số lượng tồn', nl.GiaNhap as 'Giá nhập', nl.MucToiThieu as 'Mức tối thiểu', nl.MucOnDinh as 'Mức ổn định' from NguyenLieu nl,LoaiNguyenLieu lnl " +
                            "where nl.MaLoaiNL = lnl.MaLoaiNL";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable LoadIngredients_type()
        {
            string query = "select distinct TenLoai from LoaiNguyenLieu";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable LoadIngredients_name()
        {
            string query = "select MaNL, TenNL from NguyenLieu";
            return DataProvider.ExecuteQuery(query);
        }

        public void AddIngredients(string manl, string tenloainl, string tennl, string donvi, int muctoithieu, int mucondinh)
        {
            string query = "insert into NguyenLieu (MaNL, MaLoaiNL, TenNL, DonVi, MucToiThieu, MucOnDinh) values (@MaNL,dbo.LayMaloaiNLTheoTenloaiNL(@MaLoaiNL),@TenNL,@DonVi,@MucToiThieu,@MucOnDinh)";
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

        public int GetQuantityOfIngredient(string maNL)
        {
            string query = "select SoLuongTon from NguyenLieu where MaNL = @_MaNL";
            object[] parameters = new object[] { maNL };
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["SoLuongTon"]);
            }
            return int.MaxValue;
        }

        public int UpdateQuantityOfIngredient(string maNL, int quantity)
        {
            string query = "update NguyenLieu set SoLuongTon = @_SoLuongTon where MaNL = @_MaNL";
            object[] parameters = new object[] { quantity, maNL };
            return DataProvider.ExecuteNonQuery(query, parameters);
        }
        public int GetGiaNhap(string maNL)
        {
            string query = "SELECT GiaNhap FROM ChiTietNhapKho WHERE MaNL = @MaNL";
            object result = DataProvider.ExecuteScalar(query, new object[] { maNL });

            // Nếu không tìm thấy giá nhập, trả về 0 hoặc giá trị mặc định
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public string LayDonvi(string maNL)
        {
            string query = "select donvi from nguyenlieu where manl = @maNl";
            object result = DataProvider.ExecuteScalar(query, new object[] { maNL });
            return result != null ? result.ToString() : "";
        }

        public DataTable SelectNguyenLieu()
        {
            string query = "Select * from NguyenLieu";
            return DataProvider.ExecuteQuery(query);
        }

    }
}
