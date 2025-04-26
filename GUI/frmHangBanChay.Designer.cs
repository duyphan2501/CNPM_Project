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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHangBanChay));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            gridThucDon = new Guna.UI2.WinForms.Guna2DataGridView();
            btnUpdate = new DataGridViewImageColumn();
            grbXuatNhapKho = new Guna.UI2.WinForms.Guna2GroupBox();
            btnThongKe = new Guna.UI2.WinForms.Guna2GradientButton();
            numSosanpham = new Guna.UI2.WinForms.Guna2NumericUpDown();
            label9 = new Label();
            dateStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dateStop = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridThucDon).BeginInit();
            grbXuatNhapKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSosanpham).BeginInit();
            SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            guna2GroupBox1.BackColor = SystemColors.Control;
            guna2GroupBox1.BorderThickness = 0;
            guna2GroupBox1.Controls.Add(gridThucDon);
            guna2GroupBox1.CustomBorderThickness = new Padding(0);
            guna2GroupBox1.CustomizableEdges = customizableEdges13;
            guna2GroupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2GroupBox1.ForeColor = Color.Black;
            guna2GroupBox1.Location = new Point(32, 245);
            guna2GroupBox1.Margin = new Padding(2, 5, 2, 5);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges14;
            guna2GroupBox1.Size = new Size(1859, 848);
            guna2GroupBox1.TabIndex = 19;
            guna2GroupBox1.Text = "Danh sách sản phẩm";
            // 
            // gridThucDon
            // 
            gridThucDon.AllowUserToAddRows = false;
            gridThucDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            gridThucDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(244, 103, 0);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            gridThucDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            gridThucDon.ColumnHeadersHeight = 40;
            gridThucDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridThucDon.Columns.AddRange(new DataGridViewColumn[] { btnUpdate });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            gridThucDon.DefaultCellStyle = dataGridViewCellStyle6;
            gridThucDon.GridColor = Color.White;
            gridThucDon.Location = new Point(4, 44);
            gridThucDon.Margin = new Padding(2, 5, 2, 5);
            gridThucDon.Name = "gridThucDon";
            gridThucDon.ReadOnly = true;
            gridThucDon.RowHeadersVisible = false;
            gridThucDon.RowHeadersWidth = 51;
            gridThucDon.RowTemplate.Height = 100;
            gridThucDon.Size = new Size(1855, 854);
            gridThucDon.TabIndex = 0;
            gridThucDon.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridThucDon.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridThucDon.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridThucDon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridThucDon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridThucDon.ThemeStyle.BackColor = Color.White;
            gridThucDon.ThemeStyle.GridColor = Color.White;
            gridThucDon.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gridThucDon.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gridThucDon.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridThucDon.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gridThucDon.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridThucDon.ThemeStyle.HeaderStyle.Height = 40;
            gridThucDon.ThemeStyle.ReadOnly = true;
            gridThucDon.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridThucDon.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridThucDon.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridThucDon.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            gridThucDon.ThemeStyle.RowsStyle.Height = 100;
            gridThucDon.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridThucDon.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnUpdate.HeaderText = "";
            btnUpdate.Image = (Image)resources.GetObject("btnUpdate.Image");
            btnUpdate.ImageLayout = DataGridViewImageCellLayout.Zoom;
            btnUpdate.MinimumWidth = 50;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ReadOnly = true;
            btnUpdate.Resizable = DataGridViewTriState.True;
            btnUpdate.SortMode = DataGridViewColumnSortMode.Automatic;
            btnUpdate.Width = 50;
            // 
            // grbXuatNhapKho
            // 
            grbXuatNhapKho.Controls.Add(dateStop);
            grbXuatNhapKho.Controls.Add(dateStart);
            grbXuatNhapKho.Controls.Add(btnThongKe);
            grbXuatNhapKho.Controls.Add(numSosanpham);
            grbXuatNhapKho.Controls.Add(label2);
            grbXuatNhapKho.Controls.Add(label1);
            grbXuatNhapKho.Controls.Add(label9);
            grbXuatNhapKho.CustomBorderColor = Color.FromArgb(239, 119, 18);
            grbXuatNhapKho.CustomizableEdges = customizableEdges23;
            grbXuatNhapKho.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grbXuatNhapKho.ForeColor = Color.White;
            grbXuatNhapKho.Location = new Point(36, 14);
            grbXuatNhapKho.Margin = new Padding(4, 5, 4, 5);
            grbXuatNhapKho.Name = "grbXuatNhapKho";
            grbXuatNhapKho.ShadowDecoration.CustomizableEdges = customizableEdges24;
            grbXuatNhapKho.Size = new Size(1855, 185);
            grbXuatNhapKho.TabIndex = 20;
            grbXuatNhapKho.Text = "Thống kê mặt hàng bán chạy nhất";
            // 
            // btnThongKe
            // 
            btnThongKe.AutoRoundedCorners = true;
            btnThongKe.BackColor = Color.Transparent;
            btnThongKe.BorderColor = Color.FromArgb(239, 119, 18);
            btnThongKe.BorderThickness = 1;
            btnThongKe.CustomizableEdges = customizableEdges19;
            btnThongKe.DisabledState.BorderColor = Color.DarkGray;
            btnThongKe.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThongKe.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThongKe.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnThongKe.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThongKe.FillColor = Color.Transparent;
            btnThongKe.FillColor2 = Color.Transparent;
            btnThongKe.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            btnThongKe.ForeColor = Color.FromArgb(239, 119, 18);
            btnThongKe.Location = new Point(1214, 90);
            btnThongKe.Margin = new Padding(4, 5, 4, 5);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnThongKe.Size = new Size(144, 64);
            btnThongKe.TabIndex = 13;
            btnThongKe.Text = "Thống kê";
            btnThongKe.TextAlign = HorizontalAlignment.Left;
            // 
            // numSosanpham
            // 
            numSosanpham.BackColor = Color.Transparent;
            numSosanpham.Cursor = Cursors.IBeam;
            numSosanpham.CustomizableEdges = customizableEdges21;
            numSosanpham.Font = new Font("Segoe UI", 9F);
            numSosanpham.Location = new Point(36, 104);
            numSosanpham.Margin = new Padding(4, 6, 4, 6);
            numSosanpham.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numSosanpham.Name = "numSosanpham";
            numSosanpham.ShadowDecoration.CustomizableEdges = customizableEdges22;
            numSosanpham.Size = new Size(255, 50);
            numSosanpham.TabIndex = 13;
            numSosanpham.UpDownButtonFillColor = Color.FromArgb(239, 119, 18);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(244, 103, 0);
            label9.Location = new Point(34, 68);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(139, 30);
            label9.TabIndex = 10;
            label9.Text = "Số sản phẩm";
            // 
            // dateStart
            // 
            dateStart.Checked = true;
            dateStart.CustomizableEdges = customizableEdges17;
            dateStart.Font = new Font("Segoe UI", 9F);
            dateStart.Format = DateTimePickerFormat.Long;
            dateStart.Location = new Point(399, 104);
            dateStart.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateStart.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateStart.Name = "dateStart";
            dateStart.ShadowDecoration.CustomizableEdges = customizableEdges18;
            dateStart.Size = new Size(300, 54);
            dateStart.TabIndex = 14;
            dateStart.Value = new DateTime(2025, 4, 26, 17, 51, 15, 852);
            // 
            // dateStop
            // 
            dateStop.Checked = true;
            dateStop.CustomizableEdges = customizableEdges15;
            dateStop.Font = new Font("Segoe UI", 9F);
            dateStop.Format = DateTimePickerFormat.Long;
            dateStop.Location = new Point(816, 104);
            dateStop.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateStop.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateStop.Name = "dateStop";
            dateStop.ShadowDecoration.CustomizableEdges = customizableEdges16;
            dateStop.Size = new Size(300, 50);
            dateStop.TabIndex = 14;
            dateStop.Value = new DateTime(2025, 4, 26, 17, 51, 15, 852);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(244, 103, 0);
            label1.Location = new Point(399, 68);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 30);
            label1.TabIndex = 10;
            label1.Text = "Từ ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(244, 103, 0);
            label2.Location = new Point(816, 68);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(106, 30);
            label2.TabIndex = 10;
            label2.Text = "Đến ngày";
            // 
            // frmHangBanChay
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1118);
            Controls.Add(grbXuatNhapKho);
            Controls.Add(guna2GroupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmHangBanChay";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmHangBanChay";
            guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridThucDon).EndInit();
            grbXuatNhapKho.ResumeLayout(false);
            grbXuatNhapKho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSosanpham).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView gridThucDon;
        private DataGridViewImageColumn btnUpdate;
        private Guna.UI2.WinForms.Guna2GroupBox grbXuatNhapKho;
        private Guna.UI2.WinForms.Guna2GradientButton btnThongKe;
        private Guna.UI2.WinForms.Guna2NumericUpDown numSosanpham;
        private Label label9;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateStop;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateStart;
        private Label label2;
        private Label label1;
    }
}