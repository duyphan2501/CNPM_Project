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
    public partial class frmThemLoaiSanPham : Form
    {
        BUS_LoaiSanPham loaisanphambus;
        public frmThemLoaiSanPham()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            loaisanphambus = new BUS_LoaiSanPham("", "");
            loaisanphambus.ThemLoaiSp(txtMaloai.Text, txtTenloai.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    

        private void frmThemLoaiSanPham_Load(object sender, EventArgs e)
        {
            loaisanphambus = new BUS_LoaiSanPham("", "");
            txtMaloai.Text = loaisanphambus.PhatSinhMaLoai();
            txtMaloai.ReadOnly = true;

        }
    }
}
