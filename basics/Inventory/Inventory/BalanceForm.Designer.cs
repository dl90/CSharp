
namespace Inventory
{
    partial class BalanceForm
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
            this.BalanceLabel = new System.Windows.Forms.Label();
            this.BalanceValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BalanceLabel
            // 
            this.BalanceLabel.AutoSize = true;
            this.BalanceLabel.Location = new System.Drawing.Point(45, 50);
            this.BalanceLabel.Name = "BalanceLabel";
            this.BalanceLabel.Size = new System.Drawing.Size(71, 25);
            this.BalanceLabel.TabIndex = 0;
            this.BalanceLabel.Text = "Balance";
            // 
            // BalanceValue
            // 
            this.BalanceValue.AutoSize = true;
            this.BalanceValue.Location = new System.Drawing.Point(153, 50);
            this.BalanceValue.Name = "BalanceValue";
            this.BalanceValue.Size = new System.Drawing.Size(22, 25);
            this.BalanceValue.TabIndex = 1;
            this.BalanceValue.Text = "$";
            this.BalanceValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Balance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 118);
            this.Controls.Add(this.BalanceValue);
            this.Controls.Add(this.BalanceLabel);
            this.Name = "Balance";
            this.Text = "Balance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BalanceLabel;
        private System.Windows.Forms.Label BalanceValue;
    }
}