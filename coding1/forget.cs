using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace coding1
{
    public partial class forget : Form
    {
        public forget()
        {
            InitializeComponent();
        }

        

       

        
        
       public static  async Task<string> SendResetCodeEmail(string recipientEmail, string resetCode)
        {
            try
            {
                await Task.Delay(2000);
                string fromEmail = "computertipstricks0308@gmail.com";
                string password = "rvpp tcsz udsq yhqy";

                MailMessage message = new MailMessage();
                message.To.Add(recipientEmail);
                message.From = new MailAddress(fromEmail);
                message.Body = "Your new password for Code AI is : " + resetCode;
                message.Subject = "New Password";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromEmail, password);

                smtp.Send(message);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send code. Error: " + ex.Message);
            }
            return " done";
        }
        static string GenerateRandomPassword()
            {
                const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
                StringBuilder sb = new StringBuilder();
                Random random = new Random();

                for (int i = 0; i < 12; i++)
                {
                    int index = random.Next(validChars.Length);
                    sb.Append(validChars[index]);
                }

                return sb.ToString();
            }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please Enter Your Email first ", "Error");
            }
            else
            {


                // Email to check


                // Generate a random strong password
                string newPassword = GenerateRandomPassword();
                MySqlConnection connection = Program.conn;

                try
                {
                    // Connect to the database
                    connection.Open();

                    // Check if the email exists in the database
                    string query = "SELECT COUNT(*) FROM users WHERE email = @Email";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    int emailCount = Convert.ToInt32(command.ExecuteScalar());

                    if (emailCount > 0)
                    {
                        // Email exists, update the password
                        query = "UPDATE users SET password = @Password WHERE email = @Email";
                        command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Password", newPassword);
                        command.Parameters.AddWithValue("@Email", email);
                        command.ExecuteNonQuery();


                        pro pro = new pro();
                        pro.Show();
                        string a = await SendResetCodeEmail(email, newPassword);

                        pro.Dispose();

                        MessageBox.Show("Password reset successfully and sent to your email.");

                    }
                    else
                    {
                        MessageBox.Show("Email not found in the Records.");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }


            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            
            this.Dispose();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click_1(sender, e);
            }
        }

        private void forget_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode == Keys.F4)
            {
                // Your code to handle Ctrl + Escape combination
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }


