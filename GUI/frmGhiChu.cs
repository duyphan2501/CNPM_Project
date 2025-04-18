using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmGhiChu : Form
    {
        public string GhiChu { get; private set; }

        public frmGhiChu()
        {
            InitializeComponent();
        }
        public frmGhiChu(string ghiChu)
        {
            InitializeComponent();
            txtGhiChu.Text = ghiChu;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtGhiChu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            GhiChu = txtGhiChu.Text.Trim();   // Gán giá trị người nhập
            this.DialogResult = DialogResult.OK;
            this.Close(); // Đóng dialog
        }
    }
}
