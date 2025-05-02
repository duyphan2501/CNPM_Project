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
            gridCaLam.Rows.Clear();
            gridCaLam.Columns.Clear();

            gridCaLam.DataSource = dt;

            // Cài đặt tiêu đề cột nếu cần tùy chỉnh lại
            gridCaLam.Columns["MaCaLam"].HeaderText = "Mã Ca Làm";
            gridCaLam.Columns["TenDangNhap"].HeaderText = "Người Mở Ca";
            gridCaLam.Columns["TgBatDau"].HeaderText = "Giờ Mở Ca";
            gridCaLam.Columns["TgKetThuc"].HeaderText = "Giờ Đóng Ca";
            gridCaLam.Columns["TienDauCa"].HeaderText = "Tiền Đầu Ca";
            gridCaLam.Columns["TienCuoiCa"].HeaderText = "Tiền Cuối Ca";
            gridCaLam.Columns["GhiChu"].HeaderText = "Ghi Chú";

            // Tuỳ chọn hiển thị, căn chỉnh
            gridCaLam.Columns["TgBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            gridCaLam.Columns["TgKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Thiết lập độ rộng cột
            foreach (DataGridViewColumn col in gridCaLam.Columns)
            {
                if (col.Name == "GhiChu")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }

        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (gridCaLam.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một CaLam.");
                return;
            }

            DataGridViewRow selectedRow = gridCaLam.SelectedRows[0];
            string maCaLam = selectedRow.Cells["MaCaLam"].Value?.ToString();
            frmTongKetCa frm = new frmTongKetCa(maCaLam, false);
            General.ShowDialogWithBlur(frm);
        }
    }
}
