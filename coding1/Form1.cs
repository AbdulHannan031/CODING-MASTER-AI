using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace coding1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
                signup signup = new signup();
                signup.Show();
            this.Dispose();
              
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forget forget = new forget(); forget.Show();
            this.Dispose();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Assuming you want to detect Enter key press
            {
                // Call the method associated with Button1 click event
                textBox2.Focus();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string pass = textBox2.Text;

            // Check if email or password is empty
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please input all fields");
            }
            else if (email.Equals("admin") && pass.Equals("admin"))
            {
                admin admin = new admin();
                admin.Show();
                this.Dispose();
            }
            else
            {
                // Check if database connection is initialized
                if (Program.conn != null)
                {
                    // Query to select user with matching email and password
                    string query = "SELECT id FROM users WHERE username = @email AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, Program.conn))
                    {
                        // Set parameter values
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", pass);

                        try
                        {
                            // Open the database connection
                            Program.conn.Open();

                            // Execute the query
                            object result = cmd.ExecuteScalar();

                            // Check if a user with matching credentials exists
                            if (result != null)
                            {
                                int userId = Convert.ToInt32(result);

                                // Store user ID
                                Program.id = userId;
                                Program.email = email;

                                // Navigate to dashboard
                                dashboard dashboard = new dashboard();
                                dashboard.Show();

                                // Dispose current form
                                this.Dispose();
                            }
                            else
                            {
                                // Login failed
                                MessageBox.Show("Invalid username or password");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            // Close the database connection
                            Program.conn.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cannot connect to database");
                }
            }


        }

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Assuming you want to detect Enter key press
            {
                // Call the method associated with Button1 click event
                button1_Click(sender, e);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode == Keys.F4)
            {
                // Your code to handle Ctrl + Escape combination
                Application.Exit();
            }
        }
    }
}
