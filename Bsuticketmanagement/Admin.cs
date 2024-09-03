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
    public partial class Admin : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        DataTable dt;

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myfile"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("showdata", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();
            


        }
       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = true;
        }

        private void but_c_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("adddata1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@details", richTextBox1.Text);
            MessageBox.Show("insert the data");
            cmd.ExecuteNonQuery();
            con.Close();

        }
       
            private void but_uc_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("udata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@details", richTextBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update the data  !!");
            con.Close();

        }

        private void but_ud_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("deleted1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox1.SelectedItem);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete the data!!!!");
            con.Close();

        }

        private void but_us_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("showdata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("showupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox1.SelectedItem);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[1].ToString();

                richTextBox1.Text = dr[2].ToString();

            }

            con.Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ds a = new Ds();
            a.Show();
          
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            businfo b = new businfo();
            b.Show();

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Employee e1 = new Employee();
            e1.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
       
    }

    }

