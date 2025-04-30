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
            General.SetFullScreen(this);
            //pnlBanHang.Visible = false;

        }

        private void ResetAllButtons(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Bỏ qua Panel có tên là pnlFormcon
                if (control is Panel panel && panel.Name == "pnlFormcon")
                {
                    continue; // Bỏ qua control này và tiếp tục vòng lặp
                }

                if (control is Guna.UI2.WinForms.Guna2GradientButton btn)
                {
                    btn.FillColor = Color.Transparent;
                    btn.FillColor2 = Color.Transparent;
                    btn.ForeColor = Color.Black;
                }

                // Gọi lại hàm nếu control có các controls con
                if (control.HasChildren)
                {
                    ResetAllButtons(control);
                }
            }
        }

        private void SetActiveButton(Guna.UI2.WinForms.Guna2GradientButton clickedButton)
        {
            ResetAllButtons(this);

            // Gán màu Gradient cho nút đang được chọn
            clickedButton.FillColor = Color.FromArgb(248, 92, 7);     // Màu trái
            clickedButton.FillColor2 = Color.FromArgb(255, 128, 0);   // Màu phải
            clickedButton.ForeColor = Color.Black;
            clickedButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        }


        private bool isOpenKho = false;    //Biến cờ để biết trạng thái xổ menu
        private async void btnKho_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnKho);
            if (pnlKho.Height > btnKho.Height + 40)
            {
                isOpenKho = true;
            }
            if (isOpenKho == false)
            {
                //btnKho.FillColor = Color.FromArgb(128, 64, 0);     //Tô màu nút đang được xổ
                isOpenKho = true;
                for (int i = pnlKho.Height; i <= (3 * btnKho.Height) + 37; i += 10)
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
            SetActiveButton(btnLoinhuan);
        }

        private void btnMathangbanchay_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMathangbanchay);
            pnlFormcon.Controls.Clear();
            frmHangBanChay frm = new frmHangBanChay();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

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
            SetActiveButton(btnBaocaoTK);
            if (pnlBaocaoTK.Height > btnBaocaoTK.Height + 40)
            {
                isOpenBaocao = true;
            }
            if (isOpenBaocao == false)
            {
                //btnKho.FillColor = Color.FromArgb(128, 64, 0);     //Tô màu nút đang được xổ
                isOpenKho = true;
                for (int i = pnlBaocaoTK.Height; i <= (3 * btnBaocaoTK.Height) + 37; i += 10)
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
            SetActiveButton(btnThucDon);
            pnlFormcon.Controls.Clear();
            frmThucdon frm = new frmThucdon();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnTaiKhoan);
            pnlFormcon.Controls.Clear();
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

        }

        private void btnXuatnhapkho_Click_1(object sender, EventArgs e)
        {
            SetActiveButton(btnXuatnhapkho);
            pnlFormcon.Controls.Clear();
            frmXuatNhapKho frm = new frmXuatNhapKho();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

        }

        private void btnThuchi_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnThuchi);
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
            SetActiveButton(btnTonkho);
            pnlFormcon.Controls.Clear();
            frmKho frm = new frmKho();
            frm.TopLevel = false;
            pnlFormcon.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDashboard);
        }

        private void btnBanhang_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnBanhang);
        }
    }
}
