namespace GUI.components
{
    partial class Widget
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            picSanPham = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblGiaSanPham = new Label();
            lblTenSanPham = new Label();
            btnThemSanPham = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)picSanPham).BeginInit();
            guna2ShadowPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // picSanPham
            // 
            picSanPham.CustomizableEdges = customizableEdges1;
            picSanPham.Image = Properties.Resources.nuocam;
            picSanPham.ImageRotate = 0F;
            picSanPham.Location = new Point(4, 0);
            picSanPham.Margin = new Padding(3, 4, 3, 4);
            picSanPham.Name = "picSanPham";
            picSanPham.ShadowDecoration.CustomizableEdges = customizableEdges2;
            picSanPham.Size = new Size(240, 151);
            picSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            picSanPham.TabIndex = 1;
            picSanPham.TabStop = false;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(lblGiaSanPham);
            guna2ShadowPanel1.Controls.Add(lblTenSanPham);
            guna2ShadowPanel1.Controls.Add(btnThemSanPham);
            guna2ShadowPanel1.Controls.Add(picSanPham);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 3;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowShift = 2;
            guna2ShadowPanel1.Size = new Size(248, 237);
            guna2ShadowPanel1.TabIndex = 4;
            // 
            // lblGiaSanPham
            // 
            lblGiaSanPham.AutoSize = true;
            lblGiaSanPham.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGiaSanPham.ForeColor = Color.DimGray;
            lblGiaSanPham.Location = new Point(18, 189);
            lblGiaSanPham.Name = "lblGiaSanPham";
            lblGiaSanPham.Size = new Size(73, 25);
            lblGiaSanPham.TabIndex = 6;
            lblGiaSanPham.Text = "20000đ";
            // 
            // lblTenSanPham
            // 
            lblTenSanPham.AutoSize = true;
            lblTenSanPham.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenSanPham.ForeColor = Color.Black;
            lblTenSanPham.Location = new Point(15, 155);
            lblTenSanPham.Name = "lblTenSanPham";
            lblTenSanPham.Size = new Size(192, 25);
            lblTenSanPham.TabIndex = 5;
            lblTenSanPham.Text = "Cafe Sua Da Sieu Cap";
            // 
            // btnThemSanPham
            // 
            btnThemSanPham.BorderRadius = 5;
            btnThemSanPham.Cursor = Cursors.Hand;
            btnThemSanPham.CustomizableEdges = customizableEdges3;
            btnThemSanPham.DisabledState.BorderColor = Color.DarkGray;
            btnThemSanPham.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemSanPham.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemSanPham.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemSanPham.FillColor = Color.FromArgb(244, 129, 17);
            btnThemSanPham.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemSanPham.ForeColor = Color.White;
            btnThemSanPham.Image = Properties.Resources.icons8_plus_64;
            btnThemSanPham.ImageAlign = HorizontalAlignment.Left;
            btnThemSanPham.ImageSize = new Size(40, 40);
            btnThemSanPham.Location = new Point(123, 187);
            btnThemSanPham.Name = "btnThemSanPham";
            btnThemSanPham.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnThemSanPham.Size = new Size(116, 35);
            btnThemSanPham.TabIndex = 4;
            btnThemSanPham.Text = "Thêm";
            btnThemSanPham.TextAlign = HorizontalAlignment.Right;
            // 
            // Widget
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(guna2ShadowPanel1);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Widget";
            Size = new Size(248, 237);
            ((System.ComponentModel.ISupportInitialize)picSanPham).EndInit();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public Guna.UI2.WinForms.Guna2PictureBox picSanPham;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Button btnThemSanPham;
        private Label lblTenSanPham;
        private Label lblGiaSanPham;
    }
}
