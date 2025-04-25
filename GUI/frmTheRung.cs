using BUS;
using GUI.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTheRung : Form
    {
        List<TheRung> deletedTheRung = new List<TheRung>();
        BUS_TheRung theRungBUS;
        DataTable allTheRung;
        enum FormState
        {
            None, Insert, Update, Delete
        }
        FormState currentMode = FormState.None;
        public TheRung SelectedTheRung;

        public frmTheRung()
        {
            InitializeComponent();
        }

        private void frmTheRung_Load(object sender, EventArgs e)
        {
            txtMaThe.ReadOnly = true;
            LoadTheRung();
            LoadCboTrangThaiThe();
            ResetForm();
        }

        private void LoadTheRung()
        {
            theRungBUS = new BUS_TheRung();
            // lấy tất cả thẻ rung
            allTheRung = theRungBUS.SelectALlTheRung();

            // thêm vào pnlTheRung
            foreach (DataRow dr in allTheRung.Rows)
            {
                // lấy thông tin 
                string soThe = dr["SoThe"].ToString();
                string maThe = dr["MaThe"].ToString();
                int trangThai = Int32.Parse(dr["TrangThai"].ToString());
                TheRung theRung = new TheRung(soThe, maThe, trangThai);
                theRung.theRung_Clicked += TheRung_Clicked; // thêm sự kiện để biết nút đc click
                pnlTheRung.Controls.Add(theRung);
            }
        }

        private void TheRung_Clicked(object sender, EventArgs e)
        {
            // lấy thẻ đc click
            TheRung theRung = sender as TheRung;
            // chế độ xoá
            if (currentMode == FormState.Delete)
            {
                // Hiển thị xác nhận xoá
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                messageDialog.Caption = "Xác Nhận Xoá";
                messageDialog.Text = "Bạn có chắc chắn muốn xoá thẻ này không?";
                // Yes or no
                var result = messageDialog.Show();
                if (result == DialogResult.Yes)
                {
                    // Lưu vào danh sách xoá và ẩn khỏi giao diện
                    deletedTheRung.Add(theRung);
                    pnlTheRung.Controls.Remove(theRung);
                }
            }

            // chế độ chọn số chờ
            else if (currentMode == FormState.None)
            {
                if (theRung.TrangThai != 0) // ko rảnh
                {
                    messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    messageDialog.Text = "Vui Lòng Chọn Thẻ Khác";
                    messageDialog.Caption = "Thẻ Đang Dùng hoặc Hỏng";
                    messageDialog.Show();
                    return;
                }
                SelectedTheRung = theRung;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // chế độ update
            else
            {
                SelectedTheRung = theRung;
                txtMaThe.Text = theRung.MaThe;
                txtSoThe.Text = theRung.SoThe;
                cboTrangThaiThe.SelectedIndex = theRung.TrangThai;
            }
        }
        private void LoadCboTrangThaiThe()
        {
            var trangThaiList = new Dictionary<int, string>
            {
                { 0, "Rảnh" },
                { 1, "Đang dùng" },
                { 2, "Hỏng" }
            };
            // thêm vào cbo
            cboTrangThaiThe.DataSource = new BindingSource(trangThaiList, null);
            cboTrangThaiThe.DisplayMember = "Value";
            cboTrangThaiThe.ValueMember = "Key";
            // mặc định là rảnh
            cboTrangThaiThe.SelectedIndex = 0;
        }

        public string ConvertStateToString(string state)
        {
            switch (state)
            {
                case "None":
                    return "Chọn Số Chờ";
                case "Insert":
                    return "Thêm Thẻ";
                case "Update":
                    return "Chỉnh Sửa Thẻ";
                default:
                    return "Xoá Thẻ";
            }
        }

        private void SetFormState(FormState state)
        {
            // Hiển thị lại chế độ
            currentMode = state;
            lblCurrentMode.Text = $"Chế độ: {ConvertStateToString(state.ToString())}";

            // Đổi con trỏ chuột khi ở chế độ xoá
            this.Cursor = (state == FormState.Delete) ? Cursors.No : Cursors.Default;

            // Kích hoạt/ Vô hiệu hóa group nhập liệu
            grpTheRungInfo.Enabled = (state != FormState.None);

            // Điều khiển các nút
            btnThemThe.Enabled = (state == FormState.None);
            btnSuaThe.Enabled = (state == FormState.None);
            btnXoaThe.Enabled = (state == FormState.None);

            // Nút Lưu và Huỷ chỉ bật khi không ở trạng thái None
            btnLuu.Enabled = (state != FormState.None);
            btnHuy.Enabled = (state != FormState.None);
        }

        private void ResetForm()
        {
            txtMaThe.Clear();
            txtSoThe.Clear();
            cboTrangThaiThe.SelectedIndex = 0;
            pnlTheRung.Controls.Clear();
            LoadTheRung();
            SetFormState(FormState.None);
        }

        private void btnThemThe_Click(object sender, EventArgs e)
        {
            // chuyển sang chế độ Insert
            SetFormState(FormState.Insert);
            txtMaThe.Text = theRungBUS.PhatSinhMaThe();
            txtSoThe.Clear();
            cboTrangThaiThe.SelectedIndex = 0;
            txtSoThe.Focus();
        }

        private void btnSuaThe_Click(object sender, EventArgs e)
        {
            // chuyển sang chế độ Update
            SetFormState(FormState.Update);
        }

        private void btnXoaThe_Click(object sender, EventArgs e)
        {
            // chuyển sang chế độ Delete
            SetFormState(FormState.Delete);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (currentMode == FormState.Insert || currentMode == FormState.Update)
            {
                // Lấy thông tin từ các control
                string maThe = txtMaThe.Text;
                string soThe = txtSoThe.Text;
                int trangThai = (int)cboTrangThaiThe.SelectedValue;
                if (maThe == "" || soThe == "")
                {
                    messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    messageDialog.Caption = "Nhập Thiếu";
                    messageDialog.Text = "Vui Lòng Nhập Đủ Thông Tin";
                    messageDialog.Show();
                    return;
                }
                theRungBUS = new BUS_TheRung(maThe, soThe, trangThai);

                if (currentMode == FormState.Insert)
                {
                    theRungBUS.InsertTheRung();
                }
                else
                {
                    theRungBUS.UpdateTheRung();
                }
            }
            else if (currentMode == FormState.Delete)
            {
                // Gọi BUS xoá
                foreach (TheRung the in deletedTheRung)
                {
                    // xoá các thẻ trong db
                    theRungBUS.DeleteTheRung(the.MaThe);
                }
            }
            ResetForm();
        }

        private void txtSoThe_TextChanged(object sender, EventArgs e)
        {
            string soThe = txtSoThe.Text;
            if (soThe.Length > 4)
            {
                // Giữ lại 4 ký tự đầu tiên khi nhập lố 5 kí tự
                txtSoThe.Text = soThe.Substring(0, 4);

                // Di chuyển con trỏ về cuối textbox
                txtSoThe.SelectionStart = txtSoThe.Text.Length;
            }
        }

    }
}
