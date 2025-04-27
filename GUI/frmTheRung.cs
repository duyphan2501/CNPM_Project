using BUS;
using GUI.components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTheRung : Form
    {
        List<TheRung> deletedTheRung = new List<TheRung>();
        BUS_TheRung theRungBUS;
        DataTable allTheRung;
        enum FormState { None, Insert, Update, Delete }
        FormState currentMode = FormState.None;
        public TheRung SelectedTheRung;

        public frmTheRung()
        {
            InitializeComponent();
        }

        private void frmTheRung_Load(object sender, EventArgs e)
        {
            txtMaThe.ReadOnly = true;
            LoadTheRung();        // Load tất cả thẻ ra giao diện
            LoadCboTrangThaiThe(); // Load trạng thái vào combobox
            ResetForm();          // Reset form về trạng thái mặc định
        }

        private void LoadTheRung()
        {
            // tạo đối tượng BUS_TheRung để lấy dữ liệu
            theRungBUS = new BUS_TheRung();
            allTheRung = theRungBUS.SelectALlTheRung();

            // Xoá tất cả các điều khiển trong panel trước khi thêm mới
            pnlTheRung.Controls.Clear();

            // Duyệt qua từng dòng trong DataTable và tạo các điều khiển TheRung
            foreach (DataRow dr in allTheRung.Rows)
            {
                // Lấy thông tin từ DataRow
                string soThe = dr["SoThe"].ToString();
                string maThe = dr["MaThe"].ToString();
                int trangThai = Int32.Parse(dr["TrangThai"].ToString());

                // Khởi tạo thẻ rung và gán sự kiện click
                TheRung theRung = new TheRung(soThe, maThe, trangThai);
                theRung.theRung_Clicked += TheRung_Clicked;

                // Thêm vào pnl
                pnlTheRung.Controls.Add(theRung);
            }
        }

        private void LoadCboTrangThaiThe()
        {
            // Tạo dictionary trạng thái thẻ
            var trangThaiList = new Dictionary<int, string>
            {
                { 0, "Rảnh" },
                { 1, "Đang dùng" },
                { 2, "Hỏng" }
            };

            // Gán danh sách vào combobox 
            cboTrangThaiThe.DataSource = new BindingSource(trangThaiList, null);
            cboTrangThaiThe.DisplayMember = "Value"; 
            cboTrangThaiThe.ValueMember = "Key"; 
            cboTrangThaiThe.SelectedIndex = 0; // Mặc định chọn Rảnh
        }

        private void TheRung_Clicked(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi người dùng click vào thẻ rung
            TheRung theRung = sender as TheRung;

            if (currentMode == FormState.Delete)
            {
                // Xác nhận xoá
                if (General.ShowConfirm("Bạn có chắc chắn muốn xoá thẻ này không?", this) == DialogResult.Yes)
                {
                    // Xoá thẻ đưa vào danh sách đã xoá
                    deletedTheRung.Add(theRung);
                    // Xoá thẻ khỏi panel
                    pnlTheRung.Controls.Remove(theRung);
                }
            }
            else if (currentMode == FormState.None)
            {
                if (theRung.TrangThai != 0) // Thẻ không rảnh
                {
                    General.ShowInformation("Vui Lòng Chọn Thẻ Khác", this);
                    return;
                }
                // trả thông tin thẻ về frmBanHang
                SelectedTheRung = theRung;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // chế độ sửa
            else
            {
                // Gán thẻ được chọn vào SelectedTheRung
                SelectedTheRung = theRung;
                // Hiển thị thông tin thẻ lên form
                txtMaThe.Text = theRung.MaThe;
                txtSoThe.Text = theRung.SoThe;
                cboTrangThaiThe.SelectedIndex = theRung.TrangThai;
            }
        }

        private void SetFormState(FormState state)
        {
            // Cập nhật trạng thái của form
            currentMode = state;

            // Cập nhật tiêu đề và con trỏ chuột
            lblCurrentMode.Text = $"Chế độ: {ConvertStateToString(state.ToString())}";
            this.Cursor = (state == FormState.Delete) ? Cursors.No : Cursors.Default;

            // Cập nhật trạng thái các điều khiển
            grpTheRungInfo.Enabled = (state != FormState.None);

            // Cập nhật trạng thái các nút
            // không cho người dùng bấm nút thêm, sửa, xoá khi đang ở chế độ thêm, sửa, xoá
            btnThemThe.Enabled = (state == FormState.None);
            btnSuaThe.Enabled = (state == FormState.None);
            btnXoaThe.Enabled = (state == FormState.None);

            // cho phép người dùng bấm nút lưu và huỷ khi đang ở chế độ thêm, sửa, xoá
            btnLuu.Enabled = (state != FormState.None);
            btnHuy.Enabled = (state != FormState.None);
        }

        private void ResetForm()
        {
            // Đặt lại trạng thái form về mặc định
            txtMaThe.Clear();
            txtSoThe.Clear();
            cboTrangThaiThe.SelectedIndex = 0;
            pnlTheRung.Controls.Clear();
            LoadTheRung();
            SetFormState(FormState.None);
        }

        public string ConvertStateToString(string state)
        {
            switch (state)
            {
                case "None": return "Chọn Số Chờ";
                case "Insert": return "Thêm Thẻ";
                case "Update": return "Chỉnh Sửa Thẻ";
                default: return "Xoá Thẻ";
            }
        }

        private void btnThemThe_Click(object sender, EventArgs e)
        {
            SetFormState(FormState.Insert);
            txtMaThe.Text = theRungBUS.PhatSinhMaThe(); // Phát sinh mã thẻ mới
            txtSoThe.Clear();
            cboTrangThaiThe.SelectedIndex = 0;
            txtSoThe.Focus();
        }

        private void btnSuaThe_Click(object sender, EventArgs e)
        {
            SetFormState(FormState.Update);
        }

        private void btnXoaThe_Click(object sender, EventArgs e)
        {
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
                // Lấy thông tin từ các điều khiển
                string maThe = txtMaThe.Text;
                string soThe = txtSoThe.Text;
                int trangThai = (int)cboTrangThaiThe.SelectedValue;

                // Kiểm tra thông tin nhập vào
                if (string.IsNullOrWhiteSpace(maThe) || string.IsNullOrWhiteSpace(soThe))
                {
                    string message = currentMode == FormState.Insert ? "Vui Lòng Nhập Đủ Thông Tin" : "Vui lòng chọn thẻ muốn sửa";
                    General.ShowInformation(message, this);
                    return;
                }

                theRungBUS = new BUS_TheRung(maThe, soThe, trangThai);
                if (currentMode == FormState.Insert)
                {
                    theRungBUS.InsertTheRung();
                }
                else
                {
                    // Nếu thẻ đang được sử dụng mà muốn chuyển về trạng thái rảnh
                    if (SelectedTheRung.TrangThai == 1 && trangThai == 0)
                    {
                        var result = General.ShowConfirm("Thẻ đang được sử dụng. Bạn có chắc chắn muốn chỉnh sửa thành rảnh?", this);
                        if (result != DialogResult.Yes)
                        {
                            return; // Người dùng không đồng ý => không cập nhật
                        }
                    }

                    theRungBUS.UpdateTheRung(); // Đồng ý hoặc không vướng gì thì cập nhật

                }
            }
            else if (currentMode == FormState.Delete)
            {
                // Xoá tất cả thẻ đã lưu vào danh sách deletedTheRung
                foreach (TheRung the in deletedTheRung)
                {
                    theRungBUS.DeleteTheRung(the.MaThe);
                }
            }
            ResetForm();
        }

        private void txtSoThe_TextChanged(object sender, EventArgs e)
        {
            string soThe = txtSoThe.Text;
            // độ dài mã thẻ ko đc quá 4 kí tự
            if (soThe.Length > 4)
            {
                txtSoThe.Text = soThe.Substring(0, 4);
                txtSoThe.SelectionStart = txtSoThe.Text.Length;
            }
        }
    }
}
