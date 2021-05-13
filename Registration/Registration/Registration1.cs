using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data.Sql;


namespace Registration
{
    public partial class Registration1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
        DataRow dr;
        public Registration1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Password mismatch");
            }
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");*/
           /* if(!reg.IsMatch(textBox6.Text))
            {
                MessageBox.Show("Invalid email");
            }
            * */
            //else
            try
            {
                SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
                SqlCommand com = new SqlCommand("INSERT into Table1 (FirstName,LastName,UserName,Password,Email,City) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.SelectedText + "') ", sc);
                sc.Open();
                com.ExecuteNonQuery();
                sc.Close();
                MessageBox.Show("Inserted");
                DisplayData();
                ClearData();
            }
            catch (SqlException)
            {
                MessageBox.Show("error");
            }

               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login f3 = new Login();
            f3.Show();
        
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
            String query = ("SELECT * from Table1");
            SqlCommand cmd = new SqlCommand(query, sc);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            

        }
        private void DisplayData()
        {

            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
            String query = ("SELECT * from Table1");
            SqlCommand cmd = new SqlCommand(query, sc);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Registration\\Registration\\Detail.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Text box should not be empty");
            }
            else
            {
                String query = ("Update Table1 set Firstname='" + textBox1.Text + "',Lastname='" + textBox2.Text + "' where Username ='" + textBox3.Text+"'");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                MessageBox.Show("Details Updated");
                dataGridView1.DataSource = dt;
                DisplayData();
                ClearData();

            }
        }

        private void button5_Click(object sender, EventArgs e)
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
                    String query = ("Delete from Table1 where Username ='" + textBox3.Text + "'");
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        dataGridView1.DataSource = dt;
                        DisplayData();
                        ClearData();
                        
                    }
                    else
                    {

                    MessageBox.Show("Incorrect USERNAME");
                    }
                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }


       // private void dataGridView(object sender, DataGridViewCellEventArgs e)
       // {
            
       // }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = this.Search();
           

        }
        private DataTable Search()
        {
            string query = "SELECT * FROM Table1";
            query += " WHERE UserName LIKE '%' + @UserName + '%'";
            //query += " OR LastName LIKE '%' + @LastName + '%'";
            //query += " OR @FirstName = ''";
           // string constr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Search\\Search\\Display.mdf;Integrated Security=True;User Instance=True";
            //SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserName", comboBox2.SelectedItem);
            //cmd.Parameters.AddWithValue("@LastName", textBox1.Text.Trim());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }
               
        
           // msg = "Country " + comboBox1.Text;
       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.Search1();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.Search1();

        }
        private DataTable Search1()
        {
            if (checkBox1.Checked == true && checkBox2.Checked== true)
            {
                string query = "SELECT * FROM Table1";
                query += " WHERE UserName LIKE '%' + @UserName + '%'";
                query += " OR UserName LIKE '%' + @UserName1+'%'";
                //query += " OR LastName LIKE '%' + @LastName + '%'";
                //query += " OR @FirstName = ''";
                // string constr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Search\\Search\\Display.mdf;Integrated Security=True;User Instance=True";
                //SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", checkBox1.Text);
                cmd.Parameters.AddWithValue("@UserName1", checkBox2.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                return dt;
            }
            else
            {
                if (checkBox1.Checked == true && checkBox2.Checked == false)
                {
                    string query = "SELECT * FROM Table1";
                    query += " WHERE UserName LIKE '%' + @UserName + '%'";
                    //query += " OR LastName LIKE '%' + @LastName + '%'";
                    //query += " OR @FirstName = ''";
                    // string constr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Search\\Search\\Display.mdf;Integrated Security=True;User Instance=True";
                    //SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserName", checkBox1.Text);
                    //cmd.Parameters.AddWithValue("@LastName", textBox1.Text.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    return dt;
                }
                if (checkBox1.Checked == false && checkBox2.Checked == true)
                {
                    string query = "SELECT * FROM Table1";
                    query += " WHERE UserName LIKE '%' + @UserName + '%'";
                    //query += " OR LastName LIKE '%' + @LastName + '%'";
                    //query += " OR @FirstName = ''";
                    // string constr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Search\\Search\\Display.mdf;Integrated Security=True;User Instance=True";
                    //SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserName", checkBox2.Text);
                    //cmd.Parameters.AddWithValue("@LastName", textBox1.Text.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    return dt;
                }
                else
                {
                    /*string query = "SELECT * FROM Table1";
                    //query += " OR LastName LIKE '%' + @LastName + '%'";
                    //query += " OR @FirstName = ''";
                    // string constr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Search\\Search\\Display.mdf;Integrated Security=True;User Instance=True";
                    //SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@UserName", checkBox1.Text);
                    //cmd.Parameters.AddWithValue("@LastName", textBox1.Text.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();*/
                    DataTable dt = new DataTable();
                    return dt;
                }

               
            }

        }
       /* private DataTable Search2()
        {
            if (checkBox2.Checked == true)
            {
                string query = "SELECT * FROM Table1";
                query += " WHERE UserName LIKE '%' + @UserName + '%'";
                //query += " OR LastName LIKE '%' + @LastName + '%'";
                //query += " OR @FirstName = ''";
                // string constr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Search\\Search\\Display.mdf;Integrated Security=True;User Instance=True";
                //SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", checkBox2.Text);
                //cmd.Parameters.AddWithValue("@LastName", textBox1.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                return dt;
            }
            else
            {
                string query = "SELECT * FROM Table1";
                //query += " OR LastName LIKE '%' + @LastName + '%'";
                //query += " OR @FirstName = ''";
                // string constr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\Search\\Search\\Display.mdf;Integrated Security=True;User Instance=True";
                //SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@UserName", checkBox1.Text);
                //cmd.Parameters.AddWithValue("@LastName", textBox1.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                return dt;
            }
        }*/
    }
}
