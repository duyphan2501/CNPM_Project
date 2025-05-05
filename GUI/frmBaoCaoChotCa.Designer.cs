namespace GUI
{
    partial class frmBaoCaoChotCa
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
            btnViewDetail = new Guna.UI2.WinForms.Guna2Button();
            gridCaLam = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlPagination = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)gridCaLam).BeginInit();
            SuspendLayout();
            // 
            // btnViewDetail
            // 
            btnViewDetail.BorderRadius = 8;
            btnViewDetail.CustomizableEdges = customizableEdges1;
            btnViewDetail.DisabledState.BorderColor = Color.DarkGray;
            btnViewDetail.DisabledState.CustomBorderColor = Color.DarkGray;
            btnViewDetail.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnViewDetail.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnViewDetail.FillColor = Color.FromArgb(0, 92, 191);
            btnViewDetail.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewDetail.ForeColor = Color.White;
            btnViewDetail.Location = new Point(36, 37);
            btnViewDetail.Name = "btnViewDetail";
            btnViewDetail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnViewDetail.Size = new Size(157, 43);
            btnViewDetail.TabIndex = 0;
            btnViewDetail.Text = "Xem chi tiết";
            btnViewDetail.Click += btnViewDetail_Click;
            // 
            // gridCaLam
            // 
            gridCaLam.AllowUserToAddRows = false;
            gridCaLam.AllowUserToDeleteRows = false;
            gridCaLam.AllowUserToResizeColumns = false;
            gridCaLam.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            gridCaLam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridCaLam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(244, 129, 17);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(217, 98, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridCaLam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridCaLam.ColumnHeadersHeight = 40;
            gridCaLam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 167, 73);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridCaLam.DefaultCellStyle = dataGridViewCellStyle3;
            gridCaLam.GridColor = Color.FromArgb(231, 229, 255);
            gridCaLam.Location = new Point(36, 100);
            gridCaLam.Name = "gridCaLam";
            gridCaLam.ReadOnly = true;
            gridCaLam.RowHeadersVisible = false;
            gridCaLam.RowHeadersWidth = 51;
            gridCaLam.RowTemplate.Height = 40;
            gridCaLam.Size = new Size(1162, 722);
            gridCaLam.TabIndex = 1;
            gridCaLam.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridCaLam.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridCaLam.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridCaLam.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridCaLam.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridCaLam.ThemeStyle.BackColor = Color.White;
            gridCaLam.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gridCaLam.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gridCaLam.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gridCaLam.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            gridCaLam.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gridCaLam.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridCaLam.ThemeStyle.HeaderStyle.Height = 40;
            gridCaLam.ThemeStyle.ReadOnly = true;
            gridCaLam.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridCaLam.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridCaLam.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            gridCaLam.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gridCaLam.ThemeStyle.RowsStyle.Height = 40;
            gridCaLam.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridCaLam.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // pnlPagination
            // 
            pnlPagination.CustomizableEdges = customizableEdges3;
            pnlPagination.Location = new Point(36, 834);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlPagination.Size = new Size(1029, 55);
            pnlPagination.TabIndex = 2;
            // 
            // frmBaoCaoChotCa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 899);
            Controls.Add(pnlPagination);
            Controls.Add(gridCaLam);
            Controls.Add(btnViewDetail);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmBaoCaoChotCa";
            Text = "frmBaoCaoChotCa";
            Load += frmBaoCaoChotCa_Load;
            ((System.ComponentModel.ISupportInitialize)gridCaLam).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnViewDetail;
        private Guna.UI2.WinForms.Guna2DataGridView gridCaLam;
        private Guna.UI2.WinForms.Guna2Panel pnlPagination;
    }
}