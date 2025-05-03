using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class frmThuChi : Form
    {
        BUS_PhieuThuChi phieu = new BUS_PhieuThuChi("", "", 0, "", "");
        BUS_LoaiThuChi loaithuchi = new BUS_LoaiThuChi("", "", "");

        private DataTable fullData = new DataTable(); // Dữ liệu toàn bộ phiếu thu chi

        public frmThuChi()
        {
            InitializeComponent();
        }

        private void frmThuChi_Load(object sender, EventArgs e)
        {
            gridDsThuchi.RowTemplate.Height = 50;
            cboLoaiPhieu.Text = "Tất cả";
            dateDenngay.Value = DateTime.Now.AddDays(1);
            dateTungay.Value = DateTime.Now.AddDays(-7);

            dateTungay.ValueChanged += DateOrLoaiPhieuChanged;
            dateDenngay.ValueChanged += DateOrLoaiPhieuChanged;
            cboLoaiPhieu.SelectedIndexChanged += DateOrLoaiPhieuChanged;

            LoadAndFilterData();
        }

        private void btnThemphieu_Click(object sender, EventArgs e)
        {
            frmThemPhieuThuChi themphieu = new frmThemPhieuThuChi();
            General.ShowDialogWithBlur(themphieu);
            LoadAndFilterData();
        }

        private void picThemLoai_Click(object sender, EventArgs e)
        {
            LoadAndFilterData();
        }

        private void DateOrLoaiPhieuChanged(object sender, EventArgs e)
        {
            LoadAndFilterData();
        }

        private void LoadAndFilterData()
        {
            fullData = phieu.LoadReceipt();
            DataView dv = fullData.DefaultView;

            // Lọc theo ngày
            string ngayFilter = "";
            if (dateTungay.Checked && dateDenngay.Checked)
            {
                ngayFilter = $"[Ngày lập] >= #{dateTungay.Value:MM/dd/yyyy}# AND [Ngày lập] <= #{dateDenngay.Value:MM/dd/yyyy}#";
            }
            else if (dateTungay.Checked)
            {
                ngayFilter = $"[Ngày lập] >= #{dateTungay.Value:MM/dd/yyyy}#";
            }
            else if (dateDenngay.Checked)
            {
                ngayFilter = $"[Ngày lập] <= #{dateDenngay.Value:MM/dd/yyyy}#";
            }

            // Lọc theo loại phiếu
            string loaiFilter = "";
            if (cboLoaiPhieu.Text == "Phiếu thu")
            {
                loaiFilter = "[Loại phiếu] LIKE '%Thu%'";
            }
            else if (cboLoaiPhieu.Text == "Phiếu chi")
            {
                loaiFilter = "[Loại phiếu] LIKE '%Chi%'";
            }

            // Kết hợp cả hai filter nếu cần
            if (!string.IsNullOrEmpty(ngayFilter) && !string.IsNullOrEmpty(loaiFilter))
            {
                dv.RowFilter = $"{ngayFilter} AND {loaiFilter}";
            }
            else if (!string.IsNullOrEmpty(ngayFilter))
            {
                dv.RowFilter = ngayFilter;
            }
            else if (!string.IsNullOrEmpty(loaiFilter))
            {
                dv.RowFilter = loaiFilter;
            }
            else
            {
                dv.RowFilter = "";
            }

            gridDsThuchi.DataSource = dv.ToTable();
        }

        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
