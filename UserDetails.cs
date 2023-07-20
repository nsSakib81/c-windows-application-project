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
using Bibaho.com.Properties;

namespace Bibaho.com
{
    public partial class UserDetails : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public UserDetails(string email)
        {
            InitializeComponent();
            BindGridView();

            label11.Text = email;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        void ResetControls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            pictureBox1.Image = Resources.nia;
            textBox4.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG FILE (*.png) | *.png | JPG FILE (*.jpg) | *.jpg | BMP FILE (*.bmp) | *.bmp | GIF FILE (*.gif) | *.gif";
            ofd.Filter = "image File (*.png;*.jpg;*.bmp;*.gif) | *.png;*.jpg;*.bmp;*.gif | All files (*.*) | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into signup2 values(@id, @name, @age, @img, @height, @city, @interest, @profession)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", textBox3.Text);
            cmd.Parameters.AddWithValue("@img", SavePhoto());
            cmd.Parameters.AddWithValue("@height", textBox4.Text);
            cmd.Parameters.AddWithValue("@city", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@interest", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@profession", comboBox3.SelectedItem);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("DATA INSERTED!!");
                BindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("DATA NOT INSERTED!!");
            }
            con.Close();
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            //string query = "select * from user_details_tbl";
            string query = "select * from signup2 where email = '"+label11.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con); 
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            //dgv = (DataGridViewImageColumn)dataGridView1.Columns[10];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[10].Value);
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox3.SelectedItem = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update signup2 set id = @id, name = @name, age = @age, picture = @img, height = @height, city = @city, interest = @interest, profession = @profession where id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", textBox3.Text);
            cmd.Parameters.AddWithValue("@img", SavePhoto());
            cmd.Parameters.AddWithValue("@height", textBox4.Text);
            cmd.Parameters.AddWithValue("@city", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@interest", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@profession", comboBox3.SelectedItem);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("DATA UPDATED!!");
                BindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("DATA NOT UPDATED!!");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from signup2 where id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            /*cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", textBox3.Text);
            cmd.Parameters.AddWithValue("@img", SavePhoto());
            cmd.Parameters.AddWithValue("@height", textBox4.Text);
            cmd.Parameters.AddWithValue("@city", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@interest", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@profession", comboBox3.SelectedItem);*/

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("DATA DELETED!!");
                BindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("DATA NOT DELETED!!");
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Gender().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserLogin2().Show();
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}