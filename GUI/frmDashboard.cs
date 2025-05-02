using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BUS;

namespace GUI
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            DataTable thuChi = new BUS_PhieuThuChi().SelectThuChiTrongNgay();
            DataTable donHang = new BUS_DonHang().GetDanhSachDonHangTrongNgay();
            DataTable donDaThanhToan = new BUS_DonHang().GetHoaDonDaThanhToanTrongNgay();
            DataTable nguyenLieu = new BUS_NguyenLieu().SelectNguyenLieu();

            // Kiểm tra null trước khi gán giá trị
            int doanhThu = thuChi.Rows.Count > 0 && !DBNull.Value.Equals(thuChi.Rows[0]["DoanhThu"])
                            ? Convert.ToInt32(thuChi.Rows[0]["DoanhThu"]) : 0;
            int chiPhi = thuChi.Rows.Count > 0 && !DBNull.Value.Equals(thuChi.Rows[0]["ChiPhi"])
                            ? Convert.ToInt32(thuChi.Rows[0]["ChiPhi"]) : 0;

            lblDoanhThu.Text = doanhThu.ToString("N0");
            lblChiPhi.Text = chiPhi.ToString("N0");
            lblLoiNhuan.Text = (doanhThu - chiPhi).ToString("N0");

            lblSoDonHang.Text = donHang.Rows.Count.ToString();

            // Tính tổng tiền đơn hàng
            int tienDonHang = donHang.Rows.Cast<DataRow>()
                .Where(row => row["TongTien"] != DBNull.Value) // Kiểm tra null
                .Sum(row => Convert.ToInt32(row["TongTien"]));

            lblDonHang.Text = tienDonHang.ToString("N0");

            lblSoDHDaTT.Text = donDaThanhToan.Rows.Count.ToString();

            // Tính tổng tiền đã thanh toán
            int tienDaThanhToan = donDaThanhToan.Rows.Cast<DataRow>()
                .Where(row => row["TongTien"] != DBNull.Value) // Kiểm tra null
                .Sum(row => Convert.ToInt32(row["TongTien"]));

            lblDaThanhToan.Text = tienDaThanhToan.ToString("N0");

            // Lấy số đơn hàng đang phục vụ
            int soDHDangPV = donHang.Rows.Count - donDaThanhToan.Rows.Count;
            lblSoDHDangPV.Text = soDHDangPV.ToString();
            lblDangPhucVu.Text = (tienDonHang - tienDaThanhToan).ToString("N0");

            // Tính tổng giá trị tồn kho = SoLuongTon * GiaNhap
            int gtTonKho = nguyenLieu.Rows.Cast<DataRow>()
                .Where(row => row["SoLuongTon"] != DBNull.Value && row["GiaNhap"] != DBNull.Value)
                .Sum(row => Convert.ToInt32(row["SoLuongTon"]) * Convert.ToInt32(row["GiaNhap"]));

            // Đếm số nguyên liệu dưới mức tối thiểu
            int duoiToiThieu = nguyenLieu.Rows.Cast<DataRow>()
                .Count(row =>
                    row["SoLuongTon"] != DBNull.Value && row["MucToiThieu"] != DBNull.Value &&
                    Convert.ToInt32(row["SoLuongTon"]) < Convert.ToInt32(row["MucToiThieu"])
                );

            // Đếm số nguyên liệu vượt mức ổn định
            int vuotDinhMuc = nguyenLieu.Rows.Cast<DataRow>()
                .Count(row =>
                    row["SoLuongTon"] != DBNull.Value && row["MucOnDinh"] != DBNull.Value &&
                    Convert.ToInt32(row["SoLuongTon"]) > Convert.ToInt32(row["MucOnDinh"])
                );

            // Gán vào các label
            lblGiaTriTon.Text = gtTonKho.ToString("N0");
            lblToiThieu.Text = duoiToiThieu.ToString();
            lblDinhMuc.Text = vuotDinhMuc.ToString();

            KhoiTaoBieuDoDonHang();

        }

        private void KhoiTaoBieuDoDonHang()
        {
            pnlBieuDo.Controls.Clear();

            Chart chartDonHang = new Chart();
            chartDonHang.Dock = DockStyle.Fill;

            // Vùng biểu đồ
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Giờ trong ngày";
            chartArea.AxisY.Title = "Số đơn hàng";
            chartArea.AxisX.TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10);
            chartDonHang.ChartAreas.Add(chartArea);

            // Series dữ liệu
            Series series = new Series("Số đơn");
            series.ChartType = SeriesChartType.Column;
            series.XValueType = ChartValueType.Int32;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black;
            series.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            series.Color = Color.DeepSkyBlue; // Màu xanh biển

            chartDonHang.Series.Add(series);

            // Tiêu đề biểu đồ
            Title title = new Title("Thống kê đơn hàng theo giờ", Docking.Top, new Font("Segoe UI", 14, FontStyle.Bold), Color.Navy);
            chartDonHang.Titles.Add(title);

            // Thêm vào Panel
            pnlBieuDo.Controls.Add(chartDonHang);

            // Nạp dữ liệu
            LoadDuLieuBieuDo(chartDonHang);
        }



        private void LoadDuLieuBieuDo(Chart chart)
        {
            DataTable dt = new BUS_DonHang().GetThongKeDonHangTheoGio();

            Series series = chart.Series["Số đơn"];
            series.Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int gio = Convert.ToInt32(row["Gio"]);
                int soDon = Convert.ToInt32(row["SoDon"]);
                series.Points.AddXY(gio, soDon);
            }
        }

    }
}
