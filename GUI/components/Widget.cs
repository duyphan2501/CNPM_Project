using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.components
{
    public partial class Widget : UserControl
    {
        public event EventHandler ThemSanPhamClicked;
        public string TenSanPham;
        public int GiaSanPham;
        public Widget()
        {
            InitializeComponent();
        }

        public Widget(byte[] hinhAnhSP, string tenSanPham, int giaSanPham)
        {
            InitializeComponent();
            picSanPham.Image = General.ByteArrayToImage(hinhAnhSP);
            lblTenSanPham.Text = tenSanPham;
            lblGiaSanPham.Text = giaSanPham.ToString();
            TenSanPham = tenSanPham;
            GiaSanPham = giaSanPham;
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            //Gọi event để báo về Form cha
            ThemSanPhamClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
