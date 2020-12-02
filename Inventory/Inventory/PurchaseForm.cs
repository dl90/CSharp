using System;
using System.Windows.Forms;
using System.Data;
using Inventory.Classes;
using Inventory.DB;

namespace Inventory
{
    public partial class PurchaseForm : Form
    {
        private string itemName;
        private int purchaseQuantity;
        private decimal purchasePrice;
        private DateTime date;
        private string vendor;

        public PurchaseForm()
        {
            InitializeComponent();
        }

        private bool ValidateFormInput()
        {
            return Util.CheckEmptyString(ItemNameTextBox.Text)
                && Util.CheckValidCount(QuantityTextBox.Text)
                && Util.CheckValidPrice(PurchasePriceTextBox.Text)
                && Util.CheckEmptyString(VendorTextBox.Text);
        }

        private void ResetInputText()
        {
            ItemNameTextBox.Text = "";
            QuantityTextBox.Text = "";
            PurchasePriceTextBox.Text = "";
            VendorTextBox.Text = "";
        }

        private void UpdateCashOnHand()
        {
            Cash.Subtract(purchasePrice);
        }

        private void InsertToInventory()
        {
            string query = "SELECT TOP 1 * FROM Inventory WHERE ItemName=@itemName";
            var queryArgs = new (string, dynamic)[] {
                ("@itemName", itemName)
            };

            DataTable dt = Query.PopulateDataTable(query, queryArgs);
            if (dt.Rows.Count == 0)
            {
                string insertQuery = "INSERT INTO Inventory (ItemName, ItemCount, ItemPrice) VALUES (@name, @count, @price)";
                decimal avgPrice = purchasePrice / purchaseQuantity;
                var insertArgs = new (string, dynamic)[] {
                    ("@name", itemName),
                    ("@count", purchaseQuantity),
                    ("@price", avgPrice)
                };
                Query.InsertUpdateDeleteQuery(insertQuery, insertArgs);
            }
            else
            {
                int id = Convert.ToInt32(dt.Rows[0]["Id"]);
                int prevCount = Convert.ToInt32(dt.Rows[0]["ItemCount"]);
                decimal prevPrice = Convert.ToDecimal(dt.Rows[0]["ItemPrice"]);

                int newCount = prevCount + purchaseQuantity;
                decimal newAvgPrice = Util.ReAverage(prevPrice, prevCount, purchasePrice, purchaseQuantity);

                string updateQuery = "UPDATE Inventory SET ItemCount = @count, ItemPrice = @price WHERE Id = @id";
                var updateArgs = new (string, dynamic)[] {
                    ("@count", newCount),
                    ("@price", newAvgPrice),
                    ("@id", id)
                };
                Query.InsertUpdateDeleteQuery(updateQuery, updateArgs);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInput()) MessageBox.Show("Invalid input");
            else
            {
                itemName = ItemNameTextBox.Text.Trim();
                purchaseQuantity = Convert.ToInt32(QuantityTextBox.Text.Trim());
                purchasePrice = Convert.ToDecimal(PurchasePriceTextBox.Text.Trim());
                date = PurchaseDateDateTimePicker.Value;
                vendor = VendorTextBox.Text.Trim();

                string query = "INSERT INTO Purchase (ItemName, ItemQuantity, PurchasePrice, PurchaseDate, VendorName) VALUES (@name, @quantity, @price, @date, @vendor)";
                var args = new (string, dynamic)[] {
                    ("@name", itemName),
                    ("@quantity", purchaseQuantity),
                    ("@price", purchasePrice),
                    ("@date", date),
                    ("@vendor", vendor)
                };

                int affectedRows = Query.InsertUpdateDeleteQuery(query, args);

                string msg;
                if (affectedRows == 1)
                {
                    UpdateCashOnHand();
                    InsertToInventory();
                    msg = "New purchase added";
                }
                else
                {
                    msg = "Something went wrong";
                }
                MessageBox.Show(msg);
                ResetInputText();
            }
        }
    }
}
