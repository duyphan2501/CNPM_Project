using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using Guna.UI2.WinForms.Enums;

namespace GUI
{
    public partial class frmXuatNhapKho : Form
    {
        BUS_PhieuNhapKho phieunhap = new BUS_PhieuNhapKho("", "", DateTime.Now, "");
        BUS_PhieuXuatKho phieuxuat = new BUS_PhieuXuatKho("", "", DateTime.Now, "");
        BUS_ChiTietNhapKho chitietnhap = new BUS_ChiTietNhapKho("", "", 0, 0);
        BUS_ChiTietXuatKho chitietxuat = new BUS_ChiTietXuatKho("", "", 0);
        BUS_NguyenLieu nguyenlieubus = new BUS_NguyenLieu("", "", "", "", 0, 0, 0);
        public frmXuatNhapKho()
        {
            InitializeComponent();
        }

        private void frmXuatNhapKho_Load(object sender, EventArgs e)
        {
            LoadcboLoaiPhieu();
            LoadIngredients_name();
            btnLuuphieu.Enabled = false;
            //cboLoaiphieu.Text = "Phiếu nhập";
        }

        public void LoadIngredients_name()
        {
            cboTenNguyenlieu.DataSource = phieunhap.LoadIngredients_name();
            cboTenNguyenlieu.DisplayMember = "TenNL";
            cboTenNguyenlieu.ValueMember = "MaNL";
        }

        public void LoadReceipt()
        {

            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                //BUS_PhieuNhapKho phieunhap = new BUS_PhieuNhapKho("", "", DateTime.Now, "");
                //gridDsPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridDsPhieu.DataSource = phieunhap.LoadGoodsReceipt();

            }
            else
            {
                gridDsPhieu.DataSource = phieuxuat.LoadDeliveryReceipt();
            }
        }

        private void LoadcboLoaiPhieu()
        {
            cboLoaiphieu.Items.Add("Phiếu nhập");
            cboLoaiphieu.Items.Add("Phiếu xuất");
            cboLoaiphieu.SelectedIndex = -1;
        }

        public void GenerateID()  //Phát sinh mã phiếu mới
        {
            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                txtMaphieu.Text = phieunhap.GenerateID();
                txtMaphieu.ReadOnly = true;

                numGianhap.Enabled = true; //Phiếu nhập thì cho nhập giá

            }
            else
            {
                txtMaphieu.Text = phieuxuat.GenerateID();
                txtMaphieu.ReadOnly = true;

                numGianhap.Value = 0;
                numGianhap.Enabled = false; //Phiếu xuất thì không cho nhập giá

            }

        }

        private void cboLoaiphieu_SelectedIndexChanged(object sender, EventArgs e) //Khi loại phiếu thay đổi thì tự phát sinh mã
        {
            GenerateID();
            Restocking(); //Đưa số lượng lên textbox
        }

        //Số lượng cần nhập thêm
        public void Restocking()
        {
            int muccannhap = phieunhap.Restocking(cboTenNguyenlieu.Text);
            if (cboLoaiphieu.Text == "Phiếu nhập" && muccannhap > 0)
            {
                lblCanNhap.Text = phieunhap.Restocking(cboTenNguyenlieu.Text).ToString();
            }
            else if (cboLoaiphieu.Text == "Phiếu xuất")
            {
                lblCanNhap.Text = null;
            }
            else
            {
                lblCanNhap.Text = "0";
            }
        }

        int tong = 0; //tạo biến lưu tổng tiền
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboLoaiphieu.Text)) // chưa chọn loại phiếu
            {
                MessageBox.Show("Vui lòng chọn loại phiếu trước khi thêm nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string manl = cboTenNguyenlieu.SelectedValue.ToString();
            string nguyenlieu = cboTenNguyenlieu.Text;
            int soluong = Convert.ToInt32(numSoluong.Value);
            bool laNhap = cboLoaiphieu.Text == "Phiếu nhập";
            if (cboLoaiphieu.Enabled)
            {
                AddColumnGrid(laNhap);
                cboLoaiphieu.Enabled = false;
            }

            if (IsDuplicateIngredient(manl)) return;

            if (laNhap) //check thông tin phiếu nhập kho
            {
                int gianhap = Convert.ToInt32(numGianhap.Value);
                if (CheckInput_GoodsReceipt(soluong, gianhap)) return;

                int thanhtien = soluong * gianhap;
                gridDsPhieu.Rows.Add(manl, nguyenlieu, soluong, gianhap, thanhtien);
                tong += thanhtien;
                lblTongTien.Text = tong.ToString();
                btnLuuphieu.Enabled = true; //cho phép lưu phiếu
            }
            else //check thông tin phiếu xuất kho
            {
                if (CheckInput_DeliveryReceipt(nguyenlieu, soluong)) return;
                gridDsPhieu.Rows.Add(manl, nguyenlieu, soluong);
                txtGhichu.Enabled = false;
                btnLuuphieu.Enabled = true; //cho phép lưu phiếu
            }

            numGianhap.Value = 0;
            numSoluong.Value = 0;
        }

        private void btnLuuphieu_Click(object sender, EventArgs e)
        {
            // kiểm tra có thêm nguyên liệu nào chưua
            if (gridDsPhieu.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm nguyên liệu vào phiếu trước khi lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn lưu phiếu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveReceipt();
                ResetForm();
                MessageBox.Show("Lưu phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveReceipt()
        {
            bool laNhap = cboLoaiphieu.Text == "Phiếu nhập";
            if (laNhap)
            {
                string tenDangNhap = Program.account.Rows[0]["TenDangNhap"].ToString();

                //Thêm phiếu nhập kho 
                int affectedRows = phieunhap.AddGoodsReceipt(txtMaphieu.Text, tenDangNhap, DateTime.Now, txtGhichu.Text);
                if (affectedRows == 0)
                {
                    General.ShowError("Lưu phiếu nhập không thành công!", this);
                    return;
                }

                // Tạo phiếu chi
                BUS_PhieuThuChi phieuThuChi = new BUS_PhieuThuChi();
                string maPhieuChi = phieuThuChi.GenerateID(true);
                int sotien = General.FormatMoneyToInt(lblTongTien.Text);
                string maLoaiChi = "C01";
                string ghiChu = "";

                affectedRows = phieuThuChi.AddReceipt(maPhieuChi, tenDangNhap, sotien, maLoaiChi, ghiChu);
                if (affectedRows == 0)
                {
                    General.ShowError("Tạo phiếu chi không thành công!", this);
                    return;
                }
            }

            else
            {
                //Thêm phiếu xuất kho
                int affectedRows = phieuxuat.AddDeliveryReceip(txtMaphieu.Text, Program.account.Rows[0]["TenDangNhap"].ToString(), DateTime.Now, txtGhichu.Text);
                if (affectedRows == 0)
                {
                    General.ShowError("Lưu phiếu xuất không thành công!", this);
                    return;
                }
            }

            foreach (DataGridViewRow row in gridDsPhieu.Rows)
            {
                if (!row.IsNewRow)
                {
                    string manl = row.Cells["manl"].Value?.ToString();
                    int soluong = Convert.ToInt32(row.Cells["soluong"].Value);

                    if (laNhap)  //Thêm chi tiết nhập kho
                    {
                        int gianhap = Convert.ToInt32(row.Cells["gianhap"].Value);
                        chitietnhap.AddEntryDetail(txtMaphieu.Text, manl, gianhap, soluong);
                    }
                    else  //Thêm chi tiết xuất kho
                    {
                        chitietxuat.AddExportDetail(txtMaphieu.Text, manl, soluong);
                    }
                }
            }
        }

        private void ResetForm()
        {
            cboLoaiphieu.Enabled = true;
            GenerateID();
            numGianhap.Value = 0;
            numSoluong.Value = 0;
            txtGhichu.Clear();
            txtGhichu.Enabled = true;
            gridDsPhieu.Rows.Clear();
            gridDsPhieu.Columns.Clear();
            tong = 0;
            lblTongTien.Text = "0";
        }

        //Tạo cột cho grid view theo các phiếu
        private void AddColumnGrid(bool laNhap)
        {
            gridDsPhieu.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridDsPhieu.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            gridDsPhieu.Columns.Add("manl", "Mã nguyên liệu");
            gridDsPhieu.Columns.Add("nguyenlieu", "Tên nguyên liệu");
            gridDsPhieu.Columns.Add("soluong", laNhap ? "Số lượng nhập" : "Số lượng xuất");
            if (laNhap)
            {
                gridDsPhieu.Columns.Add("gianhap", "Giá nhập");
                gridDsPhieu.Columns.Add("thanhtien", "Thành tiền");
            }
        }

        //Kiểm tra xem nguyên liệu đã có trong phiếu chưa
        private bool IsDuplicateIngredient(string manl)
        {
            foreach (DataGridViewRow row in gridDsPhieu.Rows)
            {
                if (row.Cells["manl"].Value?.ToString() == manl)
                {
                    MessageBox.Show("Phiếu đã có nguyên liệu này rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        //kiểm tra thông tin phiếu nhập
        private bool CheckInput_GoodsReceipt(int soluong, int gianhap)
        {
            if (soluong == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng nhập kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (gianhap == 0)
            {
                MessageBox.Show("Vui lòng nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        //kiểm tra thông tin phiếu xuất
        private bool CheckInput_DeliveryReceipt(string nguyenlieu, int soluong)
        {
            if (soluong == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng xuất kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            DataTable dt = nguyenlieubus.LoadIngredients();
            foreach (DataRow row in dt.Rows)
            {
                string tennl = row["Tên nguyên liệu"].ToString();
                int ton = Convert.ToInt32(row["Số lượng tồn"]);
                int muctoithieu = Convert.ToInt32(row["Mức tối thiểu"]);

                if (tennl == nguyenlieu)
                {
                    if (soluong > ton)
                    {
                        MessageBox.Show("Xuất quá số lượng tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                    if (ton - soluong < muctoithieu)
                    {
                        DialogResult confirm = MessageBox.Show("Xuất quá mức tối thiểu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        return confirm == DialogResult.No;
                    }
                }
            }
            return false;
        }

        public void LocTheoMa()
        {
            LoadReceipt();
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

        private void cboTenNguyenlieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDonvi.Text = phieunhap.TaiDonvi(cboTenNguyenlieu.Text);
            Restocking();
        }

        // Hàm cập nhật tổng tiền
        private void UpdateTongTien()
        {
            int tongTien = 0;

            foreach (DataGridViewRow row in gridDsPhieu.Rows)
            {
                if (row.Cells["thanhtien"].Value != null)
                {
                    tongTien += Convert.ToInt32(row.Cells["thanhtien"].Value);
                }
            }

            // Hiển thị tổng tiền lên TextBox
            lblTongTien.Text = tongTien.ToString();
        }

        private void gridDsPhieu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                // Kiểm tra nếu cột bị thay đổi là "Số lượng" hoặc "Giá nhập"
                if (e.RowIndex >= 0 && (gridDsPhieu.Columns[e.ColumnIndex].Name == "soluong" || gridDsPhieu.Columns[e.ColumnIndex].Name == "gianhap"))
                {
                    // Lấy dòng hiện tại
                    DataGridViewRow row = gridDsPhieu.Rows[e.RowIndex];

                    // Lấy giá trị "Số lượng" và "Giá nhập"
                    int soluong = row.Cells["soluong"].Value != null ? Convert.ToInt32(row.Cells["soluong"].Value) : 0;
                    int gianhap = row.Cells["gianhap"].Value != null ? Convert.ToInt32(row.Cells["gianhap"].Value) : 0;

                    // Tính lại "Thành tiền"
                    row.Cells["thanhtien"].Value = soluong * gianhap;

                    // Cập nhật tổng tiền
                    UpdateTongTien();
                }
            }
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            frmKho tonkho = new frmKho();
            General.ShowDialogWithBlur(tonkho);
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
