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
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for AnthClass.xaml
    /// </summary>
    public partial class AnthClass : Page
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; userid = root; password = ; Database = mydatabase");
        MySqlCommand cmdd;
        MySqlDataAdapter da;
        string sql;
        int result;
        public AnthClass()
        {
            InitializeComponent();

            

            string directory = "C:\\Users\\Gome Gumbo\\Documents\\NLPsystem";
            if (Directory.Exists(directory))
            {
                FileStream f = new FileStream("C:\\Users\\Gome Gumbo\\Documents\\NLPsystem\\Track32.txt", FileMode.Create);
                StreamWriter s = new StreamWriter(f);
            }
            else
            {
                Directory.CreateDirectory(directory);

                FileStream f = new FileStream("C:\\Users\\Gome Gumbo\\Documents\\NLPsystem\\Track32.txt", FileMode.Create);
                StreamWriter s = new StreamWriter(f);
            }
        }

        string connectionString = "datasource = 127.0.0.1; port = 3306; username = root; password = ; database = mydatabase";

        public void login()
        {
            string query = "Select * FROM employees WHERE Username = '" + UserName.Text + "' AND Password = '" + Password.Text + "' ";

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandTimeout = 60;
            MySqlDataReader Reader;

            try
            {
                con.Open();
                Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {

                        string Empn = Reader.GetString("EmpNo");
                        string Empna = Reader.GetString("EmpName");
                        string ss = DateTime.Now.ToString();


                        File.WriteAllText("C:\\Users\\Gome Gumbo\\Documents\\NLPsystem\\Track32.txt", Empn);


                        string sts = Reader.GetString("Status");

                        if(sts == "Admin")
                        {
                            this.NavigationService.Navigate(new AdminClass());
                        }

                        else if(sts == "User")
                        {
                            this.NavigationService.Navigate(new SecPG());
                        }
                        else
                        {
                            MessageBox.Show("Something Wrong with this account Contact the Admin for help, please");
                        }

                        sql = "Insert into `accessrecord`(`EmpName` , `EmpNo` , `AccessTM/DT`) values" +
                             "('" + Empna + "' " + " , '" + Empn + "' " + " , '" + ss + "')";
                        myMethod2(sql, "Access Denied", "Access Granted");


                    }

                }
                else
                {
                    AuthLb.Opacity = 0.9;
                    AuthLb.Content = "Not Available in the Database";
                }

                con.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }
        private void myMethod2(string sql, string msg_false, string msg_true)
        {
            try
            {
                
                conn.Open();
                cmdd = new MySqlCommand();
                cmdd.Connection = conn;
                cmdd.CommandText = sql;
                result = cmdd.ExecuteNonQuery();

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
                conn.Close();
            }
        }

        private void ProBtn_Click(object sender, RoutedEventArgs e)
        {
               
                if (UserName.Text == "" || Password.Text == "")
                {
                    MessageBox.Show("Fill in the Username and Password, please");
                }
                else
                {
                    login();
                }
            
            
        }
    }
}
