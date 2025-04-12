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
using cnpm;
using DTO;

namespace GUI
{
    public partial class frmXuatNhapKho : Form
    {
        BUS_PhieuNhapKho phieunhap = new BUS_PhieuNhapKho("", "", DateTime.Now, "");
        BUS_PhieuXuatKho phieuxuat = new BUS_PhieuXuatKho("", "", DateTime.Now, "");
        BUS_ChiTietNhapKho chitietnhap = new BUS_ChiTietNhapKho("", "", 0, 0);
        BUS_ChiTietXuatKho chitietxuat = new BUS_ChiTietXuatKho("", "", 0);
        public frmXuatNhapKho()
        {
            InitializeComponent();
        }

        private void frmXuatNhapKho_Load(object sender, EventArgs e)
        {
            TaiTenNguyenLieu();
            cboLoaiphieu.Text = "Phiếu nhập";
        }

        public void TaiTenNguyenLieu()
        {
            cboTenNguyenlieu.DataSource = phieunhap.TaiTenNguyenLieu();
            cboTenNguyenlieu.DisplayMember = "TenNL";
            cboTenNguyenlieu.ValueMember = "MaNL";
        }

        public void LoadPhieu()
        {

            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                //BUS_PhieuNhapKho phieunhap = new BUS_PhieuNhapKho("", "", DateTime.Now, "");
                //gridDsPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridDsPhieu.DataSource = phieunhap.TaiPhieunhap();
                //gridDsPhieu.Columns["btnUpdate"].DisplayIndex = gridDsPhieu.Columns.Count - 1; //đưa button về cuối

            }
            else
            {
                gridDsPhieu.DataSource = phieuxuat.TaiPhieuXuat();
                //gridDsPhieu.Columns["btnUpdate"].DisplayIndex = gridDsPhieu.Columns.Count - 1; //đưa button về cuối

            }
        }

      

        public void PhatSinhMa()  //Phát sinh mã phiếu mới
        {
            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                txtMaphieu.Text = phieunhap.PhatSinhMaPhieuNhap();
                txtMaphieu.ReadOnly = true;

                numGianhap.Enabled = true; //Phiếu nhập thì cho nhập giá

            }
            else
            {
                txtMaphieu.Text = phieuxuat.PhatSinhMaPhieuXuat();
                txtMaphieu.ReadOnly = true;

                numGianhap.Value = 0;
                numGianhap.Enabled = false; //Phiếu xuất thì không cho nhập giá

            }

        }

        private void cboLoaiphieu_SelectedIndexChanged(object sender, EventArgs e) //Khi loại phiếu thay đổi thì tự phát sinh mã
        {
            PhatSinhMa();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                if (cboLoaiphieu.Enabled == true)
                {
                    phieunhap.ThemPhieuNhap(txtMaphieu.Text, "haivo", DateTime.Now, txtGhichu.Text);
                }
                cboLoaiphieu.Enabled = false;
                chitietnhap.ThemChiTietNhap(txtMaphieu.Text, cboTenNguyenlieu.Text, (int)numGianhap.Value, (int)numSoluong.Value);
                numGianhap.Value = 0;
                numSoluong.Value = 0;

                LocTheoMa();
            }
            else
            {
                if (cboLoaiphieu.Enabled == true)
                {
                    phieuxuat.ThemPhieuXuat(txtMaphieu.Text, "haivo", DateTime.Now, txtGhichu.Text);
                }
                cboLoaiphieu.Enabled = false;
                chitietxuat.ThemChiTietXuat(txtMaphieu.Text, cboTenNguyenlieu.Text, (int)numSoluong.Value);
                numGianhap.Value = 0;
                numSoluong.Value = 0;

                LocTheoMa();
            }

        }

        private void btnLuuphieu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn lưu phiếu này không?",
                "Xác nhận lưu phiếu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Thực hiện lưu phiếu
                cboLoaiphieu.Enabled = true;
                PhatSinhMa();
                numGianhap.Value = 0;
                numSoluong.Value = 0;
                txtGhichu.Clear();

                MessageBox.Show("Lưu phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Người dùng chọn "Không", không làm gì cả hoặc xử lý khác
                MessageBox.Show("Đã hủy thao tác lưu phiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LocTheoMa();
        }

        //private void cboLocMaphieu_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable dt = (DataTable)gridDsPhieu.DataSource;
        //    if (cboLocLoaiphieu.Text == "Phiếu nhập")
        //    {
        //        dt.DefaultView.RowFilter = $"[Mã phiếu nhập] LIKE '%{cboLocMaphieu.Text}%'";
        //    }
        //    else
        //    {
        //        dt.DefaultView.RowFilter = $"[Mã phiếu xuất] LIKE '%{cboLocMaphieu.Text}%'";
        //    }
        //}

        public void LocTheoMa()
        {
            LoadPhieu();
            DataTable dt = (DataTable)gridDsPhieu.DataSource;
            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                dt.DefaultView.RowFilter = $"[Mã phiếu nhập] LIKE '%{txtMaphieu.Text}%'";
            }
            else
            {
                dt.DefaultView.RowFilter = $"[Mã phiếu xuất] LIKE '%{txtMaphieu.Text}%'";
            }

        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            frmLichSuXuatNhap lichsu = new frmLichSuXuatNhap();
            General.ShowDialogWithBlur(lichsu);
            
        }


        
    }
}
