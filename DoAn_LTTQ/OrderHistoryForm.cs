using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoAn_LTTQ.Data;
using DoAn_LTTQ.Models;
using System.Linq;

namespace DoAn_LTTQ
{
    public partial class OrderHistoryForm : Form
    {
        private List<Bill> bills;
        private List<Bill> filteredBills;

        public OrderHistoryForm()
        {
            InitializeComponent();
        }

        private void OrderHistoryForm_Load(object sender, EventArgs e)
        {
            LoadBillHistory();
        }

        private void LoadBillHistory()
        {
            try
            {
                dataGridView_History.Rows.Clear();
                bills = BillDAL.GetAllBills();
                filteredBills = new List<Bill>(bills);
                DisplayBills(filteredBills);
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void DisplayBills(List<Bill> billsToDisplay)
        {
            dataGridView_History.Rows.Clear();
            foreach (Bill bill in billsToDisplay.OrderByDescending(b => b.DateCheckIn))
            {
                string status = bill.Status == 0 ? "Mở" : "Đã thanh toán";
                string tableName = GetTableName(bill.TableID);
                dataGridView_History.Rows.Add(
                    bill.ID,
                    tableName,
                    bill.DateCheckIn.ToString("dd/MM/yyyy HH:mm"),
                    status,
                    bill.Discount ?? 0,
                    "Chi Tiết"
                );
            }
        }

        private string GetTableName(int tableId)
        {
            try
            {
                List<TableFood> tables = TableFoodDAL.GetAllTables();
                TableFood table = tables.FirstOrDefault(t => t.ID == tableId);
                return table != null ? table.Name : "Bàn " + tableId;
            }
            catch
            {
                return "Bàn " + tableId;
            }
        }

        private void dataGridView_History_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colDetails.Index)
            {
                int billId = (int)dataGridView_History.Rows[e.RowIndex].Cells[0].Value;
                Bill selectedBill = bills.FirstOrDefault(b => b.ID == billId);
                if (selectedBill != null)
                {
                    BillDetailsForm detailsForm = new BillDetailsForm(selectedBill);
                    detailsForm.ShowDialog();
                }
            }
        }

        public void SearchByBillId(int billId)
        {
            try
            {
                filteredBills = bills.Where(b => b.ID == billId).ToList();
                DisplayBills(filteredBills);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        public void SearchByDate(DateTime searchDate)
        {
            try
            {
                filteredBills = bills.Where(b => b.DateCheckIn.Date == searchDate.Date).ToList();
                DisplayBills(filteredBills);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        public void ResetSearch()
        {
            filteredBills = new List<Bill>(bills);
            DisplayBills(filteredBills);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_SearchBillId_Click(object sender, EventArgs e)
        {
            try
            {
                string input = textBox_BillId.Text.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Vui lòng nhập mã đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (int.TryParse(input, out int billId))
                {
                    SearchByBillId(billId);
                    if (filteredBills.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Mã đơn hàng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_SearchDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime searchDate = dateTimePicker_Search.Value;
                SearchByDate(searchDate);
                if (filteredBills.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng trong ngày này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ResetSearch_Click(object sender, EventArgs e)
        {
            textBox_BillId.Clear();
            ResetSearch();
        }

        private void label_Date_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_History_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
