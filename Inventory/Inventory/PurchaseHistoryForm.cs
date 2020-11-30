using System.Data;
using System.Windows.Forms;
using Inventory.DB;

namespace Inventory
{
    public partial class PurchaseHistoryForm : Form
    {
        public PurchaseHistoryForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Purchase";
            DataTable dt = Query.PopulateDataTable(query);
            if (dt != null)
            {
                PurchaseHistoryDataGrid.DataSource = dt;
                PurchaseHistoryDataGrid.Sort(PurchaseHistoryDataGrid.Columns[4], System.ComponentModel.ListSortDirection.Descending);
            }
            else MessageBox.Show("Could not load from Inventory");
        }

        private void RefreshButton_Click(object sender, System.EventArgs e)
        {
            LoadData();
        }
    }
}
