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
    public partial class coding : Form
    {
        public coding()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Minimized;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            dashboard o = new dashboard();
            o.Show();
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            C__ c__ = new C__();
            c__.Show();
            this.Dispose();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            C__ c__ = new C__(); 
            c__.Show();
            this.Dispose();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            py py = new py();
            py.Show();
            this.Dispose();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            csharp csharp = new csharp();
            csharp.Show();  
            this.Dispose();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Module is under progress it will be available soon");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Module is under progress it will be available soon");

        }

        private void label4_Click(object sender, EventArgs e)
        {
            csharp csharp = new csharp();
            csharp.Show();
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            py py = new py();
            py.Show();
            this.Dispose();
        }

        private void coding_KeyDown(object sender, KeyEventArgs e)
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
