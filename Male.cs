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
    public partial class Male : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Male()
        {
            InitializeComponent();
            BindComboBox();
        }

        private void Male_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from signup2 where gender = 'male'";
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
            string query = "select * from signup2 where gender = 'male'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
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
            string query = "select * from user_details_tbl where fname like '%"+textBox1.Text+ "%' or lname like '%" + textBox1.Text + "%' or profession like '%" + textBox1.Text + "%' or city like '%" + textBox1.Text + "%' and gender = male ";
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.Hide();
            //new ProfileDetails().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() != null)
            {
                int id = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from signup2 where id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable data = new DataTable();
                sda.Fill(data);
                if(data.Rows.Count > 0)
                {

                    //MemoryStream ms = new MemoryStream((byte[])data.Rows[0]["picture"]);
                    //pictureBox1.Image = new Bitmap(ms);
                    //pictureBox1.Image = GetPhoto((byte[])data.Rows[0]["picture"]);
                    textBox1.Text = data.Rows[0]["name"].ToString();
                    textBox2.Text = data.Rows[0]["age"].ToString();
                    textBox3.Text = data.Rows[0]["height"].ToString();
                    textBox4.Text = data.Rows[0]["city"].ToString();
                    textBox5.Text = data.Rows[0]["interest"].ToString();
                    textBox6.Text = data.Rows[0]["profession"].ToString();
                }
                /*private Image GetPhoto(byte[] photo)
                {
                    MemoryStream ms = new MemoryStream(photo);
                    return Image.FromStream(ms);
                }*/
            }
        }
    }
}
