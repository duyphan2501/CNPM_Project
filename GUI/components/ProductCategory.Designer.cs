namespace GUI.components
{
    partial class ProductCategory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnTenLoai = new Guna.UI2.WinForms.Guna2GradientButton();
            SuspendLayout();
            // 
            // btnTenLoai
            // 
            btnTenLoai.BorderColor = Color.FromArgb(244, 129, 17);
            btnTenLoai.BorderRadius = 5;
            btnTenLoai.CheckedState.FillColor = Color.FromArgb(244, 129, 17);
            btnTenLoai.CheckedState.FillColor2 = Color.FromArgb(244, 129, 17);
            btnTenLoai.CustomizableEdges = customizableEdges1;
            btnTenLoai.DisabledState.BorderColor = Color.DarkGray;
            btnTenLoai.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTenLoai.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTenLoai.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnTenLoai.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTenLoai.FillColor = Color.White;
            btnTenLoai.FillColor2 = Color.White;
            btnTenLoai.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTenLoai.ForeColor = Color.DimGray;
            btnTenLoai.HoverState.FillColor = Color.FromArgb(244, 129, 17);
            btnTenLoai.HoverState.FillColor2 = Color.FromArgb(244, 129, 17);
            btnTenLoai.HoverState.ForeColor = Color.White;
            btnTenLoai.Location = new Point(2, 3);
            btnTenLoai.Name = "btnTenLoai";
            btnTenLoai.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnTenLoai.Size = new Size(149, 58);
            btnTenLoai.TabIndex = 0;
            btnTenLoai.Text = "Tất Cả";
            btnTenLoai.Click += btnTenLoai_Click;
            // 
            // ProductCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnTenLoai);
            Name = "ProductCategory";
            Size = new Size(154, 64);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnTenLoai;
    }
}
