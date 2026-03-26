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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.dgvBillHistory = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvBillDetails = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày:";

            // dtpFromDate
            this.dtpFromDate.Location = new System.Drawing.Point(100, 17);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(150, 20);
            this.dtpFromDate.TabIndex = 1;

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày:";

            // dtpToDate
            this.dtpToDate.Location = new System.Drawing.Point(360, 17);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(150, 20);
            this.dtpToDate.TabIndex = 3;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(530, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnShowAll
            this.btnShowAll.Location = new System.Drawing.Point(620, 17);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(80, 23);
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Text = "Xem tất cả";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            // dgvBillHistory
            this.dgvBillHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillHistory.Location = new System.Drawing.Point(20, 50);
            this.dgvBillHistory.Name = "dgvBillHistory";
            this.dgvBillHistory.ReadOnly = true;
            this.dgvBillHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillHistory.Size = new System.Drawing.Size(740, 250);
            this.dgvBillHistory.TabIndex = 6;
            this.dgvBillHistory.SelectionChanged += new System.EventHandler(this.dgvBillHistory_SelectionChanged);

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chi tiết hóa đơn:";

            // dgvBillDetails
            this.dgvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillDetails.Location = new System.Drawing.Point(20, 330);
            this.dgvBillDetails.Name = "dgvBillDetails";
            this.dgvBillDetails.ReadOnly = true;
            this.dgvBillDetails.Size = new System.Drawing.Size(740, 150);
            this.dgvBillDetails.TabIndex = 8;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(600, 490);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 20);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "0 VND";

            // btnPrint
            this.btnPrint.Location = new System.Drawing.Point(680, 510);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 25);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // OrderHistoryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 550);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvBillDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvBillHistory);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.label1);
            this.Name = "OrderHistoryForm";
            this.Text = "Lịch sử đặt món";
            this.Load += new System.EventHandler(this.OrderHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #region Windows Form Designer generated code
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridView dgvBillHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvBillDetails;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPrint;
    }
}
