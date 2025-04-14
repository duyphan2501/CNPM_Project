namespace GUI.components
{
    partial class TheRung
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnTheRung = new Guna.UI2.WinForms.Guna2CircleButton();
            pnlSoThe = new Guna.UI2.WinForms.Guna2ShadowPanel();
            label1 = new Label();
            pnlSoThe.SuspendLayout();
            SuspendLayout();
            // 
            // btnTheRung
            // 
            btnTheRung.Cursor = Cursors.Hand;
            btnTheRung.DisabledState.BorderColor = Color.DarkGray;
            btnTheRung.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTheRung.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTheRung.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTheRung.FillColor = Color.White;
            btnTheRung.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTheRung.ForeColor = Color.Black;
            btnTheRung.Location = new Point(19, 44);
            btnTheRung.Name = "btnTheRung";
            btnTheRung.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnTheRung.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnTheRung.Size = new Size(84, 77);
            btnTheRung.TabIndex = 0;
            btnTheRung.Text = "01";
            btnTheRung.Click += btnTheRung_Click;
            // 
            // pnlSoThe
            // 
            pnlSoThe.BackColor = Color.Transparent;
            pnlSoThe.Controls.Add(label1);
            pnlSoThe.Controls.Add(btnTheRung);
            pnlSoThe.FillColor = Color.FromArgb(169, 228, 66);
            pnlSoThe.Location = new Point(3, 13);
            pnlSoThe.Name = "pnlSoThe";
            pnlSoThe.Radius = 5;
            pnlSoThe.ShadowColor = Color.Black;
            pnlSoThe.ShadowShift = 2;
            pnlSoThe.Size = new Size(122, 139);
            pnlSoThe.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 11);
            label1.Name = "label1";
            label1.Size = new Size(76, 28);
            label1.TabIndex = 1;
            label1.Text = "Số Thẻ";
            // 
            // TheRung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlSoThe);
            Name = "TheRung";
            Size = new Size(128, 155);
            pnlSoThe.ResumeLayout(false);
            pnlSoThe.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleButton btnTheRung;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlSoThe;
        private Label label1;
    }
}
