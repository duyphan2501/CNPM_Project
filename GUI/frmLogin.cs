using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (!File.Exists("config.txt"))
            {
                this.Hide();
                frmConfig f = new frmConfig();
                f.ShowDialog();
            }
            txtUsername.Focus();
        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
            // hiện viền button khi được tab đến
            btnLogin.BorderThickness = 2;
        }

        private void btnLogin_Leave(object sender, EventArgs e)
        {
            // xoá viền button không được tab đến
            btnLogin.BorderThickness = 0;
        }

        private void picShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            // xoá passworChar khi giữ chuột
            txtPassword.PasswordChar = '\0';
        }

        private void picShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            // đặt lại passwordchar khi thả chuột
            txtPassword.PasswordChar = '•';
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
