using System.Data;
using System.Windows.Forms;
using Inventory.Classes;
using Inventory.DB;

namespace Inventory
{
    internal partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private bool ValidateFormInput()
        {
            return Util.CheckEmptyString(UsernameTextBox.Text)
                && Util.CheckEmptyString(PasswordTextBox.Text);
        }


        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            if (!ValidateFormInput()) MessageBox.Show("Invalid input");
            else
            {
                string username = UsernameTextBox.Text.Trim();
                string password = PasswordTextBox.Text.Trim();

                string query = "SELECT * FROM Account WHERE Username=@username";
                var args = new (string, dynamic)[]
                {
                ("@username", username)
                };

                DataTable dt = Query.PopulateDataTable(query, args);
                if (dt.Rows.Count == 0) MessageBox.Show("Incorrect information");
                else if (password != dt.Rows[0]["Password"].ToString().Trim()) MessageBox.Show("Incorrect information");
                else
                {
                    this.Hide();
                    Console ConsoleWindow = new Console();
                    ConsoleWindow.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
