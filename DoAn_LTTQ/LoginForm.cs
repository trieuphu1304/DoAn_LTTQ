using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
namespace DoAn_LTTQ
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connectionString = @"Data Source=LAPTOP-0G3MKQED\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM Account WHERE UserName = @user AND Password = @pass";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@user", userName);
                    cmd.Parameters.AddWithValue("@pass", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string displayName = reader["DisplayName"].ToString();

                        reader.Close();
                        conn.Close();

                        // 👉 Nếu DisplayName là "quản lý"
                        if (displayName.Trim().ToLower() == "quản lý")
                        {
                            MessageBox.Show("Đăng nhập quản lý thành công!");

                            // Chỉ đóng form Master_Layout
                            CloseMasterLayout();

                            // Mở AdminPanel
                            AdminPanel admin = new AdminPanel();
                            admin.Show();

                            // Ẩn LoginForm nhưng vẫn giữ reference
                            this.Hide();
                        }
                        // 👉 Nếu DisplayName là "nhân viên" (Khớp với chữ "Nhân viên" trong SQL của bạn)
                        else if (displayName.Trim().Equals("Nhân viên", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Xin chào nhân viên: " + displayName + "\nĐăng nhập thành công!");

                            // KIỂM TRA OWNER: 
                            // Nếu LoginForm được mở từ Master_Layout bằng .ShowDialog(this)
                            if (this.Owner != null && this.Owner is Master_Layout)
                            {
                                // Chỉ cần đóng LoginForm, Master_Layout gốc sẽ tự hiện lại
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                // Trường hợp dự phòng nếu bạn chạy LoginForm độc lập
                                Master_Layout staff = new Master_Layout();
                                staff.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vai trò không được hỗ trợ!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    }

                    if (!reader.IsClosed)
                        reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Chỉ đóng form Master_Layout nếu nó đang mở
        /// </summary>
        private void CloseMasterLayout()
        {
            try
            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    Form form = Application.OpenForms[i];
                    if (form.GetType().Name == "Master_Layout")
                    {
                        form.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi khi đóng Master_Layout: " + ex.Message);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}