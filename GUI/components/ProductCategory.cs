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
    public partial class ProductCategory : UserControl
    {
        public string MaLoai;
        public event EventHandler LoaiSPClicked;
        public ProductCategory()
        {
            InitializeComponent();
        }

        public ProductCategory(string tenloai, string maloai)
        {
            InitializeComponent();
            btnTenLoai.Text = tenloai;
            MaLoai = maloai;
        }

        // Phương thức để thay đổi màu sắc khi được active
        public void SetActive(bool isActive)
        {
            btnTenLoai.Checked = isActive;
        }
    }
}
