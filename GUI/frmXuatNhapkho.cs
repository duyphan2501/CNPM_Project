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
        BUS_NguyenLieu nguyenlieubus = new BUS_NguyenLieu("", "", "", "", 0, 0, 0);
        public frmXuatNhapKho()
        {
            InitializeComponent();
        }

        private void frmXuatNhapKho_Load(object sender, EventArgs e)
        {
            TaiTenNguyenLieu();
            txtTongtien.ReadOnly = true;
            txtDonvi.ReadOnly = true;
            //cboLoaiphieu.Text = "Phiếu nhập";
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
                gridDsPhieudangnhap.DataSource = phieunhap.TaiPhieunhap();

            }
            else
            {
                gridDsPhieudangnhap.DataSource = phieuxuat.TaiPhieuXuat();
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

        int tong = 0; //tạo biến lưu tổng tiền
        private void btnThem_Click(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                if (cboLoaiphieu.Enabled == true)
                {
                    gridDsPhieudangnhap.Columns.Add("manl", "Mã nguyên liệu");
                    gridDsPhieudangnhap.Columns.Add("nguyenlieu", "Tên nguyên liệu");
                    gridDsPhieudangnhap.Columns.Add("soluong", "Số lượng nhập");
                    gridDsPhieudangnhap.Columns.Add("gianhap", "Giá nhập");
                    gridDsPhieudangnhap.Columns.Add("thanhtien", "Thành tiền");
                }
                cboLoaiphieu.Enabled = false;

                // Lấy thông tin nguyên liệu hiện tại
                string manl = cboTenNguyenlieu.SelectedValue.ToString();
                string nguyenlieu = cboTenNguyenlieu.Text;
                int soluong = Convert.ToInt32(numSoluong.Value);
                int gianhap = Convert.ToInt32(numGianhap.Value);
                int thanhtien = soluong * gianhap;

                // Kiểm tra sự tồn tại của nguyên liệu
                bool daTonTai = false;

                foreach (DataGridViewRow row in gridDsPhieudangnhap.Rows)
                {
                    if (row.Cells["manl"].Value != null && row.Cells["manl"].Value.ToString() == manl)
                    {
                        // Hiển thị thông báo nếu nguyên liệu đã tồn tại
                        MessageBox.Show("Phiếu đã có nguyên liệu này rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        daTonTai = true;
                        break;
                    }
                }

                // Thêm mới nếu chưa tồn tại
                if (!daTonTai)
                {
                    gridDsPhieudangnhap.Rows.Add(manl, nguyenlieu, soluong, gianhap, thanhtien);

                    // Cập nhật tổng tiền
                    tong += thanhtien;
                    txtTongtien.Text = tong.ToString();

                    // Reset các input
                    numGianhap.Value = 0;
                    numSoluong.Value = 0;
                }
            }
            else
            {
                if (cboLoaiphieu.Enabled == true)
                {
                    gridDsPhieudangnhap.Columns.Add("manl", "Mã nguyên liệu");
                    gridDsPhieudangnhap.Columns.Add("nguyenlieu", "Tên nguyên liệu");
                    gridDsPhieudangnhap.Columns.Add("soluong", "Số lượng xuất");
                }
                cboLoaiphieu.Enabled = false;

                // Lấy thông tin nguyên liệu hiện tại
                string manl = cboTenNguyenlieu.SelectedValue.ToString();
                string nguyenlieu = cboTenNguyenlieu.Text;
                int soluongxuat = Convert.ToInt32(numSoluong.Value);  //số lượng xuất

                bool daTonTai = false; // Kiểm tra trong phiếu có trùng nguyên liệu không
                foreach (DataGridViewRow row in gridDsPhieudangnhap.Rows)
                {
                    if (row.Cells["manl"].Value != null && row.Cells["manl"].Value.ToString() == manl)
                    {
                        // Hiển thị thông báo nếu nguyên liệu đã tồn tại
                        MessageBox.Show("Phiếu đã có nguyên liệu này rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        daTonTai = true;
                        break;
                    }
                }
                bool loi = false; //lỗi khi số lượng xuất lớn hơn số lượng tồn
                if (daTonTai == false)
                {
                    DataTable dt = nguyenlieubus.LoadIngredients();
                    foreach (DataRow row in dt.Rows)
                    {
                        string tennl = row["Tên nguyên liệu"].ToString();
                        int soluongton = Convert.ToInt32(row["Số lượng tồn"]);
                        int muctoithieu = Convert.ToInt32(row["Mức tối thiểu"]);

                        if (tennl == nguyenlieu && soluongxuat > soluongton)
                        {
                            MessageBox.Show("Xuất quá số lượng tồn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            loi = true;
                        }
                        else if (tennl == nguyenlieu && (soluongton - soluongxuat) < muctoithieu)
                        {
                            DialogResult result = MessageBox.Show(   //Thông báo xuất quá mức tối thiểu
                                "Xuất quá mức tối thiểu?",
                                "Xác nhận lưu phiếu",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {  //nếu chọn yes vẫn thêm nl vào phiếu xuất
                                loi = false;
                            }
                            else      //chọn no thì không thêm nl đó vào phiếu
                            {
                                MessageBox.Show("Đã xóa nguyên liệu vừa thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                loi = true;
                            }
                        }
                    }
                }
                // Thêm mới nếu chưa tồn tại
                if (!daTonTai && !loi)
                {
                    gridDsPhieudangnhap.Rows.Add(manl, nguyenlieu, soluongxuat);

                    // Reset các input
                    numGianhap.Value = 0;
                    numSoluong.Value = 0;
                    txtGhichu.Enabled = false;
                }
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
                cboLoaiphieu.Enabled = true; //hoạt động như biến cờ để insert phiếu 1 lần
                if (cboLoaiphieu.Text == "Phiếu nhập")
                {
                    foreach (DataGridViewRow row in gridDsPhieudangnhap.Rows) //Thêm tất cả các dòng từ gridview vào database
                    {
                        if (!row.IsNewRow) // Chỉ xử lý các dòng không phải dòng trống
                        {
                            string manguyenlieu = row.Cells["manl"].Value?.ToString();
                            int soLuong = Convert.ToInt32(row.Cells["soluong"].Value);
                            int giaNhap = Convert.ToInt32(row.Cells["gianhap"].Value);
                            if (cboLoaiphieu.Enabled == true)
                            {
                                phieunhap.ThemPhieuNhap(txtMaphieu.Text, Program.account.Rows[0]["TenDangNhap"].ToString(), DateTime.Now, txtGhichu.Text);
                                chitietnhap.ThemChiTietNhap(txtMaphieu.Text, manguyenlieu, giaNhap, soLuong);
                                cboLoaiphieu.Enabled = false;
                            }
                            else  //1 phiếu có nhiều nguyên liệu, các dòng sau chỉ thêm chi tiết
                            {
                                chitietnhap.ThemChiTietNhap(txtMaphieu.Text, manguyenlieu, giaNhap, soLuong);
                            }
                        }
                    }
                }
                else
                {

                    foreach (DataGridViewRow row in gridDsPhieudangnhap.Rows)
                    {
                        string manguyenlieu = row.Cells["manl"].Value?.ToString();
                        int soLuong = Convert.ToInt32(row.Cells["soluong"].Value);
                        string tennnl = row.Cells["nguyenlieu"].Value?.ToString();



                        if (cboLoaiphieu.Enabled == true)
                        {
                            phieuxuat.ThemPhieuXuat(txtMaphieu.Text, Program.account.Rows[0]["TenDangNhap"].ToString(), DateTime.Now, txtGhichu.Text);
                            chitietxuat.ThemChiTietXuat(txtMaphieu.Text, manguyenlieu, soLuong);
                            cboLoaiphieu.Enabled = false;
                        }
                        else
                        {
                            chitietxuat.ThemChiTietXuat(txtMaphieu.Text, manguyenlieu, soLuong);
                        }
                    }

                }

                //Phát sinh mã mới
                cboLoaiphieu.Enabled = true;
                PhatSinhMa();
                numGianhap.Value = 0;
                numSoluong.Value = 0;
                txtGhichu.Clear();

                //Xóa sạch gridview sau khi Lưu phiếu
                gridDsPhieudangnhap.Rows.Clear();
                gridDsPhieudangnhap.Columns.Clear();

                //biến tổng lại bằng 0
                tong = 0;
                txtTongtien.Text = tong.ToString();
                txtGhichu.Enabled = true;

                MessageBox.Show("Lưu phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Người dùng chọn "Không", không làm gì cả hoặc xử lý khác
                MessageBox.Show("Đã hủy thao tác lưu phiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //private void cboLocMaphieu_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable dt = (DataTable)gridDsPhieudangnhap.DataSource;
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
            DataTable dt = (DataTable)gridDsPhieudangnhap.DataSource;
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
            txtDonvi.Text = phieunhap.TaiDonvi(cboTenNguyenlieu.Text);
        }

        
        

        // Hàm cập nhật tổng tiền
        private void UpdateTongTien()
        {
            int tongTien = 0;

            foreach (DataGridViewRow row in gridDsPhieudangnhap.Rows)
            {
                if (row.Cells["thanhtien"].Value != null)
                {
                    tongTien += Convert.ToInt32(row.Cells["thanhtien"].Value);
                }
            }

            // Hiển thị tổng tiền lên TextBox
            txtTongtien.Text = tongTien.ToString();
        }

        //Nếu thay đổi giá trị trong gridview
        private void gridDsPhieudangnhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột bị thay đổi là "Số lượng" hoặc "Giá nhập"
            if (e.RowIndex >= 0 && (gridDsPhieudangnhap.Columns[e.ColumnIndex].Name == "soluong" || gridDsPhieudangnhap.Columns[e.ColumnIndex].Name == "gianhap"))
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = gridDsPhieudangnhap.Rows[e.RowIndex];

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
}
