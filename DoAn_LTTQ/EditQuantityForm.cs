using System;
using System.Windows.Forms;

namespace DoAn_LTTQ
{
    public partial class EditQuantityForm : Form
    {
        public int Quantity { get; set; }

        public EditQuantityForm(string foodName, int currentQuantity)
        {
            InitializeComponent();
            label_FoodName.Text = foodName;
            numericUpDown_Quantity.Value = currentQuantity;
            Quantity = currentQuantity;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Quantity = (int)numericUpDown_Quantity.Value;
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
