namespace DoAn_LTTQ
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCheckout;

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
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 280);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 30);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Tổng: 0đ";
            this.lblTotal.ForeColor = System.Drawing.Color.Red;

            // btnPrint
            this.btnPrint.Location = new System.Drawing.Point(200, 350);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 40);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "🖨️ In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // btnExport
            this.btnExport.Location = new System.Drawing.Point(300, 350);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 40);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "💾 Xuất";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // btnCheckout
            this.btnCheckout.Location = new System.Drawing.Point(400, 350);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(100, 40);
            this.btnCheckout.TabIndex = 3;
            this.btnCheckout.Text = "💳 Thanh Toán";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // PaymentForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTotal);
            this.Name = "PaymentForm";
            this.Text = "Thanh Toán";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
