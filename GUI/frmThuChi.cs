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
using Microsoft.VisualBasic.Devices;

namespace GUI
{
    public partial class frmThuChi : Form
    {
        BUS_PhieuThuChi phieu = new BUS_PhieuThuChi("", "", 0, "", "");
        BUS_LoaiThuChi loaithuchi = new BUS_LoaiThuChi("", "", "");
        public frmThuChi()
        {
            InitializeComponent();
        }

        private void frmThuChi_Load(object sender, EventArgs e)
        {
            grbXuatNhapKho.Visible = false;
            gridDsThuchi.RowTemplate.Height = 50;
            LoadPhieu();
            LoadLoaiPhieu();
            btnLuu.Enabled = false;

            cboLoaiPhieu.Text = "Tất cả";
            dateTungay.ValueChanged += Date_ValueChanged;
            dateDenngay.ValueChanged += Date_ValueChanged;

            
            dateDenngay.Value = DateTime.Now;   // Đặt giá trị mặc định cho dateDenngay là ngày hiện tại
            dateTungay.Value = DateTime.Now.AddDays(-7); //mặc định là 7 ngày trước
        }

        public void LoadPhieu()
        {
            gridDsThuchi.DataSource = phieu.TaiPhieu();
        }

        public void LoadLoaiPhieu()
        {
            cboLoaithuchi.DataSource = loaithuchi.TaiLoaiPhieu();
            cboLoaithuchi.DisplayMember = "TenLoai";
            cboLoaithuchi.ValueMember = "MaLoaiThuChi";
        }

        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmLoaiThuChi themloai = new frmLoaiThuChi();
            General.ShowDialogWithBlur(themloai);
            LoadLoaiPhieu();
        }

        private void btnThemphieu_Click(object sender, EventArgs e)
        {
            grbXuatNhapKho.Visible = true;
            txtMaphieu.Text = phieu.PhatSinhMaPhieu();
            txtMaphieu.ReadOnly = true;
            btnLuu.Enabled = true;

            numSotien.Value = 0;
            txtGhichu.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (numSotien.Value == 0)
            {
                General.ShowWarning("Vui lòng nhập số tiền!");
                return;
            }
            phieu.ThemThuChi(txtMaphieu.Text, Program.account.Rows[0]["TenDangNhap"].ToString(), Convert.ToInt32(numSotien.Value), cboLoaithuchi.SelectedValue.ToString(), txtGhichu.Text);
            LoadPhieu();
            btnLuu.Enabled = false;

            numSotien.Value = 0;
            txtGhichu.Clear();
            frmThuChi_Load(sender, e);

            MessageBox.Show("Lưu phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu này không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmThuChi_Load(sender, e);
            }
        }

        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboLoaiPhieu.Text == "Tất cả")
            //{
            //    LoadPhieu();
            //}
            //else if (cboLoaiPhieu.Text == "Phiếu thu")
            //{
            //    LoadPhieu();
            //    DataView dv = ((DataTable)gridDsThuchi.DataSource).DefaultView;
            //    dv.RowFilter = $"[Loại phiếu] LIKE '%Phiếu thu%'";
            //    gridDsThuchi.DataSource = dv;
            //}
            //else
            //{
            //    LoadPhieu();
            //    DataView dv = ((DataTable)gridDsThuchi.DataSource).DefaultView;
            //    dv.RowFilter = $"[Loại phiếu] LIKE '%Phiếu chi%'";
            //    gridDsThuchi.DataSource = dv;
            //}

            LocTheoNgay();
            LocTheoLoaiPhieu();
            
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
              
            LocTheoNgay();
            LocTheoLoaiPhieu();
        }

        private void LocTheoNgay()
        {
            DateTime tuNgay = dateTungay.Value.Date;
            DateTime denNgay = dateDenngay.Value.Date;  // Không cần thay đổi giờ

            LoadPhieu();
            DataView dv = ((DataTable)gridDsThuchi.DataSource).DefaultView;

            // Xử lý khi cả hai ngày đều được chọn
            if (dateTungay.Checked && dateDenngay.Checked)
            {
                dv.RowFilter = $"[Ngày lập] >= #{tuNgay:MM/dd/yyyy}# AND [Ngày lập] <= #{denNgay:MM/dd/yyyy}#";
            }
            // Xử lý khi chỉ có ngày bắt đầu được chọn
            else if (dateTungay.Checked)
            {
                dv.RowFilter = $"[Ngày lập] >= #{tuNgay:MM/dd/yyyy}#";
            }
            // Xử lý khi chỉ có ngày kết thúc được chọn
            else if (dateDenngay.Checked)
            {
                dv.RowFilter = $"[Ngày lập] <= #{denNgay:MM/dd/yyyy}#";
            }
            // Nếu không có ngày nào được chọn, không thay đổi bộ lọc
            else
            {
                dv.RowFilter = "";  // Làm rỗng bộ lọc nếu không có ngày nào được chọn
            }

            // Cập nhật lại DataSource bằng cách chuyển DataView thành DataTable
            gridDsThuchi.DataSource = dv.ToTable(); // Dùng ToTable để chuyển DataView thành DataTable
        }

        private void LocTheoLoaiPhieu()
        {
            
            DataView dv = ((DataTable)gridDsThuchi.DataSource).DefaultView;
            LoadPhieu();

            // Lọc dữ liệu theo loại phiếu
            if (cboLoaiPhieu.Text == "Tất cả")
            {
                dv.RowFilter = "";  // Không áp dụng bộ lọc nếu chọn "Tất cả"
            }
            else if (cboLoaiPhieu.Text == "Phiếu thu")
            {
                dv.RowFilter = "[Loại phiếu] LIKE '%Phiếu thu%'";
            }
            else 
            {
                dv.RowFilter = "[Loại phiếu] LIKE '%Phiếu chi%'";
            }

            // Cập nhật lại DataSource với bộ lọc
            gridDsThuchi.DataSource = dv.ToTable();  // Dùng ToTable để chuyển DataView thành DataTable
        }

        



    }
}
