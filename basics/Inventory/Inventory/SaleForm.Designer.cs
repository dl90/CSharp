
namespace Inventory
{
    partial class SaleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemLabel = new System.Windows.Forms.Label();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.InventoryStock = new System.Windows.Forms.Label();
            this.InventoryStockLabel = new System.Windows.Forms.Label();
            this.Profit = new System.Windows.Forms.Label();
            this.ProfitLabel = new System.Windows.Forms.Label();
            this.ItemComboBox = new System.Windows.Forms.ComboBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.SuggestedPrice = new System.Windows.Forms.Label();
            this.SuggestedPriceLabel = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.SellerNameTextBox = new System.Windows.Forms.TextBox();
            this.SellerLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.InputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemLabel
            // 
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Location = new System.Drawing.Point(18, 27);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(48, 25);
            this.ItemLabel.TabIndex = 0;
            this.ItemLabel.Text = "Item";
            // 
            // InputPanel
            // 
            this.InputPanel.Controls.Add(this.InventoryStock);
            this.InputPanel.Controls.Add(this.InventoryStockLabel);
            this.InputPanel.Controls.Add(this.Profit);
            this.InputPanel.Controls.Add(this.ProfitLabel);
            this.InputPanel.Controls.Add(this.ItemComboBox);
            this.InputPanel.Controls.Add(this.QuantityTextBox);
            this.InputPanel.Controls.Add(this.QuantityLabel);
            this.InputPanel.Controls.Add(this.SuggestedPrice);
            this.InputPanel.Controls.Add(this.SuggestedPriceLabel);
            this.InputPanel.Controls.Add(this.PriceTextBox);
            this.InputPanel.Controls.Add(this.PriceLabel);
            this.InputPanel.Controls.Add(this.SellerNameTextBox);
            this.InputPanel.Controls.Add(this.SellerLabel);
            this.InputPanel.Controls.Add(this.ItemLabel);
            this.InputPanel.Location = new System.Drawing.Point(12, 12);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(394, 398);
            this.InputPanel.TabIndex = 2;
            // 
            // InventoryStock
            // 
            this.InventoryStock.AutoSize = true;
            this.InventoryStock.Location = new System.Drawing.Point(221, 254);
            this.InventoryStock.Name = "InventoryStock";
            this.InventoryStock.Size = new System.Drawing.Size(22, 25);
            this.InventoryStock.TabIndex = 11;
            this.InventoryStock.Text = "0";
            // 
            // InventoryStockLabel
            // 
            this.InventoryStockLabel.AutoSize = true;
            this.InventoryStockLabel.Location = new System.Drawing.Point(50, 254);
            this.InventoryStockLabel.Name = "InventoryStockLabel";
            this.InventoryStockLabel.Size = new System.Drawing.Size(135, 25);
            this.InventoryStockLabel.TabIndex = 10;
            this.InventoryStockLabel.Text = "Inventory Stock";
            // 
            // Profit
            // 
            this.Profit.AutoSize = true;
            this.Profit.Location = new System.Drawing.Point(221, 339);
            this.Profit.Name = "Profit";
            this.Profit.Size = new System.Drawing.Size(22, 25);
            this.Profit.TabIndex = 9;
            this.Profit.Text = "$";
            // 
            // ProfitLabel
            // 
            this.ProfitLabel.AutoSize = true;
            this.ProfitLabel.Location = new System.Drawing.Point(50, 339);
            this.ProfitLabel.Name = "ProfitLabel";
            this.ProfitLabel.Size = new System.Drawing.Size(55, 25);
            this.ProfitLabel.TabIndex = 8;
            this.ProfitLabel.Text = "Profit";
            // 
            // ItemComboBox
            // 
            this.ItemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemComboBox.FormattingEnabled = true;
            this.ItemComboBox.Location = new System.Drawing.Point(138, 24);
            this.ItemComboBox.MaxDropDownItems = 25;
            this.ItemComboBox.Name = "ItemComboBox";
            this.ItemComboBox.Size = new System.Drawing.Size(198, 33);
            this.ItemComboBox.Sorted = true;
            this.ItemComboBox.TabIndex = 7;
            this.ItemComboBox.SelectedIndexChanged += new System.EventHandler(this.LoadPrice_Event);
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(138, 131);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(198, 31);
            this.QuantityTextBox.TabIndex = 6;
            this.QuantityTextBox.TextChanged += new System.EventHandler(this.QuantityChange_Event);
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(17, 134);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(80, 25);
            this.QuantityLabel.TabIndex = 5;
            this.QuantityLabel.Text = "Quantity";
            // 
            // SuggestedPrice
            // 
            this.SuggestedPrice.AutoSize = true;
            this.SuggestedPrice.Location = new System.Drawing.Point(221, 297);
            this.SuggestedPrice.Name = "SuggestedPrice";
            this.SuggestedPrice.Size = new System.Drawing.Size(22, 25);
            this.SuggestedPrice.TabIndex = 3;
            this.SuggestedPrice.Text = "$";
            // 
            // SuggestedPriceLabel
            // 
            this.SuggestedPriceLabel.AutoSize = true;
            this.SuggestedPriceLabel.Location = new System.Drawing.Point(50, 297);
            this.SuggestedPriceLabel.Name = "SuggestedPriceLabel";
            this.SuggestedPriceLabel.Size = new System.Drawing.Size(139, 25);
            this.SuggestedPriceLabel.TabIndex = 3;
            this.SuggestedPriceLabel.Text = "Suggested Price";
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(138, 182);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(198, 31);
            this.PriceTextBox.TabIndex = 3;
            this.PriceTextBox.TextChanged += new System.EventHandler(this.PriceChange_Event);
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(17, 185);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(49, 25);
            this.PriceLabel.TabIndex = 4;
            this.PriceLabel.Text = "Price";
            // 
            // SellerNameTextBox
            // 
            this.SellerNameTextBox.Location = new System.Drawing.Point(138, 77);
            this.SellerNameTextBox.Name = "SellerNameTextBox";
            this.SellerNameTextBox.Size = new System.Drawing.Size(198, 31);
            this.SellerNameTextBox.TabIndex = 3;
            // 
            // SellerLabel
            // 
            this.SellerLabel.AutoSize = true;
            this.SellerLabel.Location = new System.Drawing.Point(17, 80);
            this.SellerLabel.Name = "SellerLabel";
            this.SellerLabel.Size = new System.Drawing.Size(106, 25);
            this.SellerLabel.TabIndex = 2;
            this.SellerLabel.Text = "Seller Name";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(243, 430);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(163, 41);
            this.SubmitButton.TabIndex = 3;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 483);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.InputPanel);
            this.Name = "SaleForm";
            this.Text = "SaleForm";
            this.Load += new System.EventHandler(this.SaleForm_Load);
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.Panel InputPanel;
        private System.Windows.Forms.TextBox SellerNameTextBox;
        private System.Windows.Forms.Label SellerLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Label SuggestedPrice;
        private System.Windows.Forms.Label SuggestedPriceLabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.ComboBox ItemComboBox;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Label Profit;
        private System.Windows.Forms.Label ProfitLabel;
        private System.Windows.Forms.Label InventoryStock;
        private System.Windows.Forms.Label InventoryStockLabel;
    }
}