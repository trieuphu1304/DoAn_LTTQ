namespace DoAn_LTTQ
{
    partial class CustomerSelectionForm
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
            this.label_Description = new System.Windows.Forms.Label();
            this.radioButton_Member = new System.Windows.Forms.RadioButton();
            this.radioButton_Guest = new System.Windows.Forms.RadioButton();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.label_Phone = new System.Windows.Forms.Label();
            this.button_Accept = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.panel_Main.SuspendLayout();
            this.SuspendLayout();

            // panel_Main
            this.panel_Main.Controls.Add(this.label_Title);
            this.panel_Main.Controls.Add(this.label_Description);
            this.panel_Main.Controls.Add(this.radioButton_Member);
            this.panel_Main.Controls.Add(this.textBox_Phone);
            this.panel_Main.Controls.Add(this.label_Phone);
            this.panel_Main.Controls.Add(this.radioButton_Guest);
            this.panel_Main.Controls.Add(this.button_Accept);
            this.panel_Main.Controls.Add(this.button_Cancel);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(550, 350);
            this.panel_Main.TabIndex = 0;

            // label_Title
            this.label_Title.AutoSize = false;
            this.label_Title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Title.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(0, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(550, 50);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Kiểm tra thành viên";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // label_Description
            this.label_Description.AutoSize = true;
            this.label_Description.Font = new System.Drawing.Font("Arial", 10F);
            this.label_Description.Location = new System.Drawing.Point(20, 70);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(280, 17);
            this.label_Description.TabIndex = 1;
            this.label_Description.Text = "Số điện thoại hoặc tên thành viên";

            // radioButton_Member
            this.radioButton_Member.AutoSize = true;
            this.radioButton_Member.Font = new System.Drawing.Font("Arial", 10F);
            this.radioButton_Member.Location = new System.Drawing.Point(20, 110);
            this.radioButton_Member.Name = "radioButton_Member";
            this.radioButton_Member.Size = new System.Drawing.Size(104, 21);
            this.radioButton_Member.TabIndex = 2;
            this.radioButton_Member.Text = "Thành viên";
            this.radioButton_Member.UseVisualStyleBackColor = true;
            this.radioButton_Member.CheckedChanged += new System.EventHandler(this.radioButton_Member_CheckedChanged);

            // label_Phone
            this.label_Phone.AutoSize = true;
            this.label_Phone.Font = new System.Drawing.Font("Arial", 10F);
            this.label_Phone.Location = new System.Drawing.Point(40, 145);
            this.label_Phone.Name = "label_Phone";
            this.label_Phone.Size = new System.Drawing.Size(130, 17);
            this.label_Phone.TabIndex = 3;
            this.label_Phone.Text = "Số điện thoại:";

            // textBox_Phone
            this.textBox_Phone.Enabled = false;
            this.textBox_Phone.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Phone.Location = new System.Drawing.Point(40, 168);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(470, 24);
            this.textBox_Phone.TabIndex = 4;

            // radioButton_Guest
            this.radioButton_Guest.AutoSize = true;
            this.radioButton_Guest.Font = new System.Drawing.Font("Arial", 10F);
            this.radioButton_Guest.Location = new System.Drawing.Point(20, 210);
            this.radioButton_Guest.Name = "radioButton_Guest";
            this.radioButton_Guest.Size = new System.Drawing.Size(120, 21);
            this.radioButton_Guest.TabIndex = 5;
            this.radioButton_Guest.Text = "Khách thường";
            this.radioButton_Guest.UseVisualStyleBackColor = true;

            // button_Accept
            this.button_Accept.BackColor = System.Drawing.Color.Green;
            this.button_Accept.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_Accept.ForeColor = System.Drawing.Color.White;
            this.button_Accept.Location = new System.Drawing.Point(280, 270);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(100, 40);
            this.button_Accept.TabIndex = 6;
            this.button_Accept.Text = "Tiếp Tục";
            this.button_Accept.UseVisualStyleBackColor = false;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);

            // button_Cancel
            this.button_Cancel.BackColor = System.Drawing.Color.Gray;
            this.button_Cancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_Cancel.ForeColor = System.Drawing.Color.White;
            this.button_Cancel.Location = new System.Drawing.Point(410, 270);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 40);
            this.button_Cancel.TabIndex = 7;
            this.button_Cancel.Text = "Hủy";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);

            // CustomerSelectionForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 350);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kiểm tra thành viên";
            this.Load += new System.EventHandler(this.CustomerSelectionForm_Load);
            this.panel_Main.ResumeLayout(false);
            this.panel_Main.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.RadioButton radioButton_Member;
        private System.Windows.Forms.RadioButton radioButton_Guest;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.Label label_Phone;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Panel panel_Main;
    }
}
