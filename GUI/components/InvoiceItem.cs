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
        }
    }
}
