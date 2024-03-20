using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coding1
{
    public partial class signup : Form
    {
      

        public signup()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

            Form1 form1 = new Form1();
            // Exit the application when Form1 is closed
            form1.Show();
            this.Dispose();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            pro pro=new pro();
            pro.Show();
            string a = await register();
            pro.Dispose();


        }
        private async Task<string> register()
        {
            MySqlConnection con = Program.conn; // Initialize MySqlConnection object

            string email = textBox1.Text;
            string username = textBox3.Text;
            string phone = textBox4.Text;
            string password = textBox2.Text;

            if (con != null)

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please input all fields");
                }
                else if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format");

                }

                else if (phone.Length != 11)
                {
                    MessageBox.Show("Invalid Phone number");

                }
                else if (password.Length < 8)
                {
                    MessageBox.Show("Password should be minimum 8 charachters");

                }
                else
                {
                    // Validate email format

                    // Check if any field is empty
                    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Please fill all the fields");
                    }
                    else
                    {
                        await Task.Delay(2000);

                        // Check if username or email is already registered
                        if (IsUserOrEmailRegistered(username, email))
                        {
                            MessageBox.Show("Username or email is already registered");
                            return "";
                        }

                        // Query to insert data into the users table
                        string query = "INSERT INTO users (username, email, phone, password) VALUES (@username, @email, @phone, @password)";

                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            // Set parameter values
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@phone", phone);
                            cmd.Parameters.AddWithValue("@password", password);

                            try
                            {
                                // Open the database connection
                                con.Open();

                                // Execute the INSERT command
                                int rowsAffected = cmd.ExecuteNonQuery();

                                // Check if any rows were affected
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Registered successfully!");
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox3.Text = "";
                                    textBox4.Text = "";

                                }
                                else
                                {
                                    MessageBox.Show("Check Your Internet Connection");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                            finally
                            {
                                // Close the database connection
                                con.Close();
                            }
                        }
                    }
                }
            else
            {
                MessageBox.Show("Error: " + "Database connection is not initialized");
            }
            return "good";
        }
        // Validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Check if username or email is already registered
        private bool IsUserOrEmailRegistered(string username, string email)
        {
            MySqlConnection con = Program.conn; // Initialize MySqlConnection object

            string query = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";

            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);

                try
                {
                    // Open the database connection
                    con.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    // Close the database connection
                    con.Close();
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void signup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode==Keys.F4)
            {
                // Your code to handle Ctrl + Escape combination
                Application.Exit();
            }
        }
    }
}



