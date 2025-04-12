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
        public ProductCategory()
        {
            InitializeComponent();
        }

        public ProductCategory(string tenloai)
        {
            InitializeComponent();
            btnTenLoai.Text = tenloai;
        }
    }
}
