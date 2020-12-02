using System.Data;
using Inventory.DB;
using System.Windows.Forms;

namespace Inventory
{
    public partial class SalesHistoryForm : Form
    {
        public SalesHistoryForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Sale";
            DataTable dt = Query.PopulateDataTable(query);
            if (dt != null)
            {
                SalesHistoryDataGrid.DataSource = dt;
                SalesHistoryDataGrid.Sort(SalesHistoryDataGrid.Columns[5], System.ComponentModel.ListSortDirection.Descending);
            }
            else MessageBox.Show("Could not load from Inventory");
        }

        private void RefreshButton_Click(object sender, System.EventArgs e)
        {
            LoadData();
        }
    }
}
