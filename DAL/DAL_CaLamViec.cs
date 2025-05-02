using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CaLamViec
    {
        DTO_CaLamViec caLamViec;

        public DAL_CaLamViec(DateTime tgBatDau, DateTime? tgKetThuc, string ghiChu, int tienDauCa, int tienCuoiCa, string tenDangNhap)
        {
            caLamViec = new DTO_CaLamViec(tgBatDau, tgKetThuc, ghiChu, tienDauCa, tienCuoiCa, tenDangNhap);
        }

        public DAL_CaLamViec()
        {
            caLamViec = new DTO_CaLamViec();
        }

        public DataTable SelectOpenShift(string tenDangNhap)
        {
            string query = "select * from CaLamViec where tgKetThuc is null and TenDangNhap = @TenDangNhap";
            return DataProvider.ExecuteQuery(query, new object[] { tenDangNhap });
        }

        public string LayMaCaLonNhat()
        {
            string query = "Select top 1 MaCaLam from CaLamViec order by MaCaLam desc";
            object result = DataProvider.ExecuteScalar(query);
            return result != null ? result.ToString() : null;
        }


        public int InsertCaLamViec(string maCaLam)
        {
            string query = "INSERT INTO CaLamViec (MaCaLam, TgBatDau, TgKetThuc, GhiChu, TienDauCa, TienCuoiCa, TenDangNhap) " +
                           "VALUES (@MaCaLam, @TgBatDau, @TgKetThuc, @GhiChu, @TienDauCa, @TienCuoiCa, @TenDangNhap)";
            object[] parameters = new object[]
            {
                maCaLam,
                caLamViec.TgBatDau,
                caLamViec.TgKetThuc == null ? DBNull.Value : caLamViec.TgKetThuc,
                caLamViec.GhiChu,
                caLamViec.TienDauCa,
                caLamViec.TienCuoiCa == 0 ? DBNull.Value : caLamViec.TienCuoiCa,
                caLamViec.TenDangNhap
            };
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public string GetUserNameOfShift(string maCa)
        {
            string query = "select TenDangNhap from CaLamViec where MaCaLam = @MaCa";
            object result = DataProvider.ExecuteScalar(query, new object[] { maCa });
            return result != null ? result.ToString() : null;
        }

        public int ChotCaLamViec(string maCaLam, int tienCuoiCa, string ghiChu)
        {
            string query = "UPDATE CaLamViec SET TgKetThuc = @TgKetThuc, TienCuoiCa = @TienCuoiCa, GhiChu = @GhiChu WHERE MaCaLam = @MaCaLam";
            object[] parameters = new object[]
            {
                DateTime.Now,
                tienCuoiCa,
                ghiChu,
                maCaLam
            };
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public DataTable SelectAllShift()
        {
            string query = "select * from CaLamViec order by macalam desc";
            return DataProvider.ExecuteQuery(query);
        }

        public int GetToTalShifts()
        {
            string query = "select count(MaCaLam) from CaLamViec";
            object result = DataProvider.ExecuteScalar(query);
            return result != null ? (int)result: 0;       
        }

        public DataTable SelectCaLamOnPage(int page, int pageSize)
        {
            string query = @"
                SELECT * 
                FROM CaLamViec
                ORDER BY MaCaLam DESC
                OFFSET @Offset ROWS 
                FETCH NEXT @PageSize ROWS ONLY";

            int offset = (page - 1) * pageSize;

            return DataProvider.ExecuteQuery(query, new object[] { offset, pageSize });
        }

        public int GetTienDauCa(string maCa)
        {
            string query = "SELECT TienDauCa FROM CaLamViec WHERE MaCaLam = @MaCaLam";
            object result = DataProvider.ExecuteScalar(query, new object[] { maCa });

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }

            return 0; // hoặc bạn có thể trả về -1 nếu muốn đánh dấu lỗi
        }

        public DataTable GetInformationShift(string maCa)
        {
            string query = "select TienCuoiCa, GhiChu from calamviec where macalam = @macalam";
            return DataProvider.ExecuteQuery(query, new object[] {maCa});
        }
    }
}
