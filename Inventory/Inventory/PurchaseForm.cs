using System;
using System.Windows.Forms;
using Inventory.Classes;
using Inventory.DB;

namespace Inventory
{
    public partial class PurchaseForm : Form
    {
        public PurchaseForm()
        {
            InitializeComponent();
        }

        private bool ValidateFormInput()
        {
            return Util.CheckEmptyString(ItemNameTextBox.Text)
                && Util.CheckValidCount(QuantityTextBox.Text)
                && Util.CheckValidPrice(PurchasePriceTextBox.Text);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PurchaseDateDateTimePicker.CustomFormat);
        }
    }
}
