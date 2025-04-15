using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using cnpm;
using Microsoft.VisualBasic.Devices;

namespace GUI
{
    public partial class frmThuChi : Form
    {
        BUS_PhieuThuChi phieu = new BUS_PhieuThuChi("", "", 0, "", "");
        BUS_LoaiThuChi loaithuchi = new BUS_LoaiThuChi("", "", "");
        public frmThuChi()
        {
            InitializeComponent();
        }

        private void frmThuChi_Load(object sender, EventArgs e)
        {
            gridDsThuchi.RowTemplate.Height = 50;
            TaiPhieu();
            TaiLoaiPhieu();
            btnLuu.Enabled = false;
        }

        public void TaiPhieu()
        {
            gridDsThuchi.DataSource = phieu.TaiPhieu();

        }

        public void TaiLoaiPhieu()
        {
            cboLoaithuchi.DataSource = loaithuchi.TaiLoaiPhieu();
            cboLoaithuchi.DisplayMember = "TenLoai";
            cboLoaithuchi.ValueMember = "MaLoaiThuChi";
        }

        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmLoaiThuChi themloai = new frmLoaiThuChi();
            General.ShowDialogWithBlur(themloai);
            TaiLoaiPhieu();
        }

        private void btnThemphieu_Click(object sender, EventArgs e)
        {
            txtMaphieu.Text = phieu.PhatSinhMaPhieu();
            txtMaphieu.ReadOnly = true;
            btnLuu.Enabled = true;

            numSotien.Value = 0;
            txtGhichu.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            phieu.ThemThuChi(txtMaphieu.Text, Program.account.Rows[0]["TenDangNhap"].ToString(), Convert.ToInt32(numSotien.Value), cboLoaithuchi.SelectedValue.ToString(), txtGhichu.Text);
            TaiPhieu();
            btnLuu.Enabled = false;

            numSotien.Value = 0;
            txtGhichu.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmThuChi_Load(sender, e);
        }

        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiPhieu.Text == "Tất cả")
            {
                TaiPhieu();
            }
            else if(cboLoaiPhieu.Text == "Phiếu thu")
            {
                TaiPhieu();
                DataView dv =((DataTable) gridDsThuchi.DataSource).DefaultView;
                dv.RowFilter = $"[Loại phiếu] LIKE '%Thu%'";
                gridDsThuchi.DataSource = dv;
            }
            else
            {
                TaiPhieu();
                DataView dv = ((DataTable)gridDsThuchi.DataSource).DefaultView;
                dv.RowFilter = $"[Loại phiếu] LIKE '%Chi%'";
                gridDsThuchi.DataSource = dv;
            }
        }
    }
}
