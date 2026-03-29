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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                    "Xác Nhận Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Tìm và hiển thị LoginForm nếu nó đang bị ẩn
                    bool loginFormFound = false;
                    for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                    {
                        Form form = Application.OpenForms[i];
                        if (form.GetType().Name == "LoginForm")
                        {
                            form.Show();
                            loginFormFound = true;
                            break;
                        }
                    }

                    // Nếu không tìm thấy LoginForm, tạo mới
                    if (!loginFormFound)
                    {
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }

                    // Đóng AdminPanel
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }
    }
}
