namespace DoAn_LTTQ
{
    partial class OrderHistoryForm
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
            this.label_Title = new System.Windows.Forms.Label();
            this.panel_Search = new System.Windows.Forms.Panel();
            this.button_ResetSearch = new System.Windows.Forms.Button();
            this.button_SearchDate = new System.Windows.Forms.Button();
            this.button_SearchBillId = new System.Windows.Forms.Button();
            this.dateTimePicker_Search = new System.Windows.Forms.DateTimePicker();
            this.label_Date = new System.Windows.Forms.Label();
            this.textBox_BillId = new System.Windows.Forms.TextBox();
            this.label_BillId = new System.Windows.Forms.Label();
            this.dataGridView_History = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button_Close = new System.Windows.Forms.Button();
            this.panel_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_History)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Title.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(0, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(900, 50);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Lịch Sử Đặt Món";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Search
            // 
            this.panel_Search.BackColor = System.Drawing.SystemColors.Control;
            this.panel_Search.Controls.Add(this.button_ResetSearch);
            this.panel_Search.Controls.Add(this.button_SearchDate);
            this.panel_Search.Controls.Add(this.button_SearchBillId);
            this.panel_Search.Controls.Add(this.dateTimePicker_Search);
            this.panel_Search.Controls.Add(this.label_Date);
            this.panel_Search.Controls.Add(this.textBox_BillId);
            this.panel_Search.Controls.Add(this.label_BillId);
            this.panel_Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Search.Location = new System.Drawing.Point(0, 50);
            this.panel_Search.Name = "panel_Search";
            this.panel_Search.Size = new System.Drawing.Size(900, 80);
            this.panel_Search.TabIndex = 1;
            // 
            // button_ResetSearch
            // 
            this.button_ResetSearch.BackColor = System.Drawing.Color.Gray;
            this.button_ResetSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button_ResetSearch.ForeColor = System.Drawing.Color.White;
            this.button_ResetSearch.Location = new System.Drawing.Point(392, 25);
            this.button_ResetSearch.Name = "button_ResetSearch";
            this.button_ResetSearch.Size = new System.Drawing.Size(192, 28);
            this.button_ResetSearch.TabIndex = 6;
            this.button_ResetSearch.Text = "Hiển Thị Tất Cả";
            this.button_ResetSearch.UseVisualStyleBackColor = false;
            this.button_ResetSearch.Click += new System.EventHandler(this.button_ResetSearch_Click);
            // 
            // button_SearchDate
            // 
            this.button_SearchDate.BackColor = System.Drawing.Color.Blue;
            this.button_SearchDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button_SearchDate.ForeColor = System.Drawing.Color.White;
            this.button_SearchDate.Location = new System.Drawing.Point(282, 42);
            this.button_SearchDate.Name = "button_SearchDate";
            this.button_SearchDate.Size = new System.Drawing.Size(85, 23);
            this.button_SearchDate.TabIndex = 5;
            this.button_SearchDate.Text = "Tìm Kiếm";
            this.button_SearchDate.UseVisualStyleBackColor = false;
            this.button_SearchDate.Click += new System.EventHandler(this.button_SearchDate_Click);
            // 
            // button_SearchBillId
            // 
            this.button_SearchBillId.BackColor = System.Drawing.Color.Blue;
            this.button_SearchBillId.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button_SearchBillId.ForeColor = System.Drawing.Color.White;
            this.button_SearchBillId.Location = new System.Drawing.Point(282, 14);
            this.button_SearchBillId.Name = "button_SearchBillId";
            this.button_SearchBillId.Size = new System.Drawing.Size(85, 23);
            this.button_SearchBillId.TabIndex = 2;
            this.button_SearchBillId.Text = "Tìm Kiếm";
            this.button_SearchBillId.UseVisualStyleBackColor = false;
            this.button_SearchBillId.Click += new System.EventHandler(this.button_SearchBillId_Click);
            // 
            // dateTimePicker_Search
            // 
            this.dateTimePicker_Search.Font = new System.Drawing.Font("Arial", 10F);
            this.dateTimePicker_Search.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Search.Location = new System.Drawing.Point(122, 42);
            this.dateTimePicker_Search.Name = "dateTimePicker_Search";
            this.dateTimePicker_Search.Size = new System.Drawing.Size(145, 27);
            this.dateTimePicker_Search.TabIndex = 4;
            // 
            // label_Date
            // 
            this.label_Date.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_Date.Location = new System.Drawing.Point(10, 42);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(106, 23);
            this.label_Date.TabIndex = 3;
            this.label_Date.Text = "Theo Ngày:";
            this.label_Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_Date.Click += new System.EventHandler(this.label_Date_Click);
            // 
            // textBox_BillId
            // 
            this.textBox_BillId.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_BillId.Location = new System.Drawing.Point(122, 10);
            this.textBox_BillId.Name = "textBox_BillId";
            this.textBox_BillId.Size = new System.Drawing.Size(145, 27);
            this.textBox_BillId.TabIndex = 1;
            // 
            // label_BillId
            // 
            this.label_BillId.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_BillId.Location = new System.Drawing.Point(10, 12);
            this.label_BillId.Name = "label_BillId";
            this.label_BillId.Size = new System.Drawing.Size(90, 23);
            this.label_BillId.TabIndex = 0;
            this.label_BillId.Text = "Mã Đơn Hàng:";
            this.label_BillId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView_History
            // 
            this.dataGridView_History.AllowUserToAddRows = false;
            this.dataGridView_History.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_History.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_History.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTableId,
            this.colDate,
            this.colStatus,
            this.colDiscount,
            this.colDetails});
            this.dataGridView_History.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_History.Location = new System.Drawing.Point(0, 130);
            this.dataGridView_History.Name = "dataGridView_History";
            this.dataGridView_History.RowHeadersVisible = false;
            this.dataGridView_History.RowHeadersWidth = 51;
            this.dataGridView_History.Size = new System.Drawing.Size(900, 320);
            this.dataGridView_History.TabIndex = 1;
            this.dataGridView_History.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_History_CellClick);
            this.dataGridView_History.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_History_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "Mã HĐ";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.Width = 80;
            // 
            // colTableId
            // 
            this.colTableId.HeaderText = "Bàn";
            this.colTableId.MinimumWidth = 6;
            this.colTableId.Name = "colTableId";
            this.colTableId.Width = 70;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Thời Gian";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.Width = 170;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Trạng Thái";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 120;
            // 
            // colDiscount
            // 
            this.colDiscount.HeaderText = "Chiết Khấu";
            this.colDiscount.MinimumWidth = 6;
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.Width = 120;
            // 
            // colDetails
            // 
            this.colDetails.HeaderText = "Chi Tiết";
            this.colDetails.MinimumWidth = 6;
            this.colDetails.Name = "colDetails";
            this.colDetails.Text = "Chi Tiết";
            this.colDetails.UseColumnTextForButtonValue = true;
            this.colDetails.Width = 90;
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.Gray;
            this.button_Close.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Close.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_Close.ForeColor = System.Drawing.Color.White;
            this.button_Close.Location = new System.Drawing.Point(0, 450);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(900, 40);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "Đóng";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // OrderHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 490);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_History);
            this.Controls.Add(this.panel_Search);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lịch Sử Đặt Món";
            this.Load += new System.EventHandler(this.OrderHistoryForm_Load);
            this.panel_Search.ResumeLayout(false);
            this.panel_Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_History)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Panel panel_Search;
        private System.Windows.Forms.Label label_BillId;
        private System.Windows.Forms.TextBox textBox_BillId;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Search;
        private System.Windows.Forms.Button button_SearchBillId;
        private System.Windows.Forms.Button button_SearchDate;
        private System.Windows.Forms.Button button_ResetSearch;
        private System.Windows.Forms.DataGridView dataGridView_History;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
        private System.Windows.Forms.DataGridViewButtonColumn colDetails;
        private System.Windows.Forms.Button button_Close;
    }
}
