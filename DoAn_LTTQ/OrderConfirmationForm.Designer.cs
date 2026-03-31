namespace DoAn_LTTQ
{
    partial class OrderConfirmationForm
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
            this.dataGridView_Items = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_Total = new System.Windows.Forms.Label();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).BeginInit();
            this.SuspendLayout();

            // label_Title
            this.label_Title.AutoSize = false;
            this.label_Title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Title.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(0, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(600, 50);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Xác Nhận Đặt Món";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // dataGridView_Items
            this.dataGridView_Items.AllowUserToAddRows = false;
            this.dataGridView_Items.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colQuantity,
            this.colPrice,
            this.colTotal});
            this.dataGridView_Items.Location = new System.Drawing.Point(20, 70);
            this.dataGridView_Items.Name = "dataGridView_Items";
            this.dataGridView_Items.RowHeadersVisible = false;
            this.dataGridView_Items.Size = new System.Drawing.Size(560, 300);
            this.dataGridView_Items.TabIndex = 1;

            // colName
            this.colName.HeaderText = "Tên Món";
            this.colName.Name = "colName";
            this.colName.Width = 250;

            // colQuantity
            this.colQuantity.HeaderText = "Số Lượng";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 80;

            // colPrice
            this.colPrice.HeaderText = "Đơn Giá";
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 90;

            // colTotal
            this.colTotal.HeaderText = "Thành Tiền";
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 100;

            // label_Total
            this.label_Total.AutoSize = true;
            this.label_Total.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label_Total.Location = new System.Drawing.Point(20, 380);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(140, 19);
            this.label_Total.TabIndex = 2;
            this.label_Total.Text = "Tổng: 0 VNĐ";

            // button_Confirm
            this.button_Confirm.BackColor = System.Drawing.Color.Green;
            this.button_Confirm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_Confirm.ForeColor = System.Drawing.Color.White;
            this.button_Confirm.Location = new System.Drawing.Point(350, 420);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(120, 40);
            this.button_Confirm.TabIndex = 3;
            this.button_Confirm.Text = "Xác Nhận";
            this.button_Confirm.UseVisualStyleBackColor = false;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);

            // button_Cancel
            this.button_Cancel.BackColor = System.Drawing.Color.Gray;
            this.button_Cancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_Cancel.ForeColor = System.Drawing.Color.White;
            this.button_Cancel.Location = new System.Drawing.Point(480, 420);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 40);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Hủy";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);

            // OrderConfirmationForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 480);
            this.ControlBox = false;
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Confirm);
            this.Controls.Add(this.label_Total);
            this.Controls.Add(this.dataGridView_Items);
            this.Controls.Add(this.label_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderConfirmationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xác Nhận Đặt Món";
            this.Load += new System.EventHandler(this.OrderConfirmationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.DataGridView dataGridView_Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.Button button_Confirm;
        private System.Windows.Forms.Button button_Cancel;
    }
}
