using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class frmThuChi : Form
    {
        BUS_PhieuThuChi phieu = new BUS_PhieuThuChi("", "", 0, "", "");
        BUS_LoaiThuChi loaithuchi = new BUS_LoaiThuChi("", "", "");

        private DataTable fullData = new DataTable(); // Dữ liệu toàn bộ phiếu thu chi
        public frmThuChi()
        {
            InitializeComponent();
        }

        private void frmThuChi_Load(object sender, EventArgs e)
        {
            grbXuatNhapKho.Visible = false;
            LoadLoaiPhieu();

            btnLuu.Enabled = false;
            gridDsThuchi.RowTemplate.Height = 50;
            LoadReceipt();
          

            cboLoaiPhieu.Text = "Tất cả";
            dateDenngay.Value = DateTime.Now;
            dateTungay.Value = DateTime.Now.AddDays(-7);

            dateTungay.ValueChanged += Date_ValueChanged;
            dateDenngay.ValueChanged += Date_ValueChanged;

            LoadReceipt();

            dateDenngay.Value = DateTime.Now.AddDays(1);  // Đặt giá trị mặc định cho dateDenngay là ngày hiện tại 
            dateTungay.Value = DateTime.Now.AddDays(-7); //mặc định là 7 ngày trước
        }

        public void LoadReceipt()
        {
            fullData = phieu.LoadReceipt();
            gridDsThuchi.DataSource = fullData;
        }


        private void btnThemphieu_Click(object sender, EventArgs e)
        {
            frmThemPhieuThuChi themphieu = new frmThemPhieuThuChi();
            General.ShowDialogWithBlur(themphieu);
            LoadReceipt();
        }


        private void picThemLoai_Click(object sender, EventArgs e)
        {

            LocTheoNgay();
            LocTheoLoaiPhieu();
            
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
              
            LocTheoNgay();
            LocTheoLoaiPhieu();
        }

        private void LocTheoNgay()
        {
            DateTime tuNgay = dateTungay.Value.Date;
            DateTime denNgay = dateDenngay.Value.Date;  // Không cần thay đổi giờ

            LoadReceipt();
            DataView dv = ((DataTable)gridDsThuchi.DataSource).DefaultView;

            // Xử lý khi cả hai ngày đều được chọn
            if (dateTungay.Checked && dateDenngay.Checked)
            {
                dv.RowFilter = $"[Ngày lập] >= #{tuNgay:MM/dd/yyyy}# AND [Ngày lập] <= #{denNgay:MM/dd/yyyy}#";
            }
            // Xử lý khi chỉ có ngày bắt đầu được chọn
            else if (dateTungay.Checked)
            {
                dv.RowFilter = $"[Ngày lập] >= #{tuNgay:MM/dd/yyyy}#";
            }
            // Xử lý khi chỉ có ngày kết thúc được chọn
            else if (dateDenngay.Checked)
            {
                dv.RowFilter = $"[Ngày lập] <= #{denNgay:MM/dd/yyyy}#";
            }
            // Nếu không có ngày nào được chọn, không thay đổi bộ lọc
            else
            {
                dv.RowFilter = "";  // Làm rỗng bộ lọc nếu không có ngày nào được chọn
            }

            // Cập nhật lại DataSource bằng cách chuyển DataView thành DataTable
            gridDsThuchi.DataSource = dv.ToTable(); // Dùng ToTable để chuyển DataView thành DataTable
        }

        private void LocTheoLoaiPhieu()
        {
            
            DataView dv = ((DataTable)gridDsThuchi.DataSource).DefaultView;
            LoadReceipt();

            // Lọc dữ liệu theo loại phiếu
            if (cboLoaiPhieu.Text == "Tất cả")
            {
                dv.RowFilter = "";  // Không áp dụng bộ lọc nếu chọn "Tất cả"
            }
            else if (cboLoaiPhieu.Text == "Phiếu thu")
            {
                dv.RowFilter = "[Loại phiếu] LIKE '%Phiếu thu%'";
            }
            else 
            {
                dv.RowFilter = "[Loại phiếu] LIKE '%Phiếu chi%'";
            }

            // Cập nhật lại DataSource với bộ lọc
            gridDsThuchi.DataSource = dv.ToTable();  // Dùng ToTable để chuyển DataView thành DataTable
        }


    }
}
