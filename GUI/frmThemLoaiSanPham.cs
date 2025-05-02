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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class frmThemLoaiSanPham : Form
    {
        BUS_LoaiSanPham loaisanphambus = new BUS_LoaiSanPham("", "");
        public frmThemLoaiSanPham()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (IsDuplicate(txtTenloai.Text))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenloai.Text))
            {
                General.ShowWarning("Vui lòng nhập tên loại sản phẩm",this);
                return;
            }
            loaisanphambus.AddProduct_type(txtMaloai.Text, txtTenloai.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



        private void frmThemLoaiSanPham_Load(object sender, EventArgs e)
        {
            txtMaloai.Text = loaisanphambus.GenerateID();
            txtMaloai.ReadOnly = true;

        }

        private bool IsDuplicate(string tenloai) //kiểm tra trùng loại nguyên liệu
        {
            DataTable dt = loaisanphambus.LoadProduct_type();
            foreach (DataRow row in dt.Rows)
            {
                string TenLoai = row["TenLoai"].ToString().ToLower();

                if (TenLoai == tenloai.ToLower()) //so sánh ko phân biệt hoa thường
                {
                    General.ShowWarning("Tên loại sản phẩm đã tồn tại!", this);
                    return true;
                }
            }
            return false;
        }
    }
}
