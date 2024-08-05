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
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using MySql.Data.MySqlClient;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; userid = root; password = ; Database = mydatabase");
        MySqlCommand cmdd;
        MySqlDataAdapter da;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MyMainWindow_Loaded;
        }

        private void MyMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Mainframe.NavigationService.Navigate(new AnthClass());
        }
        private void Mainframe_Navigated(object sender, NavigationEventArgs e)
        {
            
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.NavigationService.Navigate(new InfoPage());
        }

        private void SoBtn_Click(object sender, RoutedEventArgs e)
        {
            string LT = DateTime.Now.ToString();
            try
            {

                conn.Open();
                cmdd = new MySqlCommand("update accessrecord SET LogoutTM = @A1 where logoutTM = @B1" ,conn);
                cmdd.Parameters.AddWithValue("@B1", "");
                cmdd.Parameters.AddWithValue("@A1", LT);
                cmdd.ExecuteNonQuery();

                MessageBox.Show("Signing Out, \n Make sure you saved the Documents");

                this.Close();
            }
            catch(Exception ii)
            {
                MessageBox.Show("Your System Jammed");
            }
            
        }
    }
}
