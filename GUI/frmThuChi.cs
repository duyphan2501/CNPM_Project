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
            grbXuatNhapKho.Visible = false;
            LoadLoaiPhieu();

            btnLuu.Enabled = false;
            cboLoaiPhieu.Text = "Tất cả";
            dateDenngay.Value = DateTime.Now;
            dateTungay.Value = DateTime.Now.AddDays(-7);

            dateTungay.ValueChanged += Date_ValueChanged;
            dateDenngay.ValueChanged += Date_ValueChanged;

            LoadReceipt();

        }

        public void LoadReceipt()
        {
            fullData = phieu.LoadReceipt();
            gridDsThuchi.DataSource = fullData;
        }

        public void LoadLoaiPhieu()
        {
            cboLoaithuchi.DataSource = loaithuchi.LoadType();
            cboLoaithuchi.DisplayMember = "TenLoai";
            cboLoaithuchi.ValueMember = "MaLoaiThuChi";
        }

        private void ApplyFilters()
        {
            if (fullData == null || fullData.Rows.Count == 0)
                return;

            DataView dv = fullData.DefaultView;
            List<string> filters = new List<string>();

            if (dateTungay.Checked && dateDenngay.Checked)
                filters.Add($"[Ngày lập] >= #{dateTungay.Value:MM/dd/yyyy}# AND [Ngày lập] <= #{dateDenngay.Value:MM/dd/yyyy}#");
            else if (dateTungay.Checked)
                filters.Add($"[Ngày lập] >= #{dateTungay.Value:MM/dd/yyyy}#");
            else if (dateDenngay.Checked)
                filters.Add($"[Ngày lập] <= #{dateDenngay.Value:MM/dd/yyyy}#");

            if (cboLoaiPhieu.Text == "Phiếu thu")
                filters.Add("[Loại phiếu] LIKE '%Phiếu thu%'");
            else if (cboLoaiPhieu.Text == "Phiếu chi")
                filters.Add("[Loại phiếu] LIKE '%Phiếu chi%'");

            dv.RowFilter = string.Join(" AND ", filters);
            gridDsThuchi.DataSource = dv.ToTable();
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnThemphieu_Click(object sender, EventArgs e)
        {
            grbXuatNhapKho.Visible = true;
            txtMaphieu.Text = phieu.GenerateID();
            txtMaphieu.ReadOnly = true;
            btnLuu.Enabled = true;
            numSotien.Value = 0;
            txtGhichu.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (numSotien.Value == 0)
            {
                General.ShowWarning("Vui lòng nhập số tiền!");
                return;
            }

            phieu.AddReceipt(
                txtMaphieu.Text,
                Program.account.Rows[0]["TenDangNhap"].ToString(),
                Convert.ToInt32(numSotien.Value),
                cboLoaithuchi.SelectedValue.ToString(),
                txtGhichu.Text
            );

            LoadReceipt();
            btnLuu.Enabled = false;
            numSotien.Value = 0;
            txtGhichu.Clear();

            MessageBox.Show("Lưu phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu này không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmThuChi_Load(sender, e);
            }
        }

        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmLoaiThuChi themloai = new frmLoaiThuChi();
            General.ShowDialogWithBlur(themloai);
            LoadLoaiPhieu();
        }
    }
}
