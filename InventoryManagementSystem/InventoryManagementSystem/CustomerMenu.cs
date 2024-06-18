using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static InventoryManagementSystem.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryManagementSystem
{

    public partial class CustomerMenu : Form
    {
        public static class GlobalVariablesTotalPrice
        {
            public static int TotalPrice { get; set; }
        }
        public static class GlobalVariablesOrders
        {
            public static int orderID { get; set; }
            public static int orderDetails { get; set; }
            public static string productID { get; set; }
        }
        string connectionString = "Server=Alper;Database=InventoryManagementSystem;User Id=sa;Password=1;";
        public CustomerMenu()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            this.Text = "Online Store";
        } //deneme
        private void CustomerMenu_Load(object sender, EventArgs e)
        {
            int userId = GlobalVariables.UserId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT CustomerName, Gender FROM Customers_Table WHERE UserID=@userId";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("userId", userId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string customerName = reader["CustomerName"].ToString();
                        string gender = reader["Gender"].ToString();
                        string selectedGender = (gender == "Male") ? "Mr. " : "Ms. ";
                        lblWelcome.Text = "Welcome " + selectedGender + customerName;
                    }
                    else
                    {
                        lblWelcome.Text = "Customer not found.";
                    }
                }
            }
        }
        //Main Buttons
        private void btnSP_Click(object sender, EventArgs e)
        {
            pnlProducts.Visible = true;
            pnlMO.Visible = false;
            pnlMyShoppingCart.Visible = false;
            pnlUS.Visible = false;
            string query = "SELECT * FROM Products_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvSeeProducts.DataSource = dataTable;
                }
            }
        }
        private void btnMSC_Click(object sender, EventArgs e)
        {
            int userId = GlobalVariables.UserId;
            pnlMyShoppingCart.Visible = true;

            string query = "SELECT ProductID, ProductName, Price, Amount, TotalPrice FROM CardList WHERE UserId = @UserID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvMHC.DataSource = dataTable;
                }
            }
            string queryForTotal = "SELECT SUM(TotalPrice) FROM CardList";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryForTotal, connection);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        lblTotalAmount.Text = "Total Price: " + result.ToString() + "$";

                    }
                    else
                    {
                        lblTotalAmount.Text = "No data found.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            pnlMyShoppingCart.Visible = true;
            pnlMO.Visible = false;
            pnlProducts.Visible = false;
            pnlUS.Visible = false;
        }
        private void btnUS_Click(object sender, EventArgs e)
        {
            pnlMyShoppingCart.Visible = false;
            pnlMO.Visible = false;
            pnlProducts.Visible = false;
            pnlUS.Visible = true;
            txtBSUS.Text = GlobalVariables.UserName;
            txtBMailUS.Text = GlobalVariablesMail.mailAdress;
        }
        private void btnMO_Click(object sender, EventArgs e)
        {
            pnlMO.Visible = true;
            pnlMyShoppingCart.Visible = false;
            pnlProducts.Visible = false;
            pnlUS.Visible = false;
            string sql = "SELECT OrderID, OrderDate, TotalAmount, OrderStatus, PieceCount FROM Orders_Table WHERE CustomerID=@userId;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("userId", GlobalVariables.UserId));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                    dgvMO.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        //Search Panel Buttons
        private void dgvSeeProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedProductName = dgvSeeProducts.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                lblSelectedP.Text = selectedProductName;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            btnMyOrders.Visible = true;
            btnSearchProducts.Visible = true;
            btnUserSettings.Visible = true;
            btnMySCart.Visible = true;
            pnlProducts.Visible = false;
        }
        private void btnSelectOptions_Click(object sender, EventArgs e)
        {
            int minAmount, maxAmount;
            string productName = txtBSearchName.Text.Trim();

            string query = "SELECT * FROM Products_Table WHERE 1=1";

            if (!string.IsNullOrEmpty(productName))
            {
                query += " AND ProductName LIKE @ProductName";
            }

            if (int.TryParse(txtBMin.Text, out minAmount))   
            {
                query += " AND UnitPrice >= @MinAmount";
            }

            if (int.TryParse(txtBMax.Text, out maxAmount))
            {
                query += " AND UnitPrice <= @MaxAmount";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(productName))
                    {
                        command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");
                    }

                    if (int.TryParse(txtBMin.Text, out minAmount))
                    {
                        command.Parameters.AddWithValue("@MinAmount", minAmount);
                    }

                    if (int.TryParse(txtBMax.Text, out maxAmount))
                    {
                        command.Parameters.AddWithValue("@MaxAmount", maxAmount);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvSeeProducts.DataSource = dataTable;
                }
            }
        }
        private void btnAddCart_Click_1(object sender, EventArgs e)
        {
            int userId = GlobalVariables.UserId;
            string userName = GlobalVariables.UserName;

            if (dgvSeeProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSeeProducts.SelectedRows[0];
                string productName = selectedRow.Cells["ProductName"].Value.ToString();
                string productId = selectedRow.Cells["ProductID"].Value.ToString();
                GlobalVariablesOrders.productID = productId;
                object price = selectedRow.Cells["UnitPrice"].Value;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string checkExistingQuery = "SELECT COUNT (*) FROM CardList WHERE ProductID = @ProductID AND UserID = @UserID";
                    SqlCommand checkExistingCommand = new SqlCommand(checkExistingQuery, conn);
                    checkExistingCommand.Parameters.AddWithValue("@ProductID", productId);
                    checkExistingCommand.Parameters.AddWithValue("@UserID", userId);

                    int existingCount = (int)checkExistingCommand.ExecuteScalar();

                    if (existingCount > 0)
                    {
                        string updateQuery = "UPDATE CardList SET Amount = Amount + 1 , TotalPrice = TotalPrice + Price  WHERE ProductID = @ProductID AND UserID = @UserID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
                        updateCommand.Parameters.AddWithValue("@ProductID", productId);
                        updateCommand.Parameters.AddWithValue("@UserID", userId);
                        updateCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO CardList (UserID, UserName, ProductID, ProductName, Price, Amount ,TotalPrice) VALUES (@UserID, @UserName, @ProductID, @ProductName, @Price, @Amount , @TotalPrice)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                        insertCommand.Parameters.AddWithValue("@UserID", userId);
                        insertCommand.Parameters.AddWithValue("@UserName", userName);
                        insertCommand.Parameters.AddWithValue("@ProductID", productId);
                        insertCommand.Parameters.AddWithValue("@ProductName", productName);
                        insertCommand.Parameters.AddWithValue("@Price", price);
                        insertCommand.Parameters.AddWithValue("@Amount", 1);
                        insertCommand.Parameters.AddWithValue("@TotalPrice", price);
                        insertCommand.ExecuteNonQuery();
                    }

                    string amountQuery = "SELECT Amount FROM CardList WHERE ProductID=@ProductID AND UserID=@UserID";
                    SqlCommand amountCommand = new SqlCommand(amountQuery, conn);
                    amountCommand.Parameters.AddWithValue("@ProductID", productId);
                    amountCommand.Parameters.AddWithValue("@UserID", userId);
                    int currentAmount = Convert.ToInt32(amountCommand.ExecuteScalar());
                    if (currentAmount == 10)
                    {
                        MessageBox.Show("Purchase limit reached.");
                    }
                    else if (currentAmount > 10)
                    {
                        MessageBox.Show("Purchase limit exceeded.");
                    }
                    else
                    {
                        MessageBox.Show("Product added to cart successfully.");
                    }

                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a product.");
            }

        }
        // MyCardList Buttons
        private void btnBackTwo_Click(object sender, EventArgs e)
        {
            btnMyOrders.Visible = true;
            btnSearchProducts.Visible = true;
            btnUserSettings.Visible = true;
            btnMySCart.Visible = true;
            pnlMyShoppingCart.Visible = false;
        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            int userId = GlobalVariables.UserId;
            string userName = GlobalVariables.UserName;

            if (dgvMHC.SelectedRows.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvMHC.SelectedRows)
                    {
                        if (!row.IsNewRow && !row.Cells.Cast<DataGridViewCell>().All(c => c.Value == null))
                        {
                            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                            int amount = Convert.ToInt32(row.Cells["Amount"].Value);
                            int productId = Convert.ToInt32(row.Cells["ProductID"].Value);

                            GlobalVariablesOrders.orderDetails = amount;
                            string insertQuery = "INSERT INTO Orders_Table (CustomerID, OrderDate, TotalAmount, OrderStatus, PieceCount) " +
                                                 "OUTPUT INSERTED.OrderID " +
                                                 "VALUES (@CustomerID, @OrderDate, @TotalAmount, 'Order Taken', @PieceCount)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                            {
                                insertCommand.Parameters.AddWithValue("@CustomerID", userId);
                                insertCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                                insertCommand.Parameters.AddWithValue("@TotalAmount", price);
                                insertCommand.Parameters.AddWithValue("@PieceCount", amount);

                                int newOrderId = (int)insertCommand.ExecuteScalar();
                                GlobalVariablesOrders.orderID = newOrderId;
                            }
                            string updateStockQuery = "UPDATE Products_Table SET StockAmount = StockAmount - 1 WHERE ProductID = @ProductID";

                            using (SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, conn))
                            {
                                updateStockCommand.Parameters.AddWithValue("@ProductID", productId);
                                updateStockCommand.ExecuteNonQuery();
                            }
                            string deleteCardListQuery = "DELETE FROM CardList WHERE ProductID = @ProductID"; // buraya bak

                            using (SqlCommand deleteCardListCommand = new SqlCommand(deleteCardListQuery, conn))
                            {
                                deleteCardListCommand.Parameters.AddWithValue("@ProductID", productId);
                                deleteCardListCommand.ExecuteNonQuery();
                            }
                            MessageBox.Show("Product was purchased");
                        }
                    }

                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("No items selected. Please select products before proceeding.");
            }

            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                DateTime currentTime = DateTime.Now;
                connection2.Open();
                string queryStatus = "INSERT INTO OrderInformations_Table (OrderID, CustomerID, ProcessDate, Status, ByWho) VALUES (@OrderID, @CustomerID, @ProcessDate, 'Order Taken', @ByWho);";
                using (SqlCommand command = new SqlCommand(queryStatus, connection2))
                {
                    command.Parameters.AddWithValue("@OrderID", GlobalVariablesOrders.orderID);
                    command.Parameters.AddWithValue("@CustomerID", GlobalVariablesCustomer.CustomerId);
                    command.Parameters.AddWithValue("@ProcessDate", currentTime); 
                    command.Parameters.AddWithValue("@ByWho", GlobalVariables.UserName);
                    command.ExecuteNonQuery();
                }
                connection2.Close();
            }
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                string currentTime = DateTime.Now.ToString();
                connection2.Open();
                string queryStatus = "INSERT INTO OrderDetails_Table (OrderID, ProductID, Piece) VALUES (@OrderID, @ProductID, @Piece);";
                using (SqlCommand commandDetails = new SqlCommand(queryStatus, connection2))
                {
                    commandDetails.Parameters.AddWithValue("@OrderID", GlobalVariablesOrders.orderID);
                    commandDetails.Parameters.AddWithValue("@ProductID", txtBID.Text);
                    commandDetails.Parameters.AddWithValue("@Piece", GlobalVariablesOrders.orderDetails);
                    commandDetails.ExecuteNonQuery();   //hatalı buradan kaldım
                }
                connection2.Close();
            }
        }

        // My Orders Buttons
        private void btnBack2_Click_1(object sender, EventArgs e)
        {
            btnMyOrders.Visible = true;
            btnSearchProducts.Visible = true;
            btnUserSettings.Visible = true;
            btnMySCart.Visible = true;
            pnlMO.Visible = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedProductName = dgvMO.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                txtBID.Text = selectedProductName;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvMO.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMO.SelectedRows[0];
                int orderId = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);
                int totalAmount = Convert.ToInt32(selectedRow.Cells["TotalAmount"].Value); // Seçilen satırın TotalAmount değerini al
                string sql = "DELETE FROM Orders_Table WHERE OrderID=@orderId AND (OrderStatus='Order Taken' OR OrderStatus='Preparing')";
                // Order Cancel Interaction
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order canceled.");

                            // Canceled Products Log
                            string sqlCancel = "INSERT INTO CanceledOrders_Table (CustomerID, ProductID, TotalAmount, ByWho) VALUES (@CustomerID, @ProductID, @TotalAmount, @ByWho)";
                            using (SqlCommand logCmd = new SqlCommand(sqlCancel, conn))
                            {
                                logCmd.Parameters.AddWithValue("@CustomerID", GlobalVariablesCustomer.CustomerId);
                                logCmd.Parameters.AddWithValue("@ProductID", orderId); // Bu satırda orderId kullandım, eğer ProductID'nin başka bir yere eşitlenmesi gerekiyorsa onu kullan.
                                logCmd.Parameters.AddWithValue("@TotalAmount", totalAmount); // Önceki adımda aldığımız totalAmount'u kullan
                                logCmd.Parameters.AddWithValue("@ByWho", GlobalVariables.UserName);
                                int logRowsAffected = logCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            MessageBox.Show("The order can no longer be canceled");
                        }
                    }
                    string updateStockQuery = "UPDATE Products_Table SET StockAmount = StockAmount + 1 WHERE ProductID = @ProductID";

                    using (SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, conn))
                    {
                        updateStockCommand.Parameters.AddWithValue("@ProductID", GlobalVariablesOrders.productID);
                        updateStockCommand.ExecuteNonQuery();
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }

        }

        // Çıkış tuşu
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wanna be quit", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("You pressed No.");
            }
        }
        private void dgvMHC_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedID = dgvMHC.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
                txtBSelected.Text = selectedID;
            }
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtBNewPassword.Text != txtBNewPassword2.Text)
            {
                MessageBox.Show("Passwords don't match");
            }
            else
            {
                string connectionString = $"server=Alper;database=InventoryManagementSystem;UID=sa;password=1";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT Password FROM Users_Table WHERE UserName = @UserName";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@UserName", txtBSUS.Text);
                    object result = selectCommand.ExecuteScalar();

                    if (result != null && result.ToString() == txtBOldPassword.Text)
                    {
                        string updateQuery = "UPDATE Users_Table SET Password = @password WHERE UserName = @UserName";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@password", txtBNewPassword2.Text);
                        updateCommand.Parameters.AddWithValue("@UserName", txtBSUS.Text);
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated susccessfully.");
                        }
                        else
                        {
                            MessageBox.Show("Password could not updated.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Old password is wrong.");
                    }
                }
            }
        }
    }
}
