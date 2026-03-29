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

        private System.Windows.Forms.TabControl Thoát;
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
            this.Thoát = new System.Windows.Forms.TabControl();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.Thoát.SuspendLayout();
            this.tabPageRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.tabPageMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDish)).BeginInit();
            this.tabPageTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.tabPageAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Thoát
            // 
            this.Thoát.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Thoát.Controls.Add(this.tabPageRevenue);
            this.Thoát.Controls.Add(this.tabPageMenu);
            this.Thoát.Controls.Add(this.tabPageTable);
            this.Thoát.Controls.Add(this.tabPageAccount);
            this.Thoát.Controls.Add(this.tabPageNhanvien);
            this.Thoát.Controls.Add(this.tabPage1);
            this.Thoát.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thoát.Location = new System.Drawing.Point(0, 0);
            this.Thoát.Margin = new System.Windows.Forms.Padding(2);
            this.Thoát.Name = "Thoát";
            this.Thoát.SelectedIndex = 0;
            this.Thoát.Size = new System.Drawing.Size(855, 506);
            this.Thoát.TabIndex = 0;
            // 
            // tabPageRevenue
            // 
            this.tabPageRevenue.Controls.Add(this.lblFromDate);
            this.tabPageRevenue.Controls.Add(this.dtpFromDate);
            this.tabPageRevenue.Controls.Add(this.lblToDate);
            this.tabPageRevenue.Controls.Add(this.dtpToDate);
            this.tabPageRevenue.Controls.Add(this.btnSearch);
            this.tabPageRevenue.Controls.Add(this.dgvInvoice);
            this.tabPageRevenue.Location = new System.Drawing.Point(4, 25);
            this.tabPageRevenue.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageRevenue.Name = "tabPageRevenue";
            this.tabPageRevenue.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageRevenue.Size = new System.Drawing.Size(847, 477);
            this.tabPageRevenue.TabIndex = 0;
            this.tabPageRevenue.Text = "Doanh thu";
            this.tabPageRevenue.UseVisualStyleBackColor = true;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(8, 11);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(64, 17);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(76, 8);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(257, 23);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(351, 11);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(73, 17);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(428, 8);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(246, 23);
            this.dtpToDate.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(693, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 25);
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
            this.dgvInvoice.Location = new System.Drawing.Point(8, 38);
            this.dgvInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.ReadOnly = true;
            this.dgvInvoice.RowHeadersWidth = 51;
            this.dgvInvoice.Size = new System.Drawing.Size(832, 434);
            this.dgvInvoice.TabIndex = 5;
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
            this.tabPageMenu.Location = new System.Drawing.Point(4, 25);
            this.tabPageMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageMenu.Size = new System.Drawing.Size(847, 477);
            this.tabPageMenu.TabIndex = 1;
            this.tabPageMenu.Text = "Thực đơn";
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(8, 11);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(76, 17);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Danh mục:";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(88, 10);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(140, 24);
            this.cbCategory.TabIndex = 1;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.CbCategory_SelectedIndexChanged);
            // 
            // lblDishName
            // 
            this.lblDishName.AutoSize = true;
            this.lblDishName.Location = new System.Drawing.Point(307, 12);
            this.lblDishName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDishName.Name = "lblDishName";
            this.lblDishName.Size = new System.Drawing.Size(88, 17);
            this.lblDishName.TabIndex = 2;
            this.lblDishName.Text = "Tên món ăn:";
            // 
            // txtDishName
            // 
            this.txtDishName.Location = new System.Drawing.Point(399, 9);
            this.txtDishName.Margin = new System.Windows.Forms.Padding(2);
            this.txtDishName.Name = "txtDishName";
            this.txtDishName.Size = new System.Drawing.Size(142, 23);
            this.txtDishName.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(8, 43);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(62, 17);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Giá bán:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(88, 37);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(140, 23);
            this.txtPrice.TabIndex = 5;
            // 
            // lblImagePath
            // 
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(307, 43);
            this.lblImagePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(82, 17);
            this.lblImagePath.TabIndex = 6;
            this.lblImagePath.Text = "Đường ảnh:";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(399, 36);
            this.txtImagePath.Margin = new System.Windows.Forms.Padding(2);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(142, 23);
            this.txtImagePath.TabIndex = 7;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(545, 33);
            this.btnBrowseImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(56, 26);
            this.btnBrowseImage.TabIndex = 8;
            this.btnBrowseImage.Text = "Chọn ảnh";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // btnAddDish
            // 
            this.btnAddDish.Location = new System.Drawing.Point(621, 27);
            this.btnAddDish.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(54, 32);
            this.btnAddDish.TabIndex = 6;
            this.btnAddDish.Text = "Thêm";
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // btnEditDish
            // 
            this.btnEditDish.Location = new System.Drawing.Point(679, 26);
            this.btnEditDish.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditDish.Name = "btnEditDish";
            this.btnEditDish.Size = new System.Drawing.Size(57, 33);
            this.btnEditDish.TabIndex = 7;
            this.btnEditDish.Text = "Sửa";
            this.btnEditDish.UseVisualStyleBackColor = true;
            this.btnEditDish.Click += new System.EventHandler(this.btnEditDish_Click);
            // 
            // btnDeleteDish
            // 
            this.btnDeleteDish.Location = new System.Drawing.Point(740, 26);
            this.btnDeleteDish.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteDish.Name = "btnDeleteDish";
            this.btnDeleteDish.Size = new System.Drawing.Size(52, 34);
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
            this.dgvDish.Location = new System.Drawing.Point(8, 78);
            this.dgvDish.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDish.Name = "dgvDish";
            this.dgvDish.RowHeadersWidth = 51;
            this.dgvDish.Size = new System.Drawing.Size(832, 394);
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
            this.tabPageTable.Location = new System.Drawing.Point(4, 25);
            this.tabPageTable.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageTable.Size = new System.Drawing.Size(847, 477);
            this.tabPageTable.TabIndex = 2;
            this.tabPageTable.Text = "Bàn ăn";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(8, 11);
            this.lblTableName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(65, 17);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Tên bàn:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(86, 9);
            this.txtTableName.Margin = new System.Windows.Forms.Padding(2);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(158, 23);
            this.txtTableName.TabIndex = 1;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(264, 11);
            this.lblCapacity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(77, 17);
            this.lblCapacity.TabIndex = 2;
            this.lblCapacity.Text = "Trạng thái:";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(344, 9);
            this.txtCapacity.Margin = new System.Windows.Forms.Padding(2);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(81, 23);
            this.txtCapacity.TabIndex = 3;
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(482, 8);
            this.btnAddTable.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(52, 24);
            this.btnAddTable.TabIndex = 4;
            this.btnAddTable.Text = "Thêm";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnEditTable
            // 
            this.btnEditTable.Location = new System.Drawing.Point(542, 8);
            this.btnEditTable.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditTable.Name = "btnEditTable";
            this.btnEditTable.Size = new System.Drawing.Size(52, 24);
            this.btnEditTable.TabIndex = 5;
            this.btnEditTable.Text = "Sửa";
            this.btnEditTable.UseVisualStyleBackColor = true;
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(602, 8);
            this.btnDeleteTable.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(52, 26);
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
            this.dgvTable.Location = new System.Drawing.Point(8, 38);
            this.dgvTable.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersWidth = 51;
            this.dgvTable.Size = new System.Drawing.Size(832, 434);
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
            this.tabPageAccount.Location = new System.Drawing.Point(4, 25);
            this.tabPageAccount.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAccount.Name = "tabPageAccount";
            this.tabPageAccount.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageAccount.Size = new System.Drawing.Size(847, 477);
            this.tabPageAccount.TabIndex = 3;
            this.tabPageAccount.Text = "Tài khoản";
            this.tabPageAccount.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(26, 11);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(99, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Tên tài khoản:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(129, 9);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(98, 23);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(274, 11);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(348, 8);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(98, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(26, 39);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(63, 17);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Chức vụ:";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(129, 37);
            this.cbRole.Margin = new System.Windows.Forms.Padding(2);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(98, 24);
            this.cbRole.TabIndex = 5;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(277, 39);
            this.btnAddAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(52, 26);
            this.btnAddAccount.TabIndex = 6;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(333, 39);
            this.btnEditAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(52, 26);
            this.btnEditAccount.TabIndex = 7;
            this.btnEditAccount.Text = "Sửa";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(389, 39);
            this.btnDeleteAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(57, 26);
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
            this.dgvAccount.Location = new System.Drawing.Point(8, 81);
            this.dgvAccount.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.RowHeadersWidth = 51;
            this.dgvAccount.Size = new System.Drawing.Size(832, 391);
            this.dgvAccount.TabIndex = 9;
            this.dgvAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccount_CellClick);
            // 
            // tabPageNhanvien
            // 
            this.tabPageNhanvien.Location = new System.Drawing.Point(4, 25);
            this.tabPageNhanvien.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageNhanvien.Name = "tabPageNhanvien";
            this.tabPageNhanvien.Size = new System.Drawing.Size(847, 477);
            this.tabPageNhanvien.TabIndex = 4;
            this.tabPageNhanvien.Text = "Nhân Viên";
            this.tabPageNhanvien.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(847, 477);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Thoát";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Đăng Xuất";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 506);
            this.Controls.Add(this.Thoát);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Nhà Hàng";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.Thoát.ResumeLayout(false);
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
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageNhanvien;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
    }
}