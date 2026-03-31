using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoAn_LTTQ.Data;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ
{
    public partial class CustomerSelectionForm : Form
    {
        public int SelectedCustomerID { get; set; } = -1;
        public int AppliedDiscount { get; set; } = 0;
        public int DiscountPercentage { get; set; } = 0;
        public string CustomerType { get; set; } = "Khách thường"; // Default

        public CustomerSelectionForm()
        {
            InitializeComponent();
        }

        private void CustomerSelectionForm_Load(object sender, EventArgs e)
        {
            radioButton_Guest.Checked = true;
        }

        private void radioButton_Member_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Phone.Enabled = radioButton_Member.Checked;
            if (radioButton_Member.Checked)
            {
                textBox_Phone.Focus();
            }
            else
            {
                textBox_Phone.Clear();
            }
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            if (radioButton_Member.Checked)
            {
                string phone = textBox_Phone.Text.Trim();
                if (string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Check if customer exists
                List<Customer> allCustomers = CustomerDAL.GetAllCustomers();
                Customer existingCustomer = null;

                foreach (Customer customer in allCustomers)
                {
                    if (customer.Phone == phone)
                    {
                        existingCustomer = customer;
                        break;
                    }
                }

                if (existingCustomer != null)
                {
                    // Member found - apply 5% discount
                    SelectedCustomerID = existingCustomer.ID;
                    DiscountPercentage = 5; // 5% discount
                    // AppliedDiscount will be calculated in OrderForm based on subtotal
                    CustomerType = "Thành viên";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Member not found
                    DialogResult result = MessageBox.Show(
                        "Số điện thoại chưa được đăng ký thành viên.\n\nBạn có muốn đăng ký thành viên không?",
                        "Thông báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Open customer registration form
                        CustomerPanel registrationForm = new CustomerPanel();
                        registrationForm.ShowDialog();

                        // After registration, check if the phone number now exists in database
                        allCustomers = CustomerDAL.GetAllCustomers();
                        existingCustomer = null;

                        foreach (Customer customer in allCustomers)
                        {
                            if (customer.Phone == phone)
                            {
                                existingCustomer = customer;
                                break;
                            }
                        }

                        if (existingCustomer != null)
                        {
                            // Member found after registration
                            SelectedCustomerID = existingCustomer.ID;
                            DiscountPercentage = 5; // 5% discount
                            CustomerType = "Thành viên";
                            MessageBox.Show("Đăng ký thành công! Áp dụng giảm giá 5%", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            // Still not found, continue as guest
                            SelectedCustomerID = -1;
                            AppliedDiscount = 0;
                            CustomerType = "Khách thường";
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        // Continue as guest
                        SelectedCustomerID = -1;
                        AppliedDiscount = 0;
                        CustomerType = "Khách thường";
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else if (radioButton_Guest.Checked)
            {
                SelectedCustomerID = -1;
                AppliedDiscount = 0;
                CustomerType = "Khách thường";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
