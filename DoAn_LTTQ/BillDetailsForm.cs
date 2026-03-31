using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoAn_LTTQ.Data;
using DoAn_LTTQ.Models;
using System.Linq;

namespace DoAn_LTTQ
{
    public partial class BillDetailsForm : Form
    {
        private Bill bill;
        private List<BillInfo> billItems;

        public BillDetailsForm(Bill selectedBill)
        {
            InitializeComponent();
            bill = selectedBill;
        }

        private void BillDetailsForm_Load(object sender, EventArgs e)
        {
            LoadBillDetails();
        }

        private void LoadBillDetails()
        {
            try
            {
                label_BillId.Text = "Mã HĐ: " + bill.ID;
                label_TableId.Text = "Bàn: " + bill.TableID;
                label_Date.Text = "Thời gian: " + bill.DateCheckIn.ToString("dd/MM/yyyy HH:mm");
                
                billItems = BillInfoDAL.GetBillInfoByBillID(bill.ID);
                List<Food> allFoods = FoodDAL.GetAllFoods();

                dataGridView_Items.Rows.Clear();
                int total = 0;

                foreach (BillInfo item in billItems)
                {
                    Food food = allFoods.FirstOrDefault(f => f.ID == item.FoodID);
                    if (food != null)
                    {
                        int itemTotal = (int)(food.Price * item.Count);
                        dataGridView_Items.Rows.Add(food.Name, item.Count, (int)food.Price, itemTotal);
                        total += itemTotal;
                    }
                }

                int discount = bill.Discount ?? 0;
                int finalTotal = total - discount;

                label_Total.Text = "Tổng: " + total.ToString("N0") + " VNĐ";
                label_Discount.Text = "Chiết khấu: " + discount.ToString("N0") + " VNĐ";
                label_FinalTotal.Text = "Thành tiền: " + finalTotal.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
