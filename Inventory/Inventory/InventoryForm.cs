using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Inventory.Classes;
using Inventory.DB;

namespace Inventory
{
    public partial class InventoryForm : Form
    {
        private string connectionString;
        public InventoryForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Inventory";
            DataTable dt = Query.PopulateDataTable(query);
            if (dt != null) ItemDataGridView.DataSource = dt;
            else MessageBox.Show("Could not load from Inventory");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!Util.CheckEmptyString(ItemNameTextBox.Text)
                || !Util.CheckValidCount(ItemCountTextBox.Text)
                || !Util.CheckValidPrice(ItemPriceTextBox.Text)
               ) MessageBox.Show("Invalid input");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Inventory (ItemName, ItemCount, ItemPrice) VALUES (@name, @count, @price)";
                SqlCommand insert = new SqlCommand(query, conn);
                insert.Parameters.AddWithValue("@name", ItemNameTextBox.Text.Trim());
                insert.Parameters.AddWithValue("@count", ItemCountTextBox.Text.Trim());
                insert.Parameters.AddWithValue("@price", ItemPriceTextBox.Text.Trim());
                int affectedRows = insert.ExecuteNonQuery();

                string msg = affectedRows == 1 ? "New item added" : "Something went wrong";
                MessageBox.Show(msg);
                LoadData();

                conn.Close();
                ItemNameTextBox.Text = "";
                ItemCountTextBox.Text = "";
                ItemPriceTextBox.Text = "";
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ItemDataGridView.SelectedCells[0].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string name = ItemNameTextBox.Text.Trim();
                string count = ItemCountTextBox.Text.Trim();
                string price = ItemPriceTextBox.Text.Trim();
                if (!Util.CheckEmptyString(name) || !Util.CheckValidCount(count) || !Util.CheckValidPrice(price)) MessageBox.Show("Invalid input");

                string query = "UPDATE Inventory SET ItemName = @name, ItemCount = @count, ItemPrice = @price WHERE Id = @id";
                SqlCommand update = new SqlCommand(query, conn);
                update.Parameters.AddWithValue("@name", name);
                update.Parameters.AddWithValue("@count", count);
                update.Parameters.AddWithValue("@price", price);
                update.Parameters.AddWithValue("@id", id);
                int affectedRows = update.ExecuteNonQuery();

                string msg = affectedRows == 1 ? "New item updated" : "Something went wrong";
                MessageBox.Show(msg);
                LoadData();

                conn.Close();
                ItemNameTextBox.Text = "";
                ItemCountTextBox.Text = "";
                ItemPriceTextBox.Text = "";
            }
        }

        private void ItemDataGridView_Click(object sender, DataGridViewCellEventArgs e)
        {
            ItemNameTextBox.Text = Convert.ToString(ItemDataGridView.SelectedCells[1].Value).Trim();
            ItemCountTextBox.Text = Convert.ToString(ItemDataGridView.SelectedCells[2].Value).Trim();
            ItemPriceTextBox.Text = Convert.ToString(ItemDataGridView.SelectedCells[3].Value).Trim();
        }
    }
}
