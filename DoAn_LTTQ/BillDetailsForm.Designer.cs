namespace DoAn_LTTQ
{
    partial class BillDetailsForm
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
            this.label_BillId = new System.Windows.Forms.Label();
            this.label_TableId = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.dataGridView_Items = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_Total = new System.Windows.Forms.Label();
            this.label_Discount = new System.Windows.Forms.Label();
            this.label_FinalTotal = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).BeginInit();
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
            this.label_Title.Size = new System.Drawing.Size(700, 50);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Chi Tiết Hóa Đơn";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_BillId
            // 
            this.label_BillId.AutoSize = true;
            this.label_BillId.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_BillId.Location = new System.Drawing.Point(20, 70);
            this.label_BillId.Name = "label_BillId";
            this.label_BillId.Size = new System.Drawing.Size(80, 19);
            this.label_BillId.TabIndex = 1;
            this.label_BillId.Text = "Mã HĐ: 0";
            // 
            // label_TableId
            // 
            this.label_TableId.AutoSize = true;
            this.label_TableId.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_TableId.Location = new System.Drawing.Point(200, 70);
            this.label_TableId.Name = "label_TableId";
            this.label_TableId.Size = new System.Drawing.Size(60, 19);
            this.label_TableId.TabIndex = 2;
            this.label_TableId.Text = "Bàn: 0";
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_Date.Location = new System.Drawing.Point(380, 70);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(106, 19);
            this.label_Date.TabIndex = 3;
            this.label_Date.Text = "Thời gian: --";
            // 
            // dataGridView_Items
            // 
            this.dataGridView_Items.AllowUserToAddRows = false;
            this.dataGridView_Items.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colQuantity,
            this.colPrice,
            this.colTotal});
            this.dataGridView_Items.Location = new System.Drawing.Point(20, 100);
            this.dataGridView_Items.Name = "dataGridView_Items";
            this.dataGridView_Items.RowHeadersVisible = false;
            this.dataGridView_Items.RowHeadersWidth = 51;
            this.dataGridView_Items.Size = new System.Drawing.Size(660, 250);
            this.dataGridView_Items.TabIndex = 4;
            // 
            // colName
            // 
            this.colName.HeaderText = "Tên Món";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 250;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Số Lượng";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Đơn Giá";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Thành Tiền";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.label_Total.Location = new System.Drawing.Point(20, 370);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(127, 22);
            this.label_Total.TabIndex = 5;
            this.label_Total.Text = "Tổng: 0 VNĐ";
            // 
            // label_Discount
            // 
            this.label_Discount.AutoSize = true;
            this.label_Discount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.label_Discount.Location = new System.Drawing.Point(20, 400);
            this.label_Discount.Name = "label_Discount";
            this.label_Discount.Size = new System.Drawing.Size(177, 22);
            this.label_Discount.TabIndex = 6;
            this.label_Discount.Text = "Chiết khấu: 0 VNĐ";
            // 
            // label_FinalTotal
            // 
            this.label_FinalTotal.AutoSize = true;
            this.label_FinalTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label_FinalTotal.ForeColor = System.Drawing.Color.Green;
            this.label_FinalTotal.Location = new System.Drawing.Point(20, 430);
            this.label_FinalTotal.Name = "label_FinalTotal";
            this.label_FinalTotal.Size = new System.Drawing.Size(182, 24);
            this.label_FinalTotal.TabIndex = 7;
            this.label_FinalTotal.Text = "Thành tiền: 0 VNĐ";
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.BackColor = System.Drawing.Color.Gray;
            this.button_Close.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_Close.ForeColor = System.Drawing.Color.White;
            this.button_Close.Location = new System.Drawing.Point(580, 430);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(100, 35);
            this.button_Close.TabIndex = 8;
            this.button_Close.Text = "Đóng";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // BillDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 480);
            this.ControlBox = false;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_FinalTotal);
            this.Controls.Add(this.label_Discount);
            this.Controls.Add(this.label_Total);
            this.Controls.Add(this.dataGridView_Items);
            this.Controls.Add(this.label_Date);
            this.Controls.Add(this.label_TableId);
            this.Controls.Add(this.label_BillId);
            this.Controls.Add(this.label_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Hóa Đơn";
            this.Load += new System.EventHandler(this.BillDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_BillId;
        private System.Windows.Forms.Label label_TableId;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.DataGridView dataGridView_Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.Label label_Discount;
        private System.Windows.Forms.Label label_FinalTotal;
        private System.Windows.Forms.Button button_Close;
    }
}
