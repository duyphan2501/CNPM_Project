﻿namespace GUI
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label2 = new Label();
            lblForgotpassword = new Label();
            btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            picShowPass = new Guna.UI2.WinForms.Guna2PictureBox();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            pi = new Guna.UI2.WinForms.Guna2PictureBox();
            messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picShowPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pi).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(244, 103, 0);
            label2.Location = new Point(22, 18);
            label2.Name = "label2";
            label2.Size = new Size(392, 41);
            label2.TabIndex = 10;
            label2.Text = "ĐĂNG NHẬP TÀI KHOẢN";
            // 
            // lblForgotpassword
            // 
            lblForgotpassword.AutoSize = true;
            lblForgotpassword.Cursor = Cursors.Hand;
            lblForgotpassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblForgotpassword.ForeColor = Color.DarkGray;
            lblForgotpassword.Location = new Point(249, 226);
            lblForgotpassword.Name = "lblForgotpassword";
            lblForgotpassword.Size = new Size(165, 28);
            lblForgotpassword.TabIndex = 4;
            lblForgotpassword.Text = "Đặt lại mật khẩu";
            lblForgotpassword.Click += lblForgotpassword_Click;
            // 
            // btnLogin
            // 
            btnLogin.AutoRoundedCorners = true;
            btnLogin.CustomizableEdges = customizableEdges1;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(244, 103, 0);
            btnLogin.FillColor2 = Color.DarkOrange;
            btnLogin.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(26, 305);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogin.Size = new Size(388, 65);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            btnLogin.Enter += btnLogin_Enter;
            btnLogin.Leave += btnLogin_Leave;
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.BackColor = Color.White;
            guna2GradientPanel1.Controls.Add(picShowPass);
            guna2GradientPanel1.Controls.Add(txtUsername);
            guna2GradientPanel1.Controls.Add(txtPassword);
            guna2GradientPanel1.Controls.Add(btnLogin);
            guna2GradientPanel1.Controls.Add(lblForgotpassword);
            guna2GradientPanel1.Controls.Add(label2);
            guna2GradientPanel1.CustomizableEdges = customizableEdges9;
            guna2GradientPanel1.Location = new Point(361, 58);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2GradientPanel1.Size = new Size(436, 403);
            guna2GradientPanel1.TabIndex = 16;
            // 
            // picShowPass
            // 
            picShowPass.BackColor = Color.Transparent;
            picShowPass.Cursor = Cursors.Hand;
            picShowPass.CustomizableEdges = customizableEdges3;
            picShowPass.FillColor = Color.FromArgb(229, 229, 229);
            picShowPass.Image = (Image)resources.GetObject("picShowPass.Image");
            picShowPass.ImageRotate = 0F;
            picShowPass.Location = new Point(370, 174);
            picShowPass.Name = "picShowPass";
            picShowPass.ShadowDecoration.CustomizableEdges = customizableEdges4;
            picShowPass.Size = new Size(35, 23);
            picShowPass.SizeMode = PictureBoxSizeMode.Zoom;
            picShowPass.TabIndex = 19;
            picShowPass.TabStop = false;
            picShowPass.UseTransparentBackground = true;
            picShowPass.MouseDown += picShowPass_MouseDown;
            picShowPass.MouseUp += picShowPass_MouseUp;
            // 
            // txtUsername
            // 
            txtUsername.Animated = true;
            txtUsername.BorderColor = Color.FromArgb(229, 229, 229);
            txtUsername.BorderRadius = 8;
            txtUsername.Cursor = Cursors.IBeam;
            txtUsername.CustomizableEdges = customizableEdges5;
            txtUsername.DefaultText = "";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.FillColor = Color.FromArgb(229, 229, 229);
            txtUsername.FocusedState.BorderColor = Color.FromArgb(244, 103, 0);
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.ForeColor = Color.Black;
            txtUsername.HoverState.BorderColor = Color.FromArgb(244, 103, 0);
            txtUsername.Location = new Point(26, 90);
            txtUsername.Margin = new Padding(2, 4, 2, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderForeColor = Color.Silver;
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtUsername.Size = new Size(388, 47);
            txtUsername.TabIndex = 0;
            txtUsername.KeyDown += txtPassword_KeyDown;
            // 
            // txtPassword
            // 
            txtPassword.Animated = true;
            txtPassword.BorderColor = Color.FromArgb(229, 229, 229);
            txtPassword.BorderRadius = 8;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.CustomizableEdges = customizableEdges7;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FillColor = Color.FromArgb(229, 229, 229);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(244, 103, 0);
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.HoverState.BorderColor = Color.FromArgb(244, 103, 0);
            txtPassword.Location = new Point(26, 161);
            txtPassword.Margin = new Padding(2, 4, 2, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.PlaceholderForeColor = Color.Silver;
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPassword.Size = new Size(388, 47);
            txtPassword.TabIndex = 1;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.CustomizableEdges = customizableEdges11;
            guna2ControlBox1.FillColor = Color.White;
            guna2ControlBox1.IconColor = Color.Black;
            guna2ControlBox1.Location = new Point(779, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2ControlBox1.Size = new Size(36, 29);
            guna2ControlBox1.TabIndex = 17;
            guna2ControlBox1.Click += guna2ControlBox1_Click;
            // 
            // pi
            // 
            pi.CustomizableEdges = customizableEdges13;
            pi.Image = Properties.Resources.banner_login;
            pi.ImageRotate = 0F;
            pi.Location = new Point(12, -6);
            pi.Name = "pi";
            pi.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pi.Size = new Size(343, 513);
            pi.SizeMode = PictureBoxSizeMode.CenterImage;
            pi.TabIndex = 18;
            pi.TabStop = false;
            // 
            // messageDialog
            // 
            messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            messageDialog.Caption = null;
            messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            messageDialog.Parent = this;
            messageDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            messageDialog.Text = null;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            guna2Elipse1.TargetControl = this;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(827, 505);
            Controls.Add(pi);
            Controls.Add(guna2ControlBox1);
            Controls.Add(guna2GradientPanel1);
            Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ew";
            Load += frmLogin_Load;
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picShowPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)pi).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblForgotpassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2PictureBox pi;
        private Guna.UI2.WinForms.Guna2PictureBox picShowPass;
        private Guna.UI2.WinForms.Guna2MessageDialog messageDialog;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}