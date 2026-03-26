using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_LTTQ.Models;
using DoAn_LTTQ.Services;

namespace DoAn_LTTQ
{
    public partial class OrderForm : Form
    {
        private int selectedTableID = -1;
        private string selectedTableName = "";
        private DataTable orderDataTable;
        private int currentBillID = -1;

        public OrderForm()
        {
            InitializeComponent();
        }

        public OrderForm(int preSelectedTableID)
        {
            InitializeComponent();
            selectedTableID = preSelectedTableID;
        }

        // Method để set bàn được chọn từ TableSelectionForm
        public void SetSelectedTable(int tableID, string tableName, int billID = -1)
        {
            selectedTableID = tableID;
            selectedTableName = tableName;
            currentBillID = billID;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTables();
                LoadCategories();
                InitializeOrderTable();

                // If a table was pre-selected
                if (selectedTableID != -1)
                {
                    SelectTableDirectly(selectedTableID);

                    // If editing existing bill, load its items
                    if (currentBillID > 0)
                    {
                        LoadBillItems(currentBillID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message + "\n" + ex.StackTrace, "Lỗi");
            }
        }

        private void SelectTableDirectly(int tableID)
        {
            try
            {
                var tables = TableFoodService.GetAllTables();
                var selectedTable = tables.FirstOrDefault(t => t.ID == tableID);

                if (selectedTable != null)
                {
                    cmbTable.SelectedValue = tableID;
                    string tableName = selectedTable.Name;
                    lblTableSelected.Text = "Bàn đã chọn: " + tableName;
                    lblTableSelected.ForeColor = Color.Green;

                    // Tạo hóa đơn mới
                    currentBillID = BillService.CreateBill(tableID);
                    if (currentBillID == -1)
                    {
                        MessageBox.Show("Lỗi khi tạo đơn hàng!");
                        return;
                    }

                    // ✅ Tự động chuyển sang Tab "Chọn món ăn"
                    tabControl1.SelectedIndex = 1;
                    MessageBox.Show("Bàn " + tableName + " đã được chọn!\nHãy thêm các món ăn.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn bàn: " + ex.Message, "Lỗi");
            }
        }

        private void LoadTables()
        {
            try
            {
                List<TableFood> tables = TableFoodService.GetAllTables();
                if (tables == null || tables.Count == 0)
                {
                    MessageBox.Show("Không có bàn trong database!", "Thông báo");
                    return;
                }

                cmbTable.DisplayMember = "Name";
                cmbTable.ValueMember = "ID";
                cmbTable.DataSource = tables;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bàn: " + ex.Message + "\n" + ex.StackTrace, "Lỗi");
            }
        }

        private void LoadCategories()
        {
            try
            {
                List<FoodCategory> categories = FoodCategoryService.GetAllCategories();
                if (categories == null || categories.Count == 0)
                {
                    MessageBox.Show("Không có danh mục trong database!", "Thông báo");
                    return;
                }

                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "ID";
                cmbCategory.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message + "\n" + ex.StackTrace, "Lỗi");
            }
        }

        private void LoadFoodByCategory(int categoryID)
        {
            try
            {
                List<Food> foods = FoodService.GetFoodByCategory(categoryID);
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Tên", typeof(string));
                dt.Columns.Add("Giá", typeof(decimal));

                foreach (var food in foods)
                {
                    dt.Rows.Add(food.ID, food.Name, food.Price);
                }

                dgvFood.DataSource = dt;
                dgvFood.Columns["ID"].Visible = false;

                // Format cột giá để hiển thị đẹp
                dgvFood.Columns["Giá"].DefaultCellStyle.Format = "N0";
                dgvFood.Columns["Giá"].DefaultCellStyle.NullValue = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải món ăn: " + ex.Message + "\n" + ex.StackTrace, "Lỗi");
            }
        }

        private void InitializeOrderTable()
        {
            orderDataTable = new DataTable();
            orderDataTable.Columns.Add("FoodID", typeof(int));
            orderDataTable.Columns.Add("Món", typeof(string));
            orderDataTable.Columns.Add("Số lượng", typeof(int));
            orderDataTable.Columns.Add("Giá/cái", typeof(decimal));
            orderDataTable.Columns.Add("Thành tiền", typeof(decimal));

            dgvOrder.DataSource = orderDataTable;
            dgvOrder.Columns["FoodID"].Visible = false;
        }

        // Load items từ existing bill (khi edit)
        private void LoadBillItems(int billID)
        {
            try
            {
                var billDetails = BillHistoryService.GetBillDetailsById(billID);

                if (billDetails != null && billDetails.Rows.Count > 0)
                {
                    orderDataTable.Rows.Clear();

                    foreach (DataRow row in billDetails.Rows)
                    {
                        int foodID = Convert.ToInt32(row["FoodID"]);
                        string foodName = row["FoodName"].ToString();
                        int count = Convert.ToInt32(row["Count"]);
                        decimal price = Convert.ToDecimal(row["Price"]);
                        decimal subTotal = count * price;

                        orderDataTable.Rows.Add(foodID, foodName, count, price, subTotal);
                    }

                    CalculateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        // Auto-select table từ TableSelectionForm
        private void CalculateTotal()
        {
            try
            {
                decimal total = 0;
                foreach (DataRow row in orderDataTable.Rows)
                {
                    total += (decimal)row["Thành tiền"];
                }

                lblTotal.Text = total.ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tổng: " + ex.Message);
            }
        }

        private void btnSelectTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTable.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn một bàn!");
                    return;
                }

                selectedTableID = (int)cmbTable.SelectedValue;
                string tableName = cmbTable.Text;
                lblTableSelected.Text = "Bàn đã chọn: " + tableName;
                lblTableSelected.ForeColor = Color.Green;

                // Tạo hóa đơn mới
                currentBillID = BillService.CreateBill(selectedTableID);
                if (currentBillID == -1)
                {
                    MessageBox.Show("Lỗi khi tạo đơn hàng!");
                    return;
                }

                // ✅ Tự động chuyển sang Tab "Chọn món ăn"
                tabControl1.SelectedIndex = 1;
                MessageBox.Show("Bàn " + tableName + " đã được chọn!\nHãy thêm các món ăn.", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\n" + ex.StackTrace, "Lỗi");
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedIndex != -1 && cmbCategory.SelectedValue != null)
                {
                    int categoryID = (int)cmbCategory.SelectedValue;
                    LoadFoodByCategory(categoryID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn danh mục: " + ex.Message, "Lỗi");
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (selectedTableID == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            if (dgvFood.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một món ăn!");
                return;
            }

            try
            {
                int foodID = (int)dgvFood.SelectedRows[0].Cells["ID"].Value;
                string foodName = dgvFood.SelectedRows[0].Cells["Tên"].Value.ToString();
                decimal price = (decimal)dgvFood.SelectedRows[0].Cells["Giá"].Value;
                int quantity = (int)numQuantity.Value;

                // Kiểm tra nếu món đã có trong đơn
                DataRow[] existingRows = orderDataTable.Select("FoodID = " + foodID);
                if (existingRows.Length > 0)
                {
                    // Cập nhật số lượng
                    existingRows[0]["Số lượng"] = (int)existingRows[0]["Số lượng"] + quantity;
                    existingRows[0]["Thành tiền"] = (int)existingRows[0]["Số lượng"] * price;
                }
                else
                {
                    // Thêm hàng mới
                    orderDataTable.Rows.Add(foodID, foodName, quantity, price, quantity * price);
                }

                // Cập nhật hóa đơn vào database
                BillService.AddBillInfo(currentBillID, foodID, quantity);
                UpdateTotal();
                numQuantity.Value = 1;

                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\n" + ex.StackTrace, "Lỗi");
            }
        }

        private void btnRemoveFood_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
                return;
            }

            try
            {
                dgvOrder.SelectedRows[0].Cells["Món"].Value.ToString();
                orderDataTable.Rows.RemoveAt(dgvOrder.SelectedRows[0].Index);
                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void UpdateTotal()
        {
            try
            {
                decimal total = 0;
                foreach (DataRow row in orderDataTable.Rows)
                {
                    total += (decimal)row["Thành tiền"];
                }

                lblTotal.Text = total.ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tổng: " + ex.Message);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (orderDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một món ăn!", "Thông báo");
                return;
            }

            try
            {
                // ✅ Tự động chuyển sang Tab "Đặt hàng"
                tabControl1.SelectedIndex = 2;
                MessageBox.Show("Hãy kiểm tra lại đơn hàng trước khi lưu.", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedTableID == -1 || orderDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn và thêm món ăn!");
                return;
            }

            try
            {
                // Cập nhật trạng thái bàn thành "Sử dụng"
                TableFoodService.UpdateTableStatus(selectedTableID, "Sử dụng");

                // Đóng hóa đơn
                BillService.CloseBill(currentBillID);

                MessageBox.Show("Lưu đơn hàng thành công!\nBàn đã chuyển sang 'Đang sử dụng'");

                // Quay lại TableSelectionForm
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (selectedTableID == -1 || orderDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn và thêm món ăn!");
                return;
            }

            try
            {
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in: " + ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                float y = 20;
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font smallFont = new Font("Arial", 9);

                // Tiêu đề
                e.Graphics.DrawString("HÓA ĐƠN ĐẶT HÀNG", headerFont, Brushes.Black, 150, y);
                y += 30;

                // Thông tin bàn
                TableFood table = TableFoodService.GetTableByID(selectedTableID);
                e.Graphics.DrawString("Bàn: " + table.Name, normalFont, Brushes.Black, 20, y);
                y += 20;

                e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), normalFont, Brushes.Black, 20, y);
                y += 25;

                // Tiêu đề bảng
                e.Graphics.DrawString("Món ăn", normalFont, Brushes.Black, 20, y);
                e.Graphics.DrawString("SL", normalFont, Brushes.Black, 250, y);
                e.Graphics.DrawString("Giá", normalFont, Brushes.Black, 300, y);
                e.Graphics.DrawString("Thành tiền", normalFont, Brushes.Black, 380, y);
                y += 20;

                // Đường kẻ
                e.Graphics.DrawLine(Pens.Black, 20, y, 550, y);
                y += 10;

                // Chi tiết đơn hàng
                foreach (DataRow row in orderDataTable.Rows)
                {
                    e.Graphics.DrawString(row["Món"].ToString(), smallFont, Brushes.Black, 20, y);
                    e.Graphics.DrawString(row["Số lượng"].ToString(), smallFont, Brushes.Black, 260, y);
                    e.Graphics.DrawString(row["Giá/cái"].ToString(), smallFont, Brushes.Black, 300, y);
                    e.Graphics.DrawString(row["Thành tiền"].ToString(), smallFont, Brushes.Black, 380, y);
                    y += 20;
                }

                // Đường kẻ
                e.Graphics.DrawLine(Pens.Black, 20, y, 550, y);
                y += 15;

                // Tổng tiền
                e.Graphics.DrawString("Tổng tiền:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 300, y);
                e.Graphics.DrawString(lblTotal.Text, new Font("Arial", 11, FontStyle.Bold), Brushes.Red, 380, y);

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            selectedTableID = -1;
            currentBillID = -1;
            orderDataTable.Clear();
            lblTableSelected.Text = "Chưa chọn bàn";
            lblTableSelected.ForeColor = Color.Red;
            lblTotal.Text = "0 VND";
            cmbTable.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            dgvFood.DataSource = null;
        }
    }
}
