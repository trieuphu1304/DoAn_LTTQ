using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTTQ
{
    public partial class Master_Layout : Form
    {
        public Master_Layout()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chọnBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntegratedOrderingForm orderForm = new IntegratedOrderingForm();
            orderForm.ShowDialog();
        }

        private void lịchSửĐặtMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderHistoryForm historyForm = new OrderHistoryForm();
            historyForm.ShowDialog();
        }
    }
}
