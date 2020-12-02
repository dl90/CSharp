using System;
using System.Data;
using System.Windows.Forms;
using Inventory.Classes;
using Inventory.DB;

namespace Inventory
{
    public partial class InventoryForm : Form
    {
        private string ItemName;
        private int ItemCount;
        private decimal ItemPrice;

        public InventoryForm()
        {
            InitializeComponent();
            LoadData();
        }

        private bool ValidateFormInput()
        {
            return Util.CheckEmptyString(ItemNameTextBox.Text)
                && Util.CheckValidCount(ItemCountTextBox.Text)
                && Util.CheckValidPrice(ItemPriceTextBox.Text);
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
            if (!ValidateFormInput()) MessageBox.Show("Invalid input");
            else
            {
                ItemName = ItemNameTextBox.Text.Trim();
                ItemCount = Convert.ToInt32(ItemCountTextBox.Text.Trim());
                ItemPrice = Convert.ToDecimal(ItemPriceTextBox.Text.Trim());

                string query = "INSERT INTO Inventory (ItemName, ItemCount, ItemPrice) VALUES (@name, @count, @price)";
                var args = new (string, dynamic)[] {
                    ("@name", ItemName),
                    ("@count", ItemCount),
                    ("@price", ItemPrice)
                };

                int affectedRows = Query.InsertUpdateDeleteQuery(query, args);
                string msg = affectedRows == 1 ? "New item added" : "Something went wrong";
                MessageBox.Show(msg);
                LoadData();
                ResetInputText();
            }
        }
        
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInput()) MessageBox.Show("Invalid input");
            else
            {
                int id = Convert.ToInt32(ItemDataGridView.SelectedCells[0].Value);
                ItemName = ItemNameTextBox.Text.Trim();
                ItemCount = Convert.ToInt32(ItemCountTextBox.Text.Trim());
                ItemPrice = Convert.ToDecimal(ItemPriceTextBox.Text.Trim());

                string query = "UPDATE Inventory SET ItemName = @name, ItemCount = @count, ItemPrice = @price WHERE Id = @id";
                var args = new (string, dynamic)[] {
                    ("@name", ItemName),
                    ("@count", ItemCount),
                    ("@price", ItemPrice),
                    ("@id", id)
                };

                int affectedRows = Query.InsertUpdateDeleteQuery(query, args);
                string msg = affectedRows == 1 ? "Item updated" : "Something went wrong";
                MessageBox.Show(msg);
                LoadData();
                ResetInputText();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ItemDataGridView.SelectedCells[0].Value);

            string query = "DELETE FROM Inventory WHERE Id = @id";
            var args = new (string, dynamic)[] {
                ("@id", id)
            };

            int affectedRows = Query.InsertUpdateDeleteQuery(query, args);
            string msg = affectedRows == 1 ? "Item Deleted" : "Something went wrong";
            MessageBox.Show(msg);
            LoadData();
        }

        private void ItemDataGridView_Click(object sender, DataGridViewCellEventArgs e)
        {
            ItemNameTextBox.Text = Convert.ToString(ItemDataGridView.SelectedCells[1].Value).Trim();
            ItemCountTextBox.Text = Convert.ToString(ItemDataGridView.SelectedCells[2].Value).Trim();
            ItemPriceTextBox.Text = Convert.ToString(ItemDataGridView.SelectedCells[3].Value).Trim();
        }

        private void ResetInputText()
        {
            ItemNameTextBox.Text = "";
            ItemCountTextBox.Text = "";
            ItemPriceTextBox.Text = "";
        }
    }
}
