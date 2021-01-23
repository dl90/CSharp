using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using Inventory.Classes;
using Inventory.DB;

namespace Inventory
{
    public partial class AddUserForm : Form
    {
        private string connectionString;
        public AddUserForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }

        private bool ValidateInput()
        {
            return Util.CheckEmptyString(UsernameTextbox.Text)
                && Util.CheckEmptyString(PasswordTextbox.Text)
                && Util.CheckEmptyString(PasswordVerifyTextbox.Text);
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) MessageBox.Show("Invalid input");
            else if (PasswordTextbox.Text != PasswordVerifyTextbox.Text) MessageBox.Show("Passwords do not match");
            else
            {
                string userQuery = "SELECT * FROM Account WHERE Username = @username";
                var queryArgs = new (string, dynamic)[] {
                    ("@username", UsernameTextbox.Text.Trim())
                };

                DataTable dt = Query.PopulateDataTable(userQuery, queryArgs);
                if (dt.Rows.Count != 0) MessageBox.Show("Username taken");
                else
                {
                    string insertQuery = "INSERT INTO Account (Username, Password) VALUES (@username, @password)";
                    var insertArgs = new (string, dynamic)[] {
                            ("@username", UsernameTextbox.Text.Trim()),
                            ("@password", PasswordTextbox.Text.Trim())
                        };
                    int affectedRows = Query.InsertUpdateDeleteQuery(insertQuery, insertArgs);
                    string msg = affectedRows == 1 ? "New user added" : "Something went wrong";
                    MessageBox.Show(msg);
                }
            }
        }
    }
}
