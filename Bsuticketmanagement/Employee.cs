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
    public partial class Employee : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        DataTable dt;
        string g;
        public Employee()
        {
            InitializeComponent();
        }

        private void but_c_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
              if (radioButton1.Checked == true)
            {
                g = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                g = radioButton2.Text;
            }
           string  strAr = "Insert into emp Values('" + textBox1.Text + "','" +g+ "','" + dateTimePicker1.Value +"','" + richTextBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox4.Text + "')";
            con.Open();
            cmd = new SqlCommand(strAr, con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully .......!!!!!!");
            con.Close();
        }
     
           

        private void Employee_Load(object sender, EventArgs e)
        {
            
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myfile"].ConnectionString);
            cmd = new SqlCommand("Select * from emp ", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }

            //  MessageBox.Show("Connected");
            con.Close();
        }

        private void but_uc_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void but_ud_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            cmd = new SqlCommand("Delete from emp where Id=" + comboBox1.SelectedItem + "", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void but_us_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from emp ", con);
            con.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.Visible = true;
          dataGridView1.DataSource = dt;
            con.Close();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
