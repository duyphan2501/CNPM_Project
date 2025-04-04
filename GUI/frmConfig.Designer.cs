namespace GUI
{
    partial class frmConfig
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            cboDatabase = new Guna.UI2.WinForms.Guna2ComboBox();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtUID = new Guna.UI2.WinForms.Guna2TextBox();
            txtServer = new Guna.UI2.WinForms.Guna2TextBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnCheck = new Guna.UI2.WinForms.Guna2Button();
            btnExit = new Guna.UI2.WinForms.Guna2Button();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            chkWindowAuth = new Guna.UI2.WinForms.Guna2CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(21, 65);
            label1.Name = "label1";
            label1.Size = new Size(83, 30);
            label1.TabIndex = 4;
            label1.Text = "Server";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(21, 136);
            label2.Name = "label2";
            label2.Size = new Size(117, 30);
            label2.TabIndex = 5;
            label2.Text = "Database";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(19, 201);
            label3.Name = "label3";
            label3.Size = new Size(54, 30);
            label3.TabIndex = 6;
            label3.Text = "UID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(19, 271);
            label4.Name = "label4";
            label4.Size = new Size(119, 30);
            label4.TabIndex = 7;
            label4.Text = "Password";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkOrange;
            groupBox1.Controls.Add(cboDatabase);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUID);
            groupBox1.Controls.Add(txtServer);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(12, 15);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(545, 316);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin kết nối";
            // 
            // cboDatabase
            // 
            cboDatabase.BackColor = Color.Transparent;
            cboDatabase.CustomizableEdges = customizableEdges1;
            cboDatabase.DrawMode = DrawMode.OwnerDrawFixed;
            cboDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDatabase.FocusedColor = Color.FromArgb(94, 148, 255);
            cboDatabase.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboDatabase.Font = new Font("Segoe UI", 10F);
            cboDatabase.ForeColor = Color.FromArgb(68, 88, 112);
            cboDatabase.ItemHeight = 30;
            cboDatabase.Location = new Point(162, 130);
            cboDatabase.Name = "cboDatabase";
            cboDatabase.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cboDatabase.Size = new Size(337, 36);
            cboDatabase.TabIndex = 2;
            cboDatabase.MouseClick += this.cboDatabase_MouseClick;
            // 
            // txtPassword
            // 
            txtPassword.CustomizableEdges = customizableEdges3;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(162, 258);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(337, 43);
            txtPassword.TabIndex = 4;
            // 
            // txtUID
            // 
            txtUID.CustomizableEdges = customizableEdges5;
            txtUID.DefaultText = "";
            txtUID.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUID.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUID.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUID.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUID.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUID.Font = new Font("Segoe UI", 9F);
            txtUID.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUID.Location = new Point(162, 188);
            txtUID.Margin = new Padding(3, 4, 3, 4);
            txtUID.Name = "txtUID";
            txtUID.PlaceholderText = "";
            txtUID.SelectedText = "";
            txtUID.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtUID.Size = new Size(337, 43);
            txtUID.TabIndex = 3;
            // 
            // txtServer
            // 
            txtServer.CustomizableEdges = customizableEdges7;
            txtServer.DefaultText = "";
            txtServer.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtServer.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtServer.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtServer.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtServer.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtServer.Font = new Font("Segoe UI", 9F);
            txtServer.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtServer.Location = new Point(162, 52);
            txtServer.Margin = new Padding(3, 4, 3, 4);
            txtServer.Name = "txtServer";
            txtServer.PlaceholderText = "";
            txtServer.SelectedText = "";
            txtServer.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtServer.Size = new Size(337, 43);
            txtServer.TabIndex = 1;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnCheck
            // 
            btnCheck.CustomizableEdges = customizableEdges13;
            btnCheck.DisabledState.BorderColor = Color.DarkGray;
            btnCheck.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCheck.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCheck.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCheck.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheck.ForeColor = Color.White;
            btnCheck.Location = new Point(407, 412);
            btnCheck.Name = "btnCheck";
            btnCheck.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnCheck.Size = new Size(150, 56);
            btnCheck.TabIndex = 0;
            btnCheck.Text = "Kiểm tra";
            btnCheck.Click += btnCheck_Click;
            // 
            // btnExit
            // 
            btnExit.CustomizableEdges = customizableEdges11;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(12, 412);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnExit.Size = new Size(150, 56);
            btnExit.TabIndex = 2;
            btnExit.Text = "Thoát";
            btnExit.Click += btnExit_Click;
            // 
            // btnSave
            // 
            btnSave.CustomizableEdges = customizableEdges9;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(215, 412);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSave.Size = new Size(150, 56);
            btnSave.TabIndex = 1;
            btnSave.Text = "Lưu";
            btnSave.Click += btnSave_Click;
            // 
            // chkWindowAuth
            // 
            chkWindowAuth.AutoSize = true;
            chkWindowAuth.Checked = true;
            chkWindowAuth.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            chkWindowAuth.CheckedState.BorderRadius = 0;
            chkWindowAuth.CheckedState.BorderThickness = 0;
            chkWindowAuth.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            chkWindowAuth.CheckState = CheckState.Checked;
            chkWindowAuth.ForeColor = Color.White;
            chkWindowAuth.Location = new Point(50, 356);
            chkWindowAuth.Name = "chkWindowAuth";
            chkWindowAuth.Size = new Size(187, 24);
            chkWindowAuth.TabIndex = 9;
            chkWindowAuth.Text = "Window Authentication";
            chkWindowAuth.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            chkWindowAuth.UncheckedState.BorderRadius = 0;
            chkWindowAuth.UncheckedState.BorderThickness = 0;
            chkWindowAuth.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            chkWindowAuth.CheckedChanged += chkWindowAuth_CheckedChanged;
            // 
            // frmConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 103, 0);
            ClientSize = new Size(569, 480);
            Controls.Add(chkWindowAuth);
            Controls.Add(btnSave);
            Controls.Add(btnExit);
            Controls.Add(btnCheck);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmConfig";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Config";
            Load += frmConfig_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtServer;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUID;
        private Guna.UI2.WinForms.Guna2ComboBox cboDatabase;
        private Guna.UI2.WinForms.Guna2Button btnCheck;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2CheckBox chkWindowAuth;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}