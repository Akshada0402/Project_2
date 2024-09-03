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
    public partial class Form3 : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;

        DataTable dt;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myfile"].ConnectionString);
            con.Open();

            cmd = new SqlCommand("SELECT custom1.name, custom1.age, custom1.cono, custom1.email, cbus1.busno, cbus1.name, cbus1.source,cbus1.dest, cbus1.date, cbus1.price, cbus1.time, cbus1.cusid FROM custom1 INNER JOIN cbus1 ON custom1.cusid = cbus1.cusid", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@cusid", comboBox1.Text);
            ///// cmd.Parameters.AddWithValue("@dest", comboBox2.Text);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
