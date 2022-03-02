using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Attendence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string view = "select * from Stud Where Rollno = '" + rlno.Text + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(view, Class1.con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {
                MessageBox.Show("Rollno Must Be Unique");
                clearval();
            }
            else
            {
                string ins = "Insert into Stud values('" + rlno.Text + "','" + nm.Text + "','" + comboBox1.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(ins, Class1.con);
                DataTable dt = new DataTable();
                int a = da.Fill(dt);
                if (a == 0)
                {
                    MessageBox.Show("Record Inserted");
                    clearval();
                }
                else
                {
                    MessageBox.Show("Something Wrong");
                    clearval();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearval();

        }
            private void clearval()
            {
                rlno.Text = "";
                nm.Text = "";
                comboBox1.Text = "";
                rlno.Focus();
            }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
