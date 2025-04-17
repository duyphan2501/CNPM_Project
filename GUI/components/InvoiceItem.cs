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
        public string TenMon;
        public event EventHandler XoaItemClicked;
        public event EventHandler SoLuongChanged;

        public InvoiceItem()
        {
            InitializeComponent();
        }

        public InvoiceItem(string tenmon, int dongia, int soluong)
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
        }

        public void IncreaseQuantity()
        {
            numSoluong.Value += 1;
        }

        private void picDeleteItem_Click(object sender, EventArgs e)
        {
            // Gọi sự kiện để báo về Form cha
            XoaItemClicked?.Invoke(this, EventArgs.Empty);

            // Gọi sự kiện khi số lượng thay đổi
            SoLuongChanged?.Invoke(this, EventArgs.Empty);
        }

        private void numSoluong_ValueChanged(object sender, EventArgs e)
        {
            // Tính thành tiền và hiển thị theo định dạng "N0" (hàng nghìn)
            lblThanhtien.Text = ThanhTien().ToString("N0");

            // Gọi sự kiện khi số lượng thay đổi
            SoLuongChanged?.Invoke(this, EventArgs.Empty);
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
