namespace GUI.components
{
    partial class InvoiceItem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblThanhtien = new Label();
            lblDongia = new Label();
            lblTenMon = new Label();
            picDeleteItem = new Guna.UI2.WinForms.Guna2PictureBox();
            numSoluong = new Guna.UI2.WinForms.Guna2NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)picDeleteItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoluong).BeginInit();
            SuspendLayout();
            // 
            // lblThanhtien
            // 
            lblThanhtien.AutoSize = true;
            lblThanhtien.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThanhtien.Location = new Point(406, 21);
            lblThanhtien.Name = "lblThanhtien";
            lblThanhtien.Size = new Size(60, 23);
            lblThanhtien.TabIndex = 0;
            lblThanhtien.Text = "20000";
            // 
            // lblDongia
            // 
            lblDongia.AutoSize = true;
            lblDongia.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDongia.Location = new Point(226, 21);
            lblDongia.Name = "lblDongia";
            lblDongia.Size = new Size(60, 23);
            lblDongia.TabIndex = 0;
            lblDongia.Text = "10000";
            // 
            // lblTenMon
            // 
            lblTenMon.AutoSize = true;
            lblTenMon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenMon.Location = new Point(41, 21);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(180, 23);
            lblTenMon.TabIndex = 0;
            lblTenMon.Text = "Lipton sữa chanh dây";
            // 
            // picDeleteItem
            // 
            picDeleteItem.Cursor = Cursors.Hand;
            picDeleteItem.CustomizableEdges = customizableEdges1;
            picDeleteItem.Image = Properties.Resources.recyclebin1;
            picDeleteItem.ImageRotate = 0F;
            picDeleteItem.Location = new Point(3, 11);
            picDeleteItem.Name = "picDeleteItem";
            picDeleteItem.ShadowDecoration.CustomizableEdges = customizableEdges2;
            picDeleteItem.Size = new Size(39, 38);
            picDeleteItem.SizeMode = PictureBoxSizeMode.Zoom;
            picDeleteItem.TabIndex = 1;
            picDeleteItem.TabStop = false;
            picDeleteItem.Click += picDeleteItem_Click;
            // 
            // numSoluong
            // 
            numSoluong.BackColor = Color.Transparent;
            numSoluong.BorderRadius = 5;
            numSoluong.CustomizableEdges = customizableEdges3;
            numSoluong.Font = new Font("Segoe UI", 9F);
            numSoluong.Location = new Point(303, 14);
            numSoluong.Margin = new Padding(3, 4, 3, 4);
            numSoluong.Name = "numSoluong";
            numSoluong.ShadowDecoration.CustomizableEdges = customizableEdges4;
            numSoluong.Size = new Size(63, 35);
            numSoluong.TabIndex = 2;
            numSoluong.UpDownButtonFillColor = Color.FromArgb(244, 129, 17);
            numSoluong.ValueChanged += numSoluong_ValueChanged;
            // 
            // InvoiceItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numSoluong);
            Controls.Add(picDeleteItem);
            Controls.Add(lblTenMon);
            Controls.Add(lblDongia);
            Controls.Add(lblThanhtien);
            Name = "InvoiceItem";
            Size = new Size(479, 58);
            ((System.ComponentModel.ISupportInitialize)picDeleteItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoluong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblThanhtien;
        private Label lblDongia;
        private Label lblTenMon;
        private Guna.UI2.WinForms.Guna2PictureBox picDeleteItem;
        private Guna.UI2.WinForms.Guna2NumericUpDown numSoluong;
    }
}
