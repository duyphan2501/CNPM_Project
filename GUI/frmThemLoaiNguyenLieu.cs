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
using DAL;

namespace GUI
{
    public partial class frmThemLoaiNguyenLieu : Form
    {
        BUS_LoaiNguyenLieu loainguyenlieubus = new BUS_LoaiNguyenLieu("", "");
        public frmThemLoaiNguyenLieu()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenloai.Text))
            {
                General.ShowWarning("Vui lòng nhập tên loại nguyên liệu!",this);
                return;
            }
            if (IsDuplicate(txtTenloai.Text))  //Kiểm tra có trùng tên loại nguyên liệu hay không
            {
                return;
            }
            
            loainguyenlieubus.AddIngredients_type(txtMaloai.Text, txtTenloai.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        

        private void frmThemLoaiNguyenLieu_Load(object sender, EventArgs e)
        {
            txtMaloai.Text = loainguyenlieubus.GenerateID();
            txtMaloai.ReadOnly = true;
        }
        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool IsDuplicate(string tenloai) //kiểm tra trùng loại nguyên liệu
        {
            DataTable dt = loainguyenlieubus.LoadIngredients_type();
            foreach (DataRow row in dt.Rows)
            {
                string TenLoai = row["TenLoai"].ToString().ToLower();

                if (TenLoai == tenloai.ToLower()) //so sánh ko phân biệt hoa thường
                {
                    General.ShowWarning("Tên loại nguyên liệu đã tồn tại!", this);
                    return true;
                }
            }
            return false;
        }
    }
}
