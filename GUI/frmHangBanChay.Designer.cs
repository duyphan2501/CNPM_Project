namespace GUI
{
    partial class frmHangBanChay
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            grbXuatNhapKho = new Guna.UI2.WinForms.Guna2GroupBox();
            dateStop = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dateStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnThongKe = new Guna.UI2.WinForms.Guna2GradientButton();
            numSosanpham = new Guna.UI2.WinForms.Guna2NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            label9 = new Label();
            gridHangbanchay = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlBieuDo = new Guna.UI2.WinForms.Guna2Panel();
            grbXuatNhapKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSosanpham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridHangbanchay).BeginInit();
            SuspendLayout();
            // 
            // grbXuatNhapKho
            // 
            grbXuatNhapKho.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grbXuatNhapKho.Controls.Add(dateStop);
            grbXuatNhapKho.Controls.Add(dateStart);
            grbXuatNhapKho.Controls.Add(btnThongKe);
            grbXuatNhapKho.Controls.Add(numSosanpham);
            grbXuatNhapKho.Controls.Add(label2);
            grbXuatNhapKho.Controls.Add(label1);
            grbXuatNhapKho.Controls.Add(label9);
            grbXuatNhapKho.CustomBorderColor = Color.FromArgb(239, 119, 18);
            grbXuatNhapKho.CustomizableEdges = customizableEdges9;
            grbXuatNhapKho.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grbXuatNhapKho.ForeColor = Color.White;
            grbXuatNhapKho.Location = new Point(29, 40);
            grbXuatNhapKho.Margin = new Padding(3, 4, 3, 4);
            grbXuatNhapKho.Name = "grbXuatNhapKho";
            grbXuatNhapKho.ShadowDecoration.CustomizableEdges = customizableEdges10;
            grbXuatNhapKho.Size = new Size(1484, 148);
            grbXuatNhapKho.TabIndex = 20;
            grbXuatNhapKho.Text = "Thống kê mặt hàng bán chạy nhất";
            // 
            // dateStop
            // 
            dateStop.BorderRadius = 5;
            dateStop.Checked = true;
            dateStop.CustomizableEdges = customizableEdges1;
            dateStop.Font = new Font("Segoe UI", 9F);
            dateStop.Format = DateTimePickerFormat.Long;
            dateStop.Location = new Point(653, 83);
            dateStop.Margin = new Padding(2);
            dateStop.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateStop.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateStop.Name = "dateStop";
            dateStop.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dateStop.Size = new Size(240, 40);
            dateStop.TabIndex = 14;
            dateStop.Value = new DateTime(2025, 4, 26, 17, 51, 15, 852);
            // 
            // dateStart
            // 
            dateStart.BorderRadius = 5;
            dateStart.Checked = true;
            dateStart.CustomizableEdges = customizableEdges3;
            dateStart.Font = new Font("Segoe UI", 9F);
            dateStart.Format = DateTimePickerFormat.Long;
            dateStart.Location = new Point(319, 83);
            dateStart.Margin = new Padding(2);
            dateStart.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateStart.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateStart.Name = "dateStart";
            dateStart.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dateStart.Size = new Size(240, 43);
            dateStart.TabIndex = 14;
            dateStart.Value = new DateTime(2025, 4, 26, 17, 51, 15, 852);
            // 
            // btnThongKe
            // 
            btnThongKe.AutoRoundedCorners = true;
            btnThongKe.BackColor = Color.Transparent;
            btnThongKe.BorderColor = Color.FromArgb(239, 119, 18);
            btnThongKe.BorderThickness = 1;
            btnThongKe.CustomizableEdges = customizableEdges5;
            btnThongKe.DisabledState.BorderColor = Color.DarkGray;
            btnThongKe.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThongKe.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThongKe.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnThongKe.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThongKe.FillColor = Color.Transparent;
            btnThongKe.FillColor2 = Color.Transparent;
            btnThongKe.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            btnThongKe.ForeColor = Color.FromArgb(239, 119, 18);
            btnThongKe.Location = new Point(961, 72);
            btnThongKe.Margin = new Padding(3, 4, 3, 4);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnThongKe.Size = new Size(115, 51);
            btnThongKe.TabIndex = 13;
            btnThongKe.Text = "Thống kê";
            btnThongKe.Click += btnThongKe_Click;
            // 
            // numSosanpham
            // 
            numSosanpham.BackColor = Color.Transparent;
            numSosanpham.BorderRadius = 5;
            numSosanpham.Cursor = Cursors.IBeam;
            numSosanpham.CustomizableEdges = customizableEdges7;
            numSosanpham.Font = new Font("Segoe UI", 9F);
            numSosanpham.Location = new Point(29, 83);
            numSosanpham.Margin = new Padding(3, 5, 3, 5);
            numSosanpham.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numSosanpham.Name = "numSosanpham";
            numSosanpham.ShadowDecoration.CustomizableEdges = customizableEdges8;
            numSosanpham.Size = new Size(204, 40);
            numSosanpham.TabIndex = 13;
            numSosanpham.UpDownButtonFillColor = Color.FromArgb(239, 119, 18);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(244, 103, 0);
            label2.Location = new Point(653, 54);
            label2.Name = "label2";
            label2.Size = new Size(86, 23);
            label2.TabIndex = 10;
            label2.Text = "Đến ngày";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(244, 103, 0);
            label1.Location = new Point(319, 54);
            label1.Name = "label1";
            label1.Size = new Size(75, 23);
            label1.TabIndex = 10;
            label1.Text = "Từ ngày";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(244, 103, 0);
            label9.Location = new Point(27, 54);
            label9.Name = "label9";
            label9.Size = new Size(112, 23);
            label9.TabIndex = 10;
            label9.Text = "Số sản phẩm";
            // 
            // gridHangbanchay
            // 
            gridHangbanchay.AllowUserToAddRows = false;
            gridHangbanchay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            gridHangbanchay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridHangbanchay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(244, 129, 17);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(217, 98, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridHangbanchay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridHangbanchay.ColumnHeadersHeight = 40;
            gridHangbanchay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 167, 73);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridHangbanchay.DefaultCellStyle = dataGridViewCellStyle3;
            gridHangbanchay.GridColor = Color.White;
            gridHangbanchay.Location = new Point(29, 276);
            gridHangbanchay.Margin = new Padding(2, 4, 2, 4);
            gridHangbanchay.Name = "gridHangbanchay";
            gridHangbanchay.ReadOnly = true;
            gridHangbanchay.RowHeadersVisible = false;
            gridHangbanchay.RowHeadersWidth = 51;
            gridHangbanchay.RowTemplate.Height = 35;
            gridHangbanchay.Size = new Size(739, 573);
            gridHangbanchay.TabIndex = 0;
            gridHangbanchay.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridHangbanchay.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridHangbanchay.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridHangbanchay.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridHangbanchay.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridHangbanchay.ThemeStyle.BackColor = Color.White;
            gridHangbanchay.ThemeStyle.GridColor = Color.White;
            gridHangbanchay.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gridHangbanchay.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gridHangbanchay.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridHangbanchay.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gridHangbanchay.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridHangbanchay.ThemeStyle.HeaderStyle.Height = 40;
            gridHangbanchay.ThemeStyle.ReadOnly = true;
            gridHangbanchay.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridHangbanchay.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridHangbanchay.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridHangbanchay.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            gridHangbanchay.ThemeStyle.RowsStyle.Height = 35;
            gridHangbanchay.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridHangbanchay.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // pnlBieuDo
            // 
            pnlBieuDo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBieuDo.BackColor = Color.Transparent;
            pnlBieuDo.CustomizableEdges = customizableEdges11;
            pnlBieuDo.Location = new Point(793, 218);
            pnlBieuDo.Name = "pnlBieuDo";
            pnlBieuDo.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlBieuDo.Size = new Size(720, 631);
            pnlBieuDo.TabIndex = 1;
            // 
            // frmHangBanChay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 222, 224);
            ClientSize = new Size(1536, 882);
            Controls.Add(gridHangbanchay);
            Controls.Add(pnlBieuDo);
            Controls.Add(grbXuatNhapKho);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "frmHangBanChay";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmHangBanChay";
            Load += frmHangBanChay_Load;
            grbXuatNhapKho.ResumeLayout(false);
            grbXuatNhapKho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSosanpham).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridHangbanchay).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2GroupBox grbXuatNhapKho;
        private Guna.UI2.WinForms.Guna2GradientButton btnThongKe;
        private Guna.UI2.WinForms.Guna2NumericUpDown numSosanpham;
        private Label label9;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateStop;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateStart;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView gridHangbanchay;
        private Guna.UI2.WinForms.Guna2Panel pnlBieuDo;
    }
}