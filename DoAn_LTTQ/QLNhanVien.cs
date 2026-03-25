using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTTQ
{
    public partial class QLNhanVien : Form
    {
        private int selectedEmployeeID = -1;
        private string selectedImagePath = "";

        public QLNhanVien()
        {
            InitializeComponent();
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            this.employeeTableAdapter.Fill(this.quanLyNhaHangDataSet.Employee);
            dgvQLNhanVien.CellClick += dgvQLNhanVien_CellClick;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnExit.Click += BtnExit_Click;
            tlsAvatar.Click += TlsAvatar_Click;
        }

        private void RefreshDataGridView()
        {
            try
            {
                this.quanLyNhaHangDataSet.Employee.Clear();
                this.employeeTableAdapter.Fill(this.quanLyNhaHangDataSet.Employee);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtSalary.Clear();
            txtPosition.Clear();
            selectedEmployeeID = -1;
            selectedImagePath = "";
        }

        private void dgvQLNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvQLNhanVien.Rows[e.RowIndex];
                selectedEmployeeID = Convert.ToInt32(row.Cells["iDDataGridViewTextBoxColumn"].Value);
                txtName.Text = row.Cells["nameDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["phoneDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                txtPosition.Text = row.Cells["positionDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                txtSalary.Text = row.Cells["salaryDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSalary.Text))
            {
                MessageBox.Show("Vui lòng nhập lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string avatarPath = "";
                if (!string.IsNullOrWhiteSpace(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    avatarPath = selectedImagePath;
                }

                // Add new row to dataset
                decimal salary = decimal.Parse(txtSalary.Text);
                var newRow = this.quanLyNhaHangDataSet.Employee.NewEmployeeRow();
                newRow.Name = txtName.Text;
                newRow.Phone = txtPhone.Text;
                newRow.Position = txtPosition.Text;
                newRow.Salary = salary;
                if (!string.IsNullOrWhiteSpace(avatarPath))
                    newRow.Avatar = avatarPath;

                this.quanLyNhaHangDataSet.Employee.AddEmployeeRow(newRow);

                // Update database
                this.employeeTableAdapter.Update(this.quanLyNhaHangDataSet.Employee);

                RefreshDataGridView();
                ClearForm();
                MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeID == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Find and update the row
                var employeeRow = this.quanLyNhaHangDataSet.Employee.FindByID(selectedEmployeeID);
                if (employeeRow != null)
                {
                    employeeRow.Name = txtName.Text;
                    employeeRow.Phone = txtPhone.Text;
                    employeeRow.Position = txtPosition.Text;
                    if (decimal.TryParse(txtSalary.Text, out decimal salary))
                        employeeRow.Salary = salary;

                    if (!string.IsNullOrWhiteSpace(selectedImagePath) && File.Exists(selectedImagePath))
                        employeeRow.Avatar = selectedImagePath;

                    // Update database
                    this.employeeTableAdapter.Update(this.quanLyNhaHangDataSet.Employee);

                    RefreshDataGridView();
                    ClearForm();
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeID == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var employeeRow = this.quanLyNhaHangDataSet.Employee.FindByID(selectedEmployeeID);
                    if (employeeRow != null)
                    {
                        employeeRow.Delete();
                        this.employeeTableAdapter.Update(this.quanLyNhaHangDataSet.Employee);

                        RefreshDataGridView();
                        ClearForm();
                        MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TlsAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Chọn ảnh đại diện";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                MessageBox.Show("Đã chọn ảnh: " + Path.GetFileName(selectedImagePath), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
