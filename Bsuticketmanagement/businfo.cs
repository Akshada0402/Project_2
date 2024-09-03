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
    public partial class businfo : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
   
        DataTable dt;
        public businfo()
        {
            InitializeComponent();
        }

        

        private void businfo_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myfile"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("showcity", con);
           
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr[1].ToString());
                comboBox5.Items.Add(dr[1].ToString());
            }
           
            con.Close();
            con.Open();
            cmd = new SqlCommand("showdata", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox4.Items.Add(dr[1].ToString());
               
            }

            con.Close();
            con.Open();
            cmd = new SqlCommand("busshow", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox6.Items.Add(dr[0].ToString());

            }

            con.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void but_c_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = comboBox2.Text;
            string c = a + b;
            label12.Text = c;


            con.Open();
            cmd = new SqlCommand("addbus1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",textBox5.Text);
            cmd.Parameters.AddWithValue("@busno", textBox4.Text);
            cmd.Parameters.AddWithValue("@cname", comboBox4.SelectedItem);
            cmd.Parameters.AddWithValue("@source", comboBox5.SelectedItem);
            cmd.Parameters.AddWithValue("@dest", comboBox3.SelectedItem);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@price", textBox3.Text);
            cmd.Parameters.AddWithValue("@time", label12.Text);
         //md.Parameters.AddWithValue("@time",comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@status", comboBox1.SelectedItem);
            MessageBox.Show("insert the data");
            cmd.ExecuteNonQuery();



            con.Close();

        }

        private void but_uc_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = comboBox2.Text;
            string c = a + b;
            label12.Text = c;


            con.Open();
            cmd = new SqlCommand("upbus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox6.SelectedItem);
            cmd.Parameters.AddWithValue("@name", textBox5.Text);
            cmd.Parameters.AddWithValue("@busno", textBox4.Text);
            cmd.Parameters.AddWithValue("@cname", comboBox4.SelectedItem);
            cmd.Parameters.AddWithValue("@source", comboBox5.SelectedItem);
            cmd.Parameters.AddWithValue("@dest", comboBox3.SelectedItem);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@price", textBox3.Text);
            cmd.Parameters.AddWithValue("@time", label12.Text);
            //md.Parameters.AddWithValue("@time",comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@status", comboBox1.SelectedItem);
            MessageBox.Show("Update the data");
            cmd.ExecuteNonQuery();



            con.Close();

        }

        private void but_ud_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("delbus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox6.SelectedItem);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete the data!!!!");
            con.Close();
        }
        
        private void but_us_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            con.Open();
            cmd = new SqlCommand("busshow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
           dataGridView1.DataSource = dt;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("busupsh", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox6.SelectedItem);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox5.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
                comboBox4.Text = dr[3].ToString();
                comboBox5.Text = dr[4].ToString();
                comboBox3.Text = dr[5].ToString();
                dateTimePicker1.Text = dr[6].ToString();
                textBox1.Text = dr[8].ToString();
                textBox3.Text = dr[7].ToString();
              // comboBox2.Text = dr[8].ToString();
                comboBox1.Text = dr[9].ToString();



            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            businfo b=new businfo();
            b.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
