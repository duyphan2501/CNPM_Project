using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.components
{
    public partial class InvoiceItem : UserControl
    {
        public string MaSanPham { get; set; }
        public string TenMon { get; set; }
        public int DonGia { get; set; }
        public int SoLuong
        {
            get { return (int)numSoluong.Value; }
            set { numSoluong.Value = value; }
        }

        public event EventHandler XoaItemClicked;
        public event EventHandler SoLuongChanged;

        public InvoiceItem()
        {
            InitializeComponent();
        }

        public InvoiceItem(string tenmon, int dongia, int soluong, string masp)
        {
            InitializeComponent();
            // Tăng hiệu năng vẽ control
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            lblTenMon.Text = tenmon;
            lblDongia.Text = dongia.ToString("N0"); // thêm dấu thập phân
            numSoluong.Value = soluong;
            lblThanhtien.Text = ThanhTien().ToString("N0");
            TenMon = tenmon;
            DonGia = dongia;
            MaSanPham = masp;
        }

        private void picDeleteItem_Click(object sender, EventArgs e)
        {
            // Gọi sự kiện để báo về Form cha
            XoaItemClicked?.Invoke(this, EventArgs.Empty);
            
            // Gọi sự kiện khi số lượng thay đổi
            SoLuongChanged?.Invoke(this, EventArgs.Empty);
        }

        private bool isHandlingValueChanged = false;  // Cờ để kiểm tra việc thay đổi giá trị

        // Sự kiện khi giá trị của NumericUpDown thay đổi
        private void numSoluong_ValueChanged(object sender, EventArgs e)
        {
            // Nếu chúng ta đang xử lý sự kiện, tránh tiếp tục xử lý
            if (isHandlingValueChanged) return;
            if (numSoluong.Value < 1)
            {
                numSoluong.Value = 1;  // Giảm số lượng
            }
            UpdateThanhTien();  // Cập nhật lại giá trị thành tiền

            // Gọi sự kiện khi giá trị thay đổi
            SoLuongChanged?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateThanhTien()
        {
            // Cập nhật lại giá trị thành tiền
            lblThanhtien.Text = ThanhTien().ToString("N0");
        }

        // Giảm số lượng
        public void DecreaseQuantity()
        {
            if (numSoluong.Value > 1)
            {
                numSoluong.Value -= 1;  // Giảm số lượng
            }
        }

        // Tăng số lượng
        public void IncreaseQuantity()
        {
            // Tạm ngừng sự kiện khi thay đổi giá trị
            isHandlingValueChanged = true;

            numSoluong.Value += 1;  // Tăng số lượng
            // Cập nhật lại giá trị thành tiền

            // Đặt lại cờ để tiếp tục xử lý sự kiện
            isHandlingValueChanged = false;
        }


        public int ThanhTien()
        {
            int soluong = (int)numSoluong.Value;

            // Loại bỏ dấu phân cách hàng nghìn (dấu ,)
            int dongia = Int32.Parse(lblDongia.Text.Replace(",", ""));

            return dongia * soluong;
        }

    }
}
