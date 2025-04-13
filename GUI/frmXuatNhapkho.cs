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

        int tong = 0; //tạo biến lưu tổng tiền
        private void btnThem_Click(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                if (cboLoaiphieu.Enabled == true)
                {
                    gridDsPhieu.Columns.Add("nguyenlieu", "Nguyên liệu");
                    gridDsPhieu.Columns.Add("soluong", "Số lượng nhập");
                    gridDsPhieu.Columns.Add("gianhap", "Giá nhập");
                    gridDsPhieu.Columns.Add("thanhtien", "Thành tiền");
                    gridDsPhieu.Columns.Add("ghichu", "Ghi chú");
                }
                cboLoaiphieu.Enabled = false;
                gridDsPhieu.Rows.Add(cboTenNguyenlieu.Text, (int)numSoluong.Value, (int)numGianhap.Value, (int)numSoluong.Value * (int)numGianhap.Value, txtGhichu.Text);

                tong += (int)numSoluong.Value * (int)numGianhap.Value;
                txtTongtien.Text = tong.ToString();

                numGianhap.Value = 0;
                numSoluong.Value = 0;

            }
            else
            {
                if (cboLoaiphieu.Enabled == true)
                {
                    gridDsPhieu.Columns.Add("nguyenlieu", "Nguyên liệu");
                    gridDsPhieu.Columns.Add("soluong", "Số lượng nhập");
                    gridDsPhieu.Columns.Add("ghichu", "Ghi chú"); ;
                }
                cboLoaiphieu.Enabled = false;
                gridDsPhieu.Rows.Add(cboTenNguyenlieu.Text, (int)numSoluong.Value, txtGhichu.Text);
                numGianhap.Value = 0;
                numSoluong.Value = 0;

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
                    foreach (DataGridViewRow row in gridDsPhieu.Rows) //Thêm tất cả các dòng từ gridview vào database
                    {
                        if (!row.IsNewRow) // Chỉ xử lý các dòng không phải dòng trống
                        {
                            string nguyenLieu = row.Cells["nguyenlieu"].Value?.ToString();
                            int soLuong = (int)row.Cells["soluong"].Value;
                            int giaNhap = (int)row.Cells["gianhap"].Value;
                            string ghiChu = row.Cells["ghichu"].Value?.ToString();
                            if (cboLoaiphieu.Enabled == true)
                            {
                                phieunhap.ThemPhieuNhap(txtMaphieu.Text, "haivo", DateTime.Now, ghiChu);
                                chitietnhap.ThemChiTietNhap(txtMaphieu.Text, nguyenLieu, giaNhap, soLuong);
                                cboLoaiphieu.Enabled = false;
                            }
                            else  //1 phiếu có nhiều nguyên liệu, các dòng sau chỉ thêm chi tiết
                            {
                                chitietnhap.ThemChiTietNhap(txtMaphieu.Text, nguyenLieu, giaNhap, soLuong);
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in gridDsPhieu.Rows)
                    {
                        string nguyenLieu = row.Cells["nguyenlieu"].Value?.ToString();
                        int soLuong = (int)row.Cells["soluong"].Value;
                        string ghiChu = row.Cells["ghichu"].Value?.ToString();
                        if (cboLoaiphieu.Enabled == true)
                        {
                            phieuxuat.ThemPhieuXuat(txtMaphieu.Text, "haivo", DateTime.Now, ghiChu);
                            chitietxuat.ThemChiTietXuat(txtMaphieu.Text, nguyenLieu, soLuong);
                            cboLoaiphieu.Enabled = false;
                        }
                        else
                        {
                            chitietxuat.ThemChiTietXuat(txtMaphieu.Text, nguyenLieu, soLuong);
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
                gridDsPhieu.Rows.Clear();
                gridDsPhieu.Columns.Clear();

                //biến tổng lại bằng 0
                tong = 0;
                txtTongtien.Text = tong.ToString();

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

        private void cboTenNguyenlieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDonvi.Text = phieunhap.TaiDonvi(cboTenNguyenlieu.Text);
        }
    }
}
