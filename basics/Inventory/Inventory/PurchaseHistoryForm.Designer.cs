
namespace Inventory
{
    partial class PurchaseHistoryForm
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
            this.PurchaseHistoryDataGrid = new System.Windows.Forms.DataGridView();
            this.RefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseHistoryDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PurchaseHistoryDataGrid
            // 
            this.PurchaseHistoryDataGrid.AllowUserToAddRows = false;
            this.PurchaseHistoryDataGrid.AllowUserToDeleteRows = false;
            this.PurchaseHistoryDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PurchaseHistoryDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.PurchaseHistoryDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.PurchaseHistoryDataGrid.Location = new System.Drawing.Point(0, 0);
            this.PurchaseHistoryDataGrid.MultiSelect = false;
            this.PurchaseHistoryDataGrid.Name = "PurchaseHistoryDataGrid";
            this.PurchaseHistoryDataGrid.ReadOnly = true;
            this.PurchaseHistoryDataGrid.RowHeadersWidth = 62;
            this.PurchaseHistoryDataGrid.RowTemplate.Height = 33;
            this.PurchaseHistoryDataGrid.RowTemplate.ReadOnly = true;
            this.PurchaseHistoryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PurchaseHistoryDataGrid.Size = new System.Drawing.Size(965, 411);
            this.PurchaseHistoryDataGrid.TabIndex = 0;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(797, 426);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(156, 39);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // PurchaseHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 478);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.PurchaseHistoryDataGrid);
            this.Name = "PurchaseHistoryForm";
            this.Text = "PurchaseHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseHistoryDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PurchaseHistoryDataGrid;
        private System.Windows.Forms.Button RefreshButton;
    }
}