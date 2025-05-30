﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_LoaiThuChi
    {
        DTO_LoaiThuChi loaithuchidto;

        public DAL_LoaiThuChi(string maloaithuchi, string tenloai, string loai)
        {
            loaithuchidto = new DTO_LoaiThuChi(maloaithuchi,tenloai,loai);
        }

        public DAL_LoaiThuChi()
        {
            loaithuchidto = new DTO_LoaiThuChi();
        }

        public void AddType(string maloaithuchi, string tenloai, string loai)
        {
            string query = "insert into LoaiThuChi values (@_MaLoaiThuChi, @_TenLoai,@_Loai)";
            object[] parem = new object[] {maloaithuchi,tenloai,loai };
            DataProvider.ExecuteNonQuery(query, parem);
        }

        public DataTable LoadType(string loaiphieu)
        {
            string query = "select * from LoaiThuChi where Loai = @LoaiPhieu";
            return DataProvider.ExecuteQuery(query, new object[] { loaiphieu });
        }

        // lấy mã loại thu chi lớn nhất
        public string MaxID()
        {
            string query = "select top 1 MaLoaiThuChi from LoaiThuChi order by MaLoaiThuChi desc";
            string maxMaloai = (string)DataProvider.ExecuteScalar(query);
            return maxMaloai;
        }
    }
}
