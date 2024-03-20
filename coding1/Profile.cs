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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            int points = Program.points();
            label3.Text= points.ToString();
            label1.Text = Program.email;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dashboard o = new dashboard();
            o.Show();
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldPassword = textBox1.Text;
            string newPassword = textBox2.Text;

            // Check if old password and new password are provided
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please input both old and new passwords");
            }
            else if(newPassword.Length<8){
                MessageBox.Show("Password lenfth should be minimum 8 charachters");

            }
            else
            {
                // Check if database connection is initialized
                if (Program.conn != null)
                {
                    // Query to update password
                    string query = "UPDATE users SET password = @newPassword WHERE username = @username AND password = @oldPassword";

                    using (MySqlCommand cmd = new MySqlCommand(query, Program.conn))
                    {
                        // Set parameter values
                        cmd.Parameters.AddWithValue("@username", Program.email);
                        cmd.Parameters.AddWithValue("@oldPassword", oldPassword);
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);

                        try
                        {
                            // Open the database connection
                            Program.conn.Open();

                            // Execute the update query
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
                                // Password updated successfully
                                MessageBox.Show("Password updated successfully!");
                            }
                            else
                            {
                                // Old password is incorrect or user not found
                                MessageBox.Show("Incorrect old password ");
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) {
                   button1_Click(sender, e);
            }
        }

        private void Profile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode == Keys.F4)
            {
                // Your code to handle Ctrl + Escape combination
                Application.Exit();
            }
        }
    }
}
