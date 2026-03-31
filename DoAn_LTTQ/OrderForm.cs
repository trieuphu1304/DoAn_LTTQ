using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoAn_LTTQ.Data;
using DoAn_LTTQ.Models;
using System.Drawing;
using System.Linq;

namespace DoAn_LTTQ
{
    public partial class OrderForm : Form
    {
        private TableFood selectedTable = null;
        private List<BillInfo> orderItems = new List<BillInfo>();
        private int selectedTableId = -1;
        private List<Food> allFoods = new List<Food>();
        private Dictionary<int, Button> tableButtons = new Dictionary<int, Button>();
        private bool isOrderConfirmed = false;  // Flag to track if order is confirmed

        private TableStateManager tableStateManager = TableStateManager.GetInstance();

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            tableStateManager.ClearAll();
            ResetAllTables();
            LoadTables();
            LoadCategories();
            allFoods = FoodDAL.GetAllFoods();
            ConfigureDataGridView();
        }

        private void ResetAllTables()
        {
            try
            {
                List<TableFood> tables = TableFoodDAL.GetAllTables();
                foreach (TableFood table in tables)
                {
                    table.Status = "Trống";
                    TableFoodDAL.UpdateTable(table.ID, table);
                }
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridView_Order.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Order.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Order.AllowUserToAddRows = false;
        }

        private void LoadTables()
        {
            try
            {
                flowLayoutPanel_Tables.Controls.Clear();
                tableButtons.Clear();
                List<TableFood> tables = TableFoodDAL.GetAllTables();

                foreach (TableFood table in tables)
                {
                    Button btn = new Button();
                    btn.Text = table.Name + "\n" + table.Status;
                    btn.Width = 90;
                    btn.Height = 70;
                    btn.Font = new Font("Arial", 9F, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Margin = new Padding(5);
                    btn.Tag = table.ID;
                    
                    if (table.Status == "Trống")
                    {
                        btn.BackColor = Color.LimeGreen;
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        btn.BackColor = Color.Red;
                        btn.ForeColor = Color.White;
                    }

                    tableButtons[table.ID] = btn;
                    btn.Click += (sender, e) => SelectTable(table.ID, table.Name);
                    flowLayoutPanel_Tables.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void LoadCategories()
        {
            try
            {
                comboBox_Category.Items.Clear();
                List<FoodCategory> categories = FoodCategoryDAL.GetAllCategories();

                foreach (FoodCategory category in categories)
                {
                    comboBox_Category.Items.Add(category);
                }

                if (comboBox_Category.Items.Count > 0)
                {
                    comboBox_Category.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void SelectTable(int tableId, string tableName)
        {
            // Save current table's orders if switching tables
            if (selectedTableId != -1 && selectedTableId != tableId)
            {
                tableStateManager.GetTableOrders(selectedTableId).Clear();
                tableStateManager.GetTableOrders(selectedTableId).AddRange(orderItems);
                tableStateManager.SetOrderConfirmed(selectedTableId, isOrderConfirmed);
            }

            // Load new table's orders
            selectedTableId = tableId;
            tableStateManager.InitializeTable(tableId);

            // Load the saved orders for this table
            orderItems.Clear();
            List<BillInfo> savedOrders = tableStateManager.GetTableOrders(tableId);
            orderItems.AddRange(savedOrders);
            isOrderConfirmed = tableStateManager.IsOrderConfirmed(tableId);

            label_SelectedTable.Text = tableName;
            RefreshOrderList();
        }

        private void comboBox_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFoods();
        }

        private void LoadFoods()
        {
            try
            {
                if (comboBox_Category.SelectedIndex < 0)
                    return;

                FoodCategory selectedCategory = (FoodCategory)comboBox_Category.SelectedItem;
                panel_FoodsGrid.Controls.Clear();

                List<Food> foods = FoodDAL.GetFoodsByCategory(selectedCategory.ID);

                int x = 10;
                int y = 10;
                const int itemWidth = 150;
                const int itemHeight = 180;
                const int cols = 3;

                for (int i = 0; i < foods.Count; i++)
                {
                    Food food = foods[i];
                    Panel itemPanel = CreateFoodItemPanel(food, itemWidth, itemHeight);
                    
                    itemPanel.Location = new Point(x + (i % cols) * (itemWidth + 15), y + (i / cols) * (itemHeight + 15));
                    panel_FoodsGrid.Controls.Add(itemPanel);
                }
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private Panel CreateFoodItemPanel(Food food, int width, int height)
        {
            Panel panel = new Panel();
            panel.Width = width;
            panel.Height = height;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.White;

            // Image
            PictureBox picBox = new PictureBox();
            picBox.Width = width - 4;
            picBox.Height = 100;
            picBox.Location = new Point(2, 2);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.BorderStyle = BorderStyle.FixedSingle;

            if (!string.IsNullOrEmpty(food.ImagePath) && System.IO.File.Exists(food.ImagePath))
            {
                try
                {
                    picBox.Image = Image.FromFile(food.ImagePath);
                }
                catch
                {
                    picBox.BackColor = Color.LightGray;
                }
            }
            else
            {
                picBox.BackColor = Color.LightGray;
            }

            panel.Controls.Add(picBox);

            // Food name
            Label nameLabel = new Label();
            nameLabel.Text = food.Name;
            nameLabel.Location = new Point(2, 107);
            nameLabel.Width = width - 4;
            nameLabel.Height = 20;
            nameLabel.Font = new Font("Arial", 8F, FontStyle.Bold);
            nameLabel.AutoEllipsis = true;
            panel.Controls.Add(nameLabel);

            // Price
            Label priceLabel = new Label();
            priceLabel.Text = food.Price.ToString("N0") + "đ";
            priceLabel.Location = new Point(2, 127);
            priceLabel.Width = width - 4;
            priceLabel.Height = 18;
            priceLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            priceLabel.ForeColor = Color.OrangeRed;
            panel.Controls.Add(priceLabel);

            // Add to order button
            Button addBtn = new Button();
            addBtn.Text = "+ Thêm";
            addBtn.Width = width - 4;
            addBtn.Height = 22;
            addBtn.Location = new Point(2, height - 24);
            addBtn.Font = new Font("Arial", 7F);
            addBtn.BackColor = Color.LimeGreen;
            addBtn.ForeColor = Color.White;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Click += (sender, e) => AddFoodToOrder(food.ID, food.Name, (int)food.Price);
            panel.Controls.Add(addBtn);

            return panel;
        }

        private void AddFoodToOrder(int foodId, string foodName, int price)
        {
            if (selectedTableId == -1)
            {
                return;
            }

            BillInfo existingItem = orderItems.Find(x => x.FoodID == foodId);

            if (existingItem != null)
            {
                existingItem.Count++;
            }
            else
            {
                BillInfo newItem = new BillInfo();
                newItem.FoodID = foodId;
                newItem.Count = 1;
                orderItems.Add(newItem);
            }

            RefreshOrderList();
        }

        private void RefreshOrderList()
        {
            try
            {
                dataGridView_Order.Rows.Clear();
                int total = 0;

                for (int i = 0; i < orderItems.Count; i++)
                {
                    BillInfo item = orderItems[i];
                    Food food = allFoods.Find(f => f.ID == item.FoodID);
                    if (food != null)
                    {
                        int itemTotal = (int)(food.Price * item.Count);
                        dataGridView_Order.Rows.Add(food.Name, item.Count, (int)food.Price, itemTotal, "Sửa", "Xóa", i);
                        total += itemTotal;
                    }
                }

                label_Total.Text = total.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void button_AddOrder_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                return;
            }

            ShowOrderConfirmationDialog();
        }

        private void ShowOrderConfirmationDialog()
        {
            if (orderItems.Count == 0)
            {
                return;
            }

            OrderConfirmationForm confirmForm = new OrderConfirmationForm(orderItems, allFoods);
            if (confirmForm.ShowDialog() == DialogResult.OK)
            {
                // Mark order as confirmed and update table status to "Sử dụng"
                isOrderConfirmed = true;
                tableStateManager.SetOrderConfirmed(selectedTableId, true);
                UpdateTableStatus(selectedTableId, "Sử dụng");
            }
        }

        private void dataGridView_Order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == colEdit.Index)
                {
                    if (e.RowIndex < orderItems.Count)
                    {
                        EditOrderItem(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == colDelete.Index)
                {
                    if (e.RowIndex < orderItems.Count)
                    {
                        Food food = allFoods.Find(f => f.ID == orderItems[e.RowIndex].FoodID);
                        string foodName = food?.Name ?? "Món ăn";

                        DialogResult result = MessageBox.Show(
                            $"Bạn có chắc chắn muốn xóa '{foodName}' khỏi đơn hàng?",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            orderItems.RemoveAt(e.RowIndex);
                            RefreshOrderList();
                        }
                    }
                }
            }
        }

        private void EditOrderItem(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= orderItems.Count)
                return;

            BillInfo item = orderItems[rowIndex];
            Food food = allFoods.Find(f => f.ID == item.FoodID);

            if (food != null)
            {
                EditQuantityForm editForm = new EditQuantityForm(food.Name, item.Count);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    int newQuantity = editForm.Quantity;
                    if (newQuantity <= 0)
                    {
                        orderItems.RemoveAt(rowIndex);
                    }
                    else
                    {
                        item.Count = newQuantity;
                    }
                    RefreshOrderList();
                }
            }
        }

        private void button_ThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!isOrderConfirmed || orderItems.Count == 0)
            {
                MessageBox.Show("Vui lòng đặt món trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Show customer selection dialog with phone number
            CustomerSelectionForm customerForm = new CustomerSelectionForm();
            if (customerForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                // Calculate totals
                int subtotal = 0;
                foreach (BillInfo item in orderItems)
                {
                    Food food = allFoods.Find(f => f.ID == item.FoodID);
                    if (food != null)
                    {
                        subtotal += (int)(food.Price * item.Count);
                    }
                }

                // Calculate discount (5% for members)
                int discountAmount = 0;
                if (customerForm.DiscountPercentage > 0)
                {
                    discountAmount = (int)(subtotal * customerForm.DiscountPercentage / 100);
                }
                customerForm.AppliedDiscount = discountAmount;

                int finalTotal = subtotal - discountAmount;

                // Create bill
                Bill bill = new Bill();
                bill.TableID = selectedTableId;
                bill.DateCheckIn = DateTime.Now;
                bill.DateCheckOut = null;
                bill.Status = 0;
                bill.Discount = discountAmount;
                bill.CustomerID = customerForm.SelectedCustomerID > 0 ? customerForm.SelectedCustomerID : (int?)null;

                BillDAL.AddBill(bill);

                // Get the last inserted bill
                List<Bill> allBills = BillDAL.GetAllBills();
                Bill insertedBill = allBills[allBills.Count - 1];

                // Add bill items
                foreach (BillInfo item in orderItems)
                {
                    item.BillID = insertedBill.ID;
                    BillInfoDAL.AddBillInfo(item);
                }

                // Show success message with discount information
                string successMessage = "Thanh toán thành công!\n\n";
                successMessage += $"Tổng tiền: {subtotal:N0} VNĐ\n";

                if (discountAmount > 0)
                {
                    successMessage += $"Giảm giá (5% - Thành viên): -{discountAmount:N0} VNĐ\n";
                    successMessage += $"───────────────────────\n";
                    successMessage += $"Thành tiền: {finalTotal:N0} VNĐ";
                }
                else
                {
                    successMessage += $"Thành tiền: {finalTotal:N0} VNĐ";
                }

                MessageBox.Show(successMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset table status back to Trống
                UpdateTableStatus(selectedTableId, "Trống");

                // Clear the table's orders from state manager
                tableStateManager.ClearTableOrders(selectedTableId);

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_NewOrder_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            selectedTableId = -1;
            orderItems.Clear();
            isOrderConfirmed = false;
            label_SelectedTable.Text = "Không";
            label_Total.Text = "0 VNĐ";
            dataGridView_Order.Rows.Clear();
        }

        private void UpdateTableStatus(int tableId, string status)
        {
            try
            {
                // Update database
                List<TableFood> tables = TableFoodDAL.GetAllTables();
                TableFood table = tables.Find(t => t.ID == tableId);
                if (table != null)
                {
                    table.Status = status;
                    TableFoodDAL.UpdateTable(tableId, table);
                }

                // Update UI
                if (tableButtons.ContainsKey(tableId))
                {
                    Button btn = tableButtons[tableId];
                    btn.Text = $"Bàn {tableId}\n{status}";

                    if (status == "Trống")
                    {
                        btn.BackColor = Color.LimeGreen;
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        btn.BackColor = Color.Red;
                        btn.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void button_History_Click(object sender, EventArgs e)
        {
            // Show order history
            OrderHistoryForm historyForm = new OrderHistoryForm();
            historyForm.ShowDialog();
        }

        private void button_PrintBill_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                return;
            }

            if (orderItems.Count == 0)
            {
                return;
            }

            // Print bill
            PrintBillForm printForm = new PrintBillForm(selectedTableId, orderItems, allFoods, label_Total.Text);
            printForm.ShowDialog();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            // Change button behavior to export file
            if (orderItems.Count == 0)
            {
                this.Close();
                return;
            }

            // Export file functionality
            ExportOrderToExcel();
        }

        private void ExportOrderToExcel()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveDialog.FileName = $"DonHang_Ban{selectedTableId}_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;

                    // Create CSV content
                    string content = "HÓA ĐƠN THANH TOÁN\n";
                    content += $"Bàn số,{selectedTableId}\n";
                    content += $"Ngày,{DateTime.Now:dd/MM/yyyy HH:mm}\n\n";
                    content += "Tên Món,Số Lượng,Đơn Giá,Thành Tiền\n";

                    int total = 0;
                    foreach (BillInfo item in orderItems)
                    {
                        Food food = allFoods.FirstOrDefault(f => f.ID == item.FoodID);
                        if (food != null)
                        {
                            int itemTotal = (int)(food.Price * item.Count);
                            content += $"{food.Name},{item.Count},{(int)food.Price},{itemTotal}\n";
                            total += itemTotal;
                        }
                    }

                    content += $"\nTỔNG CỘNG,,{total}\n";

                    // Save to file with UTF-8 encoding
                    System.IO.File.WriteAllText(filePath, content, System.Text.Encoding.UTF8);
                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Do NOT close the form - keep the interface displayed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
