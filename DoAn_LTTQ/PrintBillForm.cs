using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoAn_LTTQ.Models;
using System.Linq;
using System.Drawing.Printing;
using System.Drawing;

namespace DoAn_LTTQ
{
    public partial class PrintBillForm : Form
    {
        private int tableId;
        private List<BillInfo> orderItems;
        private List<Food> allFoods;
        private string totalAmount;
        private PrintDocument printDoc;
        private string billContent = "";

        public PrintBillForm(int tblId, List<BillInfo> items, List<Food> foods, string total)
        {
            InitializeComponent();
            tableId = tblId;
            orderItems = items;
            allFoods = foods;
            totalAmount = total;
        }

        private void PrintBillForm_Load(object sender, EventArgs e)
        {
            LoadBillPreview();
        }

        private void LoadBillPreview()
        {
            try
            {
                billContent = "";
                billContent += "╔════════════════════════════════════════╗\n";
                billContent += "║         HÓA ĐƠN THANH TOÁN             ║\n";
                billContent += "╠════════════════════════════════════════╣\n";
                billContent += String.Format("║ Bàn số: {0,-32} ║\n", tableId);
                billContent += String.Format("║ Ngày: {0,-35} ║\n", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                billContent += "╠════════════════════════════════════════╣\n";
                billContent += "║ STT | Tên Món          | SL | Giá     ║\n";
                billContent += "╠════════════════════════════════════════╣\n";

                int total = 0;
                int stt = 1;
                foreach (BillInfo item in orderItems)
                {
                    Food food = allFoods.FirstOrDefault(f => f.ID == item.FoodID);
                    if (food != null)
                    {
                        int itemTotal = (int)(food.Price * item.Count);
                        string foodName = food.Name.Length > 15 ? food.Name.Substring(0, 15) : food.Name;
                        billContent += String.Format("║ {0,2} | {1,-16} | {2,2} | {3,6} ║\n", 
                            stt, foodName, item.Count, itemTotal);
                        total += itemTotal;
                        stt++;
                    }
                }

                billContent += "╠════════════════════════════════════════╣\n";
                billContent += String.Format("║ TỔNG CỘNG:              {0,10} VNĐ ║\n", total);
                billContent += "╠════════════════════════════════════════╣\n";
                billContent += "║  Cảm ơn quý khách đã ghé thăm nhà hàng ║\n";
                billContent += "║         Hẹn gặp lại quý khách!         ║\n";
                billContent += "╚════════════════════════════════════════╝\n";

                textBox_Preview.Clear();
                textBox_Preview.AppendText(billContent);
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            try
            {
                printDoc = new PrintDocument();
                printDoc.PrintPage += PrintDoc_PrintPage;
                
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;
                
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                string[] lines = billContent.Split(new[] { "\n" }, StringSplitOptions.None);
                float yPosition = 50;
                Font font = new Font("Courier New", 10);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        e.Graphics.DrawString(line, font, Brushes.Black, 50, yPosition);
                        yPosition += 20;
                    }
                }

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
