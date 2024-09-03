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
    public partial class user1 : Form
    {

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;

        DataTable dt;
        public user1()
        {
            InitializeComponent();

           
        }

        private void user1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myfile"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("showcity", con);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1].ToString());
                comboBox2.Items.Add(dr[1].ToString());
            }

            con.Close();
            showp();
           

        }
        public void show()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("usdat1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@source", comboBox1.Text);
            cmd.Parameters.AddWithValue("@dest", comboBox2.Text);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible=true;
            int index = e.RowIndex;
            DataGridViewRow selectedrows= dataGridView1.Rows[index];
           textBox4.Text = selectedrows.Cells[3].Value.ToString();
           textBox2.Text = selectedrows.Cells[2].Value.ToString();
           textBox1.Text = selectedrows.Cells[5].Value.ToString();
           textBox5.Text = selectedrows.Cells[6].Value.ToString();
           textBox3.Text = selectedrows.Cells[7].Value.ToString();
           textBox6.Text = selectedrows.Cells[9].Value.ToString();
           textBox7.Text = selectedrows.Cells[8].Value.ToString();

            


        }
     

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

       
        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {
            
           
        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        

        

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
        public void showp()
        {
            con.Open();
            cmd = new SqlCommand("Select count(cusid) from customer2", con);
            int i = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            i++;
            label18.Text = 0 + i.ToString();
            con.Close();
           
            
        }
        public void bu1()
        {
            con.Open();
            cmd = new SqlCommand("addb3", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@busno", textBox4.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@source", textBox1.Text);
            cmd.Parameters.AddWithValue("@dest", textBox5.Text);
            cmd.Parameters.AddWithValue("@date", textBox3.Text);
            cmd.Parameters.AddWithValue("@price", textBox7.Text);
            cmd.Parameters.AddWithValue("@time", textBox6.Text);
            cmd.Parameters.AddWithValue("@cusid", label18.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

           // bu1();
            con.Open();


            cmd = new SqlCommand("addcust1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@busno", textBox4.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@source", textBox1.Text);
            cmd.Parameters.AddWithValue("@dest", textBox5.Text);
            cmd.Parameters.AddWithValue("@date", textBox3.Text);
            cmd.Parameters.AddWithValue("@price", textBox7.Text);
            cmd.Parameters.AddWithValue("@time", textBox6.Text);
            cmd.Parameters.AddWithValue("@cusid", label18.Text);
            cmd.Parameters.AddWithValue("@cusid", label18.Text);
            cmd.Parameters.AddWithValue("@name", textBox8.Text);
            cmd.Parameters.AddWithValue("@age", textBox10.Text);
            cmd.Parameters.AddWithValue("@cono", textBox9.Text);
            cmd.Parameters.AddWithValue("@email", textBox11.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Successfully!!!!!");
            clear();
            
            
        }
        public void clear()
        {
            showp();
           // textBox12.Text="";
            textBox10.Text = "";
                textBox11.Text="";
            textBox8.Text="";
            textBox9.Text="";
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        
    }
}
