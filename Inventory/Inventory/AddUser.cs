using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Inventory
{
    public partial class AddUser : Form
    {
        private string connectionString;
        public AddUser()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text != PasswordVerifyTextbox.Text) MessageBox.Show("Passwords do not match");
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand check = new SqlCommand("SELECT * FROM Account WHERE Username=@Username", conn);
                    check.Parameters.AddWithValue("@Username", UsernameTextbox.Text.Trim());

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(check);
                    da.Fill(dt);

                    if (dt.Rows.Count != 0) MessageBox.Show("Username taken");
                    else
                    {
                        SqlCommand insert = new SqlCommand("INSERT INTO Account (Username, Password) VALUES (@username, @password)", conn);
                        insert.Parameters.AddWithValue("@username", UsernameTextbox.Text.Trim());
                        insert.Parameters.AddWithValue("@password", PasswordTextbox.Text);
                        int affectedRows = insert.ExecuteNonQuery();

                        string msg = affectedRows == 1 ? "New user added" : "Something went wrong";
                        MessageBox.Show(msg);
                    }
                }
            }
        }
    }
}
