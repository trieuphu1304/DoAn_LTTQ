using System;
using System.Windows.Forms;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ
{
    public partial class Master_Layout : Form
    {
        private Account currentAccount = null;
        private AdminPanel adminPanelInstance = null;

        public Master_Layout()
        {
            InitializeComponent();
        }

        public Master_Layout(Account account)
        {
            InitializeComponent();
            currentAccount = account;
        }

        private void Master_Layout_Load(object sender, EventArgs e)
        {
            // Menu sẽ hiển thị bình thường
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                currentAccount = loginForm.LoggedInAccount;

                if (currentAccount != null)
                {
                    System.Diagnostics.Debug.WriteLine($"DEBUG: Đăng nhập thành công. Type = {currentAccount.Type}, DisplayName = {currentAccount.DisplayName}");

                    // Type: 0=Nhân viên, 1=Quản lý
                    if (currentAccount.Type == 1) // Quản lý (Admin)
                    {
                        System.Diagnostics.Debug.WriteLine("DEBUG: Vào vòng lặp Type = 2 (Quản lý)");
                        try
                        {
                            System.Diagnostics.Debug.WriteLine("DEBUG: Bắt đầu tạo AdminPanel");

                            // Đóng AdminPanel cũ nếu có
                            if (adminPanelInstance != null && !adminPanelInstance.IsDisposed)
                            {
                                adminPanelInstance.Close();
                            }

                            // Tạo và hiển thị AdminPanel mới
                            adminPanelInstance = new AdminPanel();
                            System.Diagnostics.Debug.WriteLine("DEBUG: AdminPanel đã tạo");

                            adminPanelInstance.FormClosed += (s, ea) =>
                            {
                                System.Diagnostics.Debug.WriteLine("DEBUG: AdminPanel đã đóng");
                                // Khi AdminPanel đóng, hiển thị lại Master_Layout
                                currentAccount = null;
                                this.Show();
                            };

                            System.Diagnostics.Debug.WriteLine("DEBUG: Gọi adminPanelInstance.Show()");
                            adminPanelInstance.Show();

                            System.Diagnostics.Debug.WriteLine("DEBUG: Ẩn Master_Layout");
                            // Ẩn Master_Layout
                            this.Hide();

                            System.Diagnostics.Debug.WriteLine("DEBUG: Xong, AdminPanel đã được hiển thị");
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("DEBUG: Exception trong khối try: " + ex.ToString());
                            MessageBox.Show("Lỗi khi mở AdminPanel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
                        }
                    }
                    else if (currentAccount.Type == 0) // Nhân viên
                    {
                        System.Diagnostics.Debug.WriteLine("DEBUG: Vào vòng lặp Type = 0 (Nhân viên)");
                        đăngNhậpToolStripMenuItem.Enabled = false;
                        MessageBox.Show($"Chào mừng, {currentAccount.DisplayName}!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"DEBUG: Type không khớp = {currentAccount.Type}");
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("DEBUG: currentAccount = null");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DEBUG: LoginForm DialogResult không phải OK");
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                currentAccount = null;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát khỏi ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Đóng AdminPanel nếu đang mở
                if (adminPanelInstance != null && !adminPanelInstance.IsDisposed)
                {
                    adminPanelInstance.Close();
                }
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngKýThànhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerPanel customerPanel = new CustomerPanel();
                customerPanel.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở giao diện khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
