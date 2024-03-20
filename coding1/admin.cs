using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("QuestionID", typeof(int));
            dataTable.Columns.Add("QuestionText", typeof(string));
            dataTable.Columns.Add("Language",typeof(string));
            dataTable.Columns.Add("Points",typeof (string));

            // Add some sample rows
            dataTable.Rows.Add(1, "what is c#","C#","10");
            dataTable.Rows.Add(2, "Wht is C++","c++","10");
            dataTable.Rows.Add(3, "What is python","python","5");
            dataGridView1.Columns.Clear();

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable;
            dataTable.Clear();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() {
                Title = "Open Csv File with Three columns First For Question Second For Language LAst For Points",
                Filter="csv files (*.csv)|*.csv",
                CheckFileExists=true,
                CheckPathExists=true
            };
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
               
                textBox1.Text=openFileDialog.FileName;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if(string.IsNullOrEmpty(path) )
            {
                MessageBox.Show("Please select file first", "Error");
            }
            else
            {
                string convertedPath = path.Replace('\\', '/');
                MessageBox.Show(convertedPath);
                LoadDataFromCSV(convertedPath);
            }
        }


        static void LoadDataFromCSV(string csvFilePath)
        {
            MySqlConnection connection = Program.conn;

            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();

                // Create temporary table
                cmd.CommandText = @"
        CREATE TEMPORARY TABLE temp_questions (
            QuestionID INT AUTO_INCREMENT PRIMARY KEY,
            QuestionText TEXT,
            Language VARCHAR(50),
            Points INT
        );";
                cmd.ExecuteNonQuery();

                // Load data from CSV into temporary table
                cmd.CommandText = $@"
        LOAD DATA INFILE @CsvFilePath
        INTO TABLE temp_questions
        FIELDS TERMINATED BY ',' 
        ENCLOSED BY '\''
        LINES TERMINATED BY '\n'
        IGNORE 1 LINES;";
                cmd.Parameters.AddWithValue("@CsvFilePath", csvFilePath);
                cmd.ExecuteNonQuery();

                // Insert unique questions into the main table
                cmd.CommandText = @"
        INSERT INTO question (QuestionText, Language, Points)
        SELECT DISTINCT t.QuestionText, t.Language, t.Points
        FROM temp_questions t
        LEFT JOIN question q ON LOWER(TRIM(q.QuestionText)) = LOWER(TRIM(t.QuestionText))
        WHERE q.QuestionText IS NULL;";
                int rowsInserted = cmd.ExecuteNonQuery();

                // Drop temporary table
                cmd.CommandText = "DROP TEMPORARY TABLE temp_questions;";
                cmd.ExecuteNonQuery();

                // Check if data is inserted into the main table
                if (rowsInserted > 0)
                {
                    MessageBox.Show("Data loaded successfully.");
                }
                else
                {
                    MessageBox.Show("No data inserted into the main table.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void admin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode == Keys.F4)
            {
                // Your code to handle Ctrl + Escape combination
               Application.Exit();
            }
        }
    }
}
