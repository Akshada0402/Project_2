using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Bsuticketmanagement
{
    public partial class Print : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;

        DataTable dt;
        public Print()
        {
            InitializeComponent();
        }



        private void Print_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myfile"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from cust23", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[8].ToString());
            }
            con.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;



            //  // cmd.Parameters.AddWithValue("@dest", comboBox2.Text);
            //  dr = cmd.ExecuteReader();
            ////  dt = new DataTable();
            ////  dt.Load(dr);
            //  //dataGridView1.DataSource = dt;
            //  con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT * from cust23", con);
            /// cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cusid", comboBox1.SelectedItem);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label11.Text = dr[0].ToString();
                label14.Text = dr[1].ToString();
                label15.Text = dr[2].ToString();
                label16.Text = dr[3].ToString();
                label13.Text = dr[4].ToString();
                label16.Text = dr[6].ToString();
                label18.Text = dr[5].ToString();
                label19.Text = dr[7].ToString();
                label17.Text = dr[8].ToString();
                //label20.Text = dr[9].ToString();

            }
            // //     richTextBox1.Text = dr[2].ToString();
            con.Close();
        }

        // con.Close

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;
            int index = e.RowIndex;
          //  DataGridViewRow selectedrows = dataGridView1.Rows[index];
            //label13.Text = selectedrows.Cells[1].Value.ToString();
            //label17.Text = selectedrows.Cells[3].Value.ToString();
            //label12.Text = selectedrows.Cells[5].Value.ToString();
            //label11.Text = selectedrows.Cells[6].Value.ToString();
            //label10.Text = selectedrows.Cells[7].Value.ToString();
            //label16.Text = selectedrows.Cells[8].Value.ToString();
            //label14.Text = selectedrows.Cells[9].Value.ToString();
            //label15.Text = selectedrows.Cells[11].Value.ToString();
            //label19.Text = selectedrows.Cells[10].Value.ToString();

            ////  }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Singuature_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("showprint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cusid", comboBox1.SelectedItem);
            dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //textBox1.Text = dr[1].ToString();


            //}

            //con.Open();
            //cmd = new SqlCommand("SELECT custom1.name, custom1.age, custom1.cono, custom1.email, cbus1.busno, cbus1.name AS Expr1, cbus1.source, cbus1.dest, cbus1.date, cbus1.price, cbus1.time FROM custom1 INNER JOIN cbus1 ON custom1.cusid = cbus1.cusid", con);
            ///// cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@cusid", comboBox1.SelectedItem);
            //dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label12.Text = dr[1].ToString();
                label11.Text = dr[2].ToString();
                label10.Text = dr[3].ToString();
                label16.Text = dr[4].ToString();
                label14.Text = dr[5].ToString();
                label13.Text = dr[9].ToString();
                label17.Text = dr[11].ToString();
                label19.Text = dr[6].ToString();
                label15.Text = dr[7].ToString();
                // label20.Text = dr[9].ToString();



            }
        }
    }
}