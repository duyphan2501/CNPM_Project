using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBaoCaoChotCa : Form
    {
        public frmBaoCaoChotCa()
        {
            InitializeComponent();
        }
        private int currentPage = 1;
        private int pageSize;
        private int totalPages;
        BUS_CaLamViec calam = new BUS_CaLamViec();
        private void frmBaoCaoChotCa_Load(object sender, EventArgs e)
        {
            pageSize = PaginationHelper.GetPageSizeFromGridView(gridCaLam);
            totalPages = (int)Math.Ceiling((double)calam.GetToTalShifts() / pageSize);
            LoadCaLamOnPage(currentPage);
        }

        private void LoadCaLamOnPage(int page)
        {
            DataTable dt = calam.SelectCaLamOnPage(page, pageSize);
            LoadCaLamIntoGrid(dt);
            // gọi hàm phân trang
            PaginationHelper.GeneratePaginationButtons(
            pnlPagination,
            currentPage,
            totalPages,
            (page) =>
            {
                currentPage = page;
                LoadCaLamOnPage(currentPage);
            });
        }

        private void LoadCaLamIntoGrid(DataTable dt)
        {
            gridCaLam.DataSource = null;
            gridCaLam.Columns.Clear(); 

            gridCaLam.DataSource = dt;
            gridCaLam.AllowUserToAddRows = false;

            // Thiết lập tiêu đề cột
            gridCaLam.Columns["MaCaLam"].HeaderText = "Mã Ca Làm";
            gridCaLam.Columns["TenDangNhap"].HeaderText = "Người Mở Ca";
            gridCaLam.Columns["TgBatDau"].HeaderText = "Giờ Mở Ca";
            gridCaLam.Columns["TgKetThuc"].HeaderText = "Giờ Đóng Ca";
            gridCaLam.Columns["TienDauCa"].HeaderText = "Tiền Đầu Ca";
            gridCaLam.Columns["TienCuoiCa"].HeaderText = "Tiền Cuối Ca";
            gridCaLam.Columns["GhiChu"].HeaderText = "Ghi Chú";

            gridCaLam.Columns["TgBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            gridCaLam.Columns["TgKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }


        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (gridCaLam.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một Ca làm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = gridCaLam.SelectedRows[0];

            // Kiểm tra cột "MaCaLam" có tồn tại và có giá trị hay không
            if (selectedRow.Cells["MaCaLam"].Value == null)
            {
                MessageBox.Show("Dữ liệu Ca làm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maCaLam = selectedRow.Cells["MaCaLam"].Value.ToString().Trim();

            if (string.IsNullOrEmpty(maCaLam))
            {
                MessageBox.Show("Mã Ca làm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTongKetCa frm = new frmTongKetCa(maCaLam, false);
            General.ShowDialogWithBlur(frm);
        }

    }
}
