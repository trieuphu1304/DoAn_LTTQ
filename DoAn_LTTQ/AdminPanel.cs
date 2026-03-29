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
        // Các biến ID được chọn
        private int selectedFoodID = -1;
        private int selectedTableID = -1;
        private string selectedAccountUserName = "";
        private int selectedEmployeeID = -1;
        private string selectedEmployeeImagePath = "";
        private int selectedCategoryID = -1;

        // Cấu hình riêng cho Tab Nhân viên (Sử dụng DataSet)
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
                LoadFoodCategories(); // Load vào ComboBox ở tab Món ăn
                LoadAccountRoles();   // Load quyền vào ComboBox tài khoản

                InitializeEmployeeTab(); // Khởi tạo tab nhân viên (DataSet)
                InitializeCategoryTab(); // Khởi tạo tab danh mục món ăn

                LoadAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu tổng thể: " + ex.Message, "Lỗi");
            }
        }

        private void LoadAllData()
        {
            LoadFoodData();
            LoadTableData();
            LoadAccountData();
            LoadBillData();
            LoadEmployeeData();
            LoadCategoryData();
        }

        // ============== LOAD DANH MỤC & CHỨC VỤ (Dùng chung) ==============
        private void LoadFoodCategories()
        {
            try
            {
                List<FoodCategory> categories = FoodCategoryDAL.GetAllCategories();
                if (categories != null && categories.Count > 0)
                {
                    cbCategory.DataSource = null;
                    cbCategory.DataSource = categories;
                    cbCategory.DisplayMember = "Name";
                    cbCategory.ValueMember = "ID";

                    cbCategory.SelectedIndexChanged -= CbCategory_SelectedIndexChanged;
                    cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;
                    cbCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh mục: " + ex.Message, "Lỗi");
            }
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue != null && cbCategory.SelectedValue is int categoryID)
            {
                LoadFoodByCategory(categoryID);
            }
        }

        private void LoadAccountRoles()
        {
            cbRole.Items.Clear();
            cbRole.Items.Add("0:Admin");
            cbRole.Items.Add("1:Nhân viên");
            cbRole.Items.Add("2:Quản lý");
        }

        // ============== TAB 1: DOANH THU ==============
        private void LoadBillData()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;
                List<Bill> bills = BillDAL.GetBillsByDateRange(fromDate, toDate);
                dgvInvoice.DataSource = bills;
                dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvInvoice.ReadOnly = true;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load hóa đơn: " + ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e) => LoadBillData();

        // ============== TAB 2: THỰC ĐƠN ==============
        private void LoadFoodData()
        {
            dgvDish.DataSource = FoodDAL.GetAllFoods();
            dgvDish.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void LoadFoodByCategory(int categoryID)
        {
            dgvDish.DataSource = FoodDAL.GetFoodsByCategory(categoryID);
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDishName.Text) || !decimal.TryParse(txtPrice.Text, out decimal price)) return;
            Food food = new Food { Name = txtDishName.Text, CategoryID = (int)cbCategory.SelectedValue, Price = (float)price, ImagePath = txtImagePath.Text };
            if (FoodDAL.AddFood(food)) { LoadFoodData(); ClearFoodInputs(); }
        }

        private void btnEditDish_Click(object sender, EventArgs e)
        {
            if (selectedFoodID == -1 || !decimal.TryParse(txtPrice.Text, out decimal price)) return;
            Food food = new Food { Name = txtDishName.Text, CategoryID = (int)cbCategory.SelectedValue, Price = (float)price, ImagePath = txtImagePath.Text };
            if (FoodDAL.UpdateFood(selectedFoodID, food)) { LoadFoodData(); }
        }

        private void btnDeleteDish_Click(object sender, EventArgs e)
        {
            if (selectedFoodID != -1 && MessageBox.Show("Xóa món này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (FoodDAL.DeleteFood(selectedFoodID)) { LoadFoodData(); ClearFoodInputs(); }
        }

        private void dgvDish_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void ClearFoodInputs() { txtDishName.Clear(); txtPrice.Clear(); txtImagePath.Clear(); selectedFoodID = -1; }

        // ============== TAB 3: BÀN ĂN ==============
        private void LoadTableData() => dgvTable.DataSource = TableFoodDAL.GetAllTables();

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (TableFoodDAL.AddTable(new TableFood { Name = txtTableName.Text, Status = txtCapacity.Text })) { LoadTableData(); ClearTableInputs(); }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (selectedTableID != -1 && TableFoodDAL.UpdateTable(selectedTableID, new TableFood { Name = txtTableName.Text, Status = txtCapacity.Text })) LoadTableData();
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTable.Rows[e.RowIndex].DataBoundItem is TableFood table)
            {
                selectedTableID = table.ID;
                txtTableName.Text = table.Name;
                txtCapacity.Text = table.Status;
            }
        }

        private void ClearTableInputs() { txtTableName.Clear(); txtCapacity.Clear(); selectedTableID = -1; }

        // ============== TAB 4: TÀI KHOẢN ==============
        private void LoadAccountData() => dgvAccount.DataSource = AccountDAL.GetAllAccounts();

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (cbRole.SelectedItem == null) return;
            Account acc = new Account { UserName = txtUsername.Text, Password = txtPassword.Text, Type = int.Parse(cbRole.SelectedItem.ToString().Split(':')[0]) };
            if (AccountDAL.AddAccount(acc)) LoadAccountData();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAccount.Rows[e.RowIndex].DataBoundItem is Account acc)
            {
                selectedAccountUserName = acc.UserName;
                txtUsername.Text = acc.UserName;
                txtPassword.Text = acc.Password;
                cbRole.SelectedItem = acc.Type == 0 ? "0:Admin" : acc.Type == 1 ? "1:Nhân viên" : "2:Quản lý";
            }
        }

        // ============== TAB 5: NHÂN VIÊN (DataSet Logic) ==============
        private void InitializeEmployeeTab()
        {
            if (quanLyNhaHangDataSet == null)
            {
                quanLyNhaHangDataSet = new QuanLyNhaHangDataSet();
                employeeBindingSource = new BindingSource { DataSource = quanLyNhaHangDataSet, DataMember = "Employee" };
                employeeTableAdapter = new QuanLyNhaHangDataSetTableAdapters.EmployeeTableAdapter();
            }
            btnNVAdd.Click += BtnNVAdd_Click;
            btnNVEdit.Click += BtnNVEdit_Click;
            btnNVDelete.Click += BtnNVDelete_Click;
            btnNVSelectAvatar.Click += BtnNVSelectAvatar_Click;
            dgvNhanVien.CellClick += DgvNhanVien_CellClick;
        }

        private void LoadEmployeeData()
        {
            quanLyNhaHangDataSet.Employee.Clear();
            employeeTableAdapter.Fill(quanLyNhaHangDataSet.Employee);
            dgvNhanVien.DataSource = employeeBindingSource;
        }

        private void DgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNhanVien.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
            {
                DataRow row = drv.Row;
                selectedEmployeeID = Convert.ToInt32(row["ID"]);
                txtNVName.Text = row["Name"].ToString();
                txtNVPhone.Text = row["Phone"].ToString();
                txtNVPosition.Text = row["Position"].ToString();
                txtNVSalary.Text = row["Salary"].ToString();
                selectedEmployeeImagePath = row["Avatar"].ToString();
                if (System.IO.File.Exists(selectedEmployeeImagePath)) lblNVAvatarDisplay.Image = Image.FromFile(selectedEmployeeImagePath);
            }
        }

        private void BtnNVAdd_Click(object sender, EventArgs e)
        {
            var newRow = quanLyNhaHangDataSet.Employee.NewEmployeeRow();
            newRow.Name = txtNVName.Text;
            newRow.Phone = txtNVPhone.Text;
            newRow.Position = txtNVPosition.Text;
            newRow.Salary = decimal.Parse(txtNVSalary.Text);
            newRow.Avatar = selectedEmployeeImagePath;
            quanLyNhaHangDataSet.Employee.AddEmployeeRow(newRow);
            employeeTableAdapter.Update(quanLyNhaHangDataSet.Employee);
            LoadEmployeeData();
        }

        private void BtnNVSelectAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedEmployeeImagePath = ofd.FileName;
                lblNVAvatarDisplay.Image = Image.FromFile(ofd.FileName);
            }
        }

        // ============== TAB 6: DANH MỤC MÓN ĂN ==============
        private void InitializeCategoryTab()
        {
            btnAdd.Click += BtnAddCategory_Click;
            btnUpdate.Click += BtnUpdateCategory_Click;
            btnDelete.Click += BtnDeleteCategory_Click;
            dgvFoodCategory.CellClick += DgvFoodCategory_CellClick;
        }

        private void LoadCategoryData() => dgvFoodCategory.DataSource = FoodCategoryDAL.GetAllCategories();

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            if (FoodCategoryDAL.AddCategory(new FoodCategory { Name = txtTenMon.Text }))
            {
                LoadCategoryData();
                LoadFoodCategories(); // Update ComboBox tab món ăn
            }
        }

        private void DgvFoodCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvFoodCategory.Rows[e.RowIndex].DataBoundItem is FoodCategory cat)
            {
                selectedCategoryID = cat.ID;
                txtTenMon.Text = cat.Name;
            }
        }

        // ============== ĐĂNG XUẤT (Từ Current Version) ==============
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác Nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void BtnNVEdit_Click(object sender, EventArgs e) { /* Logic sửa tương tự Add */ }
        private void BtnNVDelete_Click(object sender, EventArgs e) { /* Logic xóa tương tự Add */ }
        private void BtnUpdateCategory_Click(object sender, EventArgs e) { /* Logic sửa danh mục */ }
private void BtnDeleteCategory_Click(object sender, EventArgs e) { /* Logic xóa danh mục */ }
    }
}