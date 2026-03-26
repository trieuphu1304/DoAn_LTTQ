using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_LTTQ.Models;
using DoAn_LTTQ.Services;

namespace DoAn_LTTQ
{
    public partial class PaymentForm : Form
    {
        private int billID = -1;
        private int tableID = -1;
        private string tableName = "";
        private DataTable billDetailsTable;
        private PrintDocument printDocument;

        public PaymentForm(int billID, int tableID, string tableName)
        {
            InitializeComponent();
            this.billID = billID;
            this.tableID = tableID;
            this.tableName = tableName;
            this.Text = $"Thanh Toán - {tableName}";
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializePrinter();
                LoadBillDetails();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void InitializePrinter()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void LoadBillDetails()
        {
            try
            {
                // Lấy chi tiết hóa đơn
                billDetailsTable = BillHistoryService.GetBillDetailsById(billID);

                DataGridView dgv = new DataGridView();
                dgv.Dock = DockStyle.Fill;
                dgv.DataSource = billDetailsTable;
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;

                // Format column
                if (dgv.Columns["Price"] != null)
                    dgv.Columns["Price"].DefaultCellStyle.Format = "N0";
                if (dgv.Columns["SubTotal"] != null)
                    dgv.Columns["SubTotal"].DefaultCellStyle.Format = "N0";

                // Add to form - thêm vào panel trên
                Panel pnlDetails = new Panel();
                pnlDetails.Dock = DockStyle.Top;
                pnlDetails.Height = 250;
                pnlDetails.Controls.Add(dgv);
                this.Controls.Add(pnlDetails);
                this.Controls.SetChildIndex(pnlDetails, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        private void CalculateTotal()
        {
            try
            {
                decimal total = BillService.GetBillTotal(billID);
                lblTotal.Text = $"Tổng Tiền: {total.ToString("N0")} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tổng: " + ex.Message, "Lỗi");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog dialog = new PrintPreviewDialog();
                dialog.Document = printDocument;
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportBillToFile();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                // Thanh toán hóa đơn
                BillService.CloseBill(billID);

                // Cập nhật trạng thái bàn thành "Trống"
                TableFoodService.UpdateTableStatus(tableID, "Trống");

                MessageBox.Show("Thanh toán thành công!\nBàn đã được trả.", "Thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi");
            }
        }

        private void ExportBillToFile()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text Files (*.txt)|*.txt|PDF Files (*.pdf)|*.pdf";
                saveDialog.FileName = $"HoaDon_{tableName}_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string content = GenerateBillText();
                    File.WriteAllText(saveDialog.FileName, content, Encoding.UTF8);
                    MessageBox.Show($"✅ Xuất hóa đơn thành công!\nĐường dẫn: {saveDialog.FileName}", "Thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        private string GenerateBillText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("╔════════════════════════════════╗");
            sb.AppendLine("║         HÓA ĐƠN THANH TOÁN      ║");
            sb.AppendLine("╚════════════════════════════════╝");
            sb.AppendLine();
            sb.AppendLine($"Bàn: {tableName}");
            sb.AppendLine($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine();
            sb.AppendLine("────────────────────────────────");
            sb.AppendLine("Tên Món".PadRight(20) + "SL".PadRight(6) + "Giá".PadRight(12) + "Thành tiền");
            sb.AppendLine("────────────────────────────────");

            if (billDetailsTable != null)
            {
                foreach (DataRow row in billDetailsTable.Rows)
                {
                    string name = row["FoodName"].ToString().Length > 15 ? 
                        row["FoodName"].ToString().Substring(0, 15) : row["FoodName"].ToString();
                    int count = Convert.ToInt32(row["Count"]);
                    decimal price = Convert.ToDecimal(row["Price"]);
                    decimal total = Convert.ToDecimal(row["SubTotal"]);

                    sb.AppendLine(name.PadRight(20) + count.ToString().PadRight(6) + 
                        price.ToString("N0").PadRight(12) + total.ToString("N0"));
                }
            }

            sb.AppendLine("────────────────────────────────");

            decimal grandTotal = BillService.GetBillTotal(billID);
            sb.AppendLine($"TỔNG CỘNG: {grandTotal.ToString("N0")} đ".PadLeft(35));

            sb.AppendLine();
            sb.AppendLine("       Cảm ơn quý khách!");
            sb.AppendLine("     Hẹn gặp lại lần tới!");

            return sb.ToString();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // In hóa đơn
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font totalFont = new Font("Arial", 12, FontStyle.Bold);

                float y = 50;
                float x = 50;

                // Header
                e.Graphics.DrawString("HÓA ĐƠN", headerFont, Brushes.Black, x, y);
                y += 40;

                e.Graphics.DrawString($"Bàn: {tableName}", normalFont, Brushes.Black, x, y);
                y += 25;

                e.Graphics.DrawString($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}", normalFont, Brushes.Black, x, y);
                y += 40;

                // Details
                e.Graphics.DrawString("Tên Món", normalFont, Brushes.Black, x, y);
                e.Graphics.DrawString("Số lượng", normalFont, Brushes.Black, x + 300, y);
                e.Graphics.DrawString("Giá", normalFont, Brushes.Black, x + 400, y);
                e.Graphics.DrawString("Thành tiền", normalFont, Brushes.Black, x + 500, y);
                y += 30;

                // Draw line
                e.Graphics.DrawLine(Pens.Black, x, y, x + 700, y);
                y += 20;

                // Items
                if (billDetailsTable != null)
                {
                    foreach (DataRow row in billDetailsTable.Rows)
                    {
                        string name = row["FoodName"].ToString();
                        int count = Convert.ToInt32(row["Count"]);
                        decimal price = Convert.ToDecimal(row["Price"]);
                        decimal total = Convert.ToDecimal(row["SubTotal"]);

                        e.Graphics.DrawString(name, normalFont, Brushes.Black, x, y);
                        e.Graphics.DrawString(count.ToString(), normalFont, Brushes.Black, x + 320, y);
                        e.Graphics.DrawString(price.ToString("N0"), normalFont, Brushes.Black, x + 420, y);
                        e.Graphics.DrawString(total.ToString("N0"), normalFont, Brushes.Black, x + 520, y);

                        y += 25;
                    }
                }

                // Total line
                y += 20;
                e.Graphics.DrawLine(Pens.Black, x, y, x + 700, y);
                y += 20;

                decimal grandTotal = BillService.GetBillTotal(billID);
                e.Graphics.DrawString($"TỔNG CỘNG: {grandTotal.ToString("N0")} đ", totalFont, Brushes.Black, x, y);

                y += 40;
                e.Graphics.DrawString("Cảm ơn quý khách!", normalFont, Brushes.Black, x, y);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in: " + ex.Message, "Lỗi");
            }
        }
    }
}
