using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Bibaho.com
{
    public partial class Signup2 : Form
    {
        string pattern = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        string PassPattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        public Signup2()
        {
            InitializeComponent();
        }

        private void id_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(id.Text) == true)
            {
                id.Focus();
                errorProvider1.SetError(this.id, "Please fill the id");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(Char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8) 
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text) == true)
            {
                name.Focus();
                errorProvider2.SetError(this.name, "Please fill the name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void age_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(age.Text) == true)
            {
                age.Focus();
                errorProvider3.SetError(this.age, "Please fill the age");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void age_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void height_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(height.Text) == true)
            {
                height.Focus();
                errorProvider9.SetError(this.height, "Please fill the height");
            }
            else
            {
                errorProvider9.Clear();
            }
        }

        private void height_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void gcombo_Leave(object sender, EventArgs e)
        {
            if(gcombo.SelectedItem == null)
            {
                gcombo.Focus();
                errorProvider4.SetError(this.gcombo, "Please select gender");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void pcombo_Leave(object sender, EventArgs e)
        {
            if (pcombo.SelectedItem == null)
            {
                pcombo.Focus();
                errorProvider6.SetError(this.pcombo, "Please select Profession");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void incombo_Leave(object sender, EventArgs e)
        {
            if (incombo.SelectedItem == null)
            {
                incombo.Focus();
                errorProvider7.SetError(this.incombo, "Please select interest");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void city_Leave(object sender, EventArgs e)
        {
            if (city.SelectedItem == null)
            {
                city.Focus();
                errorProvider8.SetError(this.city, "Please select city");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if(Regex.IsMatch(email.Text, pattern) == false)
            {
                email.Focus();
                errorProvider5.SetError(this.email, "Invalid Email");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void pass_Leave(object sender, EventArgs e)
        {
            if(Regex.IsMatch(pass.Text, PassPattern) == false)
            {
                pass.Focus();
                errorProvider10.SetError(this.pass, "Uppercase, Lowercase, Numbers, Symbols");
            }
            else
            {
                errorProvider10.Clear();
            }
        }

        private void cpass_Leave(object sender, EventArgs e)
        {
            if(pass.Text != cpass.Text)
            {
                cpass.Focus();
                errorProvider11.SetError(this.cpass, "Password is not matched");
            }
            else
            {
                errorProvider11.Clear();
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text) == true)
            {
                id.Focus();
                errorProvider1.SetError(this.id, "Please fill the id");
            }
            else if (string.IsNullOrEmpty(name.Text) == true)
            {
                name.Focus();
                errorProvider2.SetError(this.name, "Please fill the name");
            }
            else if (string.IsNullOrEmpty(age.Text) == true)
            {
                age.Focus();
                errorProvider3.SetError(this.age, "Please fill the age");
            }
            else if (gcombo.SelectedItem == null)
            {
                gcombo.Focus();
                errorProvider4.SetError(this.gcombo, "Please select gender");
            }
            else if (Regex.IsMatch(email.Text, pattern) == false)
            {
                email.Focus();
                errorProvider5.SetError(this.email, "Invalid Email");
            }
            else if (pcombo.SelectedItem == null)
            {
                pcombo.Focus();
                errorProvider6.SetError(this.pcombo, "Please select Profession");
            }
            else if (incombo.SelectedItem == null)
            {
                incombo.Focus();
                errorProvider7.SetError(this.incombo, "Please select interest");
            }
            else if (city.SelectedItem == null)
            {
                city.Focus();
                errorProvider8.SetError(this.city, "Please select city");
            }
            else if (string.IsNullOrEmpty(height.Text) == true)
            {
                height.Focus();
                errorProvider9.SetError(this.height, "Please fill the height");
            }
            else if (Regex.IsMatch(pass.Text, PassPattern) == false)
            {
                pass.Focus();
                errorProvider10.SetError(this.pass, "Uppercase, Lowercase, Numbers, Symbols");
            }
            else if (pass.Text != cpass.Text)
            {
                cpass.Focus();
                errorProvider11.SetError(this.cpass, "Password is not matched");
            }
            else
            {
                //MessageBox.Show("welcome");

                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string query2 = "select * from signup2 where ID = @id";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@id", id.Text);
                con.Open();
                SqlDataReader rd = cmd2.ExecuteReader();
                if(rd.HasRows == true)
                {
                    MessageBox.Show(id.Text + " Id already exists", "failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    con.Close();
                    string query = "insert into signup2 values(@id, @name, @age, @gender, @email, @profession, @interest, @city, @height, @pass)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id.Text);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@age", age.Text);
                    cmd.Parameters.AddWithValue("@gender", gcombo.SelectedItem);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@profession", pcombo.SelectedItem);
                    cmd.Parameters.AddWithValue("@interest", incombo.SelectedItem);
                    cmd.Parameters.AddWithValue("@city", city.SelectedItem);
                    cmd.Parameters.AddWithValue("@height", height.Text);
                    cmd.Parameters.AddWithValue("@pass", pass.Text);
                    

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Registered Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Your Email is: " + email.Text + "\n \n" + "Your Password is: " + pass.Text, "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registered Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    con.Close();
                    this.Hide();
                    new UserLogin2().Show();
                }
            }
            
        }

        private void reset_Click(object sender, EventArgs e)
        {
            id.Clear();
            name.Clear();
            age.Clear();
            gcombo.SelectedItem = null;
            email.Clear();
            pcombo.SelectedItem = null;
            incombo.SelectedItem = null;
            city.SelectedItem = null;
            height.Clear();
            pass.Clear();
            cpass.Clear();
        }
    }
}
