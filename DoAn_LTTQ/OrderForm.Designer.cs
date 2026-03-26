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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.btnSelectTable = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dgvFood = new System.Windows.Forms.DataGridView();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.btnRemoveFood = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTableSelected = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();

            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();

            // tabControl1
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 450);
            this.tabControl1.TabIndex = 0;

            // tabPage1 - Chọn bàn
            this.tabPage1.Controls.Add(this.lblTableSelected);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbTable);
            this.tabPage1.Controls.Add(this.btnSelectTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chọn bàn";
            this.tabPage1.UseVisualStyleBackColor = true;

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn bàn ăn:";

            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.Location = new System.Drawing.Point(120, 30);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(200, 21);
            this.cmbTable.TabIndex = 1;

            this.btnSelectTable.Location = new System.Drawing.Point(330, 30);
            this.btnSelectTable.Name = "btnSelectTable";
            this.btnSelectTable.Size = new System.Drawing.Size(100, 30);
            this.btnSelectTable.TabIndex = 2;
            this.btnSelectTable.Text = "Chọn";
            this.btnSelectTable.UseVisualStyleBackColor = true;
            this.btnSelectTable.Click += new System.EventHandler(this.btnSelectTable_Click);

            this.lblTableSelected.AutoSize = true;
            this.lblTableSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTableSelected.ForeColor = System.Drawing.Color.Green;
            this.lblTableSelected.Location = new System.Drawing.Point(20, 80);
            this.lblTableSelected.Name = "lblTableSelected";
            this.lblTableSelected.Size = new System.Drawing.Size(150, 20);
            this.lblTableSelected.TabIndex = 3;
            this.lblTableSelected.Text = "Chưa chọn bàn";

            // tabPage2 - Chọn món
            this.tabPage2.Controls.Add(this.btnContinue);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cmbCategory);
            this.tabPage2.Controls.Add(this.dgvFood);
            this.tabPage2.Controls.Add(this.numQuantity);
            this.tabPage2.Controls.Add(this.btnAddFood);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chọn món ăn";
            this.tabPage2.UseVisualStyleBackColor = true;

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh mục:";

            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(100, 17);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 21);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);

            this.dgvFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFood.Location = new System.Drawing.Point(20, 50);
            this.dgvFood.Name = "dgvFood";
            this.dgvFood.ReadOnly = true;
            this.dgvFood.Size = new System.Drawing.Size(650, 250);
            this.dgvFood.TabIndex = 2;
            this.dgvFood.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.numQuantity.Location = new System.Drawing.Point(20, 320);
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(100, 20);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.btnAddFood.Location = new System.Drawing.Point(130, 320);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(100, 25);
            this.btnAddFood.TabIndex = 4;
            this.btnAddFood.Text = "Thêm vào";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);

            this.btnContinue.Location = new System.Drawing.Point(590, 320);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(80, 25);
            this.btnContinue.TabIndex = 5;
            this.btnContinue.Text = "Tiếp tục";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);

            // tabPage3 - Đặt hàng
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.dgvOrder);
            this.tabPage3.Controls.Add(this.btnRemoveFood);
            this.tabPage3.Controls.Add(this.lblTotal);
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Controls.Add(this.btnPrint);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(752, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Đặt hàng";
            this.tabPage3.UseVisualStyleBackColor = true;

            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(20, 40);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.Size = new System.Drawing.Size(650, 280);
            this.dgvOrder.TabIndex = 0;

            this.btnRemoveFood.Location = new System.Drawing.Point(590, 330);
            this.btnRemoveFood.Name = "btnRemoveFood";
            this.btnRemoveFood.Size = new System.Drawing.Size(80, 25);
            this.btnRemoveFood.TabIndex = 1;
            this.btnRemoveFood.Text = "Xóa";
            this.btnRemoveFood.UseVisualStyleBackColor = true;
            this.btnRemoveFood.Click += new System.EventHandler(this.btnRemoveFood_Click);

            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(20, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng tiền:";

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(120, 330);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 20);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0 VND";

            this.btnPrint.Location = new System.Drawing.Point(330, 370);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            this.btnSave.Location = new System.Drawing.Point(450, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // printPreviewDialog1
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = null;
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Document = this.printDocument1;

            // printDocument1
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);

            // OrderForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 474);
            this.Controls.Add(this.tabControl1);
            this.Name = "OrderForm";
            this.Text = "Đặt Món Ăn";
            this.Load += new System.EventHandler(this.OrderForm_Load);

            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);
        }

        #region Windows Form Designer generated code

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.Button btnSelectTable;
        private System.Windows.Forms.Label lblTableSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DataGridView dgvFood;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Button btnRemoveFood;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
