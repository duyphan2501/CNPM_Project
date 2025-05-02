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

        DataTable data;
        private void frmLoiNhuan_Load(object sender, EventArgs e)
        {
            LoadCboKieuThongKe();
            dtpTuNgay.Value = DateTime.Now.AddDays(-120);
            dtpDenNgay.Value = DateTime.Now.AddDays(1);
            LoadDataAndCreateChart();
        }

        private void LoadCboKieuThongKe()
        {
            cboKieuThongKe.Items.Clear();
            cboKieuThongKe.Items.Add("Tháng");
            cboKieuThongKe.Items.Add("Quý");
            cboKieuThongKe.Items.Add("Năm");
            cboKieuThongKe.SelectedIndex = 0;
        }

        private void LoadDataAndCreateChart()
        {
            // Xoá các điều khiển cũ
            pnlBieuDo.Controls.Clear();

            // Lấy dữ liệu từ database
            LayDuLieuThongKe();

            if (data.Rows.Count > 0)
            {
                // Series 1: Doanh Thu (cột)
                Series revenueSeries = new Series("Doanh Thu")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.RoyalBlue,
                    BorderWidth = 2,
                    IsValueShownAsLabel = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                // Series 2: Chi Phí (cột)
                Series costSeries = new Series("Chi Phí")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.Orange,
                    BorderWidth = 2,
                    IsValueShownAsLabel = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                // Series 3: Lợi Nhuận (đường)
                Series profitSeries = new Series("Lợi Nhuận")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.ForestGreen,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 8,
                    MarkerColor = Color.ForestGreen,
                    IsValueShownAsLabel = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                decimal minValue = 0;

                foreach (DataRow row in data.Rows)
                {
                    string label = row["ThoiGian"].ToString();
                    decimal doanhThu = Convert.ToDecimal(row["DoanhThuDonHang"]) + Convert.ToDecimal(row["DoanhThuKhac"]);
                    decimal chiPhi = Convert.ToDecimal(row["ChiPhi"]);
                    decimal loiNhuan = doanhThu - chiPhi;
                    
                    revenueSeries.Points.AddXY(label, doanhThu);
                    costSeries.Points.AddXY(label, chiPhi);
                    profitSeries.Points.AddXY(label, loiNhuan);

                    if (loiNhuan < minValue)
                        minValue = loiNhuan;
                }

                // Tạo Chart
                Chart chart = new Chart { Dock = DockStyle.Fill };

                ChartArea chartArea = new ChartArea("MainArea")
                {
                    AxisX =
                {
                    Title = "Thời gian",
                    Interval = 1,
                    TitleFont = new Font("Segoe UI", 12, FontStyle.Bold),
                    LabelStyle = { Font = new Font("Segoe UI", 10), Angle = -45 },
                    MajorGrid = { Enabled = false }
                },
                    AxisY =
                {
                    Title = "Số Tiền (VNĐ)",
                    Minimum = (double)Math.Floor(minValue),
                    TitleFont = new Font("Segoe UI", 12, FontStyle.Bold),
                    LabelStyle = { Font = new Font("Segoe UI", 10) },
                    MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dash }
                }
                };

                chart.ChartAreas.Add(chartArea);

                // Gán ChartArea cho series và ưu tiên vẽ đường sau
                revenueSeries.ChartArea = "MainArea";
                costSeries.ChartArea = "MainArea";
                profitSeries.ChartArea = "MainArea";
                profitSeries["DrawOnTop"] = "True";

                chart.Series.Add(revenueSeries);
                chart.Series.Add(costSeries);
                chart.Series.Add(profitSeries);

                chart.Legends.Add(new Legend("MainLegend")
                {
                    Docking = Docking.Top,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                });

                pnlBieuDo.Controls.Add(chart);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu trong khoảng thời gian đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDataAndCreateChart();
        }

        private void LayDuLieuThongKe()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            string kieu = cboKieuThongKe.SelectedItem?.ToString();

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Từ ngày không được lớn hơn Đến ngày!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            data = new BUS_PhieuThuChi().LayDuLieuThongKe(kieu, tuNgay, denNgay);

            if (data.Rows.Count > 0)
            {
                int tongDoanhThuDonHang = 0;
                decimal tongThuKhac = 0;
                decimal tongChiPhi = 0;
                int tongSoHoaDon = 0;

                foreach (DataRow row in data.Rows)
                {
                    int doanhThuDonHang = row["DoanhThuDonHang"] != DBNull.Value ? Convert.ToInt32(row["DoanhThuDonHang"]) : 0;
                    decimal thuKhac = row["DoanhThuKhac"] != DBNull.Value ? Convert.ToDecimal(row["DoanhThuKhac"]) : 0;
                    decimal chiPhi = row["ChiPhi"] != DBNull.Value ? Convert.ToDecimal(row["ChiPhi"]) : 0;
                    int soHoaDon = row["SoHoaDon"] != DBNull.Value ? Convert.ToInt32(row["SoHoaDon"]) : 0;

                    tongDoanhThuDonHang += doanhThuDonHang;
                    tongThuKhac += thuKhac;
                    tongChiPhi += chiPhi;
                    tongSoHoaDon += soHoaDon;
                }

                decimal tongThu = tongDoanhThuDonHang + tongThuKhac;
                decimal loiNhuan = tongThu - tongChiPhi;

                lblDoanhThu.Text = tongDoanhThuDonHang.ToString("N0");
                lblThuKhac.Text = tongThuKhac.ToString("N0");
                lblChiPhi.Text = tongChiPhi.ToString("N0");
                lblSoHoaDon.Text = tongSoHoaDon.ToString();
                lblLoiNhuan.Text = loiNhuan.ToString("N0");
            }
            else
            {
                // Trường hợp không có dữ liệu: reset về 0
                lblDoanhThu.Text = "0";
                lblThuKhac.Text = "0";
                lblChiPhi.Text = "0";
                lblSoHoaDon.Text = "0";
                lblLoiNhuan.Text = "0";
            }
        }
    }
}
