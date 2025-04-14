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
    public partial class frmThuChi : Form
    {
        BUS_PhieuThuChi phieu = new BUS_PhieuThuChi("", "", 0, "", "");
        public frmThuChi()
        {
            InitializeComponent();
        }

        private void frmThuChi_Load(object sender, EventArgs e)
        {
            TaiPhieu();
        }

        public void TaiPhieu()
        {
            gridDsThuchi.DataSource = phieu.TaiPhieu();
        }

        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmLoaiThuChi themloai = new frmLoaiThuChi();
            General.ShowDialogWithBlur(themloai);
        }
    }
}
