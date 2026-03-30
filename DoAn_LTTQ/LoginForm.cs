using System;
using System.Windows.Forms;
using DoAn_LTTQ.Data;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ
{
    public partial class LoginForm : Form
    {
        public Account LoggedInAccount { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void ClearLoginInputs()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            // Khi form được hiển thị lại, xóa trống các input
            if (this.Visible)
            {
                ClearLoginInputs();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            System.Diagnostics.Debug.WriteLine($"DEBUG Login: Username = '{username}', Password = '{password}'");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy tất cả tài khoản từ database
            try
            {
                var accounts = AccountDAL.GetAllAccounts();
                System.Diagnostics.Debug.WriteLine($"DEBUG: Tìm thấy {accounts.Count} tài khoản trong database");

                foreach (var acc in accounts)
                {
                    System.Diagnostics.Debug.WriteLine($"DEBUG: Account - UserName='{acc.UserName}', DisplayName='{acc.DisplayName}', Type={acc.Type}");
                }

                Account foundAccount = null;

                // Tìm tài khoản phù hợp
                foreach (var account in accounts)
                {
                    if (account.UserName == username && account.Password == password)
                    {
                        foundAccount = account;
                        System.Diagnostics.Debug.WriteLine($"DEBUG: Tài khoản khớp! Type = {account.Type}");
                        break;
                    }
                }

                if (foundAccount != null)
                {
                    System.Diagnostics.Debug.WriteLine($"DEBUG: Đăng nhập thành công, Type = {foundAccount.Type}");
                    LoggedInAccount = foundAccount;

                    // Ẩn LoginForm
                    this.Hide();

                    if (foundAccount.Type == 1) // Quản lý (Admin)
                    {
                        System.Diagnostics.Debug.WriteLine("DEBUG: Mở AdminPanel");
                        try
                        {
                            AdminPanel adminPanel = new AdminPanel();
                            adminPanel.FormClosed += (s, ea) =>
                            {
                                // Nếu logout (DialogResult.Cancel), show lại LoginForm
                                if (adminPanel.DialogResult == DialogResult.Cancel)
                                {
                                    this.Show();
                                }
                                else
                                {
                                    // Nếu close bình thường, đóng LoginForm
                                    this.Close();
                                }
                            };
                            adminPanel.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"DEBUG: Exception mở AdminPanel: {ex.ToString()}");
                            MessageBox.Show("Lỗi khi mở AdminPanel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Show();
                        }
                    }
                    else if (foundAccount.Type == 0) // Nhân viên
                    {
                        System.Diagnostics.Debug.WriteLine("DEBUG: Mở Master_Layout");
                        try
                        {
                            Master_Layout masterLayout = new Master_Layout(foundAccount);
                            masterLayout.FormClosed += (s, ea) =>
                            {
                                // Nếu logout (DialogResult.Cancel), show lại LoginForm
                                if (masterLayout.DialogResult == DialogResult.Cancel)
                                {
                                    this.Show();
                                }
                                else
                                {
                                    // Nếu close bình thường, đóng LoginForm
                                    this.Close();
                                }
                            };
                            masterLayout.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"DEBUG: Exception mở Master_Layout: {ex.ToString()}");
                            MessageBox.Show("Lỗi khi mở Master_Layout: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Show();
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"DEBUG: Type không hợp lệ = {foundAccount.Type}");
                        MessageBox.Show("Loại tài khoản không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"DEBUG: Không tìm thấy tài khoản phù hợp");
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DEBUG: Exception trong btnLogin_Click: {ex.ToString()}");
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
