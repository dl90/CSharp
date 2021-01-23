
namespace Inventory
{
    partial class SalesHistoryForm
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
            this.SalesHistoryDataGrid = new System.Windows.Forms.DataGridView();
            this.RefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SalesHistoryDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // SalesHistoryDataGrid
            // 
            this.SalesHistoryDataGrid.AllowUserToAddRows = false;
            this.SalesHistoryDataGrid.AllowUserToDeleteRows = false;
            this.SalesHistoryDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SalesHistoryDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.SalesHistoryDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.SalesHistoryDataGrid.Location = new System.Drawing.Point(0, 0);
            this.SalesHistoryDataGrid.MultiSelect = false;
            this.SalesHistoryDataGrid.Name = "SalesHistoryDataGrid";
            this.SalesHistoryDataGrid.ReadOnly = true;
            this.SalesHistoryDataGrid.RowHeadersWidth = 62;
            this.SalesHistoryDataGrid.RowTemplate.Height = 33;
            this.SalesHistoryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SalesHistoryDataGrid.Size = new System.Drawing.Size(980, 446);
            this.SalesHistoryDataGrid.TabIndex = 0;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(812, 465);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(156, 39);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SalesHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 515);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.SalesHistoryDataGrid);
            this.Name = "SalesHistoryForm";
            this.Text = "SalesHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.SalesHistoryDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SalesHistoryDataGrid;
        private System.Windows.Forms.Button RefreshButton;
    }
}