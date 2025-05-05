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
using Microsoft.IdentityModel.Tokens;

namespace GUI
{
    public partial class frmThemPhieuThuChi : Form
    {
        BUS_PhieuThuChi phieu = new BUS_PhieuThuChi("", "", 0, "", "");
        BUS_LoaiThuChi loaithuchi = new BUS_LoaiThuChi("", "", "");
        public frmThemPhieuThuChi()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboLoaiPhieu.Text))
            {
                General.ShowWarning("Vui chọn loại phiếu!",this);
                return;
            }
            if (string.IsNullOrEmpty(cboLoaiThuChi.Text))
            {
                General.ShowWarning("Vui chọn loại thu chi!", this);
                return;
            }
            if (numSotien.Value == 0)
            {
                General.ShowWarning("Vui lòng nhập số tiền!",this);
                return;
            }

            string maLoai = cboLoaiThuChi.SelectedValue?.ToString() ?? "";
            // lưu vào db
            phieu.AddReceipt(
                txtMaphieu.Text,
                Program.account.Rows[0]["TenDangNhap"].ToString(),
                Convert.ToInt32(numSotien.Value),
                maLoai,
                txtGhichu.Text
            );

            btnLuu.Enabled = false;

            numSotien.Value = 0;
            txtGhichu.Clear();

            MessageBox.Show("Lưu phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = General.ShowConfirm("Bạn có chắc chắn muốn hủy không?", this);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void GenerateID()
        {
            if (cboLoaiPhieu.Text == "Chi")
            {
                txtMaphieu.Text = phieu.GenerateID(true);
            }
            else
            {
                txtMaphieu.Text = phieu.GenerateID(false);
            }
        }

        private void frmThemPhieuThuChi_Load(object sender, EventArgs e)
        {
            txtMaphieu.ReadOnly = true;
            cboLoaiPhieu.Items.Clear();
            cboLoaiPhieu.Items.Add("Thu");
            cboLoaiPhieu.Items.Add("Chi");
            cboLoaiPhieu.SelectedIndex = -1;
            LoadCboLoaiThuChi();
        }

        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateID();
            LoadCboLoaiThuChi();
        }

        private void LoadCboLoaiThuChi()
        {
            cboLoaiThuChi.DataSource = null;
            cboLoaiThuChi.Items.Clear();

            // Lấy giá trị từ SelectedItem thay vì SelectedValue
            if (cboLoaiPhieu.SelectedItem == null) return;

            string loai = cboLoaiPhieu.SelectedItem.ToString(); // "Thu" hoặc "Chi"

            DataTable dt = loaithuchi.LoadType(loai);
            cboLoaiThuChi.DataSource = dt;
            cboLoaiThuChi.DisplayMember = "TenLoai";       // Tên loại hiển thị
            cboLoaiThuChi.ValueMember = "MaLoaiThuChi";    // Giá trị gốc
            cboLoaiThuChi.SelectedIndex = -1;
        }

        private void picThemLoai_Click(object sender, EventArgs e)
        {
            General.ShowDialogWithBlur(new frmLoaiThuChi());
        }
    }
}
