using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    public static class General
    {


        //chuyển hình ảnh sang byte[];
        public static byte[] ImageToByteArray(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        //chuyển byte[] sang hình ảnh;
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray != null)
            {
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    return Image.FromStream(ms);
                }
            }
            return null;
        }

        public static void SetFullScreen(Form frm)
        {
            // Đặt form toàn màn hình
            frm.Location = new Point(0, 0);
            frm.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }


        private class BlurBackgroundForm : Form
        {
            public BlurBackgroundForm()
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.BackColor = Color.Black;
                this.Opacity = 0.5;
                this.ShowInTaskbar = false;
                this.StartPosition = FormStartPosition.Manual;
                this.TopMost = false;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
        }

        public static DialogResult ShowDialogWithBlur(Form dialog)
        {
            // Lấy form hiện tại (active) để đặt làm owner
            Form mainForm = Form.ActiveForm;

            // Tạo lớp nền mờ
            BlurBackgroundForm blur = new BlurBackgroundForm();
            if (mainForm != null)
            {
                blur.StartPosition = FormStartPosition.Manual;
                blur.Location = mainForm.Location;
                blur.Size = mainForm.Size;
                blur.Owner = mainForm;
            }

            blur.Show();

            dialog.StartPosition = FormStartPosition.CenterParent;
            var result = dialog.ShowDialog(blur);

            blur.Close();

            return result;
        }

        public static string FormatMoney(int money)
        {
            return money.ToString("N0").Trim() + "đ";
        }

        public static int FormatMoneyToInt(string money)
        {
            money = money.Replace(",", "").Replace("đ", "").Trim();
            return Int32.Parse(money);
        }

        public static void ShowError(string text, Form parent)
        {
            if (parent == null || parent.IsDisposed || !parent.IsHandleCreated || !parent.TopLevel)
            {
                MessageBox.Show(text, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var dialog = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Text = text,
                    Caption = "Lỗi",
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Error,
                    Parent = parent
                };
                dialog.Show();
            }
            catch
            {
                MessageBox.Show(parent, text, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ShowWarning(string text, Form parent)
        {
            if (parent == null || parent.IsDisposed || !parent.IsHandleCreated || !parent.TopLevel)
            {
                MessageBox.Show(text, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dialog = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Text = text,
                    Caption = "Cảnh báo",
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning,
                    Parent = parent
                };
                dialog.Show();
            }
            catch
            {
                MessageBox.Show(parent, text, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        public static DialogResult ShowConfirm(string text, Form parent)
        {
            if (parent == null || parent.IsDisposed || !parent.IsHandleCreated || !parent.TopLevel)
            {
                return MessageBox.Show(text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            try
            {
                var dialog = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Text = text,
                    Caption = "Xác nhận",
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo,
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Question,
                    Parent = parent
                };
                return dialog.Show();
            }
            catch
            {
                return MessageBox.Show(parent, text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }


        public static void ShowInformation(string text, Form parent)
        {
            // Kiểm tra nếu parent không hợp lệ thì dùng MessageBox
            if (parent == null || parent.IsDisposed || !parent.IsHandleCreated || !parent.TopLevel)
            {
                MessageBox.Show(text, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var dialog = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Text = text,
                    Caption = "Thông tin",
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Information,
                    Parent = parent
                };
                dialog.Show();
            }
            catch
            {
                // Fallback nếu Guna dialog vẫn bị lỗi
                MessageBox.Show(parent, text, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
