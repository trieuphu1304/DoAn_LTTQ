using System;
using System.Data;
using System.Data.SqlClient;
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

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void đăngKýThànhViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Quản lý Khách hàng",
                Size = new System.Drawing.Size(650, 500),
                StartPosition = FormStartPosition.CenterParent
            };

            // 1. Khai báo các ô nhập liệu theo đúng cột trong DB
            Label lblTen = new Label() { Text = "Tên khách:", Location = new System.Drawing.Point(20, 30), AutoSize = true };
            TextBox txtTen = new TextBox() { Location = new System.Drawing.Point(120, 27), Width = 180 };

            Label lblSDT = new Label() { Text = "Số điện thoại:", Location = new System.Drawing.Point(20, 70), AutoSize = true };
            TextBox txtSDT = new TextBox() { Location = new System.Drawing.Point(120, 67), Width = 180 };

            Label lblDiaChi = new Label() { Text = "Địa chỉ:", Location = new System.Drawing.Point(320, 30), AutoSize = true };
            TextBox txtDiaChi = new TextBox() { Location = new System.Drawing.Point(400, 27), Width = 180 };

            // 2. Các nút bấm
            Button btnThem = new Button() { Text = "Thêm", Location = new System.Drawing.Point(20, 110), Width = 80 };
            Button btnSua = new Button() { Text = "Sửa", Location = new System.Drawing.Point(110, 110), Width = 80 };
            Button btnXoa = new Button() { Text = "Xóa", Location = new System.Drawing.Point(200, 110), Width = 80 };
            Button btnHienThi = new Button() { Text = "Hiển thị", Location = new System.Drawing.Point(290, 110), Width = 80 };

            DataGridView dgv = new DataGridView()
            {
                Location = new System.Drawing.Point(20, 160),
                Size = new System.Drawing.Size(590, 280),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            frm.Controls.AddRange(new Control[] { lblTen, txtTen, lblSDT, txtSDT, lblDiaChi, txtDiaChi, btnThem, btnSua, btnXoa, btnHienThi, dgv });

            string connStr = @"Data Source=LAPTOP-0G3MKQED\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True";

            // --- CHỨC NĂNG HIỂN THỊ (SỬA LẠI TÊN CỘT: Name, Phone, Address) ---
            Action LoadData = () => {
                using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
                {
                    try
                    {
                        string sql = "SELECT ID, Name as [Họ Tên], Phone as [SĐT], Address as [Địa chỉ], Points as [Điểm] FROM Customer";
                        var da = new System.Data.SqlClient.SqlDataAdapter(sql, conn);
                        var dt = new System.Data.DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi hiển thị: " + ex.Message); }
                }
            };

            // --- CHỨC NĂNG THÊM (DÙNG CỘT: Name, Phone, Address) ---
            btnThem.Click += (s, ev) => {
                using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        string sql = "INSERT INTO Customer (Name, Phone, Address, Points) VALUES (@name, @phone, @addr, 0)";
                        var cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@name", txtTen.Text);
                        cmd.Parameters.AddWithValue("@phone", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@addr", txtDiaChi.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm khách hàng thành công!");
                        LoadData();
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
                }
            };

            // --- CHỨC NĂNG XÓA (XÓA THEO ID) ---
            btnXoa.Click += (s, ev) => {
                if (dgv.CurrentRow == null) return;
                string id = dgv.CurrentRow.Cells["ID"].Value.ToString();
                using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "DELETE FROM Customer WHERE ID = @id";
                    var cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
            };

            btnHienThi.Click += (s, ev) => LoadData();
            frm.ShowDialog();
        }
    }

}

