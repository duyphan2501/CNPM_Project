using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            pnlKho.Height = btnDashboard.Height + 31;
            pnlBaocaoTK.Height = btnDashboard.Height + 31;
        }


        private bool isOpenKho = false;    //Biến cờ để biết trạng thái xổ menu
        private async void btnKho_Click(object sender, EventArgs e)
        {

            if (pnlKho.Height > btnKho.Height + 40)
            {
                isOpenKho = true;
            }
            if (isOpenKho == false)
            {
                //btnKho.FillColor = Color.FromArgb(128, 64, 0);     //Tô màu nút đang được xổ
                isOpenKho = true;
                for (int i = pnlKho.Height; i <= (4 * btnKho.Height) + 31; i += 5)
                {
                    pnlKho.Height = i;
                    await Task.Delay(2);         // Dừng 5ms để tạo hiệu ứng mượt
                }
            }
            else
            {
                isOpenKho = false;
                pnlKho.Height = btnKho.Height + 31;
                //btnKho.FillColor = Color.FromArgb(212, 151, 96);   //Trở lại màu ban đầu khi tắt xổ
            }

        }

        private void btnLoinhuan_Click(object sender, EventArgs e)
        {

        }

        private void btnMathangbanchay_Click(object sender, EventArgs e)
        {

        }

        private void btnKiemkekho_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatnhapkho_Click(object sender, EventArgs e)
        {

        }



        private bool isOpenBaocao = false;
        private async void btnBaocaoTK_Click(object sender, EventArgs e)
        {
            if (pnlBaocaoTK.Height > btnBaocaoTK.Height + 40)
            {
                isOpenBaocao = true;
            }
            if (isOpenBaocao == false)
            {
                //btnKho.FillColor = Color.FromArgb(128, 64, 0);     //Tô màu nút đang được xổ
                isOpenKho = true;
                for (int i = pnlBaocaoTK.Height; i <= (3 * btnBaocaoTK.Height) + 31; i += 5)
                {
                    pnlBaocaoTK.Height = i;
                    await Task.Delay(2);         // Dừng 5ms để tạo hiệu ứng mượt
                }
            }
            else
            {
                isOpenBaocao = false;
                pnlBaocaoTK.Height = btnBaocaoTK.Height + 31;
                //btnKho.FillColor = Color.FromArgb(212, 151, 96);   //Trở lại màu ban đầu khi tắt xổ
            }

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlFormcon.Controls.Clear();
            frmThucdon frm = new frmThucdon();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            pnlFormcon.Controls.Clear();
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

        }

        private void btnXuatnhapkho_Click_1(object sender, EventArgs e)
        {
            pnlFormcon.Controls.Clear();
            frmXuatNhapKho frm = new frmXuatNhapKho();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

        }

        private void btnThuchi_Click(object sender, EventArgs e)
        {
            pnlFormcon.Controls.Clear();
            frmThuChi frm = new frmThuChi();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTonkho_Click(object sender, EventArgs e)
        {
            pnlFormcon.Controls.Clear();
            frmKho frm = new frmKho();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }
    }
}
