using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace G_C_Project
{
    public partial class S_Add : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Learning Resource\Project\GC\G_C_Project\G_C_Project\Database1.mdf;Integrated Security=True;User Instance=True");

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public S_Add()
        {
            InitializeComponent();
        }
     
        private void S_Add_Load(object sender, EventArgs e)
        {
            cmd.Connection = con;
            loadlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "")
            {
                con.Open();
                cmd.CommandText = "insert into student_info(fname,lname,address,mobile,study) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show(textBox1.Text+" is Added to the Hostel DATABASE","Message From RJS");
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                loadlist();


            }
            else
            {
                MessageBox.Show("Please Fill The Text..!","Message From RJS");
            }

        }

        public void loadlist()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            con.Open();
            cmd.CommandText = "select * from student_info";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString());
                    listBox2.Items.Add(dr[1].ToString());
                    listBox3.Items.Add(dr[2].ToString());
                    listBox4.Items.Add(dr[3].ToString());
                    listBox5.Items.Add(dr[4].ToString());
                    listBox6.Items.Add(dr[5].ToString());
                }
            }
            con.Close();
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox l = sender as ListBox;
            if(l.SelectedIndex !=-1)
            {
                listBox1.SelectedIndex = l.SelectedIndex;
                listBox2.SelectedIndex = l.SelectedIndex;
                listBox3.SelectedIndex = l.SelectedIndex;
                listBox4.SelectedIndex = l.SelectedIndex;
                listBox5.SelectedIndex = l.SelectedIndex;
                listBox6.SelectedIndex = l.SelectedIndex;
                textBox1.Text = listBox2.SelectedItem.ToString();
                textBox2.Text = listBox3.SelectedItem.ToString();
                textBox3.Text = listBox4.SelectedItem.ToString();
                textBox4.Text = listBox5.SelectedItem.ToString();
                textBox5.Text = listBox6.SelectedItem.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                con.Open();
                cmd.CommandText = "delete from student_info where fname='"+textBox1.Text+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete","Message From RJS");
                loadlist();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             if(textBox1.Text!="" & listBox1.SelectedIndex!=-1)
            {
                con.Open();
                cmd.CommandText = "update student_info set fname='"+textBox1.Text+"',lname='"+textBox2.Text+"',address='"+textBox3.Text+"',mobile='"+textBox4.Text+"',study='"+textBox5.Text+"'where fname='"+listBox2.SelectedItem.ToString()+"' and lname='"+listBox3.SelectedItem.ToString()+"' and address='"+listBox4.SelectedItem.ToString()+"' and mobile='"+listBox5.SelectedItem.ToString()+"' and study='"+listBox6.SelectedItem.ToString()+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Recorded Update","Message From RJS");
                loadlist();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

            }
        }

       
    }

    
}
