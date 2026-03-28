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
    public partial class AdminPanel : Form
    {
        private int selectedFoodID = -1;
        private int selectedTableID = -1;
        private string selectedAccountUserName = "";
        private int selectedEmployeeID = -1;
        private string selectedEmployeeImagePath = "";
        private int selectedCategoryID = -1;

        // Employee Tab specific
        private QuanLyNhaHangDataSet quanLyNhaHangDataSet;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private QuanLyNhaHangDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;

        public AdminPanel()
        {
            InitializeComponent();
            this.Text = "Quản Lý Nhà Hàng - DoAn_LTTQ";
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFoodCategories();
                LoadAccountRoles();
                InitializeEmployeeTab();  // Initialize employee tab BEFORE loading data
                InitializeCategoryTab();   // Initialize category tab
                LoadAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        // ============== LOAD DANH MỤC & CHỨC VỤ ==============
        private void LoadFoodCategories()
        {
            try
            {
                List<FoodCategory> categories = FoodCategoryDAL.GetAllCategories();
                if (categories != null && categories.Count > 0)
                {
                    cbCategory.DataSource = null; // Reset trước
                    cbCategory.DataSource = categories;
                    cbCategory.DisplayMember = "Name";
                    cbCategory.ValueMember = "ID";
                    // Chỉ gán event SAU khi bind dữ liệu xong
                    cbCategory.SelectedIndexChanged -= CbCategory_SelectedIndexChanged; // Remove cũ
                    cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged; // Add mới
                    cbCategory.SelectedIndex = 0; // Chọn item đầu tiên
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh mục: " + ex.Message, "Lỗi");
            }
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbCategory.SelectedValue != null && cbCategory.SelectedValue is int)
                {
                    int categoryID = (int)cbCategory.SelectedValue;
                    LoadFoodByCategory(categoryID);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void LoadAccountRoles()
        {
            try
            {
                cbRole.Items.Clear();
                cbRole.Items.Add("0:Admin");
                cbRole.Items.Add("1:Nhân viên");
                cbRole.Items.Add("2:Quản lý");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadAllData()
        {
            LoadFoodData();
            LoadTableData();
            LoadAccountData();
            LoadBillData();
            LoadEmployeeData();
        }

        // ============== TAB 1: DOANH THU ==============
        private void LoadBillData()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;
                List<Bill> bills = BillDAL.GetBillsByDateRange(fromDate, toDate);

                dgvInvoice.DataSource = null;
                dgvInvoice.DataSource = bills;
                dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvInvoice.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBillData();
        }

        // ============== TAB 2: THỰC ĐƠN ==============
        private void LoadFoodData()
        {
            try
            {
                List<Food> foods = FoodDAL.GetAllFoods();
                dgvDish.DataSource = null;
                dgvDish.DataSource = foods;
                dgvDish.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu món ăn: " + ex.Message, "Lỗi");
            }
        }

        

        private void LoadFoodByCategory(int categoryID)
        {
            try
            {
                List<Food> foods = FoodDAL.GetFoodsByCategory(categoryID);
                dgvDish.DataSource = null;
                dgvDish.DataSource = foods;
                dgvDish.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDishName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên món ăn", "Thông báo");
                    txtDishName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá bán", "Thông báo");
                    txtPrice.Focus();
                    return;
                }

                if (cbCategory.SelectedValue == null || !(cbCategory.SelectedValue is int))
                {
                    MessageBox.Show("Vui lòng chọn danh mục", "Thông báo");
                    return;
                }

                decimal price;
                if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0)
                {
                    MessageBox.Show("Giá bán phải là số dương", "Thông báo");
                    txtPrice.Focus();
                    return;
                }

                Food food = new Food
                {
                    Name = txtDishName.Text.Trim(),
                    CategoryID = (int)cbCategory.SelectedValue,
                    Price = (float)price,
                    ImagePath = txtImagePath.Text.Trim()
                };

                if (FoodDAL.AddFood(food))
                {
                    MessageBox.Show("Thêm món ăn thành công", "Thành công");
                    ClearFoodInputs();
                    LoadFoodData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnEditDish_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedFoodID == -1)
                {
                    MessageBox.Show("Vui lòng chọn một món ăn để sửa", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDishName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên món ăn", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá bán", "Thông báo");
                    return;
                }

                decimal price;
                if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0)
                {
                    MessageBox.Show("Giá bán phải là số dương", "Thông báo");
                    return;
                }

                Food food = new Food
                {
                    Name = txtDishName.Text.Trim(),
                    CategoryID = (int)cbCategory.SelectedValue,
                    Price = (float)price,
                    ImagePath = txtImagePath.Text.Trim()
                };

                if (FoodDAL.UpdateFood(selectedFoodID, food))
                {
                    MessageBox.Show("Cập nhật món ăn thành công", "Thành công");
                    ClearFoodInputs();
                    LoadFoodData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnDeleteDish_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedFoodID == -1)
                {
                    MessageBox.Show("Vui lòng chọn một món ăn để xóa", "Thông báo");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa món ăn này?", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (FoodDAL.DeleteFood(selectedFoodID))
                    {
                        MessageBox.Show("Xóa món ăn thành công", "Thành công");
                        ClearFoodInputs();
                        LoadFoodData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void dgvDish_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgvDish.Rows[e.RowIndex].DataBoundItem is Food food)
                {
                    selectedFoodID = food.ID;
                    txtDishName.Text = food.Name;
                    cbCategory.SelectedValue = food.CategoryID;
                    txtPrice.Text = food.Price.ToString();
                    txtImagePath.Text = food.ImagePath ?? "";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void ClearFoodInputs()
        {
            txtDishName.Clear();
            txtPrice.Clear();
            txtImagePath.Clear();
            selectedFoodID = -1;
            if (cbCategory.Items.Count > 0)
                cbCategory.SelectedIndex = 0;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                    openFileDialog.Title = "Chọn ảnh cho món ăn";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtImagePath.Text = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        // ============== TAB 3: BÀN ĂN ==============
        private void LoadTableData()
        {
            try
            {
                List<TableFood> tables = TableFoodDAL.GetAllTables();
                dgvTable.DataSource = null;
                dgvTable.DataSource = tables;
                dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu bàn ăn: " + ex.Message, "Lỗi");
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTableName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên bàn", "Thông báo");
                    txtTableName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCapacity.Text))
                {
                    MessageBox.Show("Vui lòng nhập trạng thái", "Thông báo");
                    txtCapacity.Focus();
                    return;
                }

                TableFood table = new TableFood
                {
                    Name = txtTableName.Text.Trim(),
                    Status = txtCapacity.Text.Trim()
                };

                if (TableFoodDAL.AddTable(table))
                {
                    MessageBox.Show("Thêm bàn ăn thành công", "Thành công");
                    ClearTableInputs();
                    LoadTableData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTableID == -1)
                {
                    MessageBox.Show("Vui lòng chọn một bàn ăn để sửa", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTableName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên bàn", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCapacity.Text))
                {
                    MessageBox.Show("Vui lòng nhập trạng thái", "Thông báo");
                    return;
                }

                TableFood table = new TableFood
                {
                    Name = txtTableName.Text.Trim(),
                    Status = txtCapacity.Text.Trim()
                };

                if (TableFoodDAL.UpdateTable(selectedTableID, table))
                {
                    MessageBox.Show("Cập nhật bàn ăn thành công", "Thành công");
                    ClearTableInputs();
                    LoadTableData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTableID == -1)
                {
                    MessageBox.Show("Vui lòng chọn một bàn ăn để xóa", "Thông báo");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa bàn ăn này?", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (TableFoodDAL.DeleteTable(selectedTableID))
                    {
                        MessageBox.Show("Xóa bàn ăn thành công", "Thành công");
                        ClearTableInputs();
                        LoadTableData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgvTable.Rows[e.RowIndex].DataBoundItem is TableFood table)
                {
                    selectedTableID = table.ID;
                    txtTableName.Text = table.Name;
                    txtCapacity.Text = table.Status;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void ClearTableInputs()
        {
            txtTableName.Clear();
            txtCapacity.Clear();
            selectedTableID = -1;
        }

        // ============== TAB 4: TÀI KHOẢN ==============
        private void LoadAccountData()
        {
            try
            {
                List<Account> accounts = AccountDAL.GetAllAccounts();
                dgvAccount.DataSource = null;
                dgvAccount.DataSource = accounts;
                dgvAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu tài khoản: " + ex.Message, "Lỗi");
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản", "Thông báo");
                    txtUsername.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo");
                    txtPassword.Focus();
                    return;
                }

                if (cbRole.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn chức vụ", "Thông báo");
                    return;
                }

                Account account = new Account
                {
                    UserName = txtUsername.Text.Trim(),
                    DisplayName = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    Type = int.Parse(cbRole.SelectedItem.ToString().Split(':')[0]),
                    EmployeeID = null
                };

                if (AccountDAL.AddAccount(account))
                {
                    MessageBox.Show("Thêm tài khoản thành công", "Thành công");
                    ClearAccountInputs();
                    LoadAccountData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedAccountUserName))
                {
                    MessageBox.Show("Vui lòng chọn một tài khoản để sửa", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo");
                    return;
                }

                Account account = new Account
                {
                    UserName = txtUsername.Text.Trim(),
                    DisplayName = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    Type = int.Parse(cbRole.SelectedItem.ToString().Split(':')[0]),
                    EmployeeID = null
                };

                if (AccountDAL.UpdateAccount(selectedAccountUserName, account))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công", "Thành công");
                    ClearAccountInputs();
                    LoadAccountData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedAccountUserName))
                {
                    MessageBox.Show("Vui lòng chọn một tài khoản để xóa", "Thông báo");
                    return;
                }

                DialogResult result = MessageBox.Show($"Bạn chắc chắn muốn xóa tài khoản '{selectedAccountUserName}'?", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (AccountDAL.DeleteAccount(selectedAccountUserName))
                    {
                        MessageBox.Show("Xóa tài khoản thành công", "Thành công");
                        ClearAccountInputs();
                        LoadAccountData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgvAccount.Rows[e.RowIndex].DataBoundItem is Account account)
                {
                    selectedAccountUserName = account.UserName;
                    txtUsername.Text = account.UserName;
                    txtPassword.Text = account.Password;

                    // Set role based on Type int value
                    string roleText = account.Type == 0 ? "0:Admin" : 
                                      account.Type == 1 ? "1:Nhân viên" : "2:Quản lý";
                    cbRole.SelectedItem = roleText;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void ClearAccountInputs()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            selectedAccountUserName = "";
            if (cbRole.Items.Count > 0)
                cbRole.SelectedIndex = 0;
        }

        // ============== TAB 5: NHÂN VIÊN ==============
        private void InitializeEmployeeTab()
        {
            try
            {
                // Initialize dataset and adapters if not already done
                if (quanLyNhaHangDataSet == null)
                {
                    quanLyNhaHangDataSet = new QuanLyNhaHangDataSet();
                    employeeBindingSource = new System.Windows.Forms.BindingSource();
                    employeeTableAdapter = new QuanLyNhaHangDataSetTableAdapters.EmployeeTableAdapter();
                    employeeBindingSource.DataMember = "Employee";
                    employeeBindingSource.DataSource = quanLyNhaHangDataSet;
                }

                btnNVAdd.Click += BtnNVAdd_Click;
                btnNVEdit.Click += BtnNVEdit_Click;
                btnNVDelete.Click += BtnNVDelete_Click;
                
                btnNVSelectAvatar.Click += BtnNVSelectAvatar_Click;
                dgvNhanVien.CellClick += DgvNhanVien_CellClick;
                // Don't call LoadEmployeeData() here - it will be called from LoadAllData()
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo tab nhân viên: " + ex.Message, "Lỗi");
            }
        }

        private void LoadEmployeeData()
        {
            try
            {
                this.quanLyNhaHangDataSet.Employee.Clear();
                this.employeeTableAdapter.Fill(this.quanLyNhaHangDataSet.Employee);
                dgvNhanVien.DataSource = this.employeeBindingSource;
                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu nhân viên: " + ex.Message, "Lỗi");
            }
        }

        private void DgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
                {
                    DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                    // Lấy dữ liệu từ DataRow trong dataset
                    if (row.DataBoundItem is System.Data.DataRowView drv)
                    {
                        System.Data.DataRow dataRow = drv.Row;

                        // Lấy ID
                        if (dataRow.Table.Columns.Contains("ID"))
                            selectedEmployeeID = Convert.ToInt32(dataRow["ID"]);

                        // Lấy các thông tin khác
                        if (dataRow.Table.Columns.Contains("Name"))
                            txtNVName.Text = dataRow["Name"]?.ToString() ?? "";

                        if (dataRow.Table.Columns.Contains("Phone"))
                            txtNVPhone.Text = dataRow["Phone"]?.ToString() ?? "";

                        if (dataRow.Table.Columns.Contains("Position"))
                            txtNVPosition.Text = dataRow["Position"]?.ToString() ?? "";

                        if (dataRow.Table.Columns.Contains("Salary"))
                            txtNVSalary.Text = dataRow["Salary"]?.ToString() ?? "";

                        // Hiển thị ảnh từ cơ sở dữ liệu
                        if (dataRow.Table.Columns.Contains("Avatar"))
                        {
                            string avatarPath = dataRow["Avatar"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(avatarPath) && System.IO.File.Exists(avatarPath))
                            {
                                lblNVAvatarDisplay.Image = Image.FromFile(avatarPath);
                                lblNVAvatarDisplay.AutoSize = true;
                                selectedEmployeeImagePath = avatarPath;
                            }
                            else
                            {
                                lblNVAvatarDisplay.Image = null;
                                lblNVAvatarDisplay.AutoSize = false;
                                selectedEmployeeImagePath = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void BtnNVAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNVName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNVPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNVPosition.Text))
                {
                    MessageBox.Show("Vui lòng nhập vị trí!", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNVSalary.Text))
                {
                    MessageBox.Show("Vui lòng nhập lương!", "Thông báo");
                    return;
                }

                // Kiểm tra trùng lặp thông tin nhân viên
                string newName = txtNVName.Text.Trim();
                string newPhone = txtNVPhone.Text.Trim();

                foreach (System.Data.DataRow row in this.quanLyNhaHangDataSet.Employee.Rows)
                {
                    string existingName = row["Name"]?.ToString() ?? "";
                    string existingPhone = row["Phone"]?.ToString() ?? "";

                    if (existingName.Equals(newName, StringComparison.OrdinalIgnoreCase) || 
                        existingPhone.Equals(newPhone))
                    {
                        MessageBox.Show($"Nhân viên có tên '{newName}' hoặc số điện thoại '{newPhone}' đã tồn tại trong hệ thống!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string avatarPath = "";
                if (!string.IsNullOrWhiteSpace(selectedEmployeeImagePath) && System.IO.File.Exists(selectedEmployeeImagePath))
                {
                    avatarPath = selectedEmployeeImagePath;
                }

                decimal salary = decimal.Parse(txtNVSalary.Text);
                var newRow = this.quanLyNhaHangDataSet.Employee.NewEmployeeRow();
                newRow.Name = txtNVName.Text;
                newRow.Phone = txtNVPhone.Text;
                newRow.Position = txtNVPosition.Text;
                newRow.Salary = salary;
                if (!string.IsNullOrWhiteSpace(avatarPath))
                    newRow.Avatar = avatarPath;

                this.quanLyNhaHangDataSet.Employee.AddEmployeeRow(newRow);
                this.employeeTableAdapter.Update(this.quanLyNhaHangDataSet.Employee);

                LoadEmployeeData();
                ClearEmployeeInputs();
                MessageBox.Show("Thêm nhân viên thành công!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi");
            }
        }

        private void BtnNVEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedEmployeeID == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNVName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thông báo");
                    return;
                }

                var employeeRow = this.quanLyNhaHangDataSet.Employee.FindByID(selectedEmployeeID);
                if (employeeRow != null)
                {
                    employeeRow.Name = txtNVName.Text;
                    employeeRow.Phone = txtNVPhone.Text;
                    employeeRow.Position = txtNVPosition.Text;
                    if (decimal.TryParse(txtNVSalary.Text, out decimal salary))
                        employeeRow.Salary = salary;

                    if (!string.IsNullOrWhiteSpace(selectedEmployeeImagePath) && System.IO.File.Exists(selectedEmployeeImagePath))
                        employeeRow.Avatar = selectedEmployeeImagePath;

                    this.employeeTableAdapter.Update(this.quanLyNhaHangDataSet.Employee);
                    LoadEmployeeData();
                    ClearEmployeeInputs();
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi");
            }
        }

        private void BtnNVDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedEmployeeID == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var employeeRow = this.quanLyNhaHangDataSet.Employee.FindByID(selectedEmployeeID);
                    if (employeeRow != null)
                    {
                        employeeRow.Delete();
                        this.employeeTableAdapter.Update(this.quanLyNhaHangDataSet.Employee);
                        LoadEmployeeData();
                        ClearEmployeeInputs();
                        MessageBox.Show("Xóa nhân viên thành công!", "Thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi");
            }
        }

        private void BtnNVSelectAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.Title = "Chọn ảnh đại diện";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedEmployeeImagePath = openFileDialog.FileName;
                    // Hiển thị ảnh trong ToolStripLabel
                    lblNVAvatarDisplay.Image = Image.FromFile(selectedEmployeeImagePath);
                    lblNVAvatarDisplay.AutoSize = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void ClearEmployeeInputs()
        {
            txtNVName.Clear();
            txtNVPhone.Clear();
            txtNVSalary.Clear();
            txtNVPosition.Clear();
            lblNVAvatarDisplay.Image = null;
            selectedEmployeeID = -1;
            selectedEmployeeImagePath = "";
        }

        private void tableLayoutPanelNVButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // ============== TAB 6: DANH MỤC MÓN ĂN ==============
        private void InitializeCategoryTab()
        {
            try
            {
                btnAdd.Click += BtnAddCategory_Click;
                btnUpdate.Click += BtnUpdateCategory_Click;
                btnDelete.Click += BtnDeleteCategory_Click;
                dgvFoodCategory.CellClick += DgvFoodCategory_CellClick;
                LoadCategoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo tab danh mục: " + ex.Message, "Lỗi");
            }
        }

        private void LoadCategoryData()
        {
            try
            {
                List<FoodCategory> categories = FoodCategoryDAL.GetAllCategories();
                dgvFoodCategory.DataSource = null;
                dgvFoodCategory.DataSource = categories;
                dgvFoodCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh mục: " + ex.Message, "Lỗi");
            }
        }

        private void DgvFoodCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgvFoodCategory.Rows[e.RowIndex].DataBoundItem is FoodCategory category)
                {
                    selectedCategoryID = category.ID;
                    txtTenMon.Text = category.Name;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenMon.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục", "Thông báo");
                    txtTenMon.Focus();
                    return;
                }

                // Kiểm tra trùng lặp
                string newCategoryName = txtTenMon.Text.Trim();
                List<FoodCategory> existingCategories = FoodCategoryDAL.GetAllCategories();

                foreach (var cat in existingCategories)
                {
                    if (cat.Name.Equals(newCategoryName, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Danh mục '{newCategoryName}' đã tồn tại!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                FoodCategory category = new FoodCategory
                {
                    Name = newCategoryName
                };

                if (FoodCategoryDAL.AddCategory(category))
                {
                    MessageBox.Show("Thêm danh mục thành công", "Thành công");
                    ClearCategoryInputs();
                    LoadCategoryData();
                    LoadFoodCategories(); // Cập nhật combo box ở tab Thực đơn
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void BtnUpdateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCategoryID == -1)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần sửa", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenMon.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục", "Thông báo");
                    txtTenMon.Focus();
                    return;
                }

                // Kiểm tra trùng lặp (trừ danh mục đang chỉnh sửa)
                string newCategoryName = txtTenMon.Text.Trim();
                List<FoodCategory> existingCategories = FoodCategoryDAL.GetAllCategories();

                foreach (var cat in existingCategories)
                {
                    if (cat.ID != selectedCategoryID && 
                        cat.Name.Equals(newCategoryName, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Danh mục '{newCategoryName}' đã tồn tại!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                FoodCategory category = new FoodCategory
                {
                    ID = selectedCategoryID,
                    Name = newCategoryName
                };

                if (FoodCategoryDAL.UpdateCategory(selectedCategoryID, category))
                {
                    MessageBox.Show("Cập nhật danh mục thành công", "Thành công");
                    ClearCategoryInputs();
                    LoadCategoryData();
                    LoadFoodCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCategoryID == -1)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần xóa", "Thông báo");
                    return;
                }

                DialogResult result = MessageBox.Show($"Bạn chắc chắn muốn xóa danh mục này?", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (FoodCategoryDAL.DeleteCategory(selectedCategoryID))
                    {
                        MessageBox.Show("Xóa danh mục thành công", "Thành công");
                        ClearCategoryInputs();
                        LoadCategoryData();
                        LoadFoodCategories();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void ClearCategoryInputs()
        {
            txtTenMon.Clear();
            selectedCategoryID = -1;
        }
    }
}

