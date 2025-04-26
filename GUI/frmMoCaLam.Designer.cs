namespace GUI
{
    partial class frmMoCaLam
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblNhanVienCa = new Label();
            lblGioBatDau = new Label();
            txtTienDauCa = new Guna.UI2.WinForms.Guna2TextBox();
            label6 = new Label();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            btnMoCaLam = new Guna.UI2.WinForms.Guna2Button();
            messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 10;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 19);
            label1.Name = "label1";
            label1.Size = new Size(156, 28);
            label1.TabIndex = 0;
            label1.Text = "Mở ca làm việc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 58);
            label2.Name = "label2";
            label2.Size = new Size(409, 69);
            label2.TabIndex = 1;
            label2.Text = "Vui lòng mở ca làm việc để thực hiện các chức năng\r\ndành cho thu ngân\r\n\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 127);
            label3.Name = "label3";
            label3.Size = new Size(115, 23);
            label3.TabIndex = 1;
            label3.Text = "Nhân viên ca:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(30, 164);
            label4.Name = "label4";
            label4.Size = new Size(104, 23);
            label4.TabIndex = 1;
            label4.Text = "Giờ bắt đầu:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(30, 209);
            label5.Name = "label5";
            label5.Size = new Size(137, 23);
            label5.TabIndex = 1;
            label5.Text = "Tiền mặt đầu ca:";
            // 
            // lblNhanVienCa
            // 
            lblNhanVienCa.AutoSize = true;
            lblNhanVienCa.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNhanVienCa.ForeColor = SystemColors.GrayText;
            lblNhanVienCa.Location = new Point(177, 127);
            lblNhanVienCa.Name = "lblNhanVienCa";
            lblNhanVienCa.Size = new Size(115, 23);
            lblNhanVienCa.TabIndex = 1;
            lblNhanVienCa.Text = "Nhân viên ca:";
            // 
            // lblGioBatDau
            // 
            lblGioBatDau.AutoSize = true;
            lblGioBatDau.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGioBatDau.ForeColor = SystemColors.ControlText;
            lblGioBatDau.Location = new Point(177, 164);
            lblGioBatDau.Name = "lblGioBatDau";
            lblGioBatDau.Size = new Size(115, 23);
            lblGioBatDau.TabIndex = 1;
            lblGioBatDau.Text = "Nhân viên ca:";
            // 
            // txtTienDauCa
            // 
            txtTienDauCa.CustomizableEdges = customizableEdges5;
            txtTienDauCa.DefaultText = "";
            txtTienDauCa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTienDauCa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTienDauCa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTienDauCa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTienDauCa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTienDauCa.Font = new Font("Segoe UI", 9F);
            txtTienDauCa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTienDauCa.Location = new Point(177, 201);
            txtTienDauCa.Margin = new Padding(3, 4, 3, 4);
            txtTienDauCa.Name = "txtTienDauCa";
            txtTienDauCa.PlaceholderText = "";
            txtTienDauCa.SelectedText = "";
            txtTienDauCa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtTienDauCa.Size = new Size(197, 37);
            txtTienDauCa.TabIndex = 2;
            txtTienDauCa.KeyPress += txtTienDauCa_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(380, 209);
            label6.Name = "label6";
            label6.Size = new Size(39, 23);
            label6.TabIndex = 1;
            label6.Text = "vnđ";
            // 
            // btnLogout
            // 
            btnLogout.BorderRadius = 5;
            btnLogout.CustomizableEdges = customizableEdges3;
            btnLogout.DisabledState.BorderColor = Color.DarkGray;
            btnLogout.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogout.FillColor = Color.FromArgb(255, 192, 192);
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(135, 262);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnLogout.Size = new Size(139, 45);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Đăng xuất";
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMoCaLam
            // 
            btnMoCaLam.BorderRadius = 5;
            btnMoCaLam.CustomizableEdges = customizableEdges1;
            btnMoCaLam.DisabledState.BorderColor = Color.DarkGray;
            btnMoCaLam.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMoCaLam.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMoCaLam.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMoCaLam.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMoCaLam.ForeColor = Color.White;
            btnMoCaLam.Location = new Point(296, 262);
            btnMoCaLam.Name = "btnMoCaLam";
            btnMoCaLam.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnMoCaLam.Size = new Size(139, 45);
            btnMoCaLam.TabIndex = 3;
            btnMoCaLam.Text = "Mở ca";
            btnMoCaLam.Click += btnMoCaLam_Click;
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
            // frmMoCaLam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 328);
            Controls.Add(btnMoCaLam);
            Controls.Add(btnLogout);
            Controls.Add(txtTienDauCa);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(lblGioBatDau);
            Controls.Add(lblNhanVienCa);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmMoCaLam";
            Text = "frmCaLam";
            FormClosing += frmMoCaLam_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblNhanVienCa;
        private Label lblGioBatDau;
        private Guna.UI2.WinForms.Guna2TextBox txtTienDauCa;
        private Label label6;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnMoCaLam;
        private Guna.UI2.WinForms.Guna2MessageDialog messageDialog;
    }
}