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
    public partial class frmLichSuXuatNhap : Form
    {
        BUS_PhieuNhapKho phieunhap = new BUS_PhieuNhapKho("", "", DateTime.Now, "");
        BUS_PhieuXuatKho phieuxuat = new BUS_PhieuXuatKho("", "", DateTime.Now, "");
        BUS_ChiTietNhapKho chitietnhap = new BUS_ChiTietNhapKho("", "", 0, 0);
        BUS_ChiTietXuatKho chitietxuat = new BUS_ChiTietXuatKho("", "", 0);
        public frmLichSuXuatNhap()
        {
            InitializeComponent();
        }



        public void LoadReceipt() //danh sách lịch sử
        {

            if (cboLoaiphieu.Text == "Phiếu nhập")
            {
                //BUS_PhieuNhapKho phieunhap = new BUS_PhieuNhapKho("", "", DateTime.Now, "");
                //gridDsPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridLichsu.DataSource = phieunhap.LoadGoodsReceipt();
            }
            else
            {
                gridLichsu.DataSource = phieuxuat.LoadDeliveryReceipt();
            }
            gridLichsu.RowTemplate.Height = 50;
        }

        private void cboLoaiphieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReceipt();
            LocTheoNgay();
        }

        private void frmLichSuXuatNhap_Load(object sender, EventArgs e)
        {
            //cboLoaiphieu.Text = "Phiếu nhập";
            //LoadReceipt();

            dateTungay.ValueChanged += Date_ValueChanged;
            dateDenngay.ValueChanged += Date_ValueChanged;
            dateDenngay.Value = DateTime.Now;   // Đặt giá trị mặc định cho dateDenngay là ngày hiện tại
            dateTungay.Value = DateTime.Now.AddDays(-7); //mặc định là 7 ngày trước
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            LoadReceipt();
            LocTheoNgay();
        }

        private void LocTheoNgay()
        {
            DateTime tuNgay = dateTungay.Value.Date;
            DateTime denNgay = dateDenngay.Value.Date;  // Không cần thay đổi giờ

            LoadReceipt();
            DataView dv = ((DataTable)gridLichsu.DataSource).DefaultView;

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
            gridLichsu.DataSource = dv.ToTable(); // Dùng ToTable để chuyển DataView thành DataTable
        }


    }
}
