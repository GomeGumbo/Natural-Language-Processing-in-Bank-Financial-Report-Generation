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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ClientACC.xaml
    /// </summary>
    public partial class ClientACC : Window
    {
        MySqlConnection con = new MySqlConnection("server = localhost; userid = root; password = ; Database = mydatabase");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        string sql;
        int result;

        public ClientACC()
        {
            InitializeComponent();
        }

        private void myMethod(string sql, string msg_false, string msg_true)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(msg_true);
                }
                else { MessageBox.Show(msg_false); }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SubBtn_Click(object sender, RoutedEventArgs e)
        {
            sql = "Insert into `clients`(`ClientCode` , `ClientName` , `CompanyName` , `Address` , `PhoneNo` , `Email` , `Gender`) values " +
              "('" + EmpNotxt.Text + "' " + " , '" + EmpNametxt.Text + "' " + " , '" + UserNametxt.Text + "' " + " , '"
              + Addresstxt.Text + "'" + " , '" + Phonetxt.Text + "'" + " , '" + Passtxt.Text + "'" + " , '" + comboBox.Text + "')";
            myMethod(sql, "Account was not Created something Went Wrong", "Account Has Been Created Successfully");

            this.Close();

            ClientACC cli = new ClientACC();
            cli.ShowDialog();


        }
    }
}
