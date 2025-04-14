using Guna.UI2.WinForms;
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
    public partial class TheRung : UserControl
    {
        public event EventHandler theRung_Clicked;
        public string MaThe, SoThe;
        public int TrangThai;
        public TheRung()
        {
            InitializeComponent();
        }

        public TheRung(string soThe, string maThe, int trangThai)
        {
            InitializeComponent();
            btnTheRung.Text = soThe;
            MaThe = maThe;
            SoThe = soThe;
            TrangThai = trangThai;
            setColor();
        }

        private void btnTheRung_Click(object sender, EventArgs e)
        {
            theRung_Clicked?.Invoke(this, EventArgs.Empty);
        }

        public void setColor()
        {
            switch (TrangThai)
            {
                case 1: // Đang dùng
                    pnlSoThe.FillColor = Color.FromArgb(255, 255, 192);
                    break;
                case 2: // Hỏng
                    pnlSoThe.FillColor = Color.FromArgb(183, 68, 70);
                    break;
                default:// Rảnh
                    pnlSoThe.FillColor = Color.FromArgb(169, 228, 66);
                    break;
            }
        }
    }
}
