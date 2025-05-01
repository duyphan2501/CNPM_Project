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
            numSosanpham.Value = 5;
            ThongKeSanPham();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeSanPham();
        }

        private void ThongKeSanPham()
        {
            int soluong = (int)numSosanpham.Value;
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
            Chart pieChart = new Chart();
            pieChart.Dock = DockStyle.Fill;

            ChartArea chartArea = new ChartArea();
            pieChart.ChartAreas.Add(chartArea);

            Series pieSeries = new Series("Best Selling Products")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = false, // Không hiện gì trên lát
                BorderWidth = 2
            };

            foreach (DataRow row in data.Rows)
            {
                string productName = row["Tên sản phẩm"].ToString();
                decimal salesQuantity = Convert.ToDecimal(row["Tổng số lượng bán"]);

                pieSeries.Points.Add(Convert.ToDouble(salesQuantity));
                var dataPoint = pieSeries.Points[pieSeries.Points.Count - 1];

                dataPoint.Label = "#PERCENT"; // 👉 Chỉ hiện phần trăm trên lát
                dataPoint.LegendText = productName; // 👉 Chú thích chỉ hiện tên sản phẩm
                dataPoint.Font = new Font("Arial", 10, FontStyle.Bold); // 👁 Làm phần trăm rõ hơn
                dataPoint.LabelForeColor = Color.Black;
            }

            pieChart.Series.Add(pieSeries);

            pieChart.Titles.Add(new Title()
            {
                Text = "BIỂU ĐỒ TOP SẢN PHẨM BÁN CHẠY",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Alignment = ContentAlignment.TopCenter
            });

            // 👉 Chú thích nằm bên phải
            Legend legend = new Legend()
            {
                Docking = Docking.Bottom,
                Font = new Font("Arial", 11, FontStyle.Regular)
            };
            pieChart.Legends.Add(legend);

            pnlBieuDo.Controls.Clear();
            pnlBieuDo.Controls.Add(pieChart);
        }

    }
}
