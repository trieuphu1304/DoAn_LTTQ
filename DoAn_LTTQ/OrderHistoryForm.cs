using System;
using System.Data;
using System.Windows.Forms;
using DoAn_LTTQ.Services;

namespace DoAn_LTTQ
{
    public partial class OrderHistoryForm : Form
    {
        private int selectedBillID = -1;

        public OrderHistoryForm()
        {
            InitializeComponent();
        }

        private void OrderHistoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Set default dates
                dtpToDate.Value = DateTime.Now;
                dtpFromDate.Value = DateTime.Now.AddDays(-30);

                // Load all bills on startup
                LoadAllBills();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message + "\n" + ex.StackTrace, "Lỗi");
            }
        }

        private void LoadAllBills()
        {
            try
            {
                DataTable dt = BillHistoryService.GetAllBills();
                dgvBillHistory.DataSource = dt;

                // Format cột
                if (dgvBillHistory.Columns.Count > 0)
                {
                    dgvBillHistory.Columns["Total"].DefaultCellStyle.Format = "N0";
                    dgvBillHistory.Columns["DateCheckIn"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    if (dgvBillHistory.Columns.Contains("DateCheckOut"))
                    {
                        dgvBillHistory.Columns["DateCheckOut"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                }

                // Clear details
                dgvBillDetails.DataSource = null;
                lblTotal.Text = "0 VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadAllBills();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày từ không được lớn hơn ngày đến!", "Thông báo");
                    return;
                }

                DataTable dt = BillHistoryService.GetBillsByDate(fromDate, toDate);
                dgvBillHistory.DataSource = dt;

                // Format cột
                if (dgvBillHistory.Columns.Count > 0)
                {
                    dgvBillHistory.Columns["Total"].DefaultCellStyle.Format = "N0";
                    dgvBillHistory.Columns["DateCheckIn"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    if (dgvBillHistory.Columns.Contains("DateCheckOut"))
                    {
                        dgvBillHistory.Columns["DateCheckOut"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                }

                dgvBillDetails.DataSource = null;
                lblTotal.Text = "0 VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi");
            }
        }

        private void dgvBillHistory_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBillHistory.SelectedRows.Count == 0)
                {
                    dgvBillDetails.DataSource = null;
                    lblTotal.Text = "0 VND";
                    return;
                }

                selectedBillID = (int)dgvBillHistory.SelectedRows[0].Cells["ID"].Value;

                // Load bill details
                DataTable dtDetails = BillHistoryService.GetBillDetailsById(selectedBillID);
                dgvBillDetails.DataSource = dtDetails;

                // Format cột
                if (dgvBillDetails.Columns.Count > 0)
                {
                    dgvBillDetails.Columns["Price"].DefaultCellStyle.Format = "N0";
                    dgvBillDetails.Columns["SubTotal"].DefaultCellStyle.Format = "N0";
                }

                // Load and display total
                decimal total = BillHistoryService.GetBillTotal(selectedBillID);
                lblTotal.Text = total.ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết: " + ex.Message, "Lỗi");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (selectedBillID == -1)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in!", "Thông báo");
                return;
            }

            try
            {
                MessageBox.Show("Chức năng in sẽ được cập nhật.", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }
    }
}
