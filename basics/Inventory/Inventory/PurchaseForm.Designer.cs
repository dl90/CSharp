
namespace Inventory
{
    partial class PurchaseForm
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
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.PurchaseDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.VendorTextBox = new System.Windows.Forms.TextBox();
            this.PurchasePriceTextBox = new System.Windows.Forms.TextBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.VendorLabel = new System.Windows.Forms.Label();
            this.PurchaseDateLabel = new System.Windows.Forms.Label();
            this.PurchasePriceLabel = new System.Windows.Forms.Label();
            this.ItemQuantityLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Location = new System.Drawing.Point(78, 55);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(100, 25);
            this.ItemNameLabel.TabIndex = 0;
            this.ItemNameLabel.Text = "Item Name";
            // 
            // MainPanel
            // 
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.SubmitButton);
            this.MainPanel.Controls.Add(this.PurchaseDateDateTimePicker);
            this.MainPanel.Controls.Add(this.VendorTextBox);
            this.MainPanel.Controls.Add(this.PurchasePriceTextBox);
            this.MainPanel.Controls.Add(this.QuantityTextBox);
            this.MainPanel.Controls.Add(this.ItemNameTextBox);
            this.MainPanel.Controls.Add(this.VendorLabel);
            this.MainPanel.Controls.Add(this.PurchaseDateLabel);
            this.MainPanel.Controls.Add(this.PurchasePriceLabel);
            this.MainPanel.Controls.Add(this.ItemQuantityLabel);
            this.MainPanel.Controls.Add(this.ItemNameLabel);
            this.MainPanel.Location = new System.Drawing.Point(12, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(514, 420);
            this.MainPanel.TabIndex = 1;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(337, 314);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(103, 40);
            this.SubmitButton.TabIndex = 10;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // PurchaseDateDateTimePicker
            // 
            this.PurchaseDateDateTimePicker.Location = new System.Drawing.Point(219, 192);
            this.PurchaseDateDateTimePicker.Name = "PurchaseDateDateTimePicker";
            this.PurchaseDateDateTimePicker.Size = new System.Drawing.Size(221, 31);
            this.PurchaseDateDateTimePicker.TabIndex = 9;
            // 
            // VendorTextBox
            // 
            this.VendorTextBox.Location = new System.Drawing.Point(219, 243);
            this.VendorTextBox.Name = "VendorTextBox";
            this.VendorTextBox.Size = new System.Drawing.Size(221, 31);
            this.VendorTextBox.TabIndex = 8;
            // 
            // PurchasePriceTextBox
            // 
            this.PurchasePriceTextBox.Location = new System.Drawing.Point(219, 145);
            this.PurchasePriceTextBox.Name = "PurchasePriceTextBox";
            this.PurchasePriceTextBox.Size = new System.Drawing.Size(221, 31);
            this.PurchasePriceTextBox.TabIndex = 7;
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(219, 100);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(221, 31);
            this.QuantityTextBox.TabIndex = 6;
            // 
            // ItemNameTextBox
            // 
            this.ItemNameTextBox.Location = new System.Drawing.Point(219, 52);
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            this.ItemNameTextBox.Size = new System.Drawing.Size(221, 31);
            this.ItemNameTextBox.TabIndex = 5;
            // 
            // VendorLabel
            // 
            this.VendorLabel.AutoSize = true;
            this.VendorLabel.Location = new System.Drawing.Point(109, 246);
            this.VendorLabel.Name = "VendorLabel";
            this.VendorLabel.Size = new System.Drawing.Size(69, 25);
            this.VendorLabel.TabIndex = 4;
            this.VendorLabel.Text = "Vendor";
            // 
            // PurchaseDateLabel
            // 
            this.PurchaseDateLabel.AutoSize = true;
            this.PurchaseDateLabel.Location = new System.Drawing.Point(54, 197);
            this.PurchaseDateLabel.Name = "PurchaseDateLabel";
            this.PurchaseDateLabel.Size = new System.Drawing.Size(124, 25);
            this.PurchaseDateLabel.TabIndex = 3;
            this.PurchaseDateLabel.Text = "Purchase Date";
            // 
            // PurchasePriceLabel
            // 
            this.PurchasePriceLabel.AutoSize = true;
            this.PurchasePriceLabel.Location = new System.Drawing.Point(54, 148);
            this.PurchasePriceLabel.Name = "PurchasePriceLabel";
            this.PurchasePriceLabel.Size = new System.Drawing.Size(124, 25);
            this.PurchasePriceLabel.TabIndex = 2;
            this.PurchasePriceLabel.Text = "Purchase Price";
            // 
            // ItemQuantityLabel
            // 
            this.ItemQuantityLabel.AutoSize = true;
            this.ItemQuantityLabel.Location = new System.Drawing.Point(98, 103);
            this.ItemQuantityLabel.Name = "ItemQuantityLabel";
            this.ItemQuantityLabel.Size = new System.Drawing.Size(80, 25);
            this.ItemQuantityLabel.TabIndex = 1;
            this.ItemQuantityLabel.Text = "Quantity";
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(540, 445);
            this.Controls.Add(this.MainPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "PurchaseForm";
            this.Text = "PurchaseForm";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.Label ItemQuantityLabel;
        private System.Windows.Forms.Label PurchasePriceLabel;
        private System.Windows.Forms.Label PurchaseDateLabel;
        private System.Windows.Forms.Label VendorLabel;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.TextBox PurchasePriceTextBox;
        private System.Windows.Forms.DateTimePicker PurchaseDateDateTimePicker;
        private System.Windows.Forms.TextBox VendorTextBox;
        private System.Windows.Forms.Button SubmitButton;
    }
}