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
    public partial class LIZ33 : Form
    {
        MySqlConnection con = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password = ; database = mydatabase");
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        DataView dv;
        MySqlDataAdapter Da = new MySqlDataAdapter();
        DataSet Ds;

        public LIZ33()
        {
            InitializeComponent();

            listView.Columns.Add("Client Name", 150);
            listView.Columns.Add("Address", 150, HorizontalAlignment.Center);
            listView.Columns.Add("Phone No.", 150, HorizontalAlignment.Center);
            listView.Columns.Add("Email", 150, HorizontalAlignment.Center);

            listView.View = View.Details;

            listView.FullRowSelect = true;

        }

        private void populateLV(String Client, String address, String phone, String email)
        {
            String[] row = { Client, address, phone, email };

            listView.Items.Add(new ListViewItem(row));
        }
        
        private void add(String Client, String address, String phone, String email)
        {
          //  string sql = "insert into ";
        }
        private void filtertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void updbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
