using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class TeamManagerMenu : Form
    {
        string connectionString = "Server=Alper;Database=InventoryManagementSystem;User Id=sa;Password=1;";
        public TeamManagerMenu()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            this.Text = "Online Store";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBStatus.Text = lbOrderStatus.Text;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void TeamManagerMenu_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Orders_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvOrders.DataSource = dataTable;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders_Table WHERE UserID = @UserID";
                int userID = txtBID.
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dgvOrders.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Kayıt bulunamadı.");
                            dgvOrders.DataSource = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    }
                }
            }
        }
    }
}
