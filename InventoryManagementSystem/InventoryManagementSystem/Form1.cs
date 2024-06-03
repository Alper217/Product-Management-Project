using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int customerID { get; set; }
        public static class GlobalVariablesCustomer
        {
            public static int CustomerId { get; set; }
        }
        public static class GlobalVariables
        {
            public static string UserName {  get; set; }
            public static int UserId { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            this.Text = "Online Store"; 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                String str = "server=Alper;database=InventoryManagementSystem;UID=sa;password=1";
                String query = "select * from LogIn_Table";
                conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            pnlSıgnOrLog.Visible = true;
        }

        private void btnUserSıgnIn_Click(object sender, EventArgs e)
        {
            pnlLogIn.Visible = false;
            pnlSıgnIn.Visible = true;
            pnlSıgnOrLog.Visible=false;
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            pnlPersonalInfo.Visible = false;
            pnlSıgnIn.Visible = false;
            pnlLogIn.Visible = true;
            pnlSıgnOrLog.Visible = false;
        }
        // Giriş ve Kayıt bölümü ile alakalı 
        private void chkboxShowPassword1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxShowPassword1.Checked == true)
                txtBoxPassword.UseSystemPasswordChar = false;
            else if (chkboxShowPassword1.Checked == false)
                txtBoxPassword.UseSystemPasswordChar = true;
        }
        private void chkBxShowPassword2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxShowPassword2.Checked == true)
            {
                txtBoxPasswordNew1.UseSystemPasswordChar = false;
                txtBoxPasswordNew2.UseSystemPasswordChar = false;
            }
            else if (chkBxShowPassword2.Checked == false)
            {
                txtBoxPasswordNew1.UseSystemPasswordChar = true;
                txtBoxPasswordNew2.UseSystemPasswordChar = true;
            }
        }

        private void btnContinueLogIn_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Users_Table WHERE UserName=@username AND Password=@password";
            SqlParameter prm1 = new SqlParameter("username", txtBoxUsername.Text);
            SqlParameter prm2 = new SqlParameter("password", txtBoxPassword.Text);

            if (string.IsNullOrEmpty(txtBoxUsername.Text.Trim()) || string.IsNullOrEmpty(txtBoxPassword.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(prm1);
                command.Parameters.Add(prm2);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int userId = (int)dt.Rows[0]["UserID"];
                    GlobalVariables.UserId = userId;
                    string userName = dt.Rows[0]["UserName"].ToString();
                    GlobalVariables.UserName = userName;

                    // Retrieve the user role
                    string userRole = dt.Rows[0]["Role"].ToString();

                    // Retrieve CustomerID from Customers_Table using UserID
                    string customerSql = "SELECT CustomerID FROM Customers_Table WHERE UserID=@userId";
                    SqlParameter prmCustomer = new SqlParameter("userId", userId);
                    SqlCommand customerCommand = new SqlCommand(customerSql, conn);
                    customerCommand.Parameters.Add(prmCustomer);

                    DataTable customerDt = new DataTable();
                    SqlDataAdapter customerDa = new SqlDataAdapter(customerCommand);
                    customerDa.Fill(customerDt);

                    if (customerDt.Rows.Count > 0)
                    {
                        int customerId = Convert.ToInt32(customerDt.Rows[0]["CustomerID"]);
                        GlobalVariablesCustomer.CustomerId = customerId;
                    }

                    if (userRole == "Administrator")
                    {
                        AdministratorMenu adminMenu = new AdministratorMenu();
                        adminMenu.Show();
                        this.Hide();
                    }
                    else if (userRole == "Customer")
                    {
                        CustomerMenu customerMenu = new CustomerMenu();
                        customerMenu.Show();
                        this.Hide();
                    }
                    else if (userRole == "Team Manager")
                    {
                        TeamManagerMenu teamMenu = new TeamManagerMenu();
                        teamMenu.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnContinueSıgnIn_Click_1(object sender, EventArgs e)
        {
            pnlSıgnIn.Visible = false;
            pnlPersonalInfo.Visible = true;   
        }

        private void btnSıgnIn_Click(object sender, EventArgs e)
        {
            if (txtBoxPasswordNew1.Text == txtBoxPasswordNew2.Text)
            {
                string selectedGender = lbGender.SelectedItem.ToString();
                string newUsername = txtBoxUsernameNew.Text;
                string newPassword = txtBoxPasswordNew2.Text;
                string userFullName = txtBFName.Text;
                string userCommInfo = txtBCInfo.Text;
                string userAddress = txtBAddress.Text;

                string connectionString = $"server=Alper;database=InventoryManagementSystem;UID=sa;password=1";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                        string newsql = "INSERT INTO Users_Table (UserName, Password, Role, Gender) VALUES (@UserName, @Password, 'Customer', @Gender); SELECT SCOPE_IDENTITY();";
                        int newUserId;
                        using (SqlCommand command = new SqlCommand(newsql, conn, transaction))
                        {
                            command.Parameters.AddWithValue("@UserName", newUsername);
                            command.Parameters.AddWithValue("@Password", newPassword);
                            command.Parameters.AddWithValue("@Gender",selectedGender);
                            newUserId = Convert.ToInt32(command.ExecuteScalar());
                        }
                        string newUserInfosql = "INSERT INTO Customers_Table (UserID, CustomerName, CommunicationInfo, Adress, Gender) VALUES (@UserID, @CustomerName, @CommunicationInfo, @Adress, @Gender)";
                        using (SqlCommand command = new SqlCommand(newUserInfosql, conn, transaction))
                        {
                            command.Parameters.AddWithValue("@UserID", newUserId);
                            command.Parameters.AddWithValue("@CustomerName", userFullName);
                            command.Parameters.AddWithValue("@CommunicationInfo", userCommInfo);
                            command.Parameters.AddWithValue("@Adress", userAddress);
                            command.Parameters.AddWithValue("@Gender", selectedGender);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Successfully processed", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        connection2.Open();
                        string queryGetUserID = "SELECT UserID FROM Users_Table WHERE Username = @Username;";
                        SqlCommand getUserIDCommand = new SqlCommand(queryGetUserID, connection2);
                        getUserIDCommand.Parameters.AddWithValue("@Username", newUsername); 
                        int userIDFromUsersTable = 0;
                        using (SqlDataReader reader = getUserIDCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userIDFromUsersTable = reader.GetInt32(0);  //BURAYA DİKKAT BURADAN KALDIN
                            }
                        }
                        string queryStatus = "INSERT INTO UserInformations_Table (UserID, Name, ProcessDate, Status, ByWho) VALUES (@UserID, @Name, @ProcessDate, 'Set To Customer', 'Self');";
                        using (SqlCommand command = new SqlCommand(queryStatus, connection2))
                        {
                            command.Parameters.AddWithValue("@UserID", userIDFromUsersTable);
                            command.Parameters.AddWithValue("@Name", newUsername);
                            command.Parameters.AddWithValue("@ProcessDate", DateTime.Now);

                            command.ExecuteNonQuery();
                        }

                        connection2.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Passwords do not match each other", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Geri Yönlendirme tuşları
        private void lblBack_Click(object sender, EventArgs e)
        {
            pnlLogIn.Visible = false;
            pnlSıgnOrLog.Visible = true;
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            pnlSıgnIn.Visible = false;
            pnlSıgnOrLog.Visible = true;
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            pnlPersonalInfo.Visible = false;
            pnlSıgnOrLog.Visible=true;
        }

        private void lbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbGender.SelectedItem != null)
            {
                string selectedGender = lbGender.SelectedItem.ToString();
                textBox1.Text = selectedGender;
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            string senderEmail = "smtpmailsender11@gmail.com";
            string password = "zzgq xmpz tvie ibhh";
            string receiverEmail = btnSendMail.Text;
            string subject = "Reset Password";
            string body = "Reset";
            // SMTP sunucusu ve portu
            string smtpServer = "smtp.gmail.com";
            int port = 587; 
            try
            {
                using (SmtpClient client = new SmtpClient(smtpServer, port))
                {
                    client.EnableSsl = true; 
                    client.Credentials = new NetworkCredential(senderEmail, password);
                    MailMessage mail = new MailMessage(senderEmail, receiverEmail, subject, body);
                    client.Send(mail);
                    MessageBox.Show("Mail Sent");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderilirken hata oluştu: " + ex.InnerException);
            }
        }
    }
}
