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
    public partial class Ds : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        DataTable dt;

        public Ds()
        {
            InitializeComponent();
        }

        private void but_c_Click(object sender, EventArgs e)
        {
            
            con.Open();
            cmd = new SqlCommand("addcity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            
            MessageBox.Show("insert the data");
            cmd.ExecuteNonQuery();
            con.Close();
            clear();

        }
       
        private void Ds_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myfile"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("showcity", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();
            
           
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void but_uc_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("upcity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update the data  !!");
            con.Close();
            clear();
        }

        private void but_ud_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("delcity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox1.SelectedItem);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete the data!!!!");
            con.Close();
            clear();
        }

        private void but_us_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("showcity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            
            con.Close();
            clear();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("shup1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox1.SelectedItem);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[1].ToString();

                
            }
            con.Close();
          
        }
        public void clear()
        {
            textBox1.Text = "";
            comboBox1.Text= "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin a = new Admin();
            a.Show();
        }
    }
}
