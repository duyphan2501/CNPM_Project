namespace GUI
{
    partial class frmLichSuXuatNhap
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gbLichsu = new Guna.UI2.WinForms.Guna2GroupBox();
            gridLichsu = new Guna.UI2.WinForms.Guna2DataGridView();
            cboLoaiphieu = new ComboBox();
            label6 = new Label();
            btnThoat = new Guna.UI2.WinForms.Guna2GradientButton();
            dateDenngay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dateTungay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label5 = new Label();
            label3 = new Label();
            gbLichsu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLichsu).BeginInit();
            SuspendLayout();
            // 
            // gbLichsu
            // 
            gbLichsu.Controls.Add(dateDenngay);
            gbLichsu.Controls.Add(dateTungay);
            gbLichsu.Controls.Add(label5);
            gbLichsu.Controls.Add(label3);
            gbLichsu.Controls.Add(gridLichsu);
            gbLichsu.Controls.Add(cboLoaiphieu);
            gbLichsu.Controls.Add(label6);
            gbLichsu.CustomBorderColor = Color.FromArgb(239, 119, 18);
            gbLichsu.CustomizableEdges = customizableEdges5;
            gbLichsu.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            gbLichsu.ForeColor = Color.Black;
            gbLichsu.Location = new Point(1, 96);
            gbLichsu.Name = "gbLichsu";
            gbLichsu.ShadowDecoration.CustomizableEdges = customizableEdges6;
            gbLichsu.Size = new Size(1536, 738);
            gbLichsu.TabIndex = 20;
            gbLichsu.Text = "Lịch sử xuất nhập";
            // 
            // gridLichsu
            // 
            gridLichsu.AllowUserToAddRows = false;
            gridLichsu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            gridLichsu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(244, 103, 0);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridLichsu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridLichsu.ColumnHeadersHeight = 40;
            gridLichsu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridLichsu.DefaultCellStyle = dataGridViewCellStyle3;
            gridLichsu.GridColor = Color.White;
            gridLichsu.Location = new Point(25, 127);
            gridLichsu.Margin = new Padding(3, 5, 3, 5);
            gridLichsu.Name = "gridLichsu";
            gridLichsu.ReadOnly = true;
            gridLichsu.RowHeadersVisible = false;
            gridLichsu.RowHeadersWidth = 51;
            gridLichsu.RowTemplate.Height = 24;
            gridLichsu.Size = new Size(1480, 587);
            gridLichsu.TabIndex = 18;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridLichsu.ThemeStyle.BackColor = Color.White;
            gridLichsu.ThemeStyle.GridColor = Color.White;
            gridLichsu.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gridLichsu.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gridLichsu.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridLichsu.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gridLichsu.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridLichsu.ThemeStyle.HeaderStyle.Height = 40;
            gridLichsu.ThemeStyle.ReadOnly = true;
            gridLichsu.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridLichsu.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridLichsu.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridLichsu.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            gridLichsu.ThemeStyle.RowsStyle.Height = 24;
            gridLichsu.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridLichsu.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // cboLoaiphieu
            // 
            cboLoaiphieu.FormattingEnabled = true;
            cboLoaiphieu.Items.AddRange(new object[] { "Phiếu nhập", "Phiếu xuất" });
            cboLoaiphieu.Location = new Point(1194, 64);
            cboLoaiphieu.Margin = new Padding(4);
            cboLoaiphieu.Name = "cboLoaiphieu";
            cboLoaiphieu.Size = new Size(246, 36);
            cboLoaiphieu.TabIndex = 17;
            cboLoaiphieu.SelectedIndexChanged += cboLoaiphieu_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(244, 103, 0);
            label6.Location = new Point(1039, 67);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(116, 30);
            label6.TabIndex = 10;
            label6.Text = "Loại Phiếu";
            // 
            // btnThoat
            // 
            btnThoat.AutoRoundedCorners = true;
            btnThoat.BackColor = Color.Transparent;
            btnThoat.CustomizableEdges = customizableEdges7;
            btnThoat.DisabledState.BorderColor = Color.DarkGray;
            btnThoat.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThoat.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThoat.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnThoat.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThoat.FillColor = Color.FromArgb(244, 103, 0);
            btnThoat.FillColor2 = Color.DarkOrange;
            btnThoat.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(1356, 14);
            btnThoat.Margin = new Padding(4, 5, 4, 5);
            btnThoat.Name = "btnThoat";
            btnThoat.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnThoat.Size = new Size(150, 69);
            btnThoat.TabIndex = 21;
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;
            // 
            // dateDenngay
            // 
            dateDenngay.Checked = true;
            dateDenngay.CustomizableEdges = customizableEdges1;
            dateDenngay.Font = new Font("Segoe UI", 9F);
            dateDenngay.Format = DateTimePickerFormat.Long;
            dateDenngay.Location = new Point(738, 58);
            dateDenngay.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateDenngay.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateDenngay.Name = "dateDenngay";
            dateDenngay.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dateDenngay.Size = new Size(276, 46);
            dateDenngay.TabIndex = 21;
            dateDenngay.Value = new DateTime(2025, 4, 26, 22, 2, 45, 400);
            // 
            // dateTungay
            // 
            dateTungay.Checked = true;
            dateTungay.CustomizableEdges = customizableEdges3;
            dateTungay.Font = new Font("Segoe UI", 9F);
            dateTungay.Format = DateTimePickerFormat.Long;
            dateTungay.Location = new Point(305, 58);
            dateTungay.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTungay.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTungay.Name = "dateTungay";
            dateTungay.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dateTungay.Size = new Size(276, 46);
            dateTungay.TabIndex = 22;
            dateTungay.Value = new DateTime(2025, 4, 26, 22, 2, 45, 400);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(244, 103, 0);
            label5.Location = new Point(604, 65);
            label5.Name = "label5";
            label5.Size = new Size(123, 32);
            label5.TabIndex = 19;
            label5.Text = "Đến ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(244, 103, 0);
            label3.Location = new Point(185, 64);
            label3.Name = "label3";
            label3.Size = new Size(107, 32);
            label3.TabIndex = 20;
            label3.Text = "Từ ngày";
            // 
            // frmLichSuXuatNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1537, 838);
            Controls.Add(btnThoat);
            Controls.Add(gbLichsu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLichSuXuatNhap";
            Text = "frmLichSuXuatNhap";
            Load += frmLichSuXuatNhap_Load;
            gbLichsu.ResumeLayout(false);
            gbLichsu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridLichsu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gbLichsu;
        private Guna.UI2.WinForms.Guna2DataGridView gridLichsu;
        private ComboBox cboLoaiphieu;
        private Label label6;
        private Guna.UI2.WinForms.Guna2GradientButton btnThoat;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateDenngay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTungay;
        private Label label5;
        private Label label3;
    }
}