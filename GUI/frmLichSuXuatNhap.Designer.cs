﻿namespace GUI
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gbLichsu = new Guna.UI2.WinForms.Guna2GroupBox();
            cboLoaiphieu = new Guna.UI2.WinForms.Guna2ComboBox();
            dateDenngay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dateTungay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label5 = new Label();
            label3 = new Label();
            gridLichsu = new Guna.UI2.WinForms.Guna2DataGridView();
            label6 = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            pnlPagination = new Guna.UI2.WinForms.Guna2Panel();
            gbLichsu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLichsu).BeginInit();
            SuspendLayout();
            // 
            // gbLichsu
            // 
            gbLichsu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbLichsu.Controls.Add(cboLoaiphieu);
            gbLichsu.Controls.Add(dateDenngay);
            gbLichsu.Controls.Add(dateTungay);
            gbLichsu.Controls.Add(label5);
            gbLichsu.Controls.Add(label3);
            gbLichsu.Controls.Add(gridLichsu);
            gbLichsu.Controls.Add(label6);
            gbLichsu.CustomBorderColor = Color.FromArgb(245, 151, 29);
            gbLichsu.CustomizableEdges = customizableEdges7;
            gbLichsu.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbLichsu.ForeColor = Color.White;
            gbLichsu.Location = new Point(11, 53);
            gbLichsu.Margin = new Padding(2);
            gbLichsu.Name = "gbLichsu";
            gbLichsu.ShadowDecoration.CustomizableEdges = customizableEdges8;
            gbLichsu.Size = new Size(1208, 732);
            gbLichsu.TabIndex = 20;
            gbLichsu.Text = "Lịch sử xuất nhập";
            // 
            // cboLoaiphieu
            // 
            cboLoaiphieu.BackColor = Color.Transparent;
            cboLoaiphieu.BorderRadius = 5;
            cboLoaiphieu.CustomizableEdges = customizableEdges1;
            cboLoaiphieu.DrawMode = DrawMode.OwnerDrawFixed;
            cboLoaiphieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiphieu.FocusedColor = Color.FromArgb(244, 129, 17);
            cboLoaiphieu.FocusedState.BorderColor = Color.FromArgb(244, 129, 17);
            cboLoaiphieu.Font = new Font("Segoe UI", 10F);
            cboLoaiphieu.ForeColor = Color.FromArgb(68, 88, 112);
            cboLoaiphieu.ItemHeight = 30;
            cboLoaiphieu.Location = new Point(960, 64);
            cboLoaiphieu.Name = "cboLoaiphieu";
            cboLoaiphieu.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cboLoaiphieu.Size = new Size(175, 36);
            cboLoaiphieu.TabIndex = 23;
            cboLoaiphieu.SelectedIndexChanged += cboLoaiphieu_SelectedIndexChanged;
            // 
            // dateDenngay
            // 
            dateDenngay.BackColor = Color.White;
            dateDenngay.BorderRadius = 5;
            dateDenngay.Checked = true;
            dateDenngay.CustomizableEdges = customizableEdges3;
            dateDenngay.FillColor = Color.Orange;
            dateDenngay.Font = new Font("Segoe UI", 9F);
            dateDenngay.ForeColor = Color.White;
            dateDenngay.Format = DateTimePickerFormat.Long;
            dateDenngay.Location = new Point(514, 63);
            dateDenngay.Margin = new Padding(2);
            dateDenngay.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateDenngay.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateDenngay.Name = "dateDenngay";
            dateDenngay.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dateDenngay.Size = new Size(274, 37);
            dateDenngay.TabIndex = 21;
            dateDenngay.Value = new DateTime(2025, 4, 26, 22, 2, 45, 400);
            // 
            // dateTungay
            // 
            dateTungay.BackColor = Color.White;
            dateTungay.BorderRadius = 5;
            dateTungay.Checked = true;
            dateTungay.CustomizableEdges = customizableEdges5;
            dateTungay.FillColor = Color.Orange;
            dateTungay.Font = new Font("Segoe UI", 9F);
            dateTungay.ForeColor = Color.White;
            dateTungay.Format = DateTimePickerFormat.Long;
            dateTungay.Location = new Point(131, 63);
            dateTungay.Margin = new Padding(2);
            dateTungay.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTungay.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTungay.Name = "dateTungay";
            dateTungay.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dateTungay.Size = new Size(268, 37);
            dateTungay.TabIndex = 22;
            dateTungay.Value = new DateTime(2025, 4, 26, 22, 2, 45, 400);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(244, 103, 0);
            label5.Location = new Point(419, 63);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 19;
            label5.Text = "Đến ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(244, 103, 0);
            label3.Location = new Point(49, 63);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 20;
            label3.Text = "Từ ngày";
            // 
            // gridLichsu
            // 
            gridLichsu.AllowUserToAddRows = false;
            gridLichsu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            gridLichsu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridLichsu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(244, 129, 17);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(244, 129, 17);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridLichsu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridLichsu.ColumnHeadersHeight = 40;
            gridLichsu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 167, 73);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridLichsu.DefaultCellStyle = dataGridViewCellStyle3;
            gridLichsu.GridColor = Color.FromArgb(231, 229, 255);
            gridLichsu.Location = new Point(20, 129);
            gridLichsu.Margin = new Padding(2, 4, 2, 4);
            gridLichsu.Name = "gridLichsu";
            gridLichsu.ReadOnly = true;
            gridLichsu.RowHeadersVisible = false;
            gridLichsu.RowHeadersWidth = 51;
            gridLichsu.RowTemplate.Height = 35;
            gridLichsu.Size = new Size(1171, 599);
            gridLichsu.TabIndex = 18;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridLichsu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridLichsu.ThemeStyle.BackColor = Color.White;
            gridLichsu.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
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
            gridLichsu.ThemeStyle.RowsStyle.Height = 35;
            gridLichsu.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridLichsu.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(244, 103, 0);
            label6.Location = new Point(856, 64);
            label6.Name = "label6";
            label6.Size = new Size(98, 25);
            label6.TabIndex = 10;
            label6.Text = "Loại Phiếu";
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 10;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.CustomizableEdges = customizableEdges11;
            guna2ControlBox1.FillColor = Color.Transparent;
            guna2ControlBox1.IconColor = Color.Black;
            guna2ControlBox1.Location = new Point(1162, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2ControlBox1.Size = new Size(56, 36);
            guna2ControlBox1.TabIndex = 21;
            // 
            // pnlPagination
            // 
            pnlPagination.CustomizableEdges = customizableEdges9;
            pnlPagination.Location = new Point(31, 793);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlPagination.Size = new Size(980, 55);
            pnlPagination.TabIndex = 22;
            // 
            // frmLichSuXuatNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 222, 224);
            ClientSize = new Size(1230, 860);
            Controls.Add(pnlPagination);
            Controls.Add(guna2ControlBox1);
            Controls.Add(gbLichsu);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
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
        private Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateDenngay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTungay;
        private Label label5;
        private Label label3;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiphieu;
        private Guna.UI2.WinForms.Guna2Panel pnlPagination;
    }
}