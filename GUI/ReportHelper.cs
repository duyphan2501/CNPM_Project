using Microsoft.Reporting.NETCore;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public class ReportHelper
    {
        static string folderName = "Report";
        // Hàm render báo cáo RDLC thành hình ảnh (Bitmap)
        private static Bitmap RenderReportToImage(string reportPath, DataTable data)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var report = new LocalReport
            {
                ReportPath = Path.Combine(folderName, reportPath)
            };

            // Đảm bảo tên DataSource trùng với tên trong RDLC
            report.DataSources.Add(new ReportDataSource("DataSet_Invoice", data));

            try
            {
                var result = report.Render("Image", "<DeviceInfo><OutputFormat>PNG</OutputFormat><DPI>300</DPI></DeviceInfo>");
                using (var ms = new MemoryStream(result))
                {
                    return new Bitmap(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi render báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void PreviewReport(string reportPath, DataTable data)
        {
            var bitmap = RenderReportToImage(reportPath, data);
            if (bitmap == null)
            {
                MessageBox.Show("Không thể tạo hình ảnh báo cáo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            printDoc.PrintPage += (sender, e) =>
            {
                Rectangle pageBounds = e.PageBounds;
                e.Graphics.DrawImage(bitmap, pageBounds);
            };

            printDoc.EndPrint += (sender, e) =>
            {
                if (e.Cancel)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi in", "Lỗi in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            };

            try
            {
                using (PrintPreviewDialog previewDialog = new PrintPreviewDialog
                {
                    Document = printDoc
                })
                {
                    previewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xem trước in: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void PrintInvoice(string reportPath, DataTable data)
        {
            var bitmap = RenderReportToImage(reportPath, data);
            if (bitmap == null)
            {
                MessageBox.Show("Không thể tạo hình ảnh báo cáo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            printDoc.PrintPage += (sender, e) =>
            {
                Rectangle pageBounds = e.PageBounds;
                e.Graphics.DrawImage(bitmap, pageBounds);
            };

            printDoc.EndPrint += (sender, e) =>
            {
                if (e.Cancel)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi in", "Lỗi in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            };

            try
            {
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi in: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
