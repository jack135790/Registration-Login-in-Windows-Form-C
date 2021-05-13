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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Text box should not be empty");
            }
            else
            {
                String query = ("Update Table1 set Firstname='" + textBox1.Text + "',Lastname='" + textBox2.Text + "' where Username ='" + label3.Text + "'");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                MessageBox.Show("Details Updated");
                Registration1 f1 = new Registration1();
                f1.Show();
                this.Hide();

            }
        }

        private void Update_Load(object sender, EventArgs e)
        {
            label3.Text = Login.un;
        }
    }
}
