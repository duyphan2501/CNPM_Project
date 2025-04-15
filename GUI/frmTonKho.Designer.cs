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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            gridDsTonkho = new Guna.UI2.WinForms.Guna2DataGridView();
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
            guna2GroupBox1.CustomizableEdges = customizableEdges5;
            guna2GroupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2GroupBox1.ForeColor = Color.Black;
            guna2GroupBox1.Location = new Point(32, 133);
            guna2GroupBox1.Margin = new Padding(3, 5, 3, 5);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2GroupBox1.Size = new Size(1841, 935);
            guna2GroupBox1.TabIndex = 8;
            guna2GroupBox1.Text = "Danh sách tồn kho";
            // 
            // gridDsTonkho
            // 
            gridDsTonkho.AllowUserToAddRows = false;
            gridDsTonkho.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = Color.White;
            gridDsTonkho.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(244, 103, 0);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            gridDsTonkho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            gridDsTonkho.ColumnHeadersHeight = 40;
            gridDsTonkho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            gridDsTonkho.DefaultCellStyle = dataGridViewCellStyle9;
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
            // frmTonKho
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1900, 1100);
            Controls.Add(guna2GroupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmTonKho";
            Text = "frmTonKho";
            Load += frmTonKho_Load;
            guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridDsTonkho).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView gridDsTonkho;
    }
}