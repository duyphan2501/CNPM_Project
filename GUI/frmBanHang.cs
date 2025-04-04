using GUI.components;
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
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in pnlProduct.Controls)
            {
                Widget widget = (Widget)item;
                widget.Visible = widget.lblName.Text.ToLower().Contains(txtTimKiem.Text.ToLower());
            }
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
             
        }
    }
}
