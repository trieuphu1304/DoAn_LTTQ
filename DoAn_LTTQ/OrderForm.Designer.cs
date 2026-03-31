namespace DoAn_LTTQ
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.label_Tables = new System.Windows.Forms.Label();
            this.flowLayoutPanel_Tables = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_Middle = new System.Windows.Forms.Panel();
            this.panel_FoodsGrid = new System.Windows.Forms.Panel();
            this.comboBox_Category = new System.Windows.Forms.ComboBox();
            this.label_Category = new System.Windows.Forms.Label();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.dataGridView_Order = new System.Windows.Forms.DataGridView();
            this.colFoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_Order = new System.Windows.Forms.Label();
            this.button_AddOrder = new System.Windows.Forms.Button();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.label_SelectedTable = new System.Windows.Forms.Label();
            this.label_Total = new System.Windows.Forms.Label();
            this.button_ThanhToan = new System.Windows.Forms.Button();
            this.button_NewOrder = new System.Windows.Forms.Button();
            this.button_History = new System.Windows.Forms.Button();
            this.button_PrintBill = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();

            this.tableLayoutPanel_Main.SuspendLayout();
            this.panel_Left.SuspendLayout();
            this.panel_Middle.SuspendLayout();
            this.panel_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Order)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            this.SuspendLayout();

            // tableLayoutPanel_Main
            this.tableLayoutPanel_Main.ColumnCount = 3;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel_Main.Controls.Add(this.panel_Left, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.panel_Middle, 1, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.panel_Right, 2, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.panel_Bottom, 0, 1);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.RowCount = 2;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel_Main.SetColumnSpan(this.panel_Bottom, 3);
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1400, 650);
            this.tableLayoutPanel_Main.TabIndex = 0;

            // panel_Left
            this.panel_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Left.Controls.Add(this.flowLayoutPanel_Tables);
            this.panel_Left.Controls.Add(this.label_Tables);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Left.Location = new System.Drawing.Point(3, 3);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(274, 548);
            this.panel_Left.TabIndex = 0;

            // label_Tables
            this.label_Tables.AutoSize = true;
            this.label_Tables.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label_Tables.Location = new System.Drawing.Point(10, 10);
            this.label_Tables.Name = "label_Tables";
            this.label_Tables.Size = new System.Drawing.Size(85, 18);
            this.label_Tables.TabIndex = 0;
            this.label_Tables.Text = "Chọn Bàn";

            // flowLayoutPanel_Tables
            this.flowLayoutPanel_Tables.AutoScroll = true;
            this.flowLayoutPanel_Tables.Location = new System.Drawing.Point(10, 35);
            this.flowLayoutPanel_Tables.Name = "flowLayoutPanel_Tables";
            this.flowLayoutPanel_Tables.Size = new System.Drawing.Size(254, 503);
            this.flowLayoutPanel_Tables.TabIndex = 1;

            // panel_Middle
            this.panel_Middle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Middle.Controls.Add(this.panel_FoodsGrid);
            this.panel_Middle.Controls.Add(this.comboBox_Category);
            this.panel_Middle.Controls.Add(this.label_Category);
            this.panel_Middle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Middle.Location = new System.Drawing.Point(283, 3);
            this.panel_Middle.Name = "panel_Middle";
            this.panel_Middle.Size = new System.Drawing.Size(694, 548);
            this.panel_Middle.TabIndex = 1;

            // label_Category
            this.label_Category.AutoSize = true;
            this.label_Category.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label_Category.Location = new System.Drawing.Point(10, 10);
            this.label_Category.Name = "label_Category";
            this.label_Category.Size = new System.Drawing.Size(240, 18);
            this.label_Category.TabIndex = 0;
            this.label_Category.Text = "Chọn Món Ăn - Danh Mục";

            // comboBox_Category
            this.comboBox_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Category.Font = new System.Drawing.Font("Arial", 10F);
            this.comboBox_Category.FormattingEnabled = true;
            this.comboBox_Category.Location = new System.Drawing.Point(10, 35);
            this.comboBox_Category.Name = "comboBox_Category";
            this.comboBox_Category.Size = new System.Drawing.Size(674, 24);
            this.comboBox_Category.TabIndex = 1;
            this.comboBox_Category.SelectedIndexChanged += new System.EventHandler(this.comboBox_Category_SelectedIndexChanged);

            // panel_FoodsGrid
            this.panel_FoodsGrid.AutoScroll = true;
            this.panel_FoodsGrid.Location = new System.Drawing.Point(10, 65);
            this.panel_FoodsGrid.Name = "panel_FoodsGrid";
            this.panel_FoodsGrid.Size = new System.Drawing.Size(674, 473);
            this.panel_FoodsGrid.TabIndex = 2;

            // panel_Right
            this.panel_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Right.Controls.Add(this.button_AddOrder);
            this.panel_Right.Controls.Add(this.dataGridView_Order);
            this.panel_Right.Controls.Add(this.label_Order);
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Right.Location = new System.Drawing.Point(983, 3);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(414, 548);
            this.panel_Right.TabIndex = 2;

            // label_Order
            this.label_Order.AutoSize = true;
            this.label_Order.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label_Order.Location = new System.Drawing.Point(10, 10);
            this.label_Order.Name = "label_Order";
            this.label_Order.Size = new System.Drawing.Size(80, 18);
            this.label_Order.TabIndex = 0;
            this.label_Order.Text = "Đơn Hàng";

            // button_AddOrder
            this.button_AddOrder.BackColor = System.Drawing.Color.LimeGreen;
            this.button_AddOrder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button_AddOrder.ForeColor = System.Drawing.Color.Black;
            this.button_AddOrder.Location = new System.Drawing.Point(280, 10);
            this.button_AddOrder.Name = "button_AddOrder";
            this.button_AddOrder.Size = new System.Drawing.Size(110, 25);
            this.button_AddOrder.TabIndex = 8;
            this.button_AddOrder.Text = "+ Đặt Món";
            this.button_AddOrder.UseVisualStyleBackColor = false;
            this.button_AddOrder.Click += new System.EventHandler(this.button_AddOrder_Click);

            // dataGridView_Order
            this.dataGridView_Order.AllowUserToAddRows = false;
            this.dataGridView_Order.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFoodName,
            this.colQuantity,
            this.colPrice,
            this.colTotal,
            this.colEdit,
            this.colDelete,
            this.colIndex});
            this.dataGridView_Order.Location = new System.Drawing.Point(10, 40);
            this.dataGridView_Order.Name = "dataGridView_Order";
            this.dataGridView_Order.RowHeadersVisible = false;
            this.dataGridView_Order.Size = new System.Drawing.Size(394, 498);
            this.dataGridView_Order.TabIndex = 1;
            this.dataGridView_Order.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Order_CellClick);

            // colFoodName
            this.colFoodName.DataPropertyName = "FoodName";
            this.colFoodName.HeaderText = "Tên món";
            this.colFoodName.Name = "colFoodName";
            this.colFoodName.Width = 80;

            // colQuantity
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Số";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 40;

            // colPrice
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "Đơn giá";
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 60;

            // colTotal
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Thành";
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 50;

            // colEdit
            this.colEdit.DataPropertyName = "Edit";
            this.colEdit.HeaderText = "Sửa";
            this.colEdit.Name = "colEdit";
            this.colEdit.Text = "Sửa";
            this.colEdit.UseColumnTextForButtonValue = true;
            this.colEdit.Width = 35;

            // colDelete
            this.colDelete.DataPropertyName = "Delete";
            this.colDelete.HeaderText = "Xóa";
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "Xóa";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 35;

            // colIndex
            this.colIndex.DataPropertyName = "Index";
            this.colIndex.HeaderText = "Index";
            this.colIndex.Name = "colIndex";
            this.colIndex.Visible = false;

            // panel_Bottom
            this.panel_Bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Bottom.Controls.Add(this.button_Exit);
            this.panel_Bottom.Controls.Add(this.button_PrintBill);
            this.panel_Bottom.Controls.Add(this.button_History);
            this.panel_Bottom.Controls.Add(this.button_NewOrder);
            this.panel_Bottom.Controls.Add(this.button_ThanhToan);
            this.panel_Bottom.Controls.Add(this.label_Total);
            this.panel_Bottom.Controls.Add(this.label_SelectedTable);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Bottom.Location = new System.Drawing.Point(3, 557);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(1394, 90);
            this.panel_Bottom.TabIndex = 3;

            // label_SelectedTable
            this.label_SelectedTable.AutoSize = true;
            this.label_SelectedTable.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.label_SelectedTable.Location = new System.Drawing.Point(10, 10);
            this.label_SelectedTable.Name = "label_SelectedTable";
            this.label_SelectedTable.Size = new System.Drawing.Size(50, 17);
            this.label_SelectedTable.TabIndex = 0;
            this.label_SelectedTable.Text = "Không";

            // label_Total
            this.label_Total.AutoSize = true;
            this.label_Total.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label_Total.Location = new System.Drawing.Point(10, 40);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(90, 22);
            this.label_Total.TabIndex = 2;
            this.label_Total.Text = "0 VNĐ";

            // button_ThanhToan
            this.button_ThanhToan.BackColor = System.Drawing.Color.Green;
            this.button_ThanhToan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button_ThanhToan.ForeColor = System.Drawing.Color.White;
            this.button_ThanhToan.Location = new System.Drawing.Point(700, 20);
            this.button_ThanhToan.Name = "button_ThanhToan";
            this.button_ThanhToan.Size = new System.Drawing.Size(120, 50);
            this.button_ThanhToan.TabIndex = 3;
            this.button_ThanhToan.Text = "Thanh Toán";
            this.button_ThanhToan.UseVisualStyleBackColor = false;
            this.button_ThanhToan.Click += new System.EventHandler(this.button_ThanhToan_Click);

            // button_NewOrder
            this.button_NewOrder.BackColor = System.Drawing.Color.Orange;
            this.button_NewOrder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button_NewOrder.ForeColor = System.Drawing.Color.White;
            this.button_NewOrder.Location = new System.Drawing.Point(835, 20);
            this.button_NewOrder.Name = "button_NewOrder";
            this.button_NewOrder.Size = new System.Drawing.Size(120, 50);
            this.button_NewOrder.TabIndex = 4;
            this.button_NewOrder.Text = "Đơn Mới";
            this.button_NewOrder.UseVisualStyleBackColor = false;
            this.button_NewOrder.Click += new System.EventHandler(this.button_NewOrder_Click);

            // button_History
            this.button_History.BackColor = System.Drawing.Color.Blue;
            this.button_History.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button_History.ForeColor = System.Drawing.Color.White;
            this.button_History.Location = new System.Drawing.Point(970, 20);
            this.button_History.Name = "button_History";
            this.button_History.Size = new System.Drawing.Size(120, 50);
            this.button_History.TabIndex = 5;
            this.button_History.Text = "Lịch Sử";
            this.button_History.UseVisualStyleBackColor = false;
            this.button_History.Click += new System.EventHandler(this.button_History_Click);

            // button_PrintBill
            this.button_PrintBill.BackColor = System.Drawing.Color.Purple;
            this.button_PrintBill.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button_PrintBill.ForeColor = System.Drawing.Color.White;
            this.button_PrintBill.Location = new System.Drawing.Point(1105, 20);
            this.button_PrintBill.Name = "button_PrintBill";
            this.button_PrintBill.Size = new System.Drawing.Size(120, 50);
            this.button_PrintBill.TabIndex = 6;
            this.button_PrintBill.Text = "In Hóa Đơn";
            this.button_PrintBill.UseVisualStyleBackColor = false;
            this.button_PrintBill.Click += new System.EventHandler(this.button_PrintBill_Click);

            // button_Exit
            this.button_Exit.BackColor = System.Drawing.Color.Maroon;
            this.button_Exit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button_Exit.ForeColor = System.Drawing.Color.White;
            this.button_Exit.Location = new System.Drawing.Point(1240, 20);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(120, 50);
            this.button_Exit.TabIndex = 7;
            this.button_Exit.Text = "Xuất File";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);

            // OrderForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 650);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Name = "OrderForm";
            this.Text = "Chọn Bàn - Đặt Món";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.panel_Left.ResumeLayout(false);
            this.panel_Left.PerformLayout();
            this.panel_Middle.ResumeLayout(false);
            this.panel_Middle.PerformLayout();
            this.panel_Right.ResumeLayout(false);
            this.panel_Right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Order)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Bottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Label label_Tables;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Tables;
        private System.Windows.Forms.Panel panel_Middle;
        private System.Windows.Forms.Label label_Category;
        private System.Windows.Forms.ComboBox comboBox_Category;
        private System.Windows.Forms.Panel panel_FoodsGrid;
        private System.Windows.Forms.Panel panel_Right;
        private System.Windows.Forms.Label label_Order;
        private System.Windows.Forms.DataGridView dataGridView_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.Label label_SelectedTable;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.Button button_ThanhToan;
        private System.Windows.Forms.Button button_NewOrder;
        private System.Windows.Forms.Button button_History;
        private System.Windows.Forms.Button button_PrintBill;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_AddOrder;
    }
}
