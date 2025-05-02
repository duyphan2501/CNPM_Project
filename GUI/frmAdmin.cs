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
            lblHovaTen.Text = Program.account.Rows[0]["HoTen"].ToString();
            lblVaiTro.Text = Program.account.Rows[0]["VaiTro"].ToString();

            pnlKho.Height = btnDashboard.Height + 31;
            pnlBaocaoTK.Height = btnDashboard.Height + 31;
            General.SetFullScreen(this);
            //pnlBanHang.Visible = false;
            SetActiveButton(btnDashboard);
            ShowFormInPanel(new frmDashboard());
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
            clickedButton.FillColor = Color.Orange;
            clickedButton.FillColor2 = Color.Orange;
            clickedButton.ForeColor = Color.Black;
            clickedButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        }




        private void btnLoinhuan_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnLoinhuan);
            ShowFormInPanel(new frmLoiNhuan());
        }

        private void btnMathangbanchay_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMathangbanchay);
            ShowFormInPanel(new frmHangBanChay());
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
                isOpenBaocao = true;
                for (int i = pnlBaocaoTK.Height; i <= (4 * btnBaocaoTK.Height) + 37; i += 10)
                {
                    pnlBaocaoTK.Height = i;
                    await Task.Delay(1);         // Dừng 5ms để tạo hiệu ứng mượt
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
            ShowFormInPanel(new frmThucdon());
        }

        private void ShowFormInPanel(Form form)
        {
            // Đóng và giải phóng form cũ nếu có
            foreach (Control ctrl in pnlFormcon.Controls)
            {
                if (ctrl is Form oldForm)
                {
                    oldForm.Close();
                    oldForm.Dispose();
                }
            }

            // Xóa tất cả controls trong panel
            pnlFormcon.Controls.Clear();

            // Cấu hình form mới
            form.TopLevel = false;                         // Không cho form là cửa sổ độc lập
            form.FormBorderStyle = FormBorderStyle.None;   // Bỏ viền form
            form.Dock = DockStyle.Fill;                    // Chiếm toàn bộ panel

            // Thêm form vào panel
            pnlFormcon.Controls.Add(form);

            // Hiển thị form mới
            form.BringToFront();    // Đảm bảo form mới sẽ hiển thị lên trên
            form.Show();            // Hiển thị form mới
        }



        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnTaiKhoan);
            ShowFormInPanel(new frmTaiKhoan());
        }



        private void btnThuchi_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnThuchi);
            ShowFormInPanel(new frmThuChi());
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTonkho_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnTonkho);
            ShowFormInPanel(new frmKho());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDashboard);
            ShowFormInPanel(new frmDashboard());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDonHang);
            frmOrderList frmOrder = new frmOrderList("admin");
            ShowFormInPanel(frmOrder);
        }

        private void btnBaocaoketca_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnBaocaoketca);
            frmBaoCaoChotCa frm = new frmBaoCaoChotCa();
            ShowFormInPanel(frm);
        }
    }
}
