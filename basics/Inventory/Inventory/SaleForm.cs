using System;
using System.Windows.Forms;
using System.Data;
using Inventory.Classes;
using Inventory.DB;

namespace Inventory
{
    public partial class SaleForm : Form
    {
        private string itemName;
        private string sellerName;
        private int quantity;
        private int inventoryQuantity;
        private decimal salePrice;

        private DateTime date;
        private DataTable items;
        private int itemID;
        private decimal baseItemPrice;
        private decimal markupPrice;
        private decimal profitTotal;


        public SaleForm()
        {
            InitializeComponent();
        }

        private bool ValidateFormInput()
        {
            return Util.CheckEmptyString(SellerNameTextBox.Text)
                && Util.CheckValidCount(QuantityTextBox.Text)
                && Util.CheckValidPrice(PriceTextBox.Text);
        }

        private void CalcPrice()
        {
            decimal markup = baseItemPrice * Convert.ToDecimal(1.25);
            markupPrice = markup * Convert.ToInt32(QuantityTextBox.Text.Trim());
        }

        private void CalcProfit()
        {
            decimal baseRevenue = baseItemPrice * quantity;
            profitTotal = salePrice - baseRevenue;
        }

        private void LoadItems()
        {
            ItemComboBox.Items.Clear();
            string itemsQuery = "SELECT * FROM Inventory";
            items = Query.PopulateDataTable(itemsQuery);
            if (items != null)
            {
                foreach (DataRow dr in items.Rows)
                {
                    ItemComboBox.Items.Add(dr["ItemName"]);
                }
            }
            else
            {
                MessageBox.Show("No items");
            }
        }

        private bool UpdateInventory()
        {
            int newCount = inventoryQuantity - quantity;

            string updateQuery = "UPDATE Inventory SET ItemCount = @count WHERE Id = @id";
            var updateArgs = new (string, dynamic)[] {
                 ("@count", newCount),
                 ("@id", itemID)
            };
            return Query.InsertUpdateDeleteQuery(updateQuery, updateArgs) == 1;
        }

        private void UpdateCashOnHand()
        {
            Cash.Add(salePrice);
        }

        private bool InsertSale()
        {
            int affectedRows = 0;
            if (!ValidateFormInput()) MessageBox.Show("Invalid Input");
            else
            {
                itemName = ItemComboBox.Text.Trim();
                sellerName = SellerNameTextBox.Text.Trim();
                quantity = Convert.ToInt32(QuantityTextBox.Text.Trim());
                salePrice = Convert.ToInt32(PriceTextBox.Text.Trim());
                date = DateTime.Now;

                string insertQuery = "INSERT INTO Sale (ItemName, SellerName, Quantity, SalePrice, SaleDate) VALUES (@itemName, @sellerName, @quantity, @salePrice, @sdate)";
                var insertArgs = new (string, dynamic)[] {
                    ("@itemName", itemName),
                    ("@sellerName", sellerName),
                    ("@quantity", quantity),
                    ("@salePrice", salePrice),
                    ("@sdate", date)
                };
                affectedRows = Query.InsertUpdateDeleteQuery(insertQuery, insertArgs);
            }
            return affectedRows == 1;
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void PriceChange_Event(object sender, EventArgs e)
        {
            if (PriceTextBox.Text != "")
            {
                salePrice = Convert.ToInt32(PriceTextBox.Text);
                CalcProfit();
                Profit.Text = $"${profitTotal}";
            }
            else
            {
                Profit.Text = "$";
            }

        }

        private void LoadPrice_Event(object sender, EventArgs e)
        {
            DataRow selected = null;
            itemName = ItemComboBox.Text.Trim();
            foreach (DataRow dr in items.Rows)
            {
                if (dr["ItemName"].ToString().Trim() == itemName) selected = dr;
            }

            itemID = Convert.ToInt32(selected["Id"]);

            baseItemPrice = Convert.ToDecimal(selected["ItemPrice"]);
            QuantityTextBox.Text = "0";

            inventoryQuantity = Convert.ToInt32(selected["ItemCount"]);
            InventoryStock.Text = inventoryQuantity.ToString();
        }

        private void QuantityChange_Event(object sender, EventArgs e)
        {
            if (QuantityTextBox.Text != "")
            {
                quantity = Convert.ToInt32(QuantityTextBox.Text.Trim());
                CalcPrice();
                PriceChange_Event(sender, e);
                SuggestedPrice.Text = $"${markupPrice}";
            }
            else
            {
                quantity = 0;
                SuggestedPrice.Text = "$";
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string msg;
            bool ifInserted = InsertSale();
            if (ifInserted)
            {
                UpdateCashOnHand();
                UpdateInventory();
                msg = "Sale added";
            }
            else
            {
                msg = "Something went wrong";
            }
            MessageBox.Show(msg);
        }
    }
}
