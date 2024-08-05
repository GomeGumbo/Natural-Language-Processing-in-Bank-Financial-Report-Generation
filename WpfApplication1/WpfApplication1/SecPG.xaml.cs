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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for SecPG.xaml
    /// </summary>
    public partial class SecPG : Page
    {
        public SecPG()
        {
            InitializeComponent();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FinaState());
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoadPage());
            LIZ load = new LIZ();
            load.ShowDialog();
        }

        private void CCaccBtn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            ClientACC cli = new ClientACC();
            cli.ShowDialog();
        }
    }
}
