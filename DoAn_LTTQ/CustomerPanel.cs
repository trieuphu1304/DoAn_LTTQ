using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_LTTQ.Data;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ
{
    public partial class CustomerPanel : Form
    {
        private int selectedCustomerID = -1;

        public CustomerPanel()
        {
            InitializeComponent();
            this.Text = "Đăng ký thành viên";
        }

        private void CustomerPanel_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCustomerData();
                ClearInputFields();
                DisableButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void LoadCustomerData()
        {
            try
            {
                var customers = CustomerDAL.GetAllCustomers();
                dataGridViewCustomers.DataSource = customers;

                // Ẩn cột Points nếu có
                if (dataGridViewCustomers.Columns.Contains("Points"))
                {
                    dataGridViewCustomers.Columns["Points"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi");
            }
        }

        private void ClearInputFields()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            selectedCustomerID = -1;
            btnAdd.Text = "Thêm";
        }

        private void EnableButtons()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void DisableButtons()
        {
            btnAdd.Enabled = !string.IsNullOrWhiteSpace(txtName.Text);
            btnEdit.Enabled = selectedCustomerID != -1;
            btnDelete.Enabled = selectedCustomerID != -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                string.IsNullOrWhiteSpace(txtPhone.Text) || 
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (selectedCustomerID == -1)
                {
                    // Thêm mới - Kiểm tra số điện thoại trùng lặp
                    var existingCustomers = CustomerDAL.GetAllCustomers();
                    var phoneExists = existingCustomers.Any(c => c.Phone == txtPhone.Text.Trim());

                    if (phoneExists)
                    {
                        MessageBox.Show("Số điện thoại này đã được đăng ký!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPhone.Focus();
                        return;
                    }

                    Customer newCustomer = new Customer
                    {
                        Name = txtName.Text,
                        Phone = txtPhone.Text,
                        Address = txtAddress.Text,
                        Points = 0
                    };

                    CustomerDAL.AddCustomer(newCustomer);
                    MessageBox.Show("Thêm khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomerData();
                    ClearInputFields();
                }
                else
                    {
                        // Cập nhật - Kiểm tra số điện thoại trùng lặp (ngoại trừ khách hàng hiện tại)
                        var existingCustomers = CustomerDAL.GetAllCustomers();
                        var phoneExists = existingCustomers.Any(c => c.Phone == txtPhone.Text.Trim() && c.ID != selectedCustomerID);

                        if (phoneExists)
                        {
                            MessageBox.Show("Số điện thoại này đã được sử dụng bởi khách hàng khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPhone.Focus();
                            return;
                        }

                        Customer updatedCustomer = new Customer
                        {
                            ID = selectedCustomerID,
                            Name = txtName.Text,
                            Phone = txtPhone.Text,
                            Address = txtAddress.Text,
                            Points = 0
                        };

                        CustomerDAL.UpdateCustomer(selectedCustomerID, updatedCustomer);
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomerData();
                    ClearInputFields();
                    btnAdd.Text = "Thêm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID == -1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAdd.Text = "Lưu";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID == -1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    CustomerDAL.DeleteCustomer(selectedCustomerID);
                    MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomerData();
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
                }
            }
        }

        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewCustomers.Rows.Count)
            {
                DataGridViewRow row = dataGridViewCustomers.Rows[e.RowIndex];
                selectedCustomerID = Convert.ToInt32(row.Cells["ID"].Value);
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
                btnAdd.Text = "Lưu";
                EnableButtons();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DisableButtons();
        }
    }
}
