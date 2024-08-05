using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for LoadPage.xaml
    /// </summary>
    public partial class LoadPage : Page
    {
        public LoadPage()
        {
            InitializeComponent();
        }

        void list()
        {
            string connectionString = "datasource = 127.0.0.1; port = 3306; username = root; password = ; database = mydatabase";
            string query = "Select * FROM invoice;";
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandTimeout = 60;
            MySqlDataReader Reader;



            try
            {
                con.Open();
                Reader = cmd.ExecuteReader();

                while(Reader.Read())
                {
                    string In = Reader.GetString("InvoiceID");
                    listBox.Items.Add(In);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }
        }
    }
}
