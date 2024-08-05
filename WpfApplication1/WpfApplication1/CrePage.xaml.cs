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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for CrePage.xaml
    /// </summary>
    public partial class CrePage : Page
    {
        MySqlConnection con = new MySqlConnection("server = localhost; userid = root; password = ; Database = mydatabase");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        string sql;
        int result;

        public CrePage()
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
            
            sql = "Insert into `employees`(`EmpNo` , `EmpName` , `PhoneNo` , `Address` , `Password` , `UserName` , `Gender`, `Status`) values " +
               "('" + EmpNotxt.Text + "' " + " , '" + EmpNametxt.Text + "' " + " , '" + Phonetxt.Text + "' " + " , '" 
               + Addresstxt.Text + "'" + " , '" + Passtxt.Text + "'" + " , '" + UserNametxt.Text + "'" + " , '" + comboBox.Text + "'" + ",'" + Status.Text + "')";
            myMethod(sql, "Account was not Created something Went Wrong", "Account Has Been Created Successfully");

            this.NavigationService.Navigate(new CrePage());
        }

        private void DelAccBtn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            LIZ2 load = new LIZ2();
            load.ShowDialog();
        }

        private void CCaccBtn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            ClientACC cli = new ClientACC();
            cli.ShowDialog();
        }
    }
}
