using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoAn_LTTQ.Models;
using System.Linq;

namespace DoAn_LTTQ
{
    public partial class OrderConfirmationForm : Form
    {
        private List<BillInfo> orderItems;
        private List<Food> allFoods;

        public OrderConfirmationForm(List<BillInfo> items, List<Food> foods)
        {
            InitializeComponent();
            orderItems = items;
            allFoods = foods;
        }

        private void OrderConfirmationForm_Load(object sender, EventArgs e)
        {
            LoadOrderItems();
        }

        private void LoadOrderItems()
        {
            try
            {
                dataGridView_Items.Rows.Clear();
                int total = 0;

                foreach (BillInfo item in orderItems)
                {
                    Food food = allFoods.FirstOrDefault(f => f.ID == item.FoodID);
                    if (food != null)
                    {
                        int itemTotal = (int)(food.Price * item.Count);
                        dataGridView_Items.Rows.Add(food.Name, item.Count, (int)food.Price, itemTotal);
                        total += itemTotal;
                    }
                }

                label_Total.Text = "Tổng: " + total.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            // Show success message
            MessageBox.Show("Đặt món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
