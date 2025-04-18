namespace GUI
{
    partial class frmOrderList
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            gridOrderList = new Guna.UI2.WinForms.Guna2DataGridView();
            MaDonHan = new DataGridViewTextBoxColumn();
            MaCaLam = new DataGridViewTextBoxColumn();
            NVLap = new DataGridViewTextBoxColumn();
            MaCaThanhToan = new DataGridViewTextBoxColumn();
            NVThanhToan = new DataGridViewTextBoxColumn();
            LoaiThanhToan = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            NgayLap = new DataGridViewTextBoxColumn();
            pnlOrderDetail = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2NumericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            btnLuu = new Guna.UI2.WinForms.Guna2Button();
            btnChinhSua = new Guna.UI2.WinForms.Guna2Button();
            txtGhiChu = new Guna.UI2.WinForms.Guna2TextBox();
            gridOrderDetail = new Guna.UI2.WinForms.Guna2DataGridView();
            RemoveItem = new DataGridViewImageColumn();
            TenSP = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnExit = new Guna.UI2.WinForms.Guna2Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            btnViewDetail = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)gridOrderList).BeginInit();
            pnlOrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridOrderDetail).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 15;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.CustomizableEdges = customizableEdges13;
            guna2ControlBox1.FillColor = Color.Transparent;
            guna2ControlBox1.IconColor = Color.Black;
            guna2ControlBox1.Location = new Point(29, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges14;
            guna2ControlBox1.Size = new Size(42, 36);
            guna2ControlBox1.TabIndex = 0;
            // 
            // gridOrderList
            // 
            gridOrderList.AllowUserToAddRows = false;
            gridOrderList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            gridOrderList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            gridOrderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            gridOrderList.ColumnHeadersHeight = 35;
            gridOrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridOrderList.Columns.AddRange(new DataGridViewColumn[] { MaDonHan, MaCaLam, NVLap, MaCaThanhToan, NVThanhToan, LoaiThanhToan, TrangThai, NgayLap });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            gridOrderList.DefaultCellStyle = dataGridViewCellStyle6;
            gridOrderList.GridColor = Color.FromArgb(231, 229, 255);
            gridOrderList.Location = new Point(29, 89);
            gridOrderList.Name = "gridOrderList";
            gridOrderList.ReadOnly = true;
            gridOrderList.RowHeadersVisible = false;
            gridOrderList.RowHeadersWidth = 51;
            gridOrderList.Size = new Size(1118, 486);
            gridOrderList.TabIndex = 1;
            gridOrderList.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridOrderList.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridOrderList.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridOrderList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridOrderList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridOrderList.ThemeStyle.BackColor = Color.White;
            gridOrderList.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gridOrderList.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gridOrderList.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gridOrderList.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            gridOrderList.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gridOrderList.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridOrderList.ThemeStyle.HeaderStyle.Height = 35;
            gridOrderList.ThemeStyle.ReadOnly = true;
            gridOrderList.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridOrderList.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridOrderList.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            gridOrderList.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gridOrderList.ThemeStyle.RowsStyle.Height = 29;
            gridOrderList.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridOrderList.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // MaDonHan
            // 
            MaDonHan.FillWeight = 70F;
            MaDonHan.HeaderText = "MãĐH";
            MaDonHan.MinimumWidth = 6;
            MaDonHan.Name = "MaDonHan";
            MaDonHan.ReadOnly = true;
            // 
            // MaCaLam
            // 
            MaCaLam.FillWeight = 70F;
            MaCaLam.HeaderText = "CaLập";
            MaCaLam.MinimumWidth = 6;
            MaCaLam.Name = "MaCaLam";
            MaCaLam.ReadOnly = true;
            // 
            // NVLap
            // 
            NVLap.FillWeight = 110F;
            NVLap.HeaderText = "NVLập";
            NVLap.MinimumWidth = 6;
            NVLap.Name = "NVLap";
            NVLap.ReadOnly = true;
            // 
            // MaCaThanhToan
            // 
            MaCaThanhToan.HeaderText = "CaThanhToán";
            MaCaThanhToan.MinimumWidth = 6;
            MaCaThanhToan.Name = "MaCaThanhToan";
            MaCaThanhToan.ReadOnly = true;
            // 
            // NVThanhToan
            // 
            NVThanhToan.FillWeight = 115F;
            NVThanhToan.HeaderText = "NVThanhToán";
            NVThanhToan.MinimumWidth = 6;
            NVThanhToan.Name = "NVThanhToan";
            NVThanhToan.ReadOnly = true;
            // 
            // LoaiThanhToan
            // 
            LoaiThanhToan.HeaderText = "ThanhToán";
            LoaiThanhToan.MinimumWidth = 6;
            LoaiThanhToan.Name = "LoaiThanhToan";
            LoaiThanhToan.ReadOnly = true;
            // 
            // TrangThai
            // 
            TrangThai.FillWeight = 105F;
            TrangThai.HeaderText = "TrạngThái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            TrangThai.ReadOnly = true;
            // 
            // NgayLap
            // 
            NgayLap.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NgayLap.FillWeight = 200F;
            NgayLap.HeaderText = "NgàyLập";
            NgayLap.MinimumWidth = 6;
            NgayLap.Name = "NgayLap";
            NgayLap.ReadOnly = true;
            // 
            // pnlOrderDetail
            // 
            pnlOrderDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlOrderDetail.BackColor = Color.Transparent;
            pnlOrderDetail.Controls.Add(guna2NumericUpDown1);
            pnlOrderDetail.Controls.Add(btnLuu);
            pnlOrderDetail.Controls.Add(btnChinhSua);
            pnlOrderDetail.Controls.Add(txtGhiChu);
            pnlOrderDetail.Controls.Add(gridOrderDetail);
            pnlOrderDetail.Controls.Add(label5);
            pnlOrderDetail.Controls.Add(label4);
            pnlOrderDetail.Controls.Add(label3);
            pnlOrderDetail.Controls.Add(label2);
            pnlOrderDetail.Controls.Add(label1);
            pnlOrderDetail.Controls.Add(btnExit);
            pnlOrderDetail.FillColor = Color.White;
            pnlOrderDetail.Location = new Point(646, 3);
            pnlOrderDetail.Name = "pnlOrderDetail";
            pnlOrderDetail.ShadowColor = Color.Black;
            pnlOrderDetail.ShadowShift = 2;
            pnlOrderDetail.Size = new Size(527, 680);
            pnlOrderDetail.TabIndex = 2;
            // 
            // guna2NumericUpDown1
            // 
            guna2NumericUpDown1.BackColor = Color.Transparent;
            guna2NumericUpDown1.BorderRadius = 5;
            guna2NumericUpDown1.CustomizableEdges = customizableEdges3;
            guna2NumericUpDown1.Font = new Font("Segoe UI", 9F);
            guna2NumericUpDown1.Location = new Point(112, 489);
            guna2NumericUpDown1.Margin = new Padding(3, 4, 3, 4);
            guna2NumericUpDown1.Name = "guna2NumericUpDown1";
            guna2NumericUpDown1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2NumericUpDown1.Size = new Size(83, 34);
            guna2NumericUpDown1.TabIndex = 5;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.BorderRadius = 5;
            btnLuu.CustomizableEdges = customizableEdges5;
            btnLuu.DisabledState.BorderColor = Color.DarkGray;
            btnLuu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLuu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLuu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLuu.FillColor = Color.FromArgb(113, 181, 108);
            btnLuu.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(406, 40);
            btnLuu.Name = "btnLuu";
            btnLuu.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLuu.Size = new Size(110, 34);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            // 
            // btnChinhSua
            // 
            btnChinhSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChinhSua.BorderRadius = 5;
            btnChinhSua.CustomizableEdges = customizableEdges7;
            btnChinhSua.DisabledState.BorderColor = Color.DarkGray;
            btnChinhSua.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChinhSua.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChinhSua.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChinhSua.FillColor = Color.DodgerBlue;
            btnChinhSua.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChinhSua.ForeColor = Color.White;
            btnChinhSua.Location = new Point(287, 40);
            btnChinhSua.Name = "btnChinhSua";
            btnChinhSua.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnChinhSua.Size = new Size(110, 36);
            btnChinhSua.TabIndex = 4;
            btnChinhSua.Text = "Chỉnh Sửa";
            btnChinhSua.Click += btnChinhSua_Click;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGhiChu.BorderRadius = 5;
            txtGhiChu.CustomizableEdges = customizableEdges9;
            txtGhiChu.DefaultText = "";
            txtGhiChu.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtGhiChu.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtGhiChu.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtGhiChu.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtGhiChu.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtGhiChu.Font = new Font("Segoe UI", 9F);
            txtGhiChu.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtGhiChu.Location = new Point(97, 544);
            txtGhiChu.Margin = new Padding(3, 4, 3, 4);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.PlaceholderText = "";
            txtGhiChu.SelectedText = "";
            txtGhiChu.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtGhiChu.Size = new Size(425, 102);
            txtGhiChu.TabIndex = 3;
            // 
            // gridOrderDetail
            // 
            gridOrderDetail.AllowUserToAddRows = false;
            gridOrderDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            gridOrderDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridOrderDetail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridOrderDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridOrderDetail.ColumnHeadersHeight = 35;
            gridOrderDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridOrderDetail.Columns.AddRange(new DataGridViewColumn[] { RemoveItem, TenSP, DonGia, SoLuong });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridOrderDetail.DefaultCellStyle = dataGridViewCellStyle3;
            gridOrderDetail.GridColor = Color.FromArgb(231, 229, 255);
            gridOrderDetail.Location = new Point(12, 82);
            gridOrderDetail.Name = "gridOrderDetail";
            gridOrderDetail.ReadOnly = true;
            gridOrderDetail.RowHeadersVisible = false;
            gridOrderDetail.RowHeadersWidth = 51;
            gridOrderDetail.Size = new Size(504, 390);
            gridOrderDetail.TabIndex = 2;
            gridOrderDetail.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridOrderDetail.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridOrderDetail.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridOrderDetail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridOrderDetail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridOrderDetail.ThemeStyle.BackColor = Color.White;
            gridOrderDetail.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gridOrderDetail.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gridOrderDetail.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gridOrderDetail.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            gridOrderDetail.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gridOrderDetail.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridOrderDetail.ThemeStyle.HeaderStyle.Height = 35;
            gridOrderDetail.ThemeStyle.ReadOnly = true;
            gridOrderDetail.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridOrderDetail.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridOrderDetail.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            gridOrderDetail.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gridOrderDetail.ThemeStyle.RowsStyle.Height = 29;
            gridOrderDetail.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridOrderDetail.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gridOrderDetail.CellClick += gridOrderDetail_CellClick;
            gridOrderDetail.CellValueChanged += gridOrderDetail_CellValueChanged;
            // 
            // RemoveItem
            // 
            RemoveItem.FillWeight = 30F;
            RemoveItem.HeaderText = "";
            RemoveItem.Image = Properties.Resources.recyclebin2;
            RemoveItem.ImageLayout = DataGridViewImageCellLayout.Zoom;
            RemoveItem.MinimumWidth = 6;
            RemoveItem.Name = "RemoveItem";
            RemoveItem.ReadOnly = true;
            // 
            // TenSP
            // 
            TenSP.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TenSP.FillWeight = 250F;
            TenSP.HeaderText = "TênSP";
            TenSP.MinimumWidth = 6;
            TenSP.Name = "TenSP";
            TenSP.ReadOnly = true;
            // 
            // DonGia
            // 
            DonGia.HeaderText = "ĐơnGiá";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SoLuong.HeaderText = "SốLượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            SoLuong.Width = 105;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(492, 489);
            label5.Name = "label5";
            label5.Size = new Size(24, 28);
            label5.TabIndex = 1;
            label5.Text = "đ";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(275, 489);
            label4.Name = "label4";
            label4.Size = new Size(109, 28);
            label4.TabIndex = 1;
            label4.Text = "Tổng Tiền:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 489);
            label3.Name = "label3";
            label3.Size = new Size(94, 28);
            label3.TabIndex = 1;
            label3.Text = "Giảm Giá";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 544);
            label2.Name = "label2";
            label2.Size = new Size(85, 28);
            label2.TabIndex = 1;
            label2.Text = "Ghi Chú";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 46);
            label1.Name = "label1";
            label1.Size = new Size(180, 28);
            label1.TabIndex = 1;
            label1.Text = "Chi Tiết Đơn Hàng";
            // 
            // btnExit
            // 
            btnExit.BorderColor = Color.FromArgb(224, 224, 224);
            btnExit.BorderRadius = 2;
            btnExit.BorderThickness = 1;
            btnExit.CustomizableEdges = customizableEdges11;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.FillColor = Color.Transparent;
            btnExit.Font = new Font("Segoe UI", 9F);
            btnExit.ForeColor = Color.White;
            btnExit.Image = Properties.Resources.exit;
            btnExit.Location = new Point(12, 9);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnExit.Size = new Size(41, 32);
            btnExit.TabIndex = 0;
            btnExit.Click += btnExit_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // btnViewDetail
            // 
            btnViewDetail.BorderRadius = 5;
            btnViewDetail.CustomizableEdges = customizableEdges1;
            btnViewDetail.DisabledState.BorderColor = Color.DarkGray;
            btnViewDetail.DisabledState.CustomBorderColor = Color.DarkGray;
            btnViewDetail.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnViewDetail.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnViewDetail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewDetail.ForeColor = Color.White;
            btnViewDetail.Location = new Point(29, 47);
            btnViewDetail.Name = "btnViewDetail";
            btnViewDetail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnViewDetail.Size = new Size(139, 36);
            btnViewDetail.TabIndex = 3;
            btnViewDetail.Text = "Xem Chi Tiết";
            btnViewDetail.Click += btnViewDetail_Click;
            // 
            // frmOrderList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 685);
            Controls.Add(btnViewDetail);
            Controls.Add(pnlOrderDetail);
            Controls.Add(gridOrderList);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmOrderList";
            Text = "frmOrderList";
            Load += frmOrderList_Load;
            ((System.ComponentModel.ISupportInitialize)gridOrderList).EndInit();
            pnlOrderDetail.ResumeLayout(false);
            pnlOrderDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridOrderDetail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DataGridView gridOrderList;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlOrderDetail;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Label label1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Guna.UI2.WinForms.Guna2DataGridView gridOrderDetail;
        private DataGridViewImageColumn RemoveItem;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn SoLuong;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtGhiChu;
        private Guna.UI2.WinForms.Guna2Button btnChinhSua;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Label label3;
        private Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown1;
        private Label label4;
        private Label label5;
        private DataGridViewTextBoxColumn MaDonHan;
        private DataGridViewTextBoxColumn MaCaLam;
        private DataGridViewTextBoxColumn NVLap;
        private DataGridViewTextBoxColumn MaCaThanhToan;
        private DataGridViewTextBoxColumn NVThanhToan;
        private DataGridViewTextBoxColumn LoaiThanhToan;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewTextBoxColumn NgayLap;
        private Guna.UI2.WinForms.Guna2Button btnViewDetail;
    }
}