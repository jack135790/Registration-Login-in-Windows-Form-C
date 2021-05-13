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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Text box should not be empty");
                }
                else
                {
                    String query = ("Delete from Table1 where Username ='" + textBox1.Text + "'and Password='" + textBox2.Text + "'");
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                           MessageBox.Show("Details Deleted");
                         Menu f5= new Menu();
                        f5.Show();
                        this.Hide();
                        
                    }
                    else
                    {

                    MessageBox.Show("Incorrect PASSWORD/USERNAME");
                    }
                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }
        }
    
}
