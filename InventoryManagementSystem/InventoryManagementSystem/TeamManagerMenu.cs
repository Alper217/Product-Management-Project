using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static InventoryManagementSystem.Form1;
using static InventoryManagementSystem.CustomerMenu;

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
            int customerID = GlobalVariablesCustomer.CustomerId;
            int userId = GlobalVariables.UserId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT UserName, Gender FROM Users_Table WHERE UserID=@userId";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("userId", userId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string userName = reader["UserName"].ToString();
                        string gender = reader["Gender"].ToString();
                        string selectedGender = (gender == "Male") ? "Mr. " : "Ms. ";
                        lblWelcomeName.Text = "Welcome " + selectedGender + userName;
                    }
                }
            }
            string query = "SELECT * FROM Orders_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvOrders.DataSource = dataTable;
                }
                connection.Close();
            }
            string query2 = "SELECT * FROM Customers_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvCustomers.DataSource = dataTable;
                }
                connection.Close();
            }
            dgvCustomers.AutoGenerateColumns = true;
            dgvCustomers.DefaultCellStyle.BackColor = Color.White;
            dgvCustomers.DefaultCellStyle.ForeColor = Color.Black;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrders.AutoGenerateColumns = true;
            dgvOrders.DefaultCellStyle.BackColor = Color.White;
            dgvOrders.DefaultCellStyle.ForeColor = Color.Black;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders_Table WHERE OrderID = @OrderID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int OrderID = int.Parse(txtBID.Text);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dgvOrders.DataSource = dt;
                            txtBcustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
                        }
                        else
                        {
                            ShowAllOfThem();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    }
                }
            }

        }
        private void ShowAllOfThem()
        {
            string query = "SELECT * FROM Orders_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvOrders.DataSource = dataTable;
                }
                connection.Close();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Update Somethings Stuff
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectedStatus = lbOrderStatus.SelectedItem.ToString();
                string query = "UPDATE Orders_Table SET OrderStatus = @OrderStatus WHERE OrderID = @OrderID";
                int orderID;
                if (int.TryParse(txtBID.Text, out orderID))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@OrderStatus", selectedStatus);
                        comm.Parameters.AddWithValue("@OrderID", orderID);
                        int rowsAffected = comm.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Rol başarıyla güncellendi.");
                           
                        }
                        else
                        {
                            MessageBox.Show("Rol güncelleme işlemi başarısız oldu.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz SupplierID.");
                }
            }
            RefreshData();
            //
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string currentTime = DateTime.Now.ToString();
                connection.Open();
                string selectedStatus = lbOrderStatus.SelectedItem.ToString();
                int orderID;
                int customerID = int.Parse(txtBcustomerID.Text);
                if (int.TryParse(txtBID.Text, out orderID))
                {
                    string queryStatus = "INSERT INTO OrderInformations_Table (OrderID, CustomerID, ProcessDate, Status, ByWho) VALUES (@OrderID, @CustomerID, @ProcessDate, @Status, @ByWho);";
                    using (SqlCommand command = new SqlCommand(queryStatus,connection))
                    {  
                        command.Parameters.AddWithValue("@OrderID",orderID);
                        command.Parameters.AddWithValue("@CustomerID", GlobalVariablesCustomer.CustomerId); ;
                        command.Parameters.AddWithValue("@ProcessDate",currentTime);
                        command.Parameters.AddWithValue("@Status", "Changed to " + selectedStatus);
                        command.Parameters.AddWithValue("@ByWho", GlobalVariables.UserName);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }
        private void RefreshData()
        {
            string query = "SELECT * FROM Orders_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvOrders.DataSource = dataTable;
                }
                connection.Close();
            }
        }
    }
}
