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
    public partial class frmKho : Form
    {
        BUS_NguyenLieu nguyenlieubus = new BUS_NguyenLieu("", "", "", "", 0, 0);
        BUS_TonKho nltonkho = new BUS_TonKho("","",0,0,0);
        public frmKho()
        {
            InitializeComponent();
            
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            LoadNguyenLieu();
            TaiTenLoai();
            gbThongtinnguyenlieu.Enabled = false;
            btnThemNguyenlieu.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnTonkho.Enabled = false;
        }

        public void LoadNguyenLieu()
        {
            gridDsNguyenlieu.RowTemplate.Height = 50;
            gridDsNguyenlieu.DataSource = nguyenlieubus.LoadIngredients();
            gridDsNguyenlieu.Columns["btnUpdate"].DisplayIndex = gridDsNguyenlieu.Columns.Count - 1; //đưa button về cuối

        }

        public void TaiTenLoai()
        {
            cboTenloai.DataSource = nguyenlieubus.TaiLoaiNguyenLieu();
            cboTenloai.DisplayMember = "TenLoai";
        }

        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmThemLoaiNguyenLieu loainguyenlieu = new frmThemLoaiNguyenLieu();
            General.ShowDialogWithBlur(loainguyenlieu);

            TaiTenLoai();
        }

        private void btnThemNguyenlieu_Click(object sender, EventArgs e)
        {
            gbThongtinnguyenlieu.Enabled = true;
            txtMaNguyenLieu.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            txtTenNguyenLieu.Clear();
            txtDonvitinh.Clear();

            txtMaNguyenLieu.Text = nguyenlieubus.PhatSinhMaNL();
            txtMaNguyenLieu.ReadOnly = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmKho_Load(sender, e);
            btnThemNguyenlieu.Enabled = true;
        }

        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dt = nguyenlieubus.LoadIngredients_name(); //tải danh sách tên nguyên liêu
            bool tontai = false;
            foreach (DataRow row in dt.Rows)
            {
                if (row["TenNL"].ToString() == txtTenNguyenLieu.Text)
                {
                    tontai = true;
                }
            }
            if (tontai == true)
            {
                MessageBox.Show("Đã tồn tại tên nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtMaNguyenLieu.Enabled == true)
                {
                    nguyenlieubus.AddIngredients(txtMaNguyenLieu.Text, cboTenloai.Text, txtTenNguyenLieu.Text, txtDonvitinh.Text);
                    LoadNguyenLieu();

                    frmThemTonKho tonkho = new frmThemTonKho(txtMaNguyenLieu.Text, txtTenNguyenLieu.Text, 0, 0); // thêm định lượng ngay sau khi thêm nguyên liệu
                    General.ShowDialogWithBlur(tonkho);
                }
                else
                {
                    nguyenlieubus.UpdateIngredients(txtMaNguyenLieu.Text, cboTenloai.Text, txtTenNguyenLieu.Text, txtDonvitinh.Text);
                    LoadNguyenLieu();
                }
            }
            frmKho_Load(sender, e);

        }

        private void gridDsNguyenlieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // không làm gì khi click vào header hoặc các cột khác ngoài cột btnUpdate
            if (e.RowIndex < 0 || e.ColumnIndex != gridDsNguyenlieu.Columns["btnUpdate"].Index)
            {
                return;
            }
            DataGridViewRow hangduocchon = gridDsNguyenlieu.SelectedRows[0];
            txtMaNguyenLieu.Text = hangduocchon.Cells["Mã nguyên liệu"].Value.ToString();
            cboTenloai.Text = hangduocchon.Cells["Tên loại"].Value.ToString();
            txtTenNguyenLieu.Text = hangduocchon.Cells["Tên nguyên liệu"].Value.ToString();
            txtDonvitinh.Text = hangduocchon.Cells["Đơn vị tính"].Value.ToString();

            gbThongtinnguyenlieu.Enabled = true;
            txtMaNguyenLieu.Enabled = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThemNguyenlieu.Enabled = false;
            btnTonkho.Enabled = true;
        }

        private void btnTonkho_Click(object sender, EventArgs e)
        {
            DataTable dt = nltonkho.LoadWarehouse();
            DataRow ketQua = null;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Nguyên liệu"].ToString() == txtTenNguyenLieu.Text)
                {
                    ketQua = row;
                    break; // Dừng lại khi tìm thấy
                }
            }
            if (ketQua == null) //nếu chưa có thì truyền mã nl và tên nl để thêm thông tin tồn kho
            {
                frmThemTonKho tonkho = new frmThemTonKho(txtMaNguyenLieu.Text, txtTenNguyenLieu.Text,0,0); 
                General.ShowDialogWithBlur(tonkho);

            }
            else  //truyền mã thông tin để chỉnh sửa
            {       
                // Nếu tìm thấy nguyên liệu, lấy giá trị "Mức tối thiểu" và "Mức ổn định"
                int muctoithieu = Convert.ToInt32(ketQua["Mức tối thiểu"]);
                int mucondinh = Convert.ToInt32(ketQua["Mức ổn định"]);
                frmThemTonKho tonkho = new frmThemTonKho(txtMaNguyenLieu.Text, txtTenNguyenLieu.Text, muctoithieu, mucondinh);  
                General.ShowDialogWithBlur(tonkho);
            }

            frmKho_Load(sender, e);
        }
    }
}
