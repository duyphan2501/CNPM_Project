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
            lblDongia.Text = dongia.ToString();
            numSoluong.Value = soluong;
            lblThanhtien.Text = (dongia * soluong).ToString();
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
        }
    }
}
