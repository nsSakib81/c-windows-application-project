using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Bibaho.com
{
    public partial class Female : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Female()
        {
            InitializeComponent();
            BindComboBox();
        }

        private void Female_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from signup2 where gender = 'female'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = data;
        }

        void BindComboBox()
        {
            comboBox1.Items.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from signup2 where gender = 'female'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                comboBox1.Items.Add(id);
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Premium().Show();
            
            /*SqlConnection con = new SqlConnection(cs);
            string query = "select * from signup where fname like '%" + textBox1.Text + "%' or lname like '%" + textBox1.Text + "%' or profession like '%" + textBox1.Text + "%' or city like '%" + textBox1.Text + "%' and gender = female";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = data;*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Gender().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != null)
            {
                int id = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from signup2 where id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable data = new DataTable();
                sda.Fill(data);
                if (data.Rows.Count > 0)
                {
                    //MemoryStream ms = new MemoryStream((byte[])data.Rows[0]["picture"]);
                    //pictureBox1.Image = new Bitmap(ms);
                    textBox7.Text = data.Rows[0]["name"].ToString();
                    textBox2.Text = data.Rows[0]["age"].ToString();
                    textBox3.Text = data.Rows[0]["height"].ToString();
                    textBox4.Text = data.Rows[0]["city"].ToString();
                    textBox5.Text = data.Rows[0]["interest"].ToString();
                    textBox6.Text = data.Rows[0]["profession"].ToString();
                }
            }
        }
    }
}
