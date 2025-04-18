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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gbLichsu = new Guna.UI2.WinForms.Guna2GroupBox();
            gridLichsu = new Guna.UI2.WinForms.Guna2DataGridView();
            cboLoaiphieu = new ComboBox();
            label6 = new Label();
            btnThoat = new Guna.UI2.WinForms.Guna2GradientButton();
            gbLichsu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLichsu).BeginInit();
            SuspendLayout();
            // 
            // gbLichsu
            // 
            gbLichsu.Controls.Add(gridLichsu);
            gbLichsu.Controls.Add(cboLoaiphieu);
            gbLichsu.Controls.Add(label6);
            gbLichsu.CustomBorderColor = Color.FromArgb(239, 119, 18);
            gbLichsu.CustomizableEdges = customizableEdges1;
            gbLichsu.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            gbLichsu.ForeColor = Color.Black;
            gbLichsu.Location = new Point(1, 96);
            gbLichsu.Name = "gbLichsu";
            gbLichsu.ShadowDecoration.CustomizableEdges = customizableEdges2;
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
            btnThoat.CustomizableEdges = customizableEdges3;
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
            btnThoat.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnThoat.Size = new Size(150, 69);
            btnThoat.TabIndex = 21;
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;
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
    }
}