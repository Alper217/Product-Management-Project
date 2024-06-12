using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static InventoryManagementSystem.Form1;

namespace InventoryManagementSystem
{
    
    public partial class AdministratorMenu : Form
    {
        string connectionString = $"Server=Alper;Database=InventoryManagementSystem;User Id=sa;Password=1;";
        public AdministratorMenu()
        {
            InitializeComponent();
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvUM.Rows[e.RowIndex];
                txtBID.Text = row.Cells["UserID"].Value.ToString();
                txtBNS.Text = row.Cells["UserName"].Value.ToString();
                txtBRole.Text = row.Cells["Role"].Value.ToString();
            }
        }
        //Page Openers
        private void btnUM_Click(object sender, EventArgs e)
        {
            pnlR.Visible = false;
            pnlPM.Visible = false;
            pnlOM.Visible = false;
            pnlSC.Visible = false;
            pnlSM.Visible = false;
            pnlCM.Visible = false;
            pnlUM.Visible = true;
            string query = "SELECT * FROM Users_Table";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvUM.DataSource = dataTable;
                }
            }

        }
        private void btnPM_Click(object sender, EventArgs e)
        {
            pnlR.Visible = false;
            pnlUM.Visible = false;
            pnlOM.Visible = false;
            pnlSC.Visible = false;
            pnlSM.Visible = false;
            pnlCM.Visible = false;
            pnlPM.Visible = true;
            string query = "SELECT * FROM Products_Table";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvPM.DataSource = dataTable;
                }
            }
        }
        private void btnSC_Click(object sender, EventArgs e)
        {
            pnlR.Visible = false;
            pnlUM.Visible = false;
            pnlOM.Visible = false;
            pnlSM.Visible = false;
            pnlCM.Visible = false;
            pnlPM.Visible = false;
            pnlSC.Visible = true;
            string query = "SELECT Products_Table.ProductID, Products_Table.Dealer, Products_Table.ProductName, Products_Table.StockAmount FROM Products_Table";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvSC.DataSource = dataTable;
                }
            }

        }
        private void btnOM_Click(object sender, EventArgs e)
        {
            pnlR.Visible = false;
            pnlUM.Visible = false;
            pnlSC.Visible = false;
            pnlSM.Visible = false;
            pnlCM.Visible = false;
            pnlPM.Visible = false;
            pnlOM.Visible = true;

            string query = "SELECT Customers_Table.CustomerID, Customers_Table.CustomerName, Orders_Table.OrderDate, " +
                           "Orders_Table.OrderID, Orders_Table.OrderStatus " +
                           "FROM Orders_Table INNER JOIN Customers_Table ON Orders_Table.CustomerID = Customers_Table.CustomerID;";

            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }

                if (dataTable.Rows.Count > 0)
                {
                    dgvOM.DataSource = dataTable;
                    dgvOM.Refresh();
                }
                else
                {
                    MessageBox.Show("Tablo boş. Gösterilecek veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnSM_Click(object sender, EventArgs e)
        {
            pnlR.Visible = false;
            pnlUM.Visible = false;
            pnlOM.Visible = false;
            pnlSC.Visible = false;
            pnlCM.Visible = false;
            pnlPM.Visible = false;
            pnlSM.Visible = true;
            string query = "SELECT  Products_Table.ProductID ,Products_Table.Dealer, Products_Table.ProductName, Products_Table.SupplierID, " +
                "Suppliers_Table.SupplierName, Suppliers_Table.CommInfo FROM Suppliers_Table INNER JOIN Products_Table" +
                " ON Suppliers_Table.SupplierID = Products_Table.SupplierID;";

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            dgvSM.DataSource = dataTable;
        }
        private void btnCM_Click(object sender, EventArgs e)
        {
            pnlR.Visible = false;
            pnlUM.Visible = false;
            pnlOM.Visible = false;
            pnlSC.Visible = false;
            pnlSM.Visible = false;
            pnlPM.Visible = false;
            pnlCM.Visible = true;
            string query = "SELECT Customers_Table.CustomerID, Customers_Table.CustomerName,Orders_Table.OrderDate," +
                " Orders_Table.OrderID, Orders_Table.OrderStatus FROM Customers_Table INNER JOIN Orders_Table ON Customers_Table.CustomerID = Orders_Table.CustomerID;";
                DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            dgvCM.DataSource = dataTable;
        }
        private void btnR_Click(object sender, EventArgs e)
        {
            pnlUM.Visible = false;
            pnlOM.Visible = false;
            pnlSC.Visible = false;
            pnlSM.Visible = false;
            pnlPM.Visible = false;
            pnlCM.Visible = false;
            pnlR.Visible = true;
            string query3 = "SELECT * FROM UserInformations_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command2 = new SqlCommand(query3, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command2);
                    DataTable dataTable2 = new DataTable();
                    adapter.Fill(dataTable2);
                    dgvUI.DataSource = dataTable2;
                }
            }
            string query = "SELECT * FROM OrderInformations_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvProductInformation.DataSource = dataTable;
                }
            }
            //Chart1 deneme
            string queryForChart1 = "SELECT ProductID, Piece FROM OrderDetails_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryForChart1, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Chart ayarları deneme
                chart1.Series.Clear();
                Series series = new Series("Product Pieces");
                series.ChartType = SeriesChartType.Pie;
                Dictionary<int, int> productPieces = new Dictionary<int, int>();
                while (reader.Read())
                {
                    int productID = reader.GetInt32(0);
                    int piece = reader.GetInt32(1);
                    if (productPieces.ContainsKey(productID))
                    {
                        productPieces[productID] += piece;
                    }
                    else
                    {
                        productPieces.Add(productID, piece);
                    }
                }
                foreach (var kvp in productPieces)
                {
                    string pointLabel = $"{kvp.Key} : {kvp.Value}";
                    DataPoint dataPoint = new DataPoint();
                    dataPoint.SetValueXY(kvp.Key.ToString(), kvp.Value);
                    dataPoint.Label = pointLabel;
                    series.Points.Add(dataPoint);
                }
                chart1.Series.Add(series);
                reader.Close();
            }
            //Chart 3
            string queryForL3 = "SELECT CustomerID, ProductID, TotalAmount FROM CanceledOrders_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryForL3, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<string> customerIDs = new List<string>();
                List<string> productIDs = new List<string>();
                List<decimal> totalAmounts = new List<decimal>();
                while (reader.Read())
                {
                    customerIDs.Add(reader["CustomerID"].ToString());
                    productIDs.Add(reader["ProductID"].ToString());
                    totalAmounts.Add(Convert.ToDecimal(reader["TotalAmount"]));
                }
                Series series = new Series();
                series.ChartType = SeriesChartType.Pie;
                var groupedCustomerIDs = customerIDs.GroupBy(id => id).Select(group => new { CustomerID = group.Key, Count = group.Count() });
                var groupedProductIDs = productIDs.GroupBy(id => id).Select(group => new { ProductID = group.Key, Count = group.Count() });
                foreach (var item in groupedProductIDs)
                {
                    series.Points.AddXY("ProductID: " + item.ProductID, item.Count);
                }
                chart3.Series.Clear();
                chart3.Series.Add(series);
                decimal totalAmountSum = totalAmounts.Sum();
                lblTotalPrice.Text = "Total Loss: " + totalAmountSum.ToString("N0") +"$";
            }
            //Chart 2
            string queryForM2 = "SELECT SUM(Orders_Table.TotalAmount) AS TotalAmount, OrderDetails_Table.ProductID " +
                     "FROM Orders_Table " +
                     "LEFT JOIN OrderDetails_Table ON Orders_Table.OrderID = OrderDetails_Table.OrderID " +
                     "GROUP BY OrderDetails_Table.ProductID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryForM2, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (chart2.Series.IndexOf("Total Amount") == -1)
                    {
                        Series series = new Series();
                        series.ChartType = SeriesChartType.Bar;
                        series.Name = "Total Amount";
                        chart2.Series.Add(series);
                    }

                    Series totalAmountSeries = chart2.Series["Total Amount"];
                    totalAmountSeries.Points.Clear(); // Önceki verileri temizle
                    decimal totalAmount = 0;
                    while (reader.Read())
                    {
                        totalAmountSeries.Points.AddXY(reader["ProductID"].ToString(), reader["TotalAmount"]);
                        totalAmount += Convert.ToDecimal(reader["TotalAmount"]);
                    }

                    lblTotalAmount.Text = $"Total Amount : {totalAmount.ToString("N0")}$";
                }
                connection.Close();
            }

        }
        // Product Management Buttons
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                    connection.Open();
                    string query = "INSERT INTO Products_Table (ProductName, StockAmount, UnitPrice, SupplierID, Dealer) VALUES (@ProductName, @StockAmount, @UnitPrice, @SupplierID, @Dealer)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ProductName", txtBPN.Text);
                    command.Parameters.AddWithValue("@StockAmount", txtBSA.Text);
                    command.Parameters.AddWithValue("@UnitPrice", txtBUP.Text);
                    command.Parameters.AddWithValue("@Dealer", txtBDealer.Text);
                    command.Parameters.AddWithValue("@SupplierID", txtBSI.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Veri başarıyla eklendi!");
                        }
                        else
                        {
                            MessageBox.Show("Veri eklenirken bir hata oluştu!");
                        }
                    }
            }
        }
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Products_Table SET ProductName = @ProductName, StockAmount = @StockAmount, UnitPrice = @UnitPrice, SupplierID = @SupplierID, Dealer = @Dealer WHERE ProductID = @ProductID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", txtBPN.Text);
                    command.Parameters.AddWithValue("@StockAmount", txtBSA.Text);
                    command.Parameters.AddWithValue("@UnitPrice", txtBUP.Text);
                    command.Parameters.AddWithValue("@SupplierID", txtBSI.Text);
                    command.Parameters.AddWithValue("@Dealer", txtBDealer.Text);
                    command.Parameters.AddWithValue("@ProductID", txtBUpdateID.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri başarıyla güncellendi!");
                    }
                    else
                    {
                        MessageBox.Show("Veri güncellenirken bir hata oluştu!");
                    }
                }
            }
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Products_Table WHERE ProductName = @ProductName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Silinecek verinin ID'sini parametre olarak ekleyin
                    command.Parameters.AddWithValue("@ProductName",txtBPN.Text);

                    // Sorguyu çalıştırın
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Data with the specified name could not be found or could not be deleted!");
                    }
                }
            }
        }
        //Supplier Management Buttons
        private void btnUpdSupplier_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectedValue = listBox2.SelectedItem.ToString();
                string query = $"UPDATE Products_Table SET SupplierID = @NewSupplierID WHERE ProductID = @ProductID";
                int supplierID;
                if (int.TryParse(txtBUPS.Text, out supplierID))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@NewSupplierID", selectedValue);
                        comm.Parameters.AddWithValue("@ProductID", supplierID);
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
        }
        //User Management Buttons ///////////////////////////////////
        private void btnChange_Click(object sender, EventArgs e)
        {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string selectedValue = listBox1.SelectedItem.ToString();
                    string query = $"UPDATE Users_Table SET Role = @NewRole WHERE UserName = @Username";
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@NewRole", selectedValue);
                        comm.Parameters.AddWithValue("@Username", txtBNS.Text);
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
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                string currentTime = DateTime.Now.ToString();
                connection2.Open();
                string queryStatus = "INSERT INTO UserInformations_Table (UserID, Name, ProcessDate, Status, ByWho) VALUES (@UserID, @Name, @ProcessDate, @Status, 'Admin');";
                string status = listBox1.SelectedItem.ToString();
                using (SqlCommand command = new SqlCommand(queryStatus, connection2))
                {
                    command.Parameters.AddWithValue("@UserID", txtBID.Text);
                    command.Parameters.AddWithValue("@Name", txtBNS.Text);
                    command.Parameters.AddWithValue("@ProcessDate", currentTime);
                    command.Parameters.AddWithValue("@Status", "Change to "+ status);

                    command.ExecuteNonQuery();
                }
                connection2.Close();
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM Users_Table WHERE UserName = '{txtBNS.Text}'";
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = comm.ExecuteReader();
                        if (reader.Read())
                        {
                            txtBID.Text = reader.GetValue(0).ToString();
                            txtBNS.Text = (string)reader.GetValue(1);
                            txtBRole.Text = (string)reader.GetValue(3);
                        }
                        else
                            MessageBox.Show("User Not Found.");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }

        }
        //Stock Control Buttons
        private void btnControlStock_Click(object sender, EventArgs e)
        {
            string query = "SELECT ProductName FROM Products_Table WHERE StockAmount < 5";
            List<string> productsLowStock = new List<string>(); 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        productsLowStock.Add(productName); 
                    }
                }
            }
            if (productsLowStock.Count > 0)
            {
                string message = "The stocks of the following products are about to run out:\n";
                foreach (string productName in productsLowStock)
                {
                    message += "•" + productName + "\n";
                }
                lblStockControl.Text = message;
            }
            else
            {
                lblStockControl.Text = "No products with low stock.";
            }
        }
        //Customer Management Buttons
        private void btnSearchCN_Click(object sender, EventArgs e)
        {
            string customerName = txtBCNS.Text.Trim();
            if (string.IsNullOrEmpty(customerName))
            {
                ShowAllRecords();
            }
            string query = "SELECT Customers_Table.CustomerID, Customers_Table.CustomerName, Orders_Table.OrderDate, " +
                "Orders_Table.OrderID, Orders_Table.OrderStatus FROM Customers_Table INNER JOIN Orders_Table ON " +
                "Customers_Table.CustomerID = Orders_Table.CustomerID WHERE Customers_Table.CustomerName LIKE @CustomerName";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", "%" + customerName + "%");
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvCM.DataSource = table;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }
        private void ShowAllRecords()
        {
            string query = "SELECT Customers_Table.CustomerID, Customers_Table.CustomerName, Orders_Table.OrderDate, " +
                "Orders_Table.OrderID, Orders_Table.OrderStatus FROM Customers_Table INNER JOIN Orders_Table ON " +
                "Customers_Table.CustomerID = Orders_Table.CustomerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvCM.DataSource = table;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }//FOR btnSearchCN_Click
        // Order Management Button
        private void btnStatusChange_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectedChoice = listBox3.SelectedItem.ToString();
                string query = "UPDATE Orders_Table SET OrderStatus = @OrderStatus WHERE OrderID = @OrderID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderStatus", selectedChoice);
                    int orderID;
                    if (int.TryParse(txtBUOS.Text, out orderID))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderID);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Veri başarıyla güncellendi!");
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen ID'ye sahip sipariş bulunamadı!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz OrderID girdiniz!");
                    }
                }
            }
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                string currentTime = DateTime.Now.ToString();
                connection2.Open();
                string queryStatus = "INSERT INTO OrderInformations_Table (OrderID, CustomerID, ProcessDate, Status, ByWho) VALUES (@OrderID, @CustomerID, @ProcessDate, @Status, 'Admin');";
                string status = listBox3.SelectedItem.ToString();
                using (SqlCommand command = new SqlCommand(queryStatus, connection2))
                {
                    command.Parameters.AddWithValue("@OrderID", txtBUOS.Text);
                    command.Parameters.AddWithValue("@CustomerID", GlobalVariablesCustomer.CustomerId);
                    command.Parameters.AddWithValue("@ProcessDate", currentTime);
                    command.Parameters.AddWithValue("@Status","Change to "+ status);

                    command.ExecuteNonQuery();
                }
                connection2.Close();
            }

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void AdministratorMenu_Load(object sender, EventArgs e)
        {
            string query2 = "SELECT * FROM Customers_Table";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvProductInformation.DataSource = dataTable;
                }
                connection.Close();
            }
            chart1.Titles.Add("Daily Order Recap");
            chart2.Titles.Add("Order Based Profit Rate");
            chart3.Titles.Add("Loss Rate \n(Cancelled Products)");
        }
    }

}



