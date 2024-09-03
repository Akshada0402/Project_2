using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bsuticketmanagement
{
    public partial class Userform : Form
    {
        public Userform()
        {
            InitializeComponent();
        }

        private void Userform_Load(object sender, EventArgs e)
        {

        }

       
        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
    }
}
