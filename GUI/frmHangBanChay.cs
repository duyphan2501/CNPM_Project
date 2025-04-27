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
    public partial class frmHangBanChay : Form
    {
        BUS_SanPham sanpham = new BUS_SanPham("", "", "", null, 0, "");
        public frmHangBanChay()
        {
            InitializeComponent();
        }

        private void frmHangBanChay_Load(object sender, EventArgs e)
        {
           
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(numSosanpham.Value);
            DateTime tungay = dateStart.Value.Date;
            DateTime denngay = dateStop.Value.Date;
            DataView dv = sanpham.GetBestSellingProductst(num,tungay,denngay).DefaultView;
            gridHangbanchay.DataSource = dv.ToTable();
        }
    }
}
