using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Inventory
{
    public partial class UsersForm : Form
    {
        private string connectionString;
        public UsersForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(UsersDataGridView.SelectedCells[0].Value);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand delete = new SqlCommand("DELETE FROM Account WHERE Id = @SelectedID", conn);
                delete.Parameters.AddWithValue("@SelectedID", id);
                int affectedRows = delete.ExecuteNonQuery();

                string msg = affectedRows == 1 ? "User deleted" : "Something went wrong";
                LoadData();
                MessageBox.Show(msg);
                conn.Close();
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand users = new SqlCommand("SELECT * FROM Account", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(users);
                da.Fill(dt);

                UsersDataGridView.DataSource = dt;
                conn.Close();
            }
        }
    }
}
