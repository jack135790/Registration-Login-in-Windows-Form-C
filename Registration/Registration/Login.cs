using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Registration
{
    public partial class Login : Form
    {
        public static string un = "";
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "admin") && (textBox2.Text == "admin"))
            {
                MessageBox.Show("Welcome admin");
               
         

            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
                    con.Open();
                    String query = "SELECT * FROM Table1 WHERE Username = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Login Successfull");
                        un = textBox1.Text;
                        Menu f5 = new Menu();
                        f5.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Incorrect\nUsername or \nPassword!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

    }     
}
