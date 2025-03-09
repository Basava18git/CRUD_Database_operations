
using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUD_Database_operations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region SaveData
        private void SAVE_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=BASAVA\\SQLEXPRESS;Initial Catalog=Contents;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";
            SqlConnection Connection1 = new SqlConnection(connectionstring);
            try
            {
                Connection1.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand cmd1 = new SqlCommand("insert into USER_DATA values (@ID,@NAME,@Gender,@Age)", Connection1);

            cmd1.Parameters.AddWithValue("@NAME", textBox1.Text);
            cmd1.Parameters.AddWithValue("@Age", int.Parse(textBox4.Text));
            cmd1.Parameters.AddWithValue("@ID", int.Parse(textBox2.Text));
            cmd1.Parameters.AddWithValue("@Gender", textBox3.Text);
            cmd1.ExecuteNonQuery();
            Connection1.Close();
            MessageBox.Show("Successfully Executed and saved Data");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        #endregion



        #region DeleteData
        private void DELETE_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=BASAVA\\SQLEXPRESS;Initial Catalog=Contents;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";
            SqlConnection Connection1 = new SqlConnection(connectionstring);
            try
            {
                Connection1.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand cmd2 = new SqlCommand("Delete USER_DATA  where ID=@ID", Connection1);


            cmd2.Parameters.AddWithValue("@ID", int.Parse(textBox2.Text));

            cmd2.ExecuteNonQuery();
            Connection1.Close();
            MessageBox.Show("Successfully Executed and Deleted Data");
            textBox2.Clear();
        }
        #endregion



        #region UpdateData
        private void Update_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=BASAVA\\SQLEXPRESS;Initial Catalog=Contents;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";
            SqlConnection Connection1 = new SqlConnection(connectionstring);
            try
            {
                Connection1.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand cmd1 = new SqlCommand("Update USER_DATA set NAME=@NAME,Age=@Age,Gender=@Gender where ID=@ID", Connection1);

            cmd1.Parameters.AddWithValue("@NAME", textBox1.Text);
            cmd1.Parameters.AddWithValue("@Age", int.Parse(textBox4.Text));
            cmd1.Parameters.AddWithValue("@ID", int.Parse(textBox2.Text));
            cmd1.Parameters.AddWithValue("@Gender", textBox3.Text);
            cmd1.ExecuteNonQuery();
            Connection1.Close();
            MessageBox.Show("Successfully Executed and Updated Data");
        }
        #endregion



        #region SearchOrSortData
        private void Search_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=BASAVA\\SQLEXPRESS;Initial Catalog=Contents;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";
            SqlConnection Connection1 = new SqlConnection(connectionstring);
            try
            {
                Connection1.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand cmd1 = new SqlCommand("Select*From USER_DATA", Connection1);

            //cmd1.Parameters.AddWithValue("@ID", int.Parse(textBox2.Text));
;
            cmd1.ExecuteNonQuery();
            Connection1.Close();
            SqlDataAdapter Da = new SqlDataAdapter(cmd1);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;
        }
        #endregion
    }
}
