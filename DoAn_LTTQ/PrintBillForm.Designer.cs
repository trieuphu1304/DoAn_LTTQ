namespace DoAn_LTTQ
{
    partial class PrintBillForm
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
            this.textBox_Preview = new System.Windows.Forms.TextBox();
            this.button_Print = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // label_Title
            this.label_Title.AutoSize = false;
            this.label_Title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Title.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(0, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(650, 50);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Xem Trước In Hóa Đơn";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // textBox_Preview
            this.textBox_Preview.BackColor = System.Drawing.Color.White;
            this.textBox_Preview.Font = new System.Drawing.Font("Courier New", 10F);
            this.textBox_Preview.Location = new System.Drawing.Point(20, 70);
            this.textBox_Preview.Multiline = true;
            this.textBox_Preview.Name = "textBox_Preview";
            this.textBox_Preview.ReadOnly = true;
            this.textBox_Preview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Preview.Size = new System.Drawing.Size(610, 350);
            this.textBox_Preview.TabIndex = 1;

            // button_Print
            this.button_Print.BackColor = System.Drawing.Color.Blue;
            this.button_Print.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.button_Print.ForeColor = System.Drawing.Color.White;
            this.button_Print.Location = new System.Drawing.Point(240, 435);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(130, 45);
            this.button_Print.TabIndex = 2;
            this.button_Print.Text = "In Hóa Đơn";
            this.button_Print.UseVisualStyleBackColor = false;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);

            // button_Close
            this.button_Close.BackColor = System.Drawing.Color.Gray;
            this.button_Close.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.button_Close.ForeColor = System.Drawing.Color.White;
            this.button_Close.Location = new System.Drawing.Point(410, 435);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(130, 45);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "Đóng";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);

            // PrintBillForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 500);
            this.ControlBox = false;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Print);
            this.Controls.Add(this.textBox_Preview);
            this.Controls.Add(this.label_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintBillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "In Hóa Đơn";
            this.Load += new System.EventHandler(this.PrintBillForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_Preview;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.Button button_Close;
    }
}
