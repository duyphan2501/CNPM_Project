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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboTrangthai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.gridDsTaikhoan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnUpdate = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnTaotaikhoan = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDsTaikhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTrangthai
            // 
            this.cboTrangthai.BackColor = System.Drawing.Color.Transparent;
            this.cboTrangthai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTrangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangthai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangthai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangthai.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.cboTrangthai.ForeColor = System.Drawing.Color.Black;
            this.cboTrangthai.ItemHeight = 30;
            this.cboTrangthai.Items.AddRange(new object[] {
            "Hoạt Động",
            "Vô Hiệu"});
            this.cboTrangthai.Location = new System.Drawing.Point(986, 70);
            this.cboTrangthai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTrangthai.Name = "cboTrangthai";
            this.cboTrangthai.Size = new System.Drawing.Size(212, 36);
            this.cboTrangthai.TabIndex = 4;
            this.cboTrangthai.SelectedIndexChanged += new System.EventHandler(this.cboTrangthai_SelectedIndexChanged);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.guna2GroupBox1.BorderThickness = 0;
            this.guna2GroupBox1.Controls.Add(this.gridDsTaikhoan);
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(14, 142);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1361, 722);
            this.guna2GroupBox1.TabIndex = 7;
            this.guna2GroupBox1.Text = "Danh sách tài khoản";
            // 
            // gridDsTaikhoan
            // 
            this.gridDsTaikhoan.AllowUserToAddRows = false;
            this.gridDsTaikhoan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gridDsTaikhoan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDsTaikhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDsTaikhoan.ColumnHeadersHeight = 40;
            this.gridDsTaikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gridDsTaikhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnUpdate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDsTaikhoan.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridDsTaikhoan.GridColor = System.Drawing.Color.White;
            this.gridDsTaikhoan.Location = new System.Drawing.Point(3, 54);
            this.gridDsTaikhoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridDsTaikhoan.Name = "gridDsTaikhoan";
            this.gridDsTaikhoan.ReadOnly = true;
            this.gridDsTaikhoan.RowHeadersVisible = false;
            this.gridDsTaikhoan.RowHeadersWidth = 51;
            this.gridDsTaikhoan.RowTemplate.Height = 24;
            this.gridDsTaikhoan.Size = new System.Drawing.Size(1353, 639);
            this.gridDsTaikhoan.TabIndex = 0;
            this.gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridDsTaikhoan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridDsTaikhoan.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gridDsTaikhoan.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.gridDsTaikhoan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gridDsTaikhoan.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridDsTaikhoan.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDsTaikhoan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridDsTaikhoan.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gridDsTaikhoan.ThemeStyle.HeaderStyle.Height = 40;
            this.gridDsTaikhoan.ThemeStyle.ReadOnly = true;
            this.gridDsTaikhoan.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gridDsTaikhoan.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridDsTaikhoan.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDsTaikhoan.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gridDsTaikhoan.ThemeStyle.RowsStyle.Height = 24;
            this.gridDsTaikhoan.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridDsTaikhoan.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridDsTaikhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDsTaikhoan_CellClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnUpdate.HeaderText = "";
            this.btnUpdate.Image = global::GUI.Properties.Resources.update;
            this.btnUpdate.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.btnUpdate.MinimumWidth = 50;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ReadOnly = true;
            this.btnUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnUpdate.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(835, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Trạng Thái";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 150;
            // 
            // btnTaotaikhoan
            // 
            this.btnTaotaikhoan.AutoRoundedCorners = true;
            this.btnTaotaikhoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaotaikhoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaotaikhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaotaikhoan.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaotaikhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaotaikhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            this.btnTaotaikhoan.FillColor2 = System.Drawing.Color.DarkOrange;
            this.btnTaotaikhoan.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.btnTaotaikhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaotaikhoan.Location = new System.Drawing.Point(40, 60);
            this.btnTaotaikhoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTaotaikhoan.Name = "btnTaotaikhoan";
            this.btnTaotaikhoan.Size = new System.Drawing.Size(174, 55);
            this.btnTaotaikhoan.TabIndex = 1;
            this.btnTaotaikhoan.Text = "Tạo tài khoản";
            this.btnTaotaikhoan.Click += new System.EventHandler(this.btnTaotaikhoan_Click);
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1387, 854);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.cboTrangthai);
            this.Controls.Add(this.btnTaotaikhoan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTaiKhoan";
            this.Text = "frmTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDsTaikhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientButton btnTaotaikhoan;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangthai;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView gridDsTaikhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn btnUpdate;
    }
}