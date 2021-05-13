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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
            sc.Open();
            SqlCommand com = new SqlCommand("select * from Table1 where UserName ='" + textBox1.Text + "' and Password ='" + textBox2.Text + "' ", sc);
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                if (textBox3.Text == textBox4.Text)
                {
                    com = new SqlCommand(" UPDATE Table1 SET Password='" + textBox3.Text + "' where UserName='" + textBox1.Text + "' ", sc);
                    //SqlDataAdapter sda = new SqlDataAdapter(com);
                    //MessageBox.Show("Login success");
                    com.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Password mismatch");
                }
            }
            else
            {
                MessageBox.Show("Invalid UserName and Password");
            }
           
        }
    }
}
