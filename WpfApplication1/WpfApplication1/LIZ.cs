using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WpfApplication1
{
    public partial class LIZ : Form
    {
        MySqlConnection con = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password = ; database = mydatabase");
        MySqlCommand cmd;
        DataTable dt;
        DataView dv;
        MySqlDataAdapter Da = new MySqlDataAdapter();
        DataSet Ds;
        public LIZ()
        {
            InitializeComponent();

            listView.Columns.Add("InvoiceID", 150);
            listView.Columns.Add("EmployNo", 150, HorizontalAlignment.Center);
            listView.Columns.Add("Date", 150, HorizontalAlignment.Center);

            listView.View = View.Details;

           
            string query = "Select * FROM invoice;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            Da = new MySqlDataAdapter(cmd);
            Ds = new DataSet();
            cmd.CommandTimeout = 60;
            MySqlDataReader Reader;
            try
            {
                con.Open();
                Reader = cmd.ExecuteReader();

                while (Reader.Read())
                {

                    string Inv = Reader.GetString("InvoiceID");
                    listView.Items.Add(Inv);
                    string Emp = Reader.GetString("EmpNo");
                    listView.Items[listView.Items.Count - 1].SubItems.Add(Emp);
                    string DT = Reader.GetString("OrderedDT");
                    listView.Items[listView.Items.Count - 1].SubItems.Add(DT);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }
             /*  try
               {
                   con.Open();
                   cmd = new MySqlCommand("select * from mydatabase", con);
                   Da = new MySqlDataAdapter(cmd);
                   Ds = new DataSet();
                   Da.Fill(Ds, "invoice");
                   con.Close();

                   dt = Ds.Tables["invoice"];
                   int i;
                   for (i = 0; i <= dt.Rows.Count - 1; i++)
                   {
                       listView.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                       listView.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                       listView.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());

                   }
               }
               catch(Exception exe)
               {
                   MessageBox.Show("There was a problem in loading Data");
               } */

        }

        private void populateListView(DataView dv)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filtertxt_TextChanged(object sender, EventArgs e)
        {
           // dv.RowFilter = string.Format("Name Like'%{0}%'", filtertxt.Text);
        }
    }
}
