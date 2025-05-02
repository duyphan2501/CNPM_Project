namespace GUI
{
    partial class frmTaiKhoan
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaiKhoan));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cboTrangthai = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            gridDsTaikhoan = new Guna.UI2.WinForms.Guna2DataGridView();
            btnUpdate = new DataGridViewImageColumn();
            label1 = new Label();
            dataGridViewImageColumn1 = new DataGridViewImageColumn();
            btnTaotaikhoan = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDsTaikhoan).BeginInit();
            SuspendLayout();
            // 
            // cboTrangthai
            // 
            cboTrangthai.BackColor = Color.Transparent;
            cboTrangthai.BorderRadius = 5;
            cboTrangthai.CustomizableEdges = customizableEdges1;
            cboTrangthai.DrawMode = DrawMode.OwnerDrawFixed;
            cboTrangthai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangthai.FocusedColor = Color.FromArgb(94, 148, 255);
            cboTrangthai.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboTrangthai.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            cboTrangthai.ForeColor = Color.Black;
            cboTrangthai.ItemHeight = 30;
            cboTrangthai.Items.AddRange(new object[] { "Hoạt Động", "Vô Hiệu" });
            cboTrangthai.Location = new Point(1228, 58);
            cboTrangthai.Margin = new Padding(2, 4, 2, 4);
            cboTrangthai.Name = "cboTrangthai";
            cboTrangthai.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cboTrangthai.Size = new Size(189, 36);
            cboTrangthai.TabIndex = 4;
            cboTrangthai.SelectedIndexChanged += cboTrangthai_SelectedIndexChanged;
            // 
            // guna2GroupBox1
            // 
            guna2GroupBox1.BackColor = SystemColors.Control;
            guna2GroupBox1.BorderRadius = 5;
            guna2GroupBox1.BorderThickness = 0;
            guna2GroupBox1.Controls.Add(gridDsTaikhoan);
            guna2GroupBox1.CustomBorderThickness = new Padding(0);
            guna2GroupBox1.CustomizableEdges = customizableEdges3;
            guna2GroupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2GroupBox1.ForeColor = Color.Black;
            guna2GroupBox1.Location = new Point(25, 114);
            guna2GroupBox1.Margin = new Padding(2, 4, 2, 4);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GroupBox1.Size = new Size(1473, 748);
            guna2GroupBox1.TabIndex = 7;
            guna2GroupBox1.Text = "Danh sách tài khoản";
            // 
            // gridDsTaikhoan
            // 
            gridDsTaikhoan.AllowUserToAddRows = false;
            gridDsTaikhoan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            gridDsTaikhoan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(244, 129, 17);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(217, 98, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridDsTaikhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridDsTaikhoan.ColumnHeadersHeight = 40;
            gridDsTaikhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridDsTaikhoan.Columns.AddRange(new DataGridViewColumn[] { btnUpdate });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 167, 73);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridDsTaikhoan.DefaultCellStyle = dataGridViewCellStyle3;
            gridDsTaikhoan.GridColor = Color.White;
            gridDsTaikhoan.Location = new Point(14, 54);
            gridDsTaikhoan.Margin = new Padding(2, 4, 2, 4);
            gridDsTaikhoan.Name = "gridDsTaikhoan";
            gridDsTaikhoan.ReadOnly = true;
            gridDsTaikhoan.RowHeadersVisible = false;
            gridDsTaikhoan.RowHeadersWidth = 51;
            gridDsTaikhoan.RowTemplate.Height = 40;
            gridDsTaikhoan.Size = new Size(1442, 676);
            gridDsTaikhoan.TabIndex = 0;
            gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridDsTaikhoan.ThemeStyle.BackColor = Color.White;
            gridDsTaikhoan.ThemeStyle.GridColor = Color.White;
            gridDsTaikhoan.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gridDsTaikhoan.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gridDsTaikhoan.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridDsTaikhoan.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gridDsTaikhoan.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridDsTaikhoan.ThemeStyle.HeaderStyle.Height = 40;
            gridDsTaikhoan.ThemeStyle.ReadOnly = true;
            gridDsTaikhoan.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridDsTaikhoan.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridDsTaikhoan.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridDsTaikhoan.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            gridDsTaikhoan.ThemeStyle.RowsStyle.Height = 40;
            gridDsTaikhoan.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridDsTaikhoan.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gridDsTaikhoan.CellClick += gridDsTaikhoan_CellClick;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(244, 103, 0);
            label1.Location = new Point(1100, 58);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(112, 28);
            label1.TabIndex = 8;
            label1.Text = "Trạng Thái";
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewImageColumn1.HeaderText = "";
            dataGridViewImageColumn1.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridViewImageColumn1.MinimumWidth = 6;
            dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            dataGridViewImageColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewImageColumn1.Width = 150;
            // 
            // btnTaotaikhoan
            // 
            btnTaotaikhoan.AutoRoundedCorners = true;
            btnTaotaikhoan.CustomizableEdges = customizableEdges5;
            btnTaotaikhoan.DisabledState.BorderColor = Color.DarkGray;
            btnTaotaikhoan.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTaotaikhoan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTaotaikhoan.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnTaotaikhoan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTaotaikhoan.FillColor = Color.FromArgb(244, 103, 0);
            btnTaotaikhoan.FillColor2 = Color.DarkOrange;
            btnTaotaikhoan.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            btnTaotaikhoan.ForeColor = Color.White;
            btnTaotaikhoan.Location = new Point(25, 39);
            btnTaotaikhoan.Margin = new Padding(2, 4, 2, 4);
            btnTaotaikhoan.Name = "btnTaotaikhoan";
            btnTaotaikhoan.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnTaotaikhoan.Size = new Size(154, 55);
            btnTaotaikhoan.TabIndex = 1;
            btnTaotaikhoan.Text = "Tạo tài khoản";
            btnTaotaikhoan.Click += btnTaotaikhoan_Click;
            // 
            // frmTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 222, 224);
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1536, 882);
            Controls.Add(label1);
            Controls.Add(guna2GroupBox1);
            Controls.Add(cboTrangthai);
            Controls.Add(btnTaotaikhoan);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 4, 2, 4);
            Name = "frmTaiKhoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmTaiKhoan";
            Load += frmTaiKhoan_Load;
            guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridDsTaikhoan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientButton btnTaotaikhoan;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangthai;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView gridDsTaikhoan;
        private System.Windows.Forms.Label label1;
        private DataGridViewImageColumn btnUpdate;
    }
}