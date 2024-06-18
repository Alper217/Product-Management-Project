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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        public static class GlobalVariablesMail
        {
            public static string mailAdress { get; set; }
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
                MessageBox.Show("Please enter a valid value", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string userRole = dt.Rows[0]["Role"].ToString();
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
                    MessageBox.Show("Invalid username or password", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string mail = txtBMail.Text;
                string connectionString = $"server=Alper;database=InventoryManagementSystem;UID=sa;password=1";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                        string newsql = "INSERT INTO Users_Table (UserName, Password, Role, Gender, Mail) VALUES (@UserName, @Password, 'Customer', @Gender, @Mail); SELECT SCOPE_IDENTITY();";
                        int newUserId;
                        using (SqlCommand command = new SqlCommand(newsql, conn, transaction))
                        {
                            command.Parameters.AddWithValue("@UserName", newUsername);
                            command.Parameters.AddWithValue("@Password", newPassword);
                            command.Parameters.AddWithValue("@Gender",selectedGender);
                            command.Parameters.AddWithValue("@Mail",mail);
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
        // Şifre sıfırlama ve SMTP kodları
        private void lbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbGender.SelectedItem != null)
            {
                string selectedGender = lbGender.SelectedItem.ToString();
                textBox1.Text = selectedGender;
            }
        }
        private void LinkRPass_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlEmail.Visible = true;
            pnlLogIn.Visible=false;
            pnlPersonalInfo.Visible=false;
            pnlSıgnIn.Visible=false;
            pnlSıgnOrLog.Visible=false;
        }
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            string randomCode = RandomCode(6);
            string senderEmail = "smtpmailsender11@gmail.com";
            string password = "zzgq xmpz tvie ibhh";
            string receiverEmail = txtBRMail.Text;
            string subject = "Reset Password";
            string body = $"Your reset code : {randomCode}";
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
            string connectionString = $"server=Alper;database=InventoryManagementSystem;UID=sa;password=1";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string insertCode = "INSERT INTO UserCode_Table(Mail, Code) VALUES (@Mail, @Code);";
                using (SqlCommand command = new SqlCommand(insertCode, conn))
                {
                    command.Parameters.AddWithValue("@Mail", txtBRMail.Text);
                    command.Parameters.AddWithValue("@Code", randomCode);
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            pnlEmail.Visible = false;
            pnlReset.Visible = true;
        }
        private void btnBackM_Click(object sender, EventArgs e)
        {
            pnlSıgnOrLog.Visible = true;
            pnlEmail.Visible=false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtBNewPM.UseSystemPasswordChar = false;
                txtBNewPM2.UseSystemPasswordChar = false;
            }
            else if (checkBox1.Checked == false)
            {
                txtBNewPM.UseSystemPasswordChar = true;
                txtBNewPM2.UseSystemPasswordChar = true;
            }
        }

        private void btnBackNM_Click(object sender, EventArgs e)
        {
            pnlReset.Visible = false;
            pnlEmail.Visible=true;
        }
        static string RandomCode(int longs)
        {
            const string karakterler = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            StringBuilder conclusion = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < longs; i++)
            {
                int index = random.Next(karakterler.Length);
                conclusion.Append(karakterler[index]);
            }
            return conclusion.ToString();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (txtBNewPM.Text != txtBNewPM2.Text)
            {
                MessageBox.Show("Textbox1 ve Textbox2 değerleri aynı değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string connectionString = $"server=Alper;database=InventoryManagementSystem;UID=sa;password=1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                    connection.Open();
                    string selectQuery = "SELECT Password FROM Users_Table WHERE mail = @mail";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@mail", txtBRMail.Text);

                    object result = selectCommand.ExecuteScalar();

                    if (result != null)
                    {
                        string updateQuery = "UPDATE Users_Table SET Password = @password WHERE mail = @mail";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@password", txtBNewPM.Text);
                        updateCommand.Parameters.AddWithValue("@mail", txtBRMail.Text);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password Updated Successfully!", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pnlEmail.Visible = false;
                            pnlReset.Visible = false;
                            pnlSıgnOrLog.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Error Occurred while updating  the password!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("E-Mail not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }
    }
}
