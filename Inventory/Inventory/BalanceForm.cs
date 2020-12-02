using System.Windows.Forms;
using Inventory.Classes;

namespace Inventory
{
    public partial class BalanceForm : Form
    {
        public BalanceForm()
        {
            InitializeComponent();
            LoadBalance();
        }

        private void LoadBalance()
        {
            decimal balance = Cash.CurrentCashOnHand();
            BalanceValue.Text = $"${balance}";
        }
    }
}
