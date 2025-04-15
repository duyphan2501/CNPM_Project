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
    public partial class frmThemTonKho : Form
    {
        BUS_TonKho tonkho = new BUS_TonKho("","",0,0,0);
        string Manl;
        bool isUpdate;
        public frmThemTonKho(string manl, string tennl)
        {
            InitializeComponent();
            txtnNguyenlieu.Text = tennl;
            txtnNguyenlieu.ReadOnly = true;
            Manl = manl;
            txtMaton.Text = tonkho.PhatSinhMaTon();
            txtMaton.ReadOnly = true;
        }


        private void frmThemTonKho_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            tonkho.AddInventory(txtMaton.Text,Manl, Convert.ToInt32(numMuctoithieu.Value), Convert.ToInt32(numMuctoida.Value));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
