using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_LTTQ.Models;
using DoAn_LTTQ.Services;

namespace DoAn_LTTQ
{
    public partial class TableSelectionForm : Form
    {
        private List<TableFood> allTables;
        private FlowLayoutPanel flowPanel;
        private TabControl tabControl;
        private int selectedTableID = -1;
        private Dictionary<int, Panel> tableButtonCache = new Dictionary<int, Panel>();

        public int SelectedTableID
        {
            get { return selectedTableID; }
        }

        public TableSelectionForm()
        {
            InitializeComponent();
            InitializeCustomControls();
        }

        private void InitializeCustomControls()
        {
            this.Text = "Chọn Bàn - Quản Lý Nhà Hàng";
            this.Size = new System.Drawing.Size(1000, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Arial", 10);

            // Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            this.Controls.Add(mainPanel);

            // Header Label
            Label lblHeader = new Label();
            lblHeader.Text = "📋 Chọn Bàn Ăn";
            lblHeader.Font = new Font("Arial", 16, FontStyle.Bold);
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Height = 40;
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblHeader.BackColor = Color.FromArgb(0, 102, 204);
            lblHeader.ForeColor = Color.White;
            mainPanel.Controls.Add(lblHeader);

            // Tab Control
            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Arial", 11);
            tabControl.Margin = new Padding(0);
            tabControl.Padding = new Point(15, 8);

            TabPage tabAll = new TabPage("📌 Tất Cả");
            TabPage tabInUse = new TabPage("🔴 Sử Dụng");
            TabPage tabAvailable = new TabPage("🟢 Còn Trống");

            // Flow Layout Panel for table buttons
            flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.AutoScroll = true;
            flowPanel.Padding = new Padding(15);
            flowPanel.BackColor = Color.FromArgb(245, 245, 245);
            flowPanel.WrapContents = true;

            tabAll.Controls.Add(flowPanel);
            tabAll.BackColor = Color.WhiteSmoke;

            tabControl.Controls.Add(tabAll);
            tabControl.Controls.Add(tabInUse);
            tabControl.Controls.Add(tabAvailable);

            mainPanel.Controls.Add(tabControl);

            // Tab change handler
            tabControl.SelectedIndexChanged += (sender, e) =>
            {
                flowPanel.Controls.Clear();
                tableButtonCache.Clear();

                switch (tabControl.SelectedIndex)
                {
                    case 0: // Tất cả
                        if (allTables != null)
                            LoadTableButtons(allTables);
                        break;
                    case 1: // Sử dụng
                        if (allTables != null)
                        {
                            var inUse = allTables.Where(t => t.Status != "Trống").ToList();
                            if (inUse.Count == 0)
                                ShowEmptyMessage("Không có bàn nào đang sử dụng");
                            else
                                LoadTableButtons(inUse);
                        }
                        break;
                    case 2: // Còn trống
                        if (allTables != null)
                        {
                            var available = allTables.Where(t => t.Status == "Trống").ToList();
                            if (available.Count == 0)
                                ShowEmptyMessage("Không có bàn trống");
                            else
                                LoadTableButtons(available);
                        }
                        break;
                }
            };
        }

        private void ShowEmptyMessage(string message)
        {
            Label lblEmpty = new Label();
            lblEmpty.Text = message;
            lblEmpty.Font = new Font("Arial", 14);
            lblEmpty.ForeColor = Color.Gray;
            lblEmpty.Dock = DockStyle.Fill;
            lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
            flowPanel.Controls.Add(lblEmpty);
        }

        private void TableSelectionForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTables();
                if (allTables != null && allTables.Count > 0)
                {
                    LoadTableButtons(allTables);
                }
                else
                {
                    MessageBox.Show("Vui lòng chạy script SQL để thêm dữ liệu: Setup_TestData.sql", "Không có dữ liệu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải form: " + ex.Message + "\n" + ex.StackTrace, "Lỗi");
            }
        }

        private void LoadTables()
        {
            try
            {
                allTables = TableFoodService.GetAllTables();
                if (allTables == null)
                {
                    allTables = new List<TableFood>();
                }

                // Enrich table data with bill information
                foreach (var table in allTables)
                {
                    LoadTableBillInfo(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bàn: " + ex.Message, "Lỗi");
                allTables = new List<TableFood>();
            }
        }

        private void LoadTableBillInfo(TableFood table)
        {
            try
            {
                // Get current bill for this table (Status = 0 means active)
                string query = @"
                    SELECT 
                        b.ID,
                        SUM(bi.Count) AS DishCount,
                        COUNT(DISTINCT b.CustomerID) AS CustomerCount,
                        SUM(bi.Count * f.Price) AS Total
                    FROM Bill b
                    LEFT JOIN BillInfo bi ON b.ID = bi.BillID
                    LEFT JOIN Food f ON bi.FoodID = f.ID
                    WHERE b.TableID = @TableID AND b.Status = 0
                    GROUP BY b.ID";

                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@TableID", table.ID)
                };

                var dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    table.Status = "Sử dụng";
                    table.DishCount = dt.Rows[0]["DishCount"] != DBNull.Value ? 
                        Convert.ToInt32(dt.Rows[0]["DishCount"]) : 0;
                    table.CustomerCount = dt.Rows[0]["CustomerCount"] != DBNull.Value ? 
                        Convert.ToInt32(dt.Rows[0]["CustomerCount"]) : 0;
                    table.Total = dt.Rows[0]["Total"] != DBNull.Value ? 
                        Convert.ToDecimal(dt.Rows[0]["Total"]) : 0;
                }
                else
                {
                    table.Status = "Trống";
                    table.DishCount = 0;
                    table.CustomerCount = 0;
                    table.Total = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin bàn: " + ex.Message, "Lỗi");
            }
        }

        private void LoadTableButtons(List<TableFood> tables)
        {
            flowPanel.Controls.Clear();
            tableButtonCache.Clear();

            if (tables == null || tables.Count == 0)
            {
                ShowEmptyMessage("Không có bàn");
                return;
            }

            foreach (var table in tables)
            {
                var btn = CreateTableButton(table);
                flowPanel.Controls.Add(btn);
                tableButtonCache[table.ID] = btn;
            }
        }

        private Panel CreateTableButton(TableFood table)
        {
            Panel panel = new Panel();
            panel.Width = 240;
            panel.Height = 200;
            panel.Margin = new Padding(12);
            panel.Cursor = Cursors.Hand;
            panel.Tag = table.ID;

            // Determine colors based on table status
            Color bgColor;
            Color borderColor;
            Color textColor;
            string statusEmoji;

            if (table.Status == "Trống")
            {
                bgColor = Color.White;
                borderColor = Color.FromArgb(200, 200, 200);
                textColor = Color.Black;
                statusEmoji = "🟢";
            }
            else
            {
                bgColor = Color.FromArgb(255, 240, 245); // Light red for occupied
                borderColor = Color.FromArgb(255, 100, 100);
                textColor = Color.DarkRed;
                statusEmoji = "🔴";
            }

            panel.BackColor = bgColor;
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Paint border
            panel.Paint += (sender, e) =>
            {
                e.Graphics.DrawRectangle(
                    new Pen(borderColor, 3),
                    0, 0, panel.Width - 1, panel.Height - 1);
            };

            // Table number (Large)
            Label lblTableNum = new Label();
            lblTableNum.Text = table.Name.Replace("Bàn ", "");
            lblTableNum.Font = new Font("Arial", 36, FontStyle.Bold);
            lblTableNum.ForeColor = textColor;
            lblTableNum.AutoSize = false;
            lblTableNum.Location = new Point(15, 10);
            lblTableNum.Width = 60;
            lblTableNum.Height = 70;
            lblTableNum.TextAlign = ContentAlignment.TopLeft;
            panel.Controls.Add(lblTableNum);

            // Status indicator
            Label lblStatus = new Label();
            lblStatus.Text = statusEmoji;
            lblStatus.Font = new Font("Arial", 28);
            lblStatus.Location = new Point(180, 15);
            lblStatus.Width = 45;
            lblStatus.Height = 45;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblStatus);

            // Status text
            Label lblStatusText = new Label();
            lblStatusText.Text = table.Status == "Trống" ? "Còn trống" : "Đang sử dụng";
            lblStatusText.Font = new Font("Arial", 9, FontStyle.Bold);
            lblStatusText.ForeColor = table.Status == "Trống" ? Color.Green : Color.Red;
            lblStatusText.Location = new Point(15, 75);
            lblStatusText.Width = 210;
            lblStatusText.Height = 20;
            lblStatusText.TextAlign = ContentAlignment.TopLeft;
            panel.Controls.Add(lblStatusText);

            // Details (only if occupied)
            if (table.Status != "Trống")
            {
                // Dish count
                Label lblDishes = new Label();
                lblDishes.Text = $"📦 {table.DishCount} món • {table.CustomerCount} khách";
                lblDishes.Font = new Font("Arial", 9);
                lblDishes.ForeColor = Color.DarkGray;
                lblDishes.Location = new Point(15, 100);
                lblDishes.Width = 210;
                lblDishes.Height = 25;
                lblDishes.TextAlign = ContentAlignment.TopLeft;
                panel.Controls.Add(lblDishes);

                // Total amount
                Label lblTotal = new Label();
                lblTotal.Text = $"💰 {table.Total.ToString("N0")}đ";
                lblTotal.Font = new Font("Arial", 12, FontStyle.Bold);
                lblTotal.ForeColor = Color.FromArgb(0, 102, 204);
                lblTotal.Location = new Point(15, 130);
                lblTotal.Width = 210;
                lblTotal.Height = 50;
                lblTotal.TextAlign = ContentAlignment.TopLeft;
                panel.Controls.Add(lblTotal);
            }
            else
            {
                // Empty table message
                Label lblEmpty = new Label();
                lblEmpty.Text = "Sẵn sàng";
                lblEmpty.Font = new Font("Arial", 11, FontStyle.Italic);
                lblEmpty.ForeColor = Color.Green;
                lblEmpty.Location = new Point(15, 105);
                lblEmpty.Width = 210;
                lblEmpty.Height = 70;
                lblEmpty.TextAlign = ContentAlignment.TopCenter;
                panel.Controls.Add(lblEmpty);
            }

            // Click event to select table
            panel.Click += (sender, e) => SelectTable(table);
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Click += (sender, e) => SelectTable(table);
            }

            return panel;
        }

        private void SelectTable(TableFood table)
        {
            try
            {
                if (table.Status == "Trống")
                {
                    // Empty table - Open OrderForm for new order
                    selectedTableID = table.ID;

                    // Create & show OrderForm
                    OrderForm orderForm = new OrderForm();
                    orderForm.SetSelectedTable(table.ID, table.Name);

                    if (orderForm.ShowDialog() == DialogResult.OK)
                    {
                        // After order saved, refresh the table list
                        LoadTables();
                        LoadTableButtons(allTables);
                    }
                }
                else
                {
                    // Occupied table - Open OrderForm to edit/add items or checkout
                    var bill = GetActiveBillForTable(table.ID);
                    if (bill != null && bill.ID > 0)
                    {
                        // Open OrderForm for existing bill (edit mode)
                        OrderForm orderForm = new OrderForm();
                        orderForm.SetSelectedTable(table.ID, table.Name, bill.ID);

                        if (orderForm.ShowDialog() == DialogResult.OK)
                        {
                            // Refresh the table list
                            LoadTables();
                            LoadTableButtons(allTables);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn cho bàn này!", "Lỗi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private Bill GetActiveBillForTable(int tableID)
        {
            try
            {
                string query = @"
                    SELECT TOP 1 ID, TableID, Status, DateCheckIn, DateCheckOut
                    FROM Bill
                    WHERE TableID = @TableID AND Status = 0
                    ORDER BY DateCheckIn DESC";

                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@TableID", tableID)
                };

                var dt = DatabaseHelper.ExecuteQuery(query, parameters);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return new Bill
                    {
                        ID = Convert.ToInt32(dt.Rows[0]["ID"]),
                        TableID = Convert.ToInt32(dt.Rows[0]["TableID"]),
                        Status = Convert.ToInt32(dt.Rows[0]["Status"])
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy hóa đơn: " + ex.Message, "Lỗi");
            }

            return null;
        }
    }
}
