
namespace Inventory
{
    partial class InventoryForm
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

        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.Label ItemPriceLabel;
        private System.Windows.Forms.Label ItemCountLabel;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox ItemPriceTextBox;
        private System.Windows.Forms.TextBox ItemCountTextBox;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.DataGridView ItemDataGridView;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ItemPriceTextBox = new System.Windows.Forms.TextBox();
            this.ItemCountTextBox = new System.Windows.Forms.TextBox();
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.ItemPriceLabel = new System.Windows.Forms.Label();
            this.ItemCountLabel = new System.Windows.Forms.Label();
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.ItemDataGridView = new System.Windows.Forms.DataGridView();
            this.OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.Controls.Add(this.UpdateButton);
            this.OptionsPanel.Controls.Add(this.DeleteButton);
            this.OptionsPanel.Controls.Add(this.AddButton);
            this.OptionsPanel.Controls.Add(this.ItemPriceTextBox);
            this.OptionsPanel.Controls.Add(this.ItemCountTextBox);
            this.OptionsPanel.Controls.Add(this.ItemNameTextBox);
            this.OptionsPanel.Controls.Add(this.ItemPriceLabel);
            this.OptionsPanel.Controls.Add(this.ItemCountLabel);
            this.OptionsPanel.Controls.Add(this.ItemNameLabel);
            this.OptionsPanel.Location = new System.Drawing.Point(47, 456);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(600, 222);
            this.OptionsPanel.TabIndex = 0;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(453, 81);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(110, 40);
            this.UpdateButton.TabIndex = 8;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(453, 139);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(110, 40);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(453, 21);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(110, 40);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ItemPriceTextBox
            // 
            this.ItemPriceTextBox.Location = new System.Drawing.Point(120, 144);
            this.ItemPriceTextBox.Name = "ItemPriceTextBox";
            this.ItemPriceTextBox.Size = new System.Drawing.Size(238, 31);
            this.ItemPriceTextBox.TabIndex = 5;
            this.ItemPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ItemCountTextBox
            // 
            this.ItemCountTextBox.Location = new System.Drawing.Point(120, 89);
            this.ItemCountTextBox.Name = "ItemCountTextBox";
            this.ItemCountTextBox.Size = new System.Drawing.Size(238, 31);
            this.ItemCountTextBox.TabIndex = 4;
            this.ItemCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ItemNameTextBox
            // 
            this.ItemNameTextBox.Location = new System.Drawing.Point(120, 26);
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            this.ItemNameTextBox.Size = new System.Drawing.Size(238, 31);
            this.ItemNameTextBox.TabIndex = 3;
            this.ItemNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ItemPriceLabel
            // 
            this.ItemPriceLabel.AutoSize = true;
            this.ItemPriceLabel.Location = new System.Drawing.Point(13, 147);
            this.ItemPriceLabel.Name = "ItemPriceLabel";
            this.ItemPriceLabel.Size = new System.Drawing.Size(90, 25);
            this.ItemPriceLabel.TabIndex = 2;
            this.ItemPriceLabel.Text = "Item Price";
            // 
            // ItemCountLabel
            // 
            this.ItemCountLabel.AutoSize = true;
            this.ItemCountLabel.Location = new System.Drawing.Point(14, 89);
            this.ItemCountLabel.Name = "ItemCountLabel";
            this.ItemCountLabel.Size = new System.Drawing.Size(101, 25);
            this.ItemCountLabel.TabIndex = 1;
            this.ItemCountLabel.Text = "Item Count";
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Location = new System.Drawing.Point(14, 29);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(100, 25);
            this.ItemNameLabel.TabIndex = 0;
            this.ItemNameLabel.Text = "Item Name";
            // 
            // ItemDataGridView
            // 
            this.ItemDataGridView.AllowUserToAddRows = false;
            this.ItemDataGridView.AllowUserToDeleteRows = false;
            this.ItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ItemDataGridView.MultiSelect = false;
            this.ItemDataGridView.Name = "ItemDataGridView";
            this.ItemDataGridView.ReadOnly = true;
            this.ItemDataGridView.RowHeadersWidth = 62;
            this.ItemDataGridView.RowTemplate.Height = 33;
            this.ItemDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemDataGridView.Size = new System.Drawing.Size(691, 426);
            this.ItemDataGridView.TabIndex = 1;
            this.ItemDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemDataGridView_Click);
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 690);
            this.Controls.Add(this.ItemDataGridView);
            this.Controls.Add(this.OptionsPanel);
            this.Name = "InventoryForm";
            this.Text = "Inventory";
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDataGridView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}