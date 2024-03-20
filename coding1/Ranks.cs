using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace coding1
{
    public partial class Ranks : Form
    {
        public Ranks()
        {
            InitializeComponent();
            updategui();
            FetchDataAndPopulateGrid();
        }

       private void updategui()
        {
            dataGridView1.BackgroundColor = Color.FromArgb(0, 90, 127);

            // Set the font of header cells
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            // Set the text color of header cells
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Set the background color of header cells
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Set the alignment of header cells
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set the border style of the DataGridView
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;

            // Set the font of data cells
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            // Set the text color of data cells
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            // Set the alignment of data cells
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set the padding of cells
            dataGridView1.DefaultCellStyle.Padding = new Padding(5);

            // Enable visual styles for the DataGridView
            dataGridView1.EnableHeadersVisualStyles = false;

            // Set the selection background color
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;

            // Set the selection text color
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Allow users to resize columns
            dataGridView1.AllowUserToResizeColumns = false;

            // Allow users to resize rows
            dataGridView1.AllowUserToResizeRows = false;

            // Set row height
            dataGridView1.RowTemplate.Height = 30;

            // Hide row headers
            dataGridView1.RowHeadersVisible = false;

            // Enable double buffering to reduce flicker
            typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(dataGridView1, true, null);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
        }

        private async void panel1_Paint_1(object sender, PaintEventArgs e)
        {

           
        }

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;


        }
       

        // Other event handlers and methods...
    
    private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard();
            dashboard.Show();
            this.Dispose();

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // Fetch data from the database and populate the DataGridView
        private void FetchDataAndPopulateGrid()
        {
            try
            {
                MySqlConnection connection = Program.conn;
                string query = @"SELECT u.username AS Name, SUM(s.Marks) AS TotalScore
                         FROM users u
                         JOIN submission s ON u.id = s.UserID
                         GROUP BY u.username
                         ORDER BY TotalScore DESC;";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Check if the dataGridView1 control is found
                if (dataGridView1 != null)
                {
                    // Clear existing columns
                    dataGridView1.Columns.Clear();

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Optionally, set column headers (if not already set in the DataGridView designer)
                   
                }
                else
                {
                    MessageBox.Show("dataGridView1 control not found.");
                }

                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ranks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode==Keys.F4)
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
