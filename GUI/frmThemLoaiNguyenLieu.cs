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
    public partial class frmThemLoaiNguyenLieu : Form
    {
        BUS_LoaiNguyenLieu loainguyenlieubus;
        public frmThemLoaiNguyenLieu()
        {
            InitializeComponent();
            loainguyenlieubus = new BUS_LoaiNguyenLieu("", "");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            loainguyenlieubus.ThemLoaiNguyenLieu(txtMaloai.Text, txtTenloai.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmThemLoaiNguyenLieu_Load(object sender, EventArgs e)
        {
            txtMaloai.Text = loainguyenlieubus.PhatSinhMaLoaiNL();
            txtMaloai.ReadOnly = true;
        }
        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
