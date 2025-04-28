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

    public partial class frmLoaiThuChi : Form
    {
        BUS_LoaiThuChi loaithuchi = new BUS_LoaiThuChi("", "", "");
        public frmLoaiThuChi()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (IsDuplicate(txtTenloai.Text))
            {
                return;
            }
            if(!CheckInput())
            {
                return;
            }
            loaithuchi.AddType(txtMaloai.Text, txtTenloai.Text, cboLoai.Text);
            General.ShowInformation("Thêm loại thu chi thành công",this);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
        private void frmLoaiThuChi_Load(object sender, EventArgs e)
        {
            txtMaloai.Text = loaithuchi.GenerateID();
            txtMaloai.ReadOnly = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool IsDuplicate(string tenloai) //kiểm tra trùng tên loại thu chi
        {
            DataTable dt = loaithuchi.LoadType();
            foreach (DataRow row in dt.Rows)
            {
                string TenLoai = row["TenLoai"].ToString().ToLower();

                if (TenLoai == tenloai.ToLower() ) //so sánh ko phân biệt hoa thường
                {
                    MessageBox.Show("Đã có tên loại này rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenloai.Text))
            {
                General.ShowWarning("Vui lòng nhập tên loại thu chi");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(cboLoai.Text))
            {
                General.ShowWarning("Vui lòng chọn loại phiếu");
                return false;
            }
            return true;
        }
    }
}
