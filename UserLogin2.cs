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

namespace Bibaho.com
{
    public partial class UserLogin2 : Form
    {
        public UserLogin2()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Signup2().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string query2 = "select * from signup2 where email = @email and pass = @pass";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@email", textBox1.Text);
                cmd2.Parameters.AddWithValue("@pass", textBox2.Text);
                con.Open();
                SqlDataReader rd = cmd2.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show("login successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new UserDetails(textBox1.Text).Show();
                }
                else
                {
                    MessageBox.Show("login failed", "failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("PLEASE FILL BOTH FIELDS!!", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Provide Your Username!!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please Provide Your Password!!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
    }
}
