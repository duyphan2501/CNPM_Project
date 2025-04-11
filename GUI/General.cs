using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
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
    }
}
