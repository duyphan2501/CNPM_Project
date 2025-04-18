namespace GUI
{
    partial class frmTonKho
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
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            gridDsTonkho = new Guna.UI2.WinForms.Guna2DataGridView();
            label1 = new Label();
            cboLoc = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDsTonkho).BeginInit();
            SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            guna2GroupBox1.BackColor = SystemColors.Control;
            guna2GroupBox1.BorderThickness = 0;
            guna2GroupBox1.Controls.Add(gridDsTonkho);
            guna2GroupBox1.CustomBorderThickness = new Padding(0);
            guna2GroupBox1.CustomizableEdges = customizableEdges1;
            guna2GroupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2GroupBox1.ForeColor = Color.Black;
            guna2GroupBox1.Location = new Point(32, 133);
            guna2GroupBox1.Margin = new Padding(3, 5, 3, 5);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GroupBox1.Size = new Size(1841, 935);
            guna2GroupBox1.TabIndex = 8;
            guna2GroupBox1.Text = "Danh sách tồn kho";
            // 
            // gridDsTonkho
            // 
            gridDsTonkho.AllowUserToAddRows = false;
            gridDsTonkho.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            gridDsTonkho.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(244, 103, 0);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridDsTonkho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridDsTonkho.ColumnHeadersHeight = 40;
            gridDsTonkho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridDsTonkho.DefaultCellStyle = dataGridViewCellStyle3;
            gridDsTonkho.GridColor = Color.White;
            gridDsTonkho.Location = new Point(17, 68);
            gridDsTonkho.Margin = new Padding(3, 5, 3, 5);
            gridDsTonkho.Name = "gridDsTonkho";
            gridDsTonkho.ReadOnly = true;
            gridDsTonkho.RowHeadersVisible = false;
            gridDsTonkho.RowHeadersWidth = 51;
            gridDsTonkho.RowTemplate.Height = 24;
            gridDsTonkho.Size = new Size(1803, 845);
            gridDsTonkho.TabIndex = 0;
            gridDsTonkho.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridDsTonkho.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridDsTonkho.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridDsTonkho.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridDsTonkho.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridDsTonkho.ThemeStyle.BackColor = Color.White;
            gridDsTonkho.ThemeStyle.GridColor = Color.White;
            gridDsTonkho.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gridDsTonkho.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gridDsTonkho.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridDsTonkho.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gridDsTonkho.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridDsTonkho.ThemeStyle.HeaderStyle.Height = 40;
            gridDsTonkho.ThemeStyle.ReadOnly = true;
            gridDsTonkho.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridDsTonkho.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridDsTonkho.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridDsTonkho.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            gridDsTonkho.ThemeStyle.RowsStyle.Height = 24;
            gridDsTonkho.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridDsTonkho.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(244, 103, 0);
            label1.Location = new Point(1141, 52);
            label1.Name = "label1";
            label1.Size = new Size(53, 32);
            label1.TabIndex = 12;
            label1.Text = "Lọc";
            // 
            // cboLoc
            // 
            cboLoc.BackColor = Color.Transparent;
            cboLoc.CustomizableEdges = customizableEdges3;
            cboLoc.DrawMode = DrawMode.OwnerDrawFixed;
            cboLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoc.FocusedColor = Color.FromArgb(94, 148, 255);
            cboLoc.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboLoc.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            cboLoc.ForeColor = Color.Black;
            cboLoc.ItemHeight = 30;
            cboLoc.Items.AddRange(new object[] { "Tất cả", "Cần nhập" });
            cboLoc.Location = new Point(1239, 48);
            cboLoc.Margin = new Padding(3, 5, 3, 5);
            cboLoc.Name = "cboLoc";
            cboLoc.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboLoc.Size = new Size(235, 36);
            cboLoc.TabIndex = 11;
            cboLoc.SelectedIndexChanged += cboLoc_SelectedIndexChanged;
            // 
            // frmTonKho
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1900, 1100);
            Controls.Add(label1);
            Controls.Add(cboLoc);
            Controls.Add(guna2GroupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmTonKho";
            Text = "frmTonKho";
            Load += frmTonKho_Load;
            guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridDsTonkho).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView gridDsTonkho;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoc;
    }
}