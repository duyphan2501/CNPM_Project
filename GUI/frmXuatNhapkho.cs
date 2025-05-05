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

        // Đảm bảo cột btnDelete luôn ở cuối cùng
        private void MoveDeleteColumnToEnd()
        {
            var col = gridDsPhieu.Columns["btnDelete"];
            if (col != null && col.DisplayIndex != gridDsPhieu.ColumnCount - 1)
            {
                col.DisplayIndex = gridDsPhieu.ColumnCount - 1;
            }
        }


        public void LoadIngredients_name()
        {
            cboTenNguyenlieu.DataSource = phieunhap.LoadIngredients_name();
            cboTenNguyenlieu.DisplayMember = "TenNL";
            cboTenNguyenlieu.ValueMember = "MaNL";
        }

        private void griDsPhieu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string columnName = gridDsPhieu.Columns[e.ColumnIndex].Name;
            if (columnName != "soluong" && columnName != "gianhap")
            {
                e.Cancel = true; // Không cho sửa các cột khác
            }
        }

        private void gridDsPhieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridDsPhieu.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xoá dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool laNhap = cboLoaiphieu.Text == "Phiếu nhập";
                    if (laNhap)
                    {
                        int thanhtien = Convert.ToInt32(gridDsPhieu.Rows[e.RowIndex].Cells["thanhtien"].Value);
                        tong -= thanhtien;
                        lblTongTien.Text = tong.ToString();
                    }

                    gridDsPhieu.Rows.RemoveAt(e.RowIndex);

                    if (gridDsPhieu.Rows.Count == 0)
                    {
                        btnLuuphieu.Enabled = false;
                        cboLoaiphieu.Enabled = true;
                    }
                }
            }
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
            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                numGianhap.Visible = true;
                lblGianhap.Visible = true;
                lblHienthi.Text = "cần nhập";
            }
            else {
                numGianhap.Visible = false;
                lblGianhap.Visible = false;
                lblHienthi.Text = "tồn kho";
            }
            GenerateID();
            Restocking(); //Đưa số lượng lên textbox
        }

        //Số lượng cần nhập thêm
        public void Restocking()
        {
            int muccannhap = phieunhap.Restocking(cboTenNguyenlieu.Text,0);
            int tonkho = phieunhap.Restocking(cboTenNguyenlieu.Text, 1);
            if (cboLoaiphieu.Text == "Phiếu nhập" && muccannhap > 0)
            {
                lblCanNhap.Text = phieunhap.Restocking(cboTenNguyenlieu.Text,0).ToString();
            }
            else if (cboLoaiphieu.Text == "Phiếu xuất" && tonkho > 0)
            {
                lblCanNhap.Text = phieunhap.Restocking(cboTenNguyenlieu.Text, 1).ToString(); ;
            }
            else
            {
                lblCanNhap.Text = "0";
            }
        }

        int tong = 0; //tạo biến lưu tổng tiền
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboLoaiphieu.Text))
            {
               General.ShowWarning("Vui lòng chọn loại phiếu!", this);
                return;
            }

            string manl = cboTenNguyenlieu.SelectedValue.ToString();
            string nguyenlieu = cboTenNguyenlieu.Text;
            int soluong = Convert.ToInt32(numSoluong.Value);
            bool laNhap = cboLoaiphieu.Text == "Phiếu nhập";
            

            if (IsDuplicateIngredient(manl)) return;
            if (laNhap)
            {
                int gianhap = Convert.ToInt32(numGianhap.Value);
                if (CheckInput_GoodsReceipt(soluong, gianhap)) return;

                if (cboLoaiphieu.Enabled)
                {
                    AddColumnGrid(laNhap);
                    cboLoaiphieu.Enabled = false;
                }

                //Thêm nguyên liệu vào phiếu nhập
                int thanhtien = soluong * gianhap;
                gridDsPhieu.Rows.Add(manl, nguyenlieu, soluong, gianhap, thanhtien, Properties.Resources.recyclebin);
                tong += thanhtien;
                lblTongTien.Text = tong.ToString();
                btnLuuphieu.Enabled = true; //cho phép lưu phiếu
                
            }
            else
            {
                if (CheckInput_DeliveryReceipt(nguyenlieu, soluong)) return;

                if (cboLoaiphieu.Enabled) 
                {
                    AddColumnGrid(laNhap);
                    cboLoaiphieu.Enabled = false;
                }

                //Thêm nguyên liệu vào phiếu xuất
                gridDsPhieu.Rows.Add(manl, nguyenlieu, soluong);
                txtGhichu.Enabled = false;
                btnLuuphieu.Enabled = true; //cho phép lưu phiếu
                cboLoaiphieu.Enabled = false;
            }

            btnLuuphieu.Enabled = true;
            numGianhap.Value = 0;
            numSoluong.Value = 0;
        }

        private void btnLuuphieu_Click(object sender, EventArgs e)
        {
            // kiểm tra có thêm nguyên liệu nào chưua
            if (gridDsPhieu.Rows.Count == 0)
            {
               General.ShowWarning("Vui lòng thêm nguyên liệu vào phiếu!", this);
                return;
            }

            DialogResult result = General.ShowConfirm("Bạn có chắc chắn muốn lưu phiếu không?", this);
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
                string maLoaiChi = "TC02";
                string ghiChu = txtMaphieu.Text;

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

        private void gridDsPhieu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;  // Không xử lý nếu là tiêu đề cột

            // Kiểm tra cột có tồn tại không
            var colGiaNhap = gridDsPhieu.Columns["gianhap"];
            var colSoLuong = gridDsPhieu.Columns["soluong"];
            var colThanhTien = gridDsPhieu.Columns["thanhtien"];

            if (colGiaNhap == null || colSoLuong == null || colThanhTien == null)
            {
                MessageBox.Show("Một hoặc nhiều cột không tồn tại.", "Lỗi cấu trúc bảng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Chỉ xử lý nếu sửa ở cột gianhap hoặc soluong
            if (e.ColumnIndex == colGiaNhap.Index || e.ColumnIndex == colSoLuong.Index)
            {
                DataGridViewRow row = gridDsPhieu.Rows[e.RowIndex];

                int gianhap = 0;
                int soluong = 0;

                if (int.TryParse(row.Cells["gianhap"].Value?.ToString(), out gianhap) && gianhap > 0
                    && int.TryParse(row.Cells["soluong"].Value?.ToString(), out soluong) && soluong > 0)
                {
                    int thanhtien = gianhap * soluong;
                    row.Cells["thanhtien"].Value = thanhtien;

                    // Cập nhật tổng tiền
                    tong = 0;
                    foreach (DataGridViewRow r in gridDsPhieu.Rows)
                    {
                        int temp = 0;
                        int.TryParse(r.Cells["thanhtien"]?.Value?.ToString(), out temp);
                        tong += temp;
                    }

                    lblTongTien.Text = tong.ToString();
                }
                else
                {
                    MessageBox.Show("Giá nhập và số lượng phải là số dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (e.ColumnIndex == colGiaNhap.Index)
                        row.Cells["gianhap"].Value = 0;
                    else if (e.ColumnIndex == colSoLuong.Index)
                        row.Cells["soluong"].Value = 1;
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
            // ko cho chỉnh mã và tên nl, thành tiền
            gridDsPhieu.Columns["manl"].ReadOnly = true;
            gridDsPhieu.Columns["nguyenlieu"].ReadOnly = true;
            if (laNhap)
            {
                gridDsPhieu.Columns.Add("gianhap", "Giá nhập");
                gridDsPhieu.Columns.Add("thanhtien", "Thành tiền");
                gridDsPhieu.Columns["thanhtien"].ReadOnly = true;
            }

            // Cột xoá
            DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
            deleteColumn.Name = "btnDelete";
            deleteColumn.HeaderText = "";
            deleteColumn.Image = Properties.Resources.recyclebin;
            deleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            deleteColumn.Width = 30;

            gridDsPhieu.Columns.Add(deleteColumn);

            // Đảm bảo cột nằm ở cuối
            MoveDeleteColumnToEnd();
        }


        //Kiểm tra xem nguyên liệu đã có trong phiếu chưa
        private bool IsDuplicateIngredient(string manl)
        {
            foreach (DataGridViewRow row in gridDsPhieu.Rows)
            {
                if (row.Cells["manl"].Value?.ToString() == manl)
                {
                    General.ShowWarning("Nguyên liệu đã có trong phiếu!", this);
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
                General.ShowWarning("Vui lòng nhập số lượng nhập kho", this);
                return true;
            }
            if (gianhap == 0)
            {
                General.ShowWarning("Vui lòng nhập giá nhập", this);
                return true;
            }
            return false;
        }

        //kiểm tra thông tin phiếu xuất
        private bool CheckInput_DeliveryReceipt(string nguyenlieu, int soluong)
        {
            if (soluong == 0)
            {
                General.ShowWarning("Vui lòng nhập số lượng xuất kho", this);
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
                        General.ShowWarning("Số lượng xuất lớn hơn số lượng tồn!", this);
                        return true;
                    }
                    if (ton - soluong < muctoithieu)
                    {
                        DialogResult confirm = General.ShowConfirm("Số lượng tồn sau khi xuất sẽ nhỏ hơn mức tối thiểu. Bạn có muốn tiếp tục không?", this);
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
