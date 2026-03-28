namespace DoAn_LTTQ
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRevenue;
        private System.Windows.Forms.TabPage tabPageMenu;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.TabPage tabPageAccount;

        // Revenue Tab Controls
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvInvoice;

        // Menu Tab Controls
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblDishName;
        private System.Windows.Forms.TextBox txtDishName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnAddDish;
        private System.Windows.Forms.Button btnEditDish;
        private System.Windows.Forms.Button btnDeleteDish;
        private System.Windows.Forms.DataGridView dgvDish;

        // Table Tab Controls
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnEditTable;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.DataGridView dgvTable;

        // Account Tab Controls
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.DataGridView dgvAccount;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRevenue = new System.Windows.Forms.TabPage();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.tabPageMenu = new System.Windows.Forms.TabPage();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblDishName = new System.Windows.Forms.Label();
            this.txtDishName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnAddDish = new System.Windows.Forms.Button();
            this.btnEditDish = new System.Windows.Forms.Button();
            this.btnDeleteDish = new System.Windows.Forms.Button();
            this.dgvDish = new System.Windows.Forms.DataGridView();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.lblTableName = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnEditTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.tabPageAccount = new System.Windows.Forms.TabPage();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.tabPageNhanvien = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelNVList = new System.Windows.Forms.TableLayoutPanel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelNVButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnNVAdd = new System.Windows.Forms.Button();
            this.btnNVEdit = new System.Windows.Forms.Button();
            this.btnNVDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanelNVInfo = new System.Windows.Forms.TableLayoutPanel();
            this.labelNVName = new System.Windows.Forms.Label();
            this.labelNVPhone = new System.Windows.Forms.Label();
            this.labelNVAvatar = new System.Windows.Forms.Label();
            this.labelNVSalary = new System.Windows.Forms.Label();
            this.labelNVPosition = new System.Windows.Forms.Label();
            this.txtNVName = new System.Windows.Forms.TextBox();
            this.txtNVPhone = new System.Windows.Forms.TextBox();
            this.txtNVSalary = new System.Windows.Forms.TextBox();
            this.txtNVPosition = new System.Windows.Forms.TextBox();
            this.toolStripNVAvatar = new System.Windows.Forms.ToolStrip();
            this.btnNVSelectAvatar = new System.Windows.Forms.ToolStripButton();
            this.lblNVAvatarDisplay = new System.Windows.Forms.ToolStripLabel();
            this.btnNVRefresh = new System.Windows.Forms.Button();
            this.tabPageCategory = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvFoodCategory = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.tabPageMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDish)).BeginInit();
            this.tabPageTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.tabPageAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.tabPageNhanvien.SuspendLayout();
            this.tableLayoutPanelNVList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.tableLayoutPanelNVButtons.SuspendLayout();
            this.tableLayoutPanelNVInfo.SuspendLayout();
            this.toolStripNVAvatar.SuspendLayout();
            this.tabPageCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageRevenue);
            this.tabControl1.Controls.Add(this.tabPageMenu);
            this.tabControl1.Controls.Add(this.tabPageCategory);
            this.tabControl1.Controls.Add(this.tabPageTable);
            this.tabControl1.Controls.Add(this.tabPageAccount);
            this.tabControl1.Controls.Add(this.tabPageNhanvien);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1282, 779);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageRevenue
            // 
            this.tabPageRevenue.Controls.Add(this.lblFromDate);
            this.tabPageRevenue.Controls.Add(this.dtpFromDate);
            this.tabPageRevenue.Controls.Add(this.lblToDate);
            this.tabPageRevenue.Controls.Add(this.dtpToDate);
            this.tabPageRevenue.Controls.Add(this.btnSearch);
            this.tabPageRevenue.Controls.Add(this.dgvInvoice);
            this.tabPageRevenue.Location = new System.Drawing.Point(4, 34);
            this.tabPageRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageRevenue.Name = "tabPageRevenue";
            this.tabPageRevenue.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageRevenue.Size = new System.Drawing.Size(1274, 741);
            this.tabPageRevenue.TabIndex = 0;
            this.tabPageRevenue.Text = "Doanh thu";
            this.tabPageRevenue.UseVisualStyleBackColor = true;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(12, 18);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(90, 25);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(114, 12);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(383, 30);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(526, 18);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(102, 25);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(642, 12);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(367, 30);
            this.dtpToDate.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1040, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 39);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Location = new System.Drawing.Point(12, 59);
            this.dgvInvoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.ReadOnly = true;
            this.dgvInvoice.RowHeadersWidth = 51;
            this.dgvInvoice.Size = new System.Drawing.Size(1248, 668);
            this.dgvInvoice.TabIndex = 5;
            this.dgvInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellContentClick);
            // 
            // tabPageMenu
            // 
            this.tabPageMenu.Controls.Add(this.lblCategory);
            this.tabPageMenu.Controls.Add(this.cbCategory);
            this.tabPageMenu.Controls.Add(this.lblDishName);
            this.tabPageMenu.Controls.Add(this.txtDishName);
            this.tabPageMenu.Controls.Add(this.lblPrice);
            this.tabPageMenu.Controls.Add(this.txtPrice);
            this.tabPageMenu.Controls.Add(this.lblImagePath);
            this.tabPageMenu.Controls.Add(this.txtImagePath);
            this.tabPageMenu.Controls.Add(this.btnBrowseImage);
            this.tabPageMenu.Controls.Add(this.btnAddDish);
            this.tabPageMenu.Controls.Add(this.btnEditDish);
            this.tabPageMenu.Controls.Add(this.btnDeleteDish);
            this.tabPageMenu.Controls.Add(this.dgvDish);
            this.tabPageMenu.Location = new System.Drawing.Point(4, 34);
            this.tabPageMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMenu.Size = new System.Drawing.Size(1274, 741);
            this.tabPageMenu.TabIndex = 1;
            this.tabPageMenu.Text = "Thực đơn";
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 18);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(107, 25);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Danh mục:";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(132, 15);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(208, 33);
            this.cbCategory.TabIndex = 1;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.CbCategory_SelectedIndexChanged);
            // 
            // lblDishName
            // 
            this.lblDishName.AutoSize = true;
            this.lblDishName.Location = new System.Drawing.Point(460, 19);
            this.lblDishName.Name = "lblDishName";
            this.lblDishName.Size = new System.Drawing.Size(123, 25);
            this.lblDishName.TabIndex = 2;
            this.lblDishName.Text = "Tên món ăn:";
            // 
            // txtDishName
            // 
            this.txtDishName.Location = new System.Drawing.Point(598, 14);
            this.txtDishName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDishName.Name = "txtDishName";
            this.txtDishName.Size = new System.Drawing.Size(211, 30);
            this.txtDishName.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 66);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(86, 25);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Giá bán:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(132, 58);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(208, 30);
            this.txtPrice.TabIndex = 5;
            // 
            // lblImagePath
            // 
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(460, 66);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(114, 25);
            this.lblImagePath.TabIndex = 6;
            this.lblImagePath.Text = "Đường ảnh:";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(598, 55);
            this.txtImagePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(211, 30);
            this.txtImagePath.TabIndex = 7;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(818, 51);
            this.btnBrowseImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(84, 40);
            this.btnBrowseImage.TabIndex = 8;
            this.btnBrowseImage.Text = "Chọn ảnh";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // btnAddDish
            // 
            this.btnAddDish.Location = new System.Drawing.Point(932, 41);
            this.btnAddDish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(81, 49);
            this.btnAddDish.TabIndex = 6;
            this.btnAddDish.Text = "Thêm";
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // btnEditDish
            // 
            this.btnEditDish.Location = new System.Drawing.Point(1018, 40);
            this.btnEditDish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditDish.Name = "btnEditDish";
            this.btnEditDish.Size = new System.Drawing.Size(86, 51);
            this.btnEditDish.TabIndex = 7;
            this.btnEditDish.Text = "Sửa";
            this.btnEditDish.UseVisualStyleBackColor = true;
            this.btnEditDish.Click += new System.EventHandler(this.btnEditDish_Click);
            // 
            // btnDeleteDish
            // 
            this.btnDeleteDish.Location = new System.Drawing.Point(1110, 40);
            this.btnDeleteDish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteDish.Name = "btnDeleteDish";
            this.btnDeleteDish.Size = new System.Drawing.Size(78, 52);
            this.btnDeleteDish.TabIndex = 8;
            this.btnDeleteDish.Text = "Xóa";
            this.btnDeleteDish.UseVisualStyleBackColor = true;
            this.btnDeleteDish.Click += new System.EventHandler(this.btnDeleteDish_Click);
            // 
            // dgvDish
            // 
            this.dgvDish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDish.Location = new System.Drawing.Point(12, 120);
            this.dgvDish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDish.Name = "dgvDish";
            this.dgvDish.RowHeadersWidth = 51;
            this.dgvDish.Size = new System.Drawing.Size(1248, 606);
            this.dgvDish.TabIndex = 9;
            this.dgvDish.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDish_CellClick);
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.lblTableName);
            this.tabPageTable.Controls.Add(this.txtTableName);
            this.tabPageTable.Controls.Add(this.lblCapacity);
            this.tabPageTable.Controls.Add(this.txtCapacity);
            this.tabPageTable.Controls.Add(this.btnAddTable);
            this.tabPageTable.Controls.Add(this.btnEditTable);
            this.tabPageTable.Controls.Add(this.btnDeleteTable);
            this.tabPageTable.Controls.Add(this.dgvTable);
            this.tabPageTable.Location = new System.Drawing.Point(4, 34);
            this.tabPageTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageTable.Size = new System.Drawing.Size(1274, 741);
            this.tabPageTable.TabIndex = 2;
            this.tabPageTable.Text = "Bàn ăn";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(12, 18);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(91, 25);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Tên bàn:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(129, 14);
            this.txtTableName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(235, 30);
            this.txtTableName.TabIndex = 1;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(396, 18);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(106, 25);
            this.lblCapacity.TabIndex = 2;
            this.lblCapacity.Text = "Trạng thái:";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(516, 14);
            this.txtCapacity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(120, 30);
            this.txtCapacity.TabIndex = 3;
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(723, 12);
            this.btnAddTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(78, 38);
            this.btnAddTable.TabIndex = 4;
            this.btnAddTable.Text = "Thêm";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnEditTable
            // 
            this.btnEditTable.Location = new System.Drawing.Point(813, 12);
            this.btnEditTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditTable.Name = "btnEditTable";
            this.btnEditTable.Size = new System.Drawing.Size(78, 38);
            this.btnEditTable.TabIndex = 5;
            this.btnEditTable.Text = "Sửa";
            this.btnEditTable.UseVisualStyleBackColor = true;
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(903, 12);
            this.btnDeleteTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(78, 40);
            this.btnDeleteTable.TabIndex = 6;
            this.btnDeleteTable.Text = "Xóa";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // dgvTable
            // 
            this.dgvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Location = new System.Drawing.Point(12, 59);
            this.dgvTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersWidth = 51;
            this.dgvTable.Size = new System.Drawing.Size(1248, 668);
            this.dgvTable.TabIndex = 7;
            this.dgvTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellClick);
            // 
            // tabPageAccount
            // 
            this.tabPageAccount.Controls.Add(this.lblUsername);
            this.tabPageAccount.Controls.Add(this.txtUsername);
            this.tabPageAccount.Controls.Add(this.lblPassword);
            this.tabPageAccount.Controls.Add(this.txtPassword);
            this.tabPageAccount.Controls.Add(this.lblRole);
            this.tabPageAccount.Controls.Add(this.cbRole);
            this.tabPageAccount.Controls.Add(this.btnAddAccount);
            this.tabPageAccount.Controls.Add(this.btnEditAccount);
            this.tabPageAccount.Controls.Add(this.btnDeleteAccount);
            this.tabPageAccount.Controls.Add(this.dgvAccount);
            this.tabPageAccount.Location = new System.Drawing.Point(4, 34);
            this.tabPageAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAccount.Name = "tabPageAccount";
            this.tabPageAccount.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAccount.Size = new System.Drawing.Size(1274, 741);
            this.tabPageAccount.TabIndex = 3;
            this.tabPageAccount.Text = "Tài khoản";
            this.tabPageAccount.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(39, 18);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(137, 25);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Tên tài khoản:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(194, 14);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(145, 30);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(411, 18);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(99, 25);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(522, 12);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(145, 30);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(39, 60);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(91, 25);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Chức vụ:";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(194, 58);
            this.cbRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(145, 33);
            this.cbRole.TabIndex = 5;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(415, 60);
            this.btnAddAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(78, 40);
            this.btnAddAccount.TabIndex = 6;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(500, 60);
            this.btnEditAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(78, 40);
            this.btnEditAccount.TabIndex = 7;
            this.btnEditAccount.Text = "Sửa";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(584, 60);
            this.btnDeleteAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(86, 40);
            this.btnDeleteAccount.TabIndex = 8;
            this.btnDeleteAccount.Text = "Xóa";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // dgvAccount
            // 
            this.dgvAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Location = new System.Drawing.Point(12, 125);
            this.dgvAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.RowHeadersWidth = 51;
            this.dgvAccount.Size = new System.Drawing.Size(1248, 601);
            this.dgvAccount.TabIndex = 9;
            this.dgvAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccount_CellClick);
            // 
            // tabPageNhanvien
            // 
            this.tabPageNhanvien.Controls.Add(this.tableLayoutPanelNVList);
            this.tabPageNhanvien.Controls.Add(this.tableLayoutPanelNVButtons);
            this.tabPageNhanvien.Controls.Add(this.tableLayoutPanelNVInfo);
            this.tabPageNhanvien.Location = new System.Drawing.Point(4, 34);
            this.tabPageNhanvien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageNhanvien.Name = "tabPageNhanvien";
            this.tabPageNhanvien.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageNhanvien.Size = new System.Drawing.Size(1274, 741);
            this.tabPageNhanvien.TabIndex = 4;
            this.tabPageNhanvien.Text = "Nhân Viên";
            this.tabPageNhanvien.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelNVList
            // 
            this.tableLayoutPanelNVList.ColumnCount = 1;
            this.tableLayoutPanelNVList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelNVList.Controls.Add(this.dgvNhanVien, 0, 0);
            this.tableLayoutPanelNVList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelNVList.Location = new System.Drawing.Point(3, 209);
            this.tableLayoutPanelNVList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanelNVList.Name = "tableLayoutPanelNVList";
            this.tableLayoutPanelNVList.RowCount = 1;
            this.tableLayoutPanelNVList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelNVList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 528F));
            this.tableLayoutPanelNVList.Size = new System.Drawing.Size(1268, 528);
            this.tableLayoutPanelNVList.TabIndex = 3;
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(3, 4);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 62;
            this.dgvNhanVien.Size = new System.Drawing.Size(1262, 520);
            this.dgvNhanVien.TabIndex = 1;
            // 
            // tableLayoutPanelNVButtons
            // 
            this.tableLayoutPanelNVButtons.ColumnCount = 7;
            this.tableLayoutPanelNVButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelNVButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelNVButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelNVButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelNVButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelNVButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelNVButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanelNVButtons.Controls.Add(this.btnNVAdd, 1, 0);
            this.tableLayoutPanelNVButtons.Controls.Add(this.btnNVEdit, 2, 0);
            this.tableLayoutPanelNVButtons.Controls.Add(this.btnNVDelete, 3, 0);
            this.tableLayoutPanelNVButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelNVButtons.Location = new System.Drawing.Point(3, 160);
            this.tableLayoutPanelNVButtons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanelNVButtons.Name = "tableLayoutPanelNVButtons";
            this.tableLayoutPanelNVButtons.RowCount = 1;
            this.tableLayoutPanelNVButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelNVButtons.Size = new System.Drawing.Size(1268, 49);
            this.tableLayoutPanelNVButtons.TabIndex = 2;
            // 
            // btnNVAdd
            // 
            this.btnNVAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNVAdd.Location = new System.Drawing.Point(256, 4);
            this.btnNVAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNVAdd.Name = "btnNVAdd";
            this.btnNVAdd.Size = new System.Drawing.Size(184, 41);
            this.btnNVAdd.TabIndex = 0;
            this.btnNVAdd.Text = "Thêm";
            this.btnNVAdd.UseVisualStyleBackColor = true;
            // 
            // btnNVEdit
            // 
            this.btnNVEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNVEdit.Location = new System.Drawing.Point(446, 4);
            this.btnNVEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNVEdit.Name = "btnNVEdit";
            this.btnNVEdit.Size = new System.Drawing.Size(184, 41);
            this.btnNVEdit.TabIndex = 1;
            this.btnNVEdit.Text = "Sửa";
            this.btnNVEdit.UseVisualStyleBackColor = true;
            // 
            // btnNVDelete
            // 
            this.btnNVDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNVDelete.Location = new System.Drawing.Point(636, 4);
            this.btnNVDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNVDelete.Name = "btnNVDelete";
            this.btnNVDelete.Size = new System.Drawing.Size(184, 41);
            this.btnNVDelete.TabIndex = 2;
            this.btnNVDelete.Text = "Xóa";
            this.btnNVDelete.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelNVInfo
            // 
            this.tableLayoutPanelNVInfo.ColumnCount = 4;
            this.tableLayoutPanelNVInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelNVInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelNVInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelNVInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelNVInfo.Controls.Add(this.labelNVName, 0, 0);
            this.tableLayoutPanelNVInfo.Controls.Add(this.labelNVPhone, 0, 1);
            this.tableLayoutPanelNVInfo.Controls.Add(this.labelNVAvatar, 0, 2);
            this.tableLayoutPanelNVInfo.Controls.Add(this.labelNVSalary, 2, 0);
            this.tableLayoutPanelNVInfo.Controls.Add(this.labelNVPosition, 2, 1);
            this.tableLayoutPanelNVInfo.Controls.Add(this.txtNVName, 1, 0);
            this.tableLayoutPanelNVInfo.Controls.Add(this.txtNVPhone, 1, 1);
            this.tableLayoutPanelNVInfo.Controls.Add(this.txtNVSalary, 3, 0);
            this.tableLayoutPanelNVInfo.Controls.Add(this.txtNVPosition, 3, 1);
            this.tableLayoutPanelNVInfo.Controls.Add(this.toolStripNVAvatar, 1, 2);
            this.tableLayoutPanelNVInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelNVInfo.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanelNVInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanelNVInfo.Name = "tableLayoutPanelNVInfo";
            this.tableLayoutPanelNVInfo.RowCount = 3;
            this.tableLayoutPanelNVInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelNVInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelNVInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelNVInfo.Size = new System.Drawing.Size(1268, 156);
            this.tableLayoutPanelNVInfo.TabIndex = 1;
            // 
            // labelNVName
            // 
            this.labelNVName.AutoSize = true;
            this.labelNVName.Location = new System.Drawing.Point(3, 0);
            this.labelNVName.Name = "labelNVName";
            this.labelNVName.Size = new System.Drawing.Size(137, 25);
            this.labelNVName.TabIndex = 0;
            this.labelNVName.Text = "Tên nhân viên";
            // 
            // labelNVPhone
            // 
            this.labelNVPhone.AutoSize = true;
            this.labelNVPhone.Location = new System.Drawing.Point(3, 52);
            this.labelNVPhone.Name = "labelNVPhone";
            this.labelNVPhone.Size = new System.Drawing.Size(126, 25);
            this.labelNVPhone.TabIndex = 1;
            this.labelNVPhone.Text = "Số điện thoại";
            // 
            // labelNVAvatar
            // 
            this.labelNVAvatar.AutoSize = true;
            this.labelNVAvatar.Location = new System.Drawing.Point(3, 104);
            this.labelNVAvatar.Name = "labelNVAvatar";
            this.labelNVAvatar.Size = new System.Drawing.Size(121, 25);
            this.labelNVAvatar.TabIndex = 2;
            this.labelNVAvatar.Text = "Ảnh đại diện";
            // 
            // labelNVSalary
            // 
            this.labelNVSalary.AutoSize = true;
            this.labelNVSalary.Location = new System.Drawing.Point(636, 0);
            this.labelNVSalary.Name = "labelNVSalary";
            this.labelNVSalary.Size = new System.Drawing.Size(67, 25);
            this.labelNVSalary.TabIndex = 3;
            this.labelNVSalary.Text = "Lương";
            // 
            // labelNVPosition
            // 
            this.labelNVPosition.AutoSize = true;
            this.labelNVPosition.Location = new System.Drawing.Point(636, 52);
            this.labelNVPosition.Name = "labelNVPosition";
            this.labelNVPosition.Size = new System.Drawing.Size(50, 25);
            this.labelNVPosition.TabIndex = 4;
            this.labelNVPosition.Text = "Vị trí";
            // 
            // txtNVName
            // 
            this.txtNVName.Location = new System.Drawing.Point(193, 4);
            this.txtNVName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNVName.Name = "txtNVName";
            this.txtNVName.Size = new System.Drawing.Size(302, 30);
            this.txtNVName.TabIndex = 5;
            // 
            // txtNVPhone
            // 
            this.txtNVPhone.Location = new System.Drawing.Point(193, 56);
            this.txtNVPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNVPhone.Name = "txtNVPhone";
            this.txtNVPhone.Size = new System.Drawing.Size(302, 30);
            this.txtNVPhone.TabIndex = 6;
            // 
            // txtNVSalary
            // 
            this.txtNVSalary.Location = new System.Drawing.Point(826, 4);
            this.txtNVSalary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNVSalary.Name = "txtNVSalary";
            this.txtNVSalary.Size = new System.Drawing.Size(304, 30);
            this.txtNVSalary.TabIndex = 7;
            // 
            // txtNVPosition
            // 
            this.txtNVPosition.Location = new System.Drawing.Point(826, 56);
            this.txtNVPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNVPosition.Name = "txtNVPosition";
            this.txtNVPosition.Size = new System.Drawing.Size(304, 30);
            this.txtNVPosition.TabIndex = 8;
            // 
            // toolStripNVAvatar
            // 
            this.toolStripNVAvatar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripNVAvatar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNVSelectAvatar,
            this.lblNVAvatarDisplay});
            this.toolStripNVAvatar.Location = new System.Drawing.Point(190, 104);
            this.toolStripNVAvatar.Name = "toolStripNVAvatar";
            this.toolStripNVAvatar.Size = new System.Drawing.Size(443, 34);
            this.toolStripNVAvatar.TabIndex = 9;
            this.toolStripNVAvatar.Text = "toolStripNVAvatar";
            // 
            // btnNVSelectAvatar
            // 
            this.btnNVSelectAvatar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNVSelectAvatar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNVSelectAvatar.Name = "btnNVSelectAvatar";
            this.btnNVSelectAvatar.Size = new System.Drawing.Size(92, 29);
            this.btnNVSelectAvatar.Text = "Chọn ảnh";
            // 
            // lblNVAvatarDisplay
            // 
            this.lblNVAvatarDisplay.AutoSize = false;
            this.lblNVAvatarDisplay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNVAvatarDisplay.Name = "lblNVAvatarDisplay";
            this.lblNVAvatarDisplay.Size = new System.Drawing.Size(100, 29);
            this.lblNVAvatarDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNVRefresh
            // 
            this.btnNVRefresh.Location = new System.Drawing.Point(0, 0);
            this.btnNVRefresh.Name = "btnNVRefresh";
            this.btnNVRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnNVRefresh.TabIndex = 0;
            // 
            // tabPageCategory
            // 
            this.tabPageCategory.Controls.Add(this.dgvFoodCategory);
            this.tabPageCategory.Controls.Add(this.btnDelete);
            this.tabPageCategory.Controls.Add(this.btnUpdate);
            this.tabPageCategory.Controls.Add(this.btnAdd);
            this.tabPageCategory.Controls.Add(this.txtTenMon);
            this.tabPageCategory.Controls.Add(this.label1);
            this.tabPageCategory.Location = new System.Drawing.Point(4, 34);
            this.tabPageCategory.Name = "tabPageCategory";
            this.tabPageCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCategory.Size = new System.Drawing.Size(1274, 741);
            this.tabPageCategory.TabIndex = 5;
            this.tabPageCategory.Text = "Danh mục món ăn";
            this.tabPageCategory.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên danh mục";
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(220, 50);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(276, 30);
            this.txtTenMon.TabIndex = 2;
            this.txtTenMon.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(588, 41);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 49);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm ";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(762, 41);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 49);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(911, 41);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 49);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvFoodCategory
            // 
            this.dgvFoodCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFoodCategory.Location = new System.Drawing.Point(54, 155);
            this.dgvFoodCategory.Name = "dgvFoodCategory";
            this.dgvFoodCategory.RowHeadersWidth = 62;
            this.dgvFoodCategory.RowTemplate.Height = 28;
            this.dgvFoodCategory.Size = new System.Drawing.Size(1124, 488);
            this.dgvFoodCategory.TabIndex = 6;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 779);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Nhà Hàng";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRevenue.ResumeLayout(false);
            this.tabPageRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.tabPageMenu.ResumeLayout(false);
            this.tabPageMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDish)).EndInit();
            this.tabPageTable.ResumeLayout(false);
            this.tabPageTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.tabPageAccount.ResumeLayout(false);
            this.tabPageAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            this.tabPageNhanvien.ResumeLayout(false);
            this.tableLayoutPanelNVList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.tableLayoutPanelNVButtons.ResumeLayout(false);
            this.tableLayoutPanelNVInfo.ResumeLayout(false);
            this.tableLayoutPanelNVInfo.PerformLayout();
            this.toolStripNVAvatar.ResumeLayout(false);
            this.toolStripNVAvatar.PerformLayout();
            this.tabPageCategory.ResumeLayout(false);
            this.tabPageCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageNhanvien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelNVInfo;
        private System.Windows.Forms.Label labelNVName;
        private System.Windows.Forms.Label labelNVPhone;
        private System.Windows.Forms.Label labelNVPosition;
        private System.Windows.Forms.Label labelNVSalary;
        private System.Windows.Forms.Label labelNVAvatar;
        private System.Windows.Forms.TextBox txtNVName;
        private System.Windows.Forms.TextBox txtNVPhone;
        private System.Windows.Forms.TextBox txtNVPosition;
        private System.Windows.Forms.TextBox txtNVSalary;
        private System.Windows.Forms.ToolStrip toolStripNVAvatar;
        private System.Windows.Forms.ToolStripButton btnNVSelectAvatar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelNVButtons;
        private System.Windows.Forms.Button btnNVDelete;
        private System.Windows.Forms.Button btnNVRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelNVList;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Button btnNVEdit;
        private System.Windows.Forms.Button btnNVAdd;
        private System.Windows.Forms.ToolStripLabel lblNVAvatarDisplay;
        private System.Windows.Forms.TabPage tabPageCategory;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvFoodCategory;
    }
}