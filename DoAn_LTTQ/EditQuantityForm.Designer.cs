namespace DoAn_LTTQ
{
    partial class EditQuantityForm
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
            this.label_FoodName = new System.Windows.Forms.Label();
            this.label_Quantity = new System.Windows.Forms.Label();
            this.numericUpDown_Quantity = new System.Windows.Forms.NumericUpDown();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Quantity)).BeginInit();
            this.SuspendLayout();

            // label_Title
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label_Title.Location = new System.Drawing.Point(20, 20);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(100, 18);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Chỉnh Sửa Số Lượng";

            // label_FoodName
            this.label_FoodName.AutoSize = true;
            this.label_FoodName.Font = new System.Drawing.Font("Arial", 11F);
            this.label_FoodName.Location = new System.Drawing.Point(20, 60);
            this.label_FoodName.Name = "label_FoodName";
            this.label_FoodName.Size = new System.Drawing.Size(75, 17);
            this.label_FoodName.TabIndex = 1;
            this.label_FoodName.Text = "Tên Món:";

            // label_Quantity
            this.label_Quantity.AutoSize = true;
            this.label_Quantity.Font = new System.Drawing.Font("Arial", 11F);
            this.label_Quantity.Location = new System.Drawing.Point(20, 110);
            this.label_Quantity.Name = "label_Quantity";
            this.label_Quantity.Size = new System.Drawing.Size(80, 17);
            this.label_Quantity.TabIndex = 2;
            this.label_Quantity.Text = "Số Lượng:";

            // numericUpDown_Quantity
            this.numericUpDown_Quantity.Font = new System.Drawing.Font("Arial", 11F);
            this.numericUpDown_Quantity.Location = new System.Drawing.Point(120, 110);
            this.numericUpDown_Quantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numericUpDown_Quantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDown_Quantity.Name = "numericUpDown_Quantity";
            this.numericUpDown_Quantity.Size = new System.Drawing.Size(100, 24);
            this.numericUpDown_Quantity.TabIndex = 3;
            this.numericUpDown_Quantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // button_OK
            this.button_OK.BackColor = System.Drawing.Color.Green;
            this.button_OK.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_OK.ForeColor = System.Drawing.Color.White;
            this.button_OK.Location = new System.Drawing.Point(100, 160);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 35);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = false;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);

            // button_Cancel
            this.button_Cancel.BackColor = System.Drawing.Color.Gray;
            this.button_Cancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_Cancel.ForeColor = System.Drawing.Color.White;
            this.button_Cancel.Location = new System.Drawing.Point(210, 160);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 35);
            this.button_Cancel.TabIndex = 5;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);

            // EditQuantityForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 220);
            this.ControlBox = false;
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.numericUpDown_Quantity);
            this.Controls.Add(this.label_Quantity);
            this.Controls.Add(this.label_FoodName);
            this.Controls.Add(this.label_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditQuantityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh Sửa Số Lượng";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_FoodName;
        private System.Windows.Forms.Label label_Quantity;
        private System.Windows.Forms.NumericUpDown numericUpDown_Quantity;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
    }
}
