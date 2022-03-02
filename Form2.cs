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
    public partial class Form2 : Form
    {
       
        int rlno;
        string cd;
        string cm;
        DateTime d = DateTime.Now;
        
        public Form2()
        {
            InitializeComponent();
            view();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void view()
        {
            string view = "select * from Stud";
            SqlDataAdapter da1 = new SqlDataAdapter(view, Class1.con);
            DataTable dt1 = new DataTable();
            int a = da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            rlno = Convert.ToInt32(row.Cells[0].Value.ToString());
            MessageBox.Show(rlno.ToString(),"You Are Taking Attendence Of");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cd = d.Day.ToString();
            string cm = d.Month.ToString();
            //MessageBox.Show(cd,cm);
            ins();
            
        }

        private void ins()
        {

                string cd = d.Day.ToString();
                string view = "select * from Att where curdate = '" + cd + "' and rlno = '"+rlno+"' ";
                SqlDataAdapter da2 = new SqlDataAdapter(view, Class1.con);
                DataTable dt2 = new DataTable();
                int aa = da2.Fill(dt2);



                if (dt2.Rows.Count > 0)
                {
                    MessageBox.Show("Attendence is Already Filled");
                }
                else
                {
                    string inse = "insert into Att values('" + at.Text + "','" + cd + "','" + rlno + "')";
                    SqlDataAdapter daa = new SqlDataAdapter(inse, Class1.con);
                    DataTable dt = new DataTable();
                    int aaa = daa.Fill(dt);
                    if (aaa == 0)
                    {
                        MessageBox.Show("Record Inserted");
                    }
                    else
                    {
                        MessageBox.Show("Wrong");
                    }
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
    }