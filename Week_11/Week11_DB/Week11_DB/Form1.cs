using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Week_11
{
    public partial class Form1 : Form
    {
        string db = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Don Li\\Documents\\Github\\CSharp\\Week_11\\db.mdf;Integrated Security=True;Connect Timeout=30";

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Users values (@ID, @Name, @Age)", con);

            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Saved");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);

            con.Open();
            SqlCommand cmd = new SqlCommand("Update Users set Name=@Name, Age = @Age where ID = @ID", con);

            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);

            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Users where ID = @ID", con);

            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            // cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            // cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users", con);

            // cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            // cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            // cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            MessageBox.Show("Successfully Loaded");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
