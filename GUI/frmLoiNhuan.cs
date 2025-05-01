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
using Microsoft.Data.SqlClient;

namespace GUI
{
    public partial class frmLoiNhuan : Form
    {
        public frmLoiNhuan()
        {
            InitializeComponent();
        }

        private void LoadDataAndCreateChart()
        {
            // Giả sử bạn đã có dữ liệu từ database
            DataTable data = new BUS_PhieuThuChi().LayDoanhThuTheoThang();

            // Kiểm tra xem có dữ liệu hay không
            if (data.Rows.Count > 0)
            {
                // Tạo các series cho Doanh thu và Chi phí
                Series revenueSeries = new Series("Doanh Thu")
                {
                    ChartType = SeriesChartType.Column,  // Biểu đồ dạng cột
                    Color = Color.Green,  // Màu xanh cho doanh thu
                    BorderWidth = 2  // Đặt độ dày cho đường biên của cột
                };

                Series costSeries = new Series("Chi Phí")
                {
                    ChartType = SeriesChartType.Column,  // Biểu đồ dạng cột
                    Color = Color.Red,  // Màu đỏ cho chi phí
                    BorderWidth = 2  // Đặt độ dày cho đường biên của cột
                };

                // Duyệt qua từng dòng trong DataTable và thêm dữ liệu vào các series
                foreach (DataRow row in data.Rows)
                {
                    int month = Convert.ToInt32(row["Thang"]);
                    decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                    decimal chiPhi = Convert.ToDecimal(row["ChiPhi"]);

                    // Thêm dữ liệu vào các Series tương ứng
                    revenueSeries.Points.AddXY(month, doanhThu);
                    costSeries.Points.AddXY(month, chiPhi);
                }

                // Tạo biểu đồ mới
                Chart chartRevenueCost = new Chart
                {
                    Dock = DockStyle.Fill  // Biểu đồ sẽ tự động điều chỉnh kích thước theo form
                };

                // Thêm ChartArea vào biểu đồ
                ChartArea chartArea = new ChartArea("MainArea")
                {
                    AxisX = { Title = "Tháng", Interval = 1 },  // Tùy chỉnh trục X (Tháng)
                    AxisY = { Title = "Số Tiền (VNĐ)", Minimum = 0 }  // Tùy chỉnh trục Y (Số Tiền)
                };

                chartRevenueCost.ChartAreas.Add(chartArea);

                // Thêm các series vào biểu đồ
                chartRevenueCost.Series.Clear();
                chartRevenueCost.Series.Add(revenueSeries);
                chartRevenueCost.Series.Add(costSeries);

                // Thêm chú thích cho biểu đồ
                chartRevenueCost.Legends.Add(new Legend("MainLegend")
                {
                    Docking = Docking.Top,  // Chú thích sẽ nằm phía trên biểu đồ
                    Alignment = StringAlignment.Center  // Căn giữa chú thích
                });

                // Cải thiện khả năng hiển thị điểm trên biểu đồ (Hiển thị giá trị mỗi cột)
                revenueSeries.IsValueShownAsLabel = true;  // Hiển thị giá trị cho doanh thu
                costSeries.IsValueShownAsLabel = true;  // Hiển thị giá trị cho chi phí

                // Thêm biểu đồ vào Form
                this.Controls.Add(chartRevenueCost);

                // Thông báo khi vẽ thành công
                MessageBox.Show("Biểu đồ đã được vẽ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu không có dữ liệu, thông báo cho người dùng
                MessageBox.Show("Không có dữ liệu để vẽ biểu đồ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void frmLoiNhuan_Load(object sender, EventArgs e)
        {
            LoadDataAndCreateChart();
        }
    }
}
