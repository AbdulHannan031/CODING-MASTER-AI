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
    public partial class py : Form
    {
        public py()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            coding coding = new coding();
            coding.Show();
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
            (int id, string question, int points) = new Question().GetQuestion("Python", Program.id);
            groupBox1.Text = "Question : \n " + question;
            label5.Text = Convert.ToString(points);
            label6.Text = Convert.ToString(id);
            button2.Visible = true;
            textBox1.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button1.Visible = false;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string Answer = textBox1.Text;
            if (string.IsNullOrEmpty(Answer))
            {
                MessageBox.Show("Please input The answer first ", "Error");
            }
            else
            {
                string question = groupBox1.Text;
                Answer = "Answer: \n" + Answer;
                int point = Convert.ToInt32(label5.Text);
                int userid = Program.id;
                int questionid = Convert.ToInt32(label6.Text);
               

                pro pro=new pro();
                pro.Show();
                string result = await Program.GenerateResponse(question, Answer, "Python");
                pro.Dispose();
                if (result == "Correct" || result == "correct")
                {
                    Program.InsertSubmission(questionid, point, userid);
                    textBox1.Text = "";
                    updatequestions();
                }
                else
                {
                    MessageBox.Show("Wrong answer", "Poor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            void updatequestions()
            {
                (int id, string question, int points) = new Question().GetQuestion("Python", Program.id);
                groupBox1.Text = "Question : \n " + question;
                label5.Text = Convert.ToString(points);
                label6.Text = Convert.ToString(id);
              
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void py_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode == Keys.F4)
            {
                // Your code to handle Ctrl + Escape combination
                Application.Exit();
            }
        }

        private void py_Load(object sender, EventArgs e)
        {

        }
    }
}
