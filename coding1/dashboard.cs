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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string developerName = "Abdul Hannan";
            string version = "1.0";

            // Display the information in a MessageBox
            MessageBox.Show($"Developer Name: {developerName}\nVersion: {version}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Dispose();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            coding coding = new coding();
            coding.Show();
            this.Dispose();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Dispose();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Ranks ranks = new Ranks();
            ranks.Show();
            this.Dispose(); 
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode == Keys.F4)
            {
                // Your code to handle Ctrl + Escape combination
                Application.Exit();
            }
        }
    }
}
