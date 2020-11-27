
namespace Inventory
{
    partial class AddUserForm
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
            this.AddUserPanel = new System.Windows.Forms.Panel();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.PasswordVerifyLabel = new System.Windows.Forms.Label();
            this.PasswordVerifyTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.AddUserLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.AddUserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddUserPanel
            // 
            this.AddUserPanel.Controls.Add(this.AddUserButton);
            this.AddUserPanel.Controls.Add(this.PasswordVerifyLabel);
            this.AddUserPanel.Controls.Add(this.PasswordVerifyTextbox);
            this.AddUserPanel.Controls.Add(this.PasswordTextbox);
            this.AddUserPanel.Controls.Add(this.UsernameTextbox);
            this.AddUserPanel.Controls.Add(this.Password);
            this.AddUserPanel.Controls.Add(this.AddUserLabel);
            this.AddUserPanel.Controls.Add(this.UsernameLabel);
            this.AddUserPanel.Location = new System.Drawing.Point(12, 12);
            this.AddUserPanel.Name = "AddUserPanel";
            this.AddUserPanel.Size = new System.Drawing.Size(475, 435);
            this.AddUserPanel.TabIndex = 0;
            // 
            // AddUserButton
            // 
            this.AddUserButton.BackColor = System.Drawing.Color.White;
            this.AddUserButton.ForeColor = System.Drawing.Color.Black;
            this.AddUserButton.Location = new System.Drawing.Point(313, 370);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(112, 34);
            this.AddUserButton.TabIndex = 7;
            this.AddUserButton.Text = "Add";
            this.AddUserButton.UseVisualStyleBackColor = false;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // PasswordVerifyLabel
            // 
            this.PasswordVerifyLabel.AutoSize = true;
            this.PasswordVerifyLabel.Location = new System.Drawing.Point(50, 303);
            this.PasswordVerifyLabel.Name = "PasswordVerifyLabel";
            this.PasswordVerifyLabel.Size = new System.Drawing.Size(136, 25);
            this.PasswordVerifyLabel.TabIndex = 6;
            this.PasswordVerifyLabel.Text = "Verify Password";
            // 
            // PasswordVerifyTextbox
            // 
            this.PasswordVerifyTextbox.Location = new System.Drawing.Point(213, 300);
            this.PasswordVerifyTextbox.Name = "PasswordVerifyTextbox";
            this.PasswordVerifyTextbox.Size = new System.Drawing.Size(212, 31);
            this.PasswordVerifyTextbox.TabIndex = 5;
            this.PasswordVerifyTextbox.UseSystemPasswordChar = true;
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(213, 257);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(212, 31);
            this.PasswordTextbox.TabIndex = 4;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(213, 163);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(212, 31);
            this.UsernameTextbox.TabIndex = 3;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(99, 260);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(87, 25);
            this.Password.TabIndex = 2;
            this.Password.Text = "Password";
            // 
            // AddUserLabel
            // 
            this.AddUserLabel.AutoSize = true;
            this.AddUserLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddUserLabel.Location = new System.Drawing.Point(158, 56);
            this.AddUserLabel.Name = "AddUserLabel";
            this.AddUserLabel.Size = new System.Drawing.Size(162, 30);
            this.AddUserLabel.TabIndex = 1;
            this.AddUserLabel.Text = "Add New User";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(95, 166);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(91, 25);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(498, 461);
            this.Controls.Add(this.AddUserPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.AddUserPanel.ResumeLayout(false);
            this.AddUserPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AddUserPanel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Label PasswordVerifyLabel;
        private System.Windows.Forms.TextBox PasswordVerifyTextbox;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label AddUserLabel;
    }
}