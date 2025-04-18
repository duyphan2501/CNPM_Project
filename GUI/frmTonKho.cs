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
    public partial class frmTonKho : Form
    {
        BUS_TonKho tonkho = new BUS_TonKho("", "", 0, 0, 0);
        public frmTonKho()
        {
            InitializeComponent();
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            LoadWarehouse();
        }

        public void LoadWarehouse()
        {
            gridDsTonkho.RowTemplate.Height = 50;
            gridDsTonkho.DataSource = tonkho.LoadWarehouse();
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoc.Text == "Tất cả")
            {
                LoadWarehouse();
            }
            else
            {
                LoadWarehouse();
                DataView dv = ((DataTable)gridDsTonkho.DataSource).DefaultView;
                dv.RowFilter = "[Số lượng tồn] < [Mức tối thiểu]";
                gridDsTonkho.DataSource = dv;
            }
        }
    }
}
