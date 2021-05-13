using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Registration
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword f4 = new ChangePassword();
            f4.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
            //sc.Open();
            //SqlCommand com = new SqlCommand("select * from Table1 where UserName ='" + );
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update u = new Update();
            u.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete d = new Delete();
            d.Show();
            this.Hide();
        }
    }
}
