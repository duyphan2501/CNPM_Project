using System;
using System.Data;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class frmLichSuXuatNhap : Form
    {
        BUS_PhieuNhapKho phieunhap = new BUS_PhieuNhapKho("", "", DateTime.Now, "");
        BUS_PhieuXuatKho phieuxuat = new BUS_PhieuXuatKho("", "", DateTime.Now, "");

        public frmLichSuXuatNhap()
        {
            InitializeComponent();
        }

        private void LoadCboLoaiPhieu()
        {
            cboLoaiphieu.Items.Clear();
            cboLoaiphieu.Items.Add("Phiếu nhập");
            cboLoaiphieu.Items.Add("Phiếu xuất");
            cboLoaiphieu.SelectedIndex = 0;
        }

        public void LoadReceipt()
        {
            gridLichsu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Xóa dữ liệu cũ
            gridLichsu.DataSource = null;

            // Lấy dữ liệu phiếu nhập và phiếu xuất từ cơ sở dữ liệu
            DataTable dtNhap = new DataTable();
            DataTable dtXuat = new DataTable();

            // Kiểm tra lựa chọn của người dùng trong combo box
            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                // Lấy dữ liệu phiếu nhập
                dtNhap = phieunhap.LoadGoodsReceipt();
                gridLichsu.DataSource = dtNhap;
            }
            else if (cboLoaiphieu.Text == "Phiếu xuất")
            {
                // Lấy dữ liệu phiếu xuất
                dtXuat = phieuxuat.LoadDeliveryReceipt();
                gridLichsu.DataSource = dtXuat;
            }

            // Cột cuối cùng chiếm phần còn lại
            if (gridLichsu.Columns.Count > 0)
            {
                foreach (DataGridViewColumn col in gridLichsu.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

                // Cột "Ghi chú" luôn fill phần còn lại
                var colGhichu = gridLichsu.Columns["Ghi chú"];
                if (colGhichu != null)
                {
                    colGhichu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    colGhichu.DisplayIndex = gridLichsu.Columns.Count - 1; // Đặt "Ghi chú" là cột cuối cùng
                }
            }
        }

        private void frmLichSuXuatNhap_Load(object sender, EventArgs e)
        {
            LoadCboLoaiPhieu();
            dateDenngay.Value = DateTime.Today.AddDays(1);
            dateTungay.Value = DateTime.Now.AddDays(-7);

            dateTungay.ValueChanged += Date_ValueChanged;
            dateDenngay.ValueChanged += Date_ValueChanged;

            LoadAndFilterData();
        }

        private void cboLoaiphieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAndFilterData();
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            LoadAndFilterData();
        }

        private void LoadAndFilterData()
        {
            LoadReceipt();
            FilterByDate();
        }

        private void FilterByDate()
        {
            DateTime tuNgay = dateTungay.Value.Date;
            DateTime denNgay = dateDenngay.Value.Date;

            if (gridLichsu.DataSource is not DataTable dt || !dt.Columns.Contains("Ngày lập"))
                return;

            DataView dv = dt.DefaultView;

            // Tạo điều kiện lọc theo ngày
            string filter = "";
            if (dateTungay.Checked && dateDenngay.Checked)
            {
                filter = $"[Ngày lập] >= #{tuNgay:MM/dd/yyyy}# AND [Ngày lập] <= #{denNgay:MM/dd/yyyy}#";
            }
            else if (dateTungay.Checked)
            {
                filter = $"[Ngày lập] >= #{tuNgay:MM/dd/yyyy}#";
            }
            else if (dateDenngay.Checked)
            {
                filter = $"[Ngày lập] <= #{denNgay:MM/dd/yyyy}#";
            }

            dv.RowFilter = filter;
            gridLichsu.DataSource = dv.ToTable();
        }
    }
}
