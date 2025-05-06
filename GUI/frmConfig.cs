using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DAL;

namespace GUI
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            txtUID.Enabled = false;
            txtPassword.Enabled = false;
            txtServer.Focus();
        }

        private void chkWindowAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUID.Clear();
            txtPassword.Clear();
            bool isWindowsAuth = chkWindowAuth.Checked;
            txtUID.Enabled = !isWindowsAuth;
            txtPassword.Enabled = !isWindowsAuth;
        }

        private string getConnectionStr()
        {
            if (string.IsNullOrWhiteSpace(txtServer.Text))
            {
                MessageBox.Show("Vui lòng nhập Server");
                return null;
            }
            return chkWindowAuth.Checked
                ? $"Server={txtServer.Text};Integrated Security=True;TrustServerCertificate=True;"
                : $"Server={txtServer.Text};User ID={txtUID.Text};Password={txtPassword.Text};TrustServerCertificate=True;";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkWindowAuth.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtServer.Text) || string.IsNullOrWhiteSpace(cboDatabase.Text))
                {
                    MessageBox.Show("Server và Database không được để trống");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtServer.Text) || string.IsNullOrWhiteSpace(cboDatabase.Text) ||
                    string.IsNullOrWhiteSpace(txtUID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập tất cả thông tin");
                    return;
                }
            }

            string configFilePath = "config.txt";
            using (StreamWriter writer = new StreamWriter(configFilePath))
            {
                writer.WriteLine(CryptoHelper.EncryptString(chkWindowAuth.Checked ? "window" : "sql"));
                writer.WriteLine(CryptoHelper.EncryptString(txtServer.Text));
                writer.WriteLine(CryptoHelper.EncryptString(cboDatabase.Text));
                if (!chkWindowAuth.Checked)
                {
                    writer.WriteLine(CryptoHelper.EncryptString(txtUID.Text));
                    writer.WriteLine(CryptoHelper.EncryptString(txtPassword.Text));
                }
            }
            MessageBox.Show("Lưu cấu hình thành công");
            this.Hide();
            new frmLogin().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string connStr = getConnectionStr();
                if (connStr == null) return;

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                    await connection.OpenAsync(cts.Token);
                    MessageBox.Show("✅ Kết nối thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Kết nối thất bại: " + ex.Message);
            }
            Cursor = Cursors.Default;
        }

        private async void txtServer_Leave(object sender, EventArgs e)
        {
            await LoadDatabaseList();
        }

        private async void cboDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            await LoadDatabaseList();
        }

        private async Task LoadDatabaseList()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string connStr = getConnectionStr();
                if (connStr == null) return;

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE state_desc = 'ONLINE'", connection))
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        cboDatabase.Items.Clear(); // Xóa danh sách cũ
                        while (await reader.ReadAsync())
                        {
                            cboDatabase.Items.Add(reader[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách database: " + ex.Message);
            }
            Cursor = Cursors.Default;
        }
    }
}
