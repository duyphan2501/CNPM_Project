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
    public partial class frmLichSuXuatNhap : Form
    {
        BUS_PhieuNhapKho phieunhap = new BUS_PhieuNhapKho("", "", DateTime.Now, "");
        BUS_PhieuXuatKho phieuxuat = new BUS_PhieuXuatKho("", "", DateTime.Now, "");
        BUS_ChiTietNhapKho chitietnhap = new BUS_ChiTietNhapKho("", "", 0, 0);
        BUS_ChiTietXuatKho chitietxuat = new BUS_ChiTietXuatKho("", "", 0);
        public frmLichSuXuatNhap()
        {
            InitializeComponent();
        }



        public void LoadReceipt() //danh sách lịch sử
        {

            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                //BUS_PhieuNhapKho phieunhap = new BUS_PhieuNhapKho("", "", DateTime.Now, "");
                //gridDsPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridLichsu.DataSource = phieunhap.LoadGoodsReceipt();
            }
            else
            {
                gridLichsu.DataSource = phieuxuat.LoadDeliveryReceipt();
            }
            gridLichsu.RowTemplate.Height = 50;
        }

        private void cboLoaiphieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReceipt();
        }

        private void frmLichSuXuatNhap_Load(object sender, EventArgs e)
        {
            cboLoaiphieu.Text = "Phiếu nhập";
            LoadReceipt();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
