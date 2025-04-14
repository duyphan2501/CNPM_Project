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

namespace GUI
{

    public partial class frmLoaiThuChi : Form
    {
        BUS_LoaiThuChi loaithuchi = new BUS_LoaiThuChi("", "", "");
        public frmLoaiThuChi()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            loaithuchi.ThemLoai(txtMaloai.Text, txtTenloai.Text, cboLoai.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmLoaiThuChi_Load(object sender, EventArgs e)
        {
            txtMaloai.Text = loaithuchi.PhatSinhMaLoai();
            txtMaloai.ReadOnly = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
