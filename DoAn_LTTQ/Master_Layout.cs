using System;
using System.Windows.Forms;

namespace DoAn_LTTQ
{
    public partial class Master_Layout : Form
    {
        public Master_Layout()
        {
            InitializeComponent();
            // Kết nối event cho các menu items
            this.đăngNhậpToolStripMenuItem.Click += đăngNhậpToolStripMenuItem_Click;
            this.đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            this.thoátToolStripMenuItem.Click += thoátToolStripMenuItem_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new LoginForm())
            {
                dlg.ShowDialog(this);
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", 
                    "Xác Nhận Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", 
                    "Xác Nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }
    }
}
