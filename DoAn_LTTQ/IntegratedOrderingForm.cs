using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_LTTQ.Models;
using DoAn_LTTQ.Services;

namespace DoAn_LTTQ
{
    public partial class IntegratedOrderingForm : Form
    {
        private List<TableFood> allTables;
        private FlowLayoutPanel flowTablePanel;
        private Panel orderPanel;
        private Panel tableSelectionPanel;
        private int selectedTableID = -1;
        private int currentBillID = -1;
        private Dictionary<int, Panel> tableButtonCache = new Dictionary<int, Panel>();
        private DataGridView dgvOrderList; // Thêm DataGridView để hiển thị danh sách

        public IntegratedOrderingForm()
        {
            InitializeComponent();
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            this.Text = "📋 Quản Lý Đặt Món - Nhà Hàng";
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Arial", 9);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Main container
            Panel mainContainer = new Panel();
            mainContainer.Dock = DockStyle.Fill;
            this.Controls.Add(mainContainer);

            // Header
            Label lblHeader = new Label();
            lblHeader.Text = "🍽️ CHỌN BÀN ĂN";
            lblHeader.Font = new Font("Arial", 13, FontStyle.Bold);
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Height = 35;
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblHeader.BackColor = Color.FromArgb(0, 102, 204);
            lblHeader.ForeColor = Color.White;
            mainContainer.Controls.Add(lblHeader);

            // Table Selection Panel
            tableSelectionPanel = new Panel();
            tableSelectionPanel.Dock = DockStyle.Fill;
            tableSelectionPanel.BackColor = Color.FromArgb(245, 245, 245);
            tableSelectionPanel.Padding = new Padding(10);
            mainContainer.Controls.Add(tableSelectionPanel);

            // Title for table selection
            Label lblSelectTable = new Label();
            lblSelectTable.Text = "Chọn bàn để đặt món:";
            lblSelectTable.Font = new Font("Arial", 11, FontStyle.Bold);
            lblSelectTable.Dock = DockStyle.Top;
            lblSelectTable.Height = 25;
            lblSelectTable.TextAlign = ContentAlignment.BottomLeft;
            tableSelectionPanel.Controls.Add(lblSelectTable);

            // Flow panel for tables
            flowTablePanel = new FlowLayoutPanel();
            flowTablePanel.Dock = DockStyle.Fill;
            flowTablePanel.AutoScroll = true;
            flowTablePanel.WrapContents = true;
            flowTablePanel.Padding = new Padding(5);
            flowTablePanel.BackColor = Color.FromArgb(245, 245, 245);
            tableSelectionPanel.Controls.Add(flowTablePanel);

            // Reset button
            Button btnReset = new Button();
            btnReset.Text = "🔄 Reset Tất Cả";
            btnReset.Dock = DockStyle.Bottom;
            btnReset.Height = 35;
            btnReset.Font = new Font("Arial", 10, FontStyle.Bold);
            btnReset.BackColor = Color.FromArgb(255, 107, 107);
            btnReset.ForeColor = Color.White;
            btnReset.Click += BtnReset_Click;
            tableSelectionPanel.Controls.Add(btnReset);

            // Order Panel (hidden initially)
            orderPanel = new Panel();
            orderPanel.Dock = DockStyle.Fill;
            orderPanel.Visible = false;
            mainContainer.Controls.Add(orderPanel);

            // Load tables on form load
            this.Load += IntegratedOrderingForm_Load;
        }

        private void IntegratedOrderingForm_Load(object sender, EventArgs e)
        {
            InitializeTeaItem();
            LoadTables();
        }

        private void InitializeTeaItem()
        {
            try
            {
                // Di chuyển "Trà Đá" vào CategoryID = 1 (Món chính) để nó nằm cùng Cơm chiên, Phở bò
                string query = "UPDATE Food SET CategoryID = 1 WHERE Name = N'Trà Đá'";
                DatabaseHelper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                // Im lặng - nếu lỗi thì bỏ qua
            }
        }

        private void LoadTables()
        {
            try
            {
                allTables = TableFoodService.GetAllTables();
                DisplayTables(allTables);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bàn: " + ex.Message, "Lỗi");
            }
        }

        private void DisplayTables(List<TableFood> tables)
        {
            flowTablePanel.Controls.Clear();
            tableButtonCache.Clear();

            if (tables == null || tables.Count == 0)
                return;

            foreach (var table in tables)
            {
                Panel tableButton = CreateTableButton(table);
                flowTablePanel.Controls.Add(tableButton);
                tableButtonCache[table.ID] = tableButton;
            }
        }

        private Panel CreateTableButton(TableFood table)
        {
            // Use a custom panel that properly handles click events
            Button tableButton = new Button();
            tableButton.Size = new Size(140, 130);
            tableButton.Margin = new Padding(5);
            tableButton.FlatStyle = FlatStyle.Flat;
            tableButton.BackColor = GetTableColor(table.Status);
            tableButton.ForeColor = Color.Black;
            tableButton.Cursor = Cursors.Hand;
            tableButton.Font = new Font("Arial", 11, FontStyle.Bold);

            // Create display text
            string displayText = table.Name + "\n";
            displayText += table.Status + "\n";

            if (table.Status == "Trống")
            {
                displayText += "Sẵn sàng";
            }
            else
            {
                displayText += $"{table.DishCount} món | {table.CustomerCount} khách\n{table.Total:N0}đ";
            }

            tableButton.Text = displayText;
            tableButton.TextAlign = ContentAlignment.MiddleCenter;
            tableButton.Click += (sender, e) => SelectTable(table.ID);

            // Convert Button to Panel for consistency
            Panel wrapper = new Panel();
            wrapper.Size = tableButton.Size;
            wrapper.Margin = tableButton.Margin;
            wrapper.Controls.Add(tableButton);
            tableButton.Dock = DockStyle.Fill;

            return wrapper;
        }

        private Color GetTableColor(string status)
        {
            if (status == "Trống")
                return Color.FromArgb(200, 255, 200); // Light green
            else
                return Color.FromArgb(255, 200, 200); // Light red
        }

        private Color GetStatusColor(string status)
        {
            if (status == "Trống")
                return Color.Green;
            else
                return Color.Red;
        }

        private void SelectTable(int tableID)
        {
            try
            {
                selectedTableID = tableID;
                var selectedTable = allTables.FirstOrDefault(t => t.ID == tableID);

                if (selectedTable != null && selectedTable.Status == "Trống")
                {
                    // Create new bill
                    currentBillID = BillService.CreateBill(tableID);
                    if (currentBillID == -1)
                    {
                        MessageBox.Show("Lỗi khi tạo đơn hàng!", "Lỗi");
                        return;
                    }

                    // Show order form
                    ShowOrderPanel(selectedTable);
                }
                else if (selectedTable != null && selectedTable.Status == "Sử dụng")
                {
                    // Show existing order details
                    ShowExistingOrderPanel(selectedTable);
                }
                else if (selectedTable != null)
                {
                    MessageBox.Show("Bàn này không khả dụng!\nTrạng thái: " + selectedTable.Status, "Thông báo");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void ShowOrderPanel(TableFood table)
        {
            tableSelectionPanel.Visible = false;
            orderPanel.Visible = true;
            orderPanel.Controls.Clear();

            // Header
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 40;
            headerPanel.BackColor = Color.FromArgb(0, 102, 204);
            orderPanel.Controls.Add(headerPanel);

            Label lblOrderHeader = new Label();
            lblOrderHeader.Text = $"📋 Đặt Món - {table.Name}";
            lblOrderHeader.Font = new Font("Arial", 12, FontStyle.Bold);
            lblOrderHeader.ForeColor = Color.White;
            lblOrderHeader.Dock = DockStyle.Fill;
            lblOrderHeader.TextAlign = ContentAlignment.MiddleCenter;
            headerPanel.Controls.Add(lblOrderHeader);

            // Main content - Split layout
            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Padding = new Padding(10);
            orderPanel.Controls.Add(contentPanel);

            // LEFT: Tab food categories
            Panel leftPanel = new Panel();
            leftPanel.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(leftPanel);

            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Arial", 9);
            leftPanel.Controls.Add(tabControl);

            // Load categories
            try
            {
                List<FoodCategory> categories = FoodCategoryService.GetAllCategories();

                foreach (var category in categories)
                {
                    CreateCategoryTab(tabControl, category, table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi");
            }

            // RIGHT: Order list panel
            Panel rightPanel = new Panel();
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Width = 350;
            rightPanel.Padding = new Padding(8, 0, 0, 0);
            rightPanel.BackColor = Color.FromArgb(240, 240, 240);
            contentPanel.Controls.Add(rightPanel);

            // Title
            Label lblOrderList = new Label();
            lblOrderList.Text = "📝 Danh Sách Đặt Hàng";
            lblOrderList.Font = new Font("Arial", 10, FontStyle.Bold);
            lblOrderList.Dock = DockStyle.Top;
            lblOrderList.Height = 28;
            lblOrderList.TextAlign = ContentAlignment.MiddleCenter;
            lblOrderList.BackColor = Color.FromArgb(76, 175, 80);
            lblOrderList.ForeColor = Color.White;
            rightPanel.Controls.Add(lblOrderList);

            // DataGridView for order list
            dgvOrderList = new DataGridView();
            dgvOrderList.Dock = DockStyle.Fill;
            dgvOrderList.ReadOnly = false;
            dgvOrderList.AllowUserToAddRows = false;
            dgvOrderList.AllowUserToDeleteRows = false;
            dgvOrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderList.Font = new Font("Arial", 8);
            dgvOrderList.BackgroundColor = Color.White;
            dgvOrderList.GridColor = Color.LightGray;
            dgvOrderList.RowHeadersWidth = 25;

            // Thêm columns
            dgvOrderList.Columns.Add("MonAn", "Món Ăn");
            dgvOrderList.Columns.Add("SoLuong", "SL");
            dgvOrderList.Columns.Add("Gia", "Giá");
            dgvOrderList.Columns.Add("ThanhTien", "Thành Tiền");
            dgvOrderList.Columns.Add("Sua", "");
            dgvOrderList.Columns.Add("Xoa", "");
            dgvOrderList.Columns.Add("FoodID", "FoodID");
            dgvOrderList.Columns.Add("BillInfoID", "BillInfoID");

            dgvOrderList.Columns["MonAn"].Width = 100;
            dgvOrderList.Columns["SoLuong"].Width = 32;
            dgvOrderList.Columns["Gia"].Width = 50;
            dgvOrderList.Columns["ThanhTien"].Width = 60;
            dgvOrderList.Columns["Sua"].Width = 25;
            dgvOrderList.Columns["Xoa"].Width = 25;
            dgvOrderList.Columns["FoodID"].Visible = false;
            dgvOrderList.Columns["BillInfoID"].Visible = false;

            // Button columns
            DataGridViewButtonColumn btnSua = new DataGridViewButtonColumn();
            btnSua.Name = "Sua";
            btnSua.HeaderText = "";
            btnSua.Text = "✏️";
            btnSua.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
            btnXoa.Name = "Xoa";
            btnXoa.HeaderText = "";
            btnXoa.Text = "🗑️";
            btnXoa.UseColumnTextForButtonValue = true;

            dgvOrderList.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == dgvOrderList.Columns["Sua"].Index)
                    {
                        EditOrderItem(e.RowIndex, table);
                    }
                    else if (e.ColumnIndex == dgvOrderList.Columns["Xoa"].Index)
                    {
                        DeleteOrderItem(e.RowIndex, table);
                    }
                }
            };

            rightPanel.Controls.Add(dgvOrderList);

            // Bottom button panel
            Panel bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 40;
            bottomPanel.BackColor = Color.LightGray;
            orderPanel.Controls.Add(bottomPanel);

            Button btnComplete = new Button();
            btnComplete.Text = "✅ Hoàn Tất";
            btnComplete.Size = new Size(120, 35);
            btnComplete.Location = new Point(bottomPanel.Width - 130, 3);
            btnComplete.Font = new Font("Arial", 10, FontStyle.Bold);
            btnComplete.BackColor = Color.FromArgb(76, 175, 80);
            btnComplete.ForeColor = Color.White;
            btnComplete.Click += (sender, e) => CompleteOrder(table);
            bottomPanel.Controls.Add(btnComplete);

            Button btnCancel = new Button();
            btnCancel.Text = "❌ Hủy";
            btnCancel.Size = new Size(110, 35);
            btnCancel.Location = new Point(bottomPanel.Width - 255, 3);
            btnCancel.Font = new Font("Arial", 10, FontStyle.Bold);
            btnCancel.BackColor = Color.FromArgb(255, 107, 107);
            btnCancel.ForeColor = Color.White;
            btnCancel.Click += (sender, e) => CancelOrder();
            bottomPanel.Controls.Add(btnCancel);

            // Load danh sách đặt hàng
            RefreshOrderList();
        }

        private void RefreshOrderList()
        {
            try
            {
                dgvOrderList.Rows.Clear();

                // Lấy danh sách từ database
                string query = @"SELECT bi.ID, f.Name, bi.Count, f.Price, (f.Price * bi.Count) as Total, f.ID as FoodID
                               FROM BillInfo bi
                               JOIN Food f ON bi.FoodID = f.ID
                               WHERE bi.BillID = @BillID
                               ORDER BY f.Name";

                SqlParameter[] parameters = new SqlParameter[] 
                {
                    new SqlParameter("@BillID", currentBillID)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                decimal tongTien = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int soLuong = (int)row["Count"];
                    decimal gia = (decimal)row["Price"];
                    decimal thanhTien = soLuong * gia;
                    tongTien += thanhTien;

                    dgvOrderList.Rows.Add(
                        row["Name"].ToString(),
                        soLuong,
                        gia.ToString("N0") + "đ",
                        thanhTien.ToString("N0") + "đ",
                        "✏️",
                        "🗑️",
                        row["FoodID"],
                        row["ID"]
                    );
                }

                // Thêm hàng tổng
                if (dgvOrderList.Rows.Count > 0)
                {
                    dgvOrderList.Rows.Add();
                    int lastRow = dgvOrderList.Rows.Count - 1;
                    dgvOrderList.Rows[lastRow].Cells[0].Value = "TỔNG CỘNG";
                    dgvOrderList.Rows[lastRow].Cells[0].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                    dgvOrderList.Rows[lastRow].Cells[3].Value = tongTien.ToString("N0") + "đ";
                    dgvOrderList.Rows[lastRow].Cells[3].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                    dgvOrderList.Rows[lastRow].Cells[3].Style.BackColor = Color.Yellow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message, "Lỗi");
            }
        }

        private void DeleteOrderItem(int rowIndex, TableFood table)
        {
            try
            {
                if (rowIndex >= dgvOrderList.Rows.Count - 1)
                    return; // Không xóa hàng tổng

                object billInfoID = dgvOrderList.Rows[rowIndex].Cells["BillInfoID"].Value;

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món này?", "Xác nhận", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM BillInfo WHERE ID = @ID";
                    SqlParameter[] parameters = new SqlParameter[] 
                    {
                        new SqlParameter("@ID", billInfoID)
                    };

                    DatabaseHelper.ExecuteNonQuery(query, parameters);
                    RefreshOrderList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void EditOrderItem(int rowIndex, TableFood table)
        {
            try
            {
                if (rowIndex >= dgvOrderList.Rows.Count - 1)
                    return; // Không sửa hàng tổng

                object billInfoID = dgvOrderList.Rows[rowIndex].Cells["BillInfoID"].Value;
                object soLuongHienTai = dgvOrderList.Rows[rowIndex].Cells["SoLuong"].Value;

                // Dialog nhập số lượng mới
                Form editForm = new Form();
                editForm.Text = "Sửa Số Lượng";
                editForm.Width = 300;
                editForm.Height = 150;
                editForm.StartPosition = FormStartPosition.CenterScreen;

                Label lbl = new Label();
                lbl.Text = "Số lượng mới:";
                lbl.Location = new Point(20, 20);
                lbl.Width = 100;
                editForm.Controls.Add(lbl);

                NumericUpDown numQty = new NumericUpDown();
                numQty.Location = new Point(120, 20);
                numQty.Width = 150;
                numQty.Minimum = 1;
                numQty.Maximum = 100;
                numQty.Value = int.Parse(soLuongHienTai.ToString());
                editForm.Controls.Add(numQty);

                Button btnOK = new Button();
                btnOK.Text = "OK";
                btnOK.Location = new Point(120, 80);
                btnOK.Width = 70;
                btnOK.Click += (sender, e) => editForm.DialogResult = DialogResult.OK;
                editForm.Controls.Add(btnOK);

                Button btnCancel = new Button();
                btnCancel.Text = "Hủy";
                btnCancel.Location = new Point(200, 80);
                btnCancel.Width = 70;
                btnCancel.Click += (sender, e) => editForm.DialogResult = DialogResult.Cancel;
                editForm.Controls.Add(btnCancel);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    int newQty = (int)numQty.Value;
                    string query = "UPDATE BillInfo SET Count = @Count WHERE ID = @ID";
                    SqlParameter[] parameters = new SqlParameter[] 
                    {
                        new SqlParameter("@Count", newQty),
                        new SqlParameter("@ID", billInfoID)
                    };

                    DatabaseHelper.ExecuteNonQuery(query, parameters);
                    RefreshOrderList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void CreateCategoryTab(TabControl tabControl, FoodCategory category, TableFood table)
        {
            TabPage tabPage = new TabPage(category.Name);
            tabPage.BackColor = Color.White;
            tabPage.Padding = new Padding(5);

            // FlowLayout for foods in this category
            FlowLayoutPanel flowFood = new FlowLayoutPanel();
            flowFood.Dock = DockStyle.Fill;
            flowFood.AutoScroll = true;
            flowFood.WrapContents = true;
            tabPage.Controls.Add(flowFood);

            // Load foods
            List<Food> foods = FoodService.GetFoodByCategory(category.ID);
            foreach (var food in foods)
            {
                Panel foodPanel = CreateFoodButton(food, table);
                flowFood.Controls.Add(foodPanel);
            }

            tabControl.TabPages.Add(tabPage);
        }

        private Panel CreateFoodButton(Food food, TableFood table)
        {
            Panel foodPanel = new Panel();
            foodPanel.Size = new Size(160, 200);
            foodPanel.Margin = new Padding(8);
            foodPanel.BorderStyle = BorderStyle.FixedSingle;
            foodPanel.BackColor = Color.White;
            foodPanel.Cursor = Cursors.Hand;
            foodPanel.Tag = food.ID;

            // Image
            try
            {
                string imagePath = Path.Combine(Application.StartupPath, food.ImagePath ?? "");

                if (!string.IsNullOrEmpty(food.ImagePath) && File.Exists(imagePath))
                {
                    PictureBox picFood = new PictureBox();
                    picFood.Dock = DockStyle.Top;
                    picFood.Height = 70;
                    picFood.SizeMode = PictureBoxSizeMode.Zoom;
                    picFood.BackColor = Color.White;

                    try
                    {
                        picFood.Image = Image.FromFile(imagePath);
                    }
                    catch
                    {
                        picFood.BackColor = Color.LightGray;
                    }

                    foodPanel.Controls.Add(picFood);
                }
            }
            catch { }

            // Food name
            Label lblFoodName = new Label();
            lblFoodName.Text = food.Name;
            lblFoodName.Font = new Font("Arial", 10, FontStyle.Bold);
            lblFoodName.Dock = DockStyle.Top;
            lblFoodName.Height = 30;
            lblFoodName.TextAlign = ContentAlignment.MiddleCenter;
            lblFoodName.AutoEllipsis = true;
            lblFoodName.BackColor = Color.FromArgb(240, 240, 240);
            lblFoodName.Padding = new Padding(3);
            foodPanel.Controls.Add(lblFoodName);

            // Price
            Label lblPrice = new Label();
            lblPrice.Text = $"{food.Price:N0}đ";
            lblPrice.Font = new Font("Arial", 9, FontStyle.Bold);
            lblPrice.ForeColor = Color.Crimson;
            lblPrice.Dock = DockStyle.Top;
            lblPrice.Height = 22;
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            lblPrice.BackColor = Color.FromArgb(255, 250, 205);
            foodPanel.Controls.Add(lblPrice);

            // Quantity input with +/- buttons
            Panel qtyPanel = new Panel();
            qtyPanel.Dock = DockStyle.Top;
            qtyPanel.Height = 38;
            qtyPanel.Padding = new Padding(4);
            qtyPanel.BackColor = Color.FromArgb(250, 250, 250);
            foodPanel.Controls.Add(qtyPanel);

            Label lblQtyLabel = new Label();
            lblQtyLabel.Text = "Số lượng:";
            lblQtyLabel.Font = new Font("Arial", 8);
            lblQtyLabel.Dock = DockStyle.Top;
            lblQtyLabel.Height = 12;
            lblQtyLabel.TextAlign = ContentAlignment.MiddleLeft;
            qtyPanel.Controls.Add(lblQtyLabel);

            // Quantity control panel with +/- buttons
            Panel qtyControlPanel = new Panel();
            qtyControlPanel.Dock = DockStyle.Bottom;
            qtyControlPanel.Height = 20;
            qtyPanel.Controls.Add(qtyControlPanel);

            // Minus button
            Button btnMinus = new Button();
            btnMinus.Text = "−";
            btnMinus.Font = new Font("Arial", 9, FontStyle.Bold);
            btnMinus.Size = new Size(22, 20);
            btnMinus.Dock = DockStyle.Left;
            btnMinus.BackColor = Color.FromArgb(200, 200, 200);
            btnMinus.ForeColor = Color.White;
            btnMinus.FlatStyle = FlatStyle.Flat;
            qtyControlPanel.Controls.Add(btnMinus);

            // Quantity display
            Label lblQtyValue = new Label();
            lblQtyValue.Text = "1";
            lblQtyValue.Font = new Font("Arial", 9, FontStyle.Bold);
            lblQtyValue.Dock = DockStyle.Fill;
            lblQtyValue.TextAlign = ContentAlignment.MiddleCenter;
            lblQtyValue.BackColor = Color.White;
            lblQtyValue.BorderStyle = BorderStyle.FixedSingle;
            qtyControlPanel.Controls.Add(lblQtyValue);

            // Plus button
            Button btnPlus = new Button();
            btnPlus.Text = "+";
            btnPlus.Font = new Font("Arial", 9, FontStyle.Bold);
            btnPlus.Size = new Size(22, 20);
            btnPlus.Dock = DockStyle.Right;
            btnPlus.BackColor = Color.FromArgb(100, 150, 255);
            btnPlus.ForeColor = Color.White;
            btnPlus.FlatStyle = FlatStyle.Flat;
            qtyControlPanel.Controls.Add(btnPlus);

            // Plus/Minus button handlers
            int quantity = 1;
            btnPlus.Click += (sender, e) =>
            {
                if (quantity < 100)
                {
                    quantity++;
                    lblQtyValue.Text = quantity.ToString();
                }
            };

            btnMinus.Click += (sender, e) =>
            {
                if (quantity > 1)
                {
                    quantity--;
                    lblQtyValue.Text = quantity.ToString();
                }
            };

            // Add button - Full width
            Button btnAdd = new Button();
            btnAdd.Text = "➕ Thêm Vào Đơn";
            btnAdd.Dock = DockStyle.Bottom;
            btnAdd.Height = 35;
            btnAdd.Font = new Font("Arial", 9, FontStyle.Bold);
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Click += (sender, e) => AddFoodToOrder(food, quantity, table);
            foodPanel.Controls.Add(btnAdd);

            // Hover effect
            foodPanel.MouseEnter += (sender, e) =>
            {
                foodPanel.BackColor = Color.FromArgb(240, 248, 255);
            };
            foodPanel.MouseLeave += (sender, e) =>
            {
                foodPanel.BackColor = Color.White;
            };

            return foodPanel;
        }

        private Panel CreateDrinkButton(Food drink, TableFood table)
        {
            Panel drinkPanel = new Panel();
            drinkPanel.Size = new Size(160, 200);
            drinkPanel.Margin = new Padding(8);
            drinkPanel.BorderStyle = BorderStyle.FixedSingle;
            drinkPanel.BackColor = Color.White;
            drinkPanel.Cursor = Cursors.Hand;
            drinkPanel.Tag = drink.ID;

            // Drink name - same style as food
            Label lblDrinkName = new Label();
            lblDrinkName.Text = drink.Name;
            lblDrinkName.Font = new Font("Arial", 11, FontStyle.Bold);
            lblDrinkName.Dock = DockStyle.Top;
            lblDrinkName.Height = 40;
            lblDrinkName.TextAlign = ContentAlignment.MiddleCenter;
            lblDrinkName.AutoEllipsis = true;
            lblDrinkName.BackColor = Color.FromArgb(240, 240, 240);
            lblDrinkName.Padding = new Padding(5);
            drinkPanel.Controls.Add(lblDrinkName);

            // Price
            Label lblPrice = new Label();
            lblPrice.Text = $"{drink.Price:N0}đ";
            lblPrice.Font = new Font("Arial", 10, FontStyle.Bold);
            lblPrice.ForeColor = Color.Crimson;
            lblPrice.Dock = DockStyle.Top;
            lblPrice.Height = 28;
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            lblPrice.BackColor = Color.FromArgb(255, 245, 225);
            drinkPanel.Controls.Add(lblPrice);

            // Quantity input with +/- buttons
            Panel qtyPanel = new Panel();
            qtyPanel.Dock = DockStyle.Top;
            qtyPanel.Height = 50;
            qtyPanel.Padding = new Padding(5);
            qtyPanel.BackColor = Color.FromArgb(250, 250, 250);
            drinkPanel.Controls.Add(qtyPanel);

            Label lblQtyLabel = new Label();
            lblQtyLabel.Text = "Số lượng:";
            lblQtyLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            lblQtyLabel.Dock = DockStyle.Top;
            lblQtyLabel.Height = 15;
            lblQtyLabel.TextAlign = ContentAlignment.MiddleLeft;
            qtyPanel.Controls.Add(lblQtyLabel);

            // Quantity control panel with +/- buttons
            Panel qtyControlPanel = new Panel();
            qtyControlPanel.Dock = DockStyle.Bottom;
            qtyControlPanel.Height = 28;
            qtyPanel.Controls.Add(qtyControlPanel);

            // Minus button
            Button btnMinus = new Button();
            btnMinus.Text = "−";
            btnMinus.Font = new Font("Arial", 12, FontStyle.Bold);
            btnMinus.Size = new Size(28, 28);
            btnMinus.Dock = DockStyle.Left;
            btnMinus.BackColor = Color.FromArgb(200, 200, 200);
            btnMinus.ForeColor = Color.White;
            btnMinus.FlatStyle = FlatStyle.Flat;
            qtyControlPanel.Controls.Add(btnMinus);

            // Quantity display
            Label lblQtyValue = new Label();
            lblQtyValue.Text = "1";
            lblQtyValue.Font = new Font("Arial", 11, FontStyle.Bold);
            lblQtyValue.Dock = DockStyle.Fill;
            lblQtyValue.TextAlign = ContentAlignment.MiddleCenter;
            lblQtyValue.BackColor = Color.White;
            lblQtyValue.BorderStyle = BorderStyle.FixedSingle;
            qtyControlPanel.Controls.Add(lblQtyValue);

            // Plus button
            Button btnPlus = new Button();
            btnPlus.Text = "+";
            btnPlus.Font = new Font("Arial", 12, FontStyle.Bold);
            btnPlus.Size = new Size(28, 28);
            btnPlus.Dock = DockStyle.Right;
            btnPlus.BackColor = Color.FromArgb(100, 150, 255);
            btnPlus.ForeColor = Color.White;
            btnPlus.FlatStyle = FlatStyle.Flat;
            qtyControlPanel.Controls.Add(btnPlus);

            // Plus/Minus handlers
            int quantity = 1;
            btnPlus.Click += (sender, e) =>
            {
                if (quantity < 50)
                {
                    quantity++;
                    lblQtyValue.Text = quantity.ToString();
                }
            };

            btnMinus.Click += (sender, e) =>
            {
                if (quantity > 1)
                {
                    quantity--;
                    lblQtyValue.Text = quantity.ToString();
                }
            };

            // Add button - Full width
            Button btnAdd = new Button();
            btnAdd.Text = "➕ Thêm Vào Đơn";
            btnAdd.Dock = DockStyle.Bottom;
            btnAdd.Height = 40;
            btnAdd.Font = new Font("Arial", 10, FontStyle.Bold);
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Click += (sender, e) => AddFoodToOrder(drink, quantity, table);
            drinkPanel.Controls.Add(btnAdd);

            // Hover effect
            drinkPanel.MouseEnter += (sender, e) =>
            {
                drinkPanel.BackColor = Color.FromArgb(240, 248, 255);
            };
            drinkPanel.MouseLeave += (sender, e) =>
            {
                drinkPanel.BackColor = Color.White;
            };

            return drinkPanel;
        }

        private void AddFoodToOrder(Food food, int quantity, TableFood table)
        {
            try
            {
                if (BillService.AddBillInfo(currentBillID, food.ID, quantity))
                {
                    RefreshOrderList();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm món ăn!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void CompleteOrder(TableFood table)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    $"✅ Xác nhận hoàn tất đơn hàng cho {table.Name}?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update table status
                    if (TableFoodService.UpdateTableStatus(table.ID, "Sử dụng"))
                    {
                        MessageBox.Show("✅ Đơn hàng đã được tạo thành công!\nCác món ăn sẽ được gửi đến bàn này.", "Hoàn Tất");

                        // Reset view
                        ResetToTableSelection();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi cập nhật trạng thái bàn!", "Lỗi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void CancelOrder()
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn hủy đơn hàng này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete the bill
                    BillService.DeleteBill(currentBillID);
                    ResetToTableSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "🔄 Reset tất cả bàn về 'Trống'?\n\n⚠️ Sẽ xóa tất cả hóa đơn, chi tiết hóa đơn và đặt lại tất cả bàn.\n\nTiếp tục?",
                "Cảnh báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.ExecuteNonQuery(
                        "DELETE FROM BillInfo; " +
                        "DELETE FROM Bill; " +
                        "UPDATE TableFood SET Status = N'Trống'");

                    MessageBox.Show("✅ Đã reset tất cả bàn thành công!", "Thành công");
                    LoadTables();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi reset: " + ex.Message, "Lỗi");
                }
            }
        }

        private void ResetToTableSelection()
        {
            orderPanel.Visible = false;
            tableSelectionPanel.Visible = true;
            LoadTables();
        }

        private void ShowExistingOrderPanel(TableFood table)
        {
            try
            {
                tableSelectionPanel.Visible = false;
                orderPanel.Visible = true;
                orderPanel.Controls.Clear();

                // Header
                Panel headerPanel = new Panel();
                headerPanel.Dock = DockStyle.Top;
                headerPanel.Height = 40;
                headerPanel.BackColor = Color.FromArgb(0, 102, 204);
                orderPanel.Controls.Add(headerPanel);

                Label lblOrderHeader = new Label();
                lblOrderHeader.Text = $"📋 Chi tiết đơn - {table.Name}";
                lblOrderHeader.Font = new Font("Arial", 12, FontStyle.Bold);
                lblOrderHeader.ForeColor = Color.White;
                lblOrderHeader.Dock = DockStyle.Fill;
                lblOrderHeader.TextAlign = ContentAlignment.MiddleCenter;
                headerPanel.Controls.Add(lblOrderHeader);

                // Main content - Display bill items
                Panel contentPanel = new Panel();
                contentPanel.Dock = DockStyle.Fill;
                contentPanel.Padding = new Padding(10);
                contentPanel.BackColor = Color.White;
                orderPanel.Controls.Add(contentPanel);

                // Get bill ID for this table
                int billID = BillService.GetBillIDByTable(table.ID);
                if (billID == -1)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn cho bàn này!", "Lỗi");
                    ResetToTableSelection();
                    return;
                }

                // Display DataGridView with bill items
                DataGridView dgvBillItems = new DataGridView();
                dgvBillItems.Dock = DockStyle.Fill;
                dgvBillItems.AllowUserToAddRows = false;
                dgvBillItems.AllowUserToDeleteRows = false;
                dgvBillItems.ReadOnly = true;
                dgvBillItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBillItems.Font = new Font("Arial", 9);

                // Load bill items
                DataTable billItems = BillService.GetBillInfoWithFoodByBillID(billID);
                dgvBillItems.DataSource = billItems;

                // Format columns
                if (dgvBillItems.Columns.Count > 0)
                {
                    dgvBillItems.Columns[0].HeaderText = "Tên Món";
                    dgvBillItems.Columns[0].Width = 200;
                    if (dgvBillItems.Columns.Count > 1)
                    {
                        dgvBillItems.Columns[1].HeaderText = "Giá";
                        dgvBillItems.Columns[1].Width = 100;
                    }
                    if (dgvBillItems.Columns.Count > 2)
                    {
                        dgvBillItems.Columns[2].HeaderText = "Số Lượng";
                        dgvBillItems.Columns[2].Width = 80;
                    }
                    if (dgvBillItems.Columns.Count > 3)
                    {
                        dgvBillItems.Columns[3].HeaderText = "Thành Tiền";
                        dgvBillItems.Columns[3].Width = 120;
                    }
                }

                contentPanel.Controls.Add(dgvBillItems);

                // Bottom buttons panel
                Panel bottomPanel = new Panel();
                bottomPanel.Dock = DockStyle.Bottom;
                bottomPanel.Height = 40;
                bottomPanel.BackColor = Color.LightGray;
                orderPanel.Controls.Add(bottomPanel);

                Button btnPayment = new Button();
                btnPayment.Text = "💳 Thanh Toán";
                btnPayment.Size = new Size(120, 35);
                btnPayment.Location = new Point(bottomPanel.Width - 130, 3);
                btnPayment.Font = new Font("Arial", 10, FontStyle.Bold);
                btnPayment.BackColor = Color.FromArgb(0, 150, 136);
                btnPayment.ForeColor = Color.White;
                btnPayment.Click += (sender, e) => OpenPaymentForm(billID, table);
                bottomPanel.Controls.Add(btnPayment);

                Button btnBack = new Button();
                btnBack.Text = "← Quay Lại";
                btnBack.Size = new Size(110, 35);
                btnBack.Location = new Point(bottomPanel.Width - 255, 3);
                btnBack.Font = new Font("Arial", 10, FontStyle.Bold);
                btnBack.BackColor = Color.FromArgb(158, 158, 158);
                btnBack.ForeColor = Color.White;
                btnBack.Click += (sender, e) => ResetToTableSelection();
                bottomPanel.Controls.Add(btnBack);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
                ResetToTableSelection();
            }
        }

        private void OpenPaymentForm(int billID, TableFood table)
        {
            try
            {
                PaymentForm paymentForm = new PaymentForm(billID, table.ID, table.Name);
                paymentForm.ShowDialog();

                // Reload tables after payment
                ResetToTableSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form thanh toán: " + ex.Message, "Lỗi");
            }
        }

    }
}
