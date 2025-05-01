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
    public partial class frmHangBanChay : Form
    {
        BUS_SanPham sanpham = new BUS_SanPham("", "", "", null, 0, "");
        public frmHangBanChay()
        {
            InitializeComponent();
        }

        private void frmHangBanChay_Load(object sender, EventArgs e)
        {
            dateStop.Value = DateTime.Now;  // Đặt giá trị mặc định cho dateDenngay là ngày hiện tại 
            dateStart.Value = DateTime.Now.AddDays(-7); //mặc định là 7 ngày trước
            ThongKeSanPham(5);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy số lượng sản phẩm muốn thống kê
            int soluong = Convert.ToInt32(numSosanpham.Value);
            ThongKeSanPham(soluong);
        }

        private void ThongKeSanPham(int soluong)
        {
            DateTime tungay = dateStart.Value.Date;
            DateTime denngay = dateStop.Value.Date;

            // Lấy dữ liệu sản phẩm bán chạy từ bus
            DataTable dt = sanpham.GetBestSellingProductst(soluong, tungay, denngay);

            // Hiển thị dữ liệu vào DataGridView (gridHangbanchay)
            DataView dv = dt.DefaultView;
            gridHangbanchay.DataSource = dv.ToTable();

            // Vẽ biểu đồ pie
            DrawPieChart(dt);
        }

        private void DrawPieChart(DataTable data)
        {
            // Tạo biểu đồ pie
            Chart pieChart = new Chart();
            pieChart.Dock = DockStyle.Fill; // Đảm bảo biểu đồ chiếm hết diện tích trong Panel

            // Tạo một ChartArea cho biểu đồ
            ChartArea chartArea = new ChartArea();
            pieChart.ChartAreas.Add(chartArea);

            // Thêm các dữ liệu vào biểu đồ pie
            Series pieSeries = new Series("Best Selling Products")
            {
                ChartType = SeriesChartType.Pie,  // Loại biểu đồ là Pie
                IsValueShownAsLabel = true,  // Hiển thị giá trị trên mỗi phần của pie
                BorderWidth = 2 
            };

            foreach (DataRow row in data.Rows)
            {
                string productName = row["Tên sản phẩm"].ToString();  // Tên sản phẩm (tên cột trong DataTable)
                decimal salesQuantity = Convert.ToDecimal(row["Tổng số lượng bán"]);  // Số lượng bán được (tên cột trong DataTable)
                pieSeries.Points.AddXY(productName, salesQuantity);  // Thêm dữ liệu vào Pie chart
            }

            // Thêm Series vào biểu đồ
            pieChart.Series.Add(pieSeries);

            // Thêm biểu đồ vào Panel
            pnlBieuDo.Controls.Clear();  // Xóa các điều khiển cũ trong Panel trước khi vẽ mới
            pnlBieuDo.Controls.Add(pieChart);  // Thêm biểu đồ mới vào Panel
        }
    }
}
