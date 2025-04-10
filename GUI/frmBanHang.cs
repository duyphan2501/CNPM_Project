using GUI.components;
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

namespace GUI
{
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }


        private void frmBanHang_Load(object sender, EventArgs e)
        {
            int widthScreen = Screen.PrimaryScreen.Bounds.Width;
            int heightScreen = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(widthScreen, heightScreen);
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, pnlDonHangItem, new object[] { true });
            for (int i = 0; i < 7; i++)
            {
                InvoiceItem item = new InvoiceItem("cafe sữa", 12000, 2);
                pnlDonHangItem.Controls.Add(item);
            }

            for (int i = 0; i < 10; i++)
            {
                Widget widget = new Widget();
                ProductCategory category = new ProductCategory();
                pnlProductCategory.Controls.Add(category);
                pnlThucDon.Controls.Add(widget);
            }

        }
    }
}
