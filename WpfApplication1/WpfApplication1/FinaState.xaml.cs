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
    /// Interaction logic for FinaState.xaml
    /// </summary>
    public partial class FinaState : Page
    {
        public FinaState()
        {
            InitializeComponent();
        }

        private void IVbtn_Click(object sender, RoutedEventArgs e)
        {
            Invoice NewInvoice = new Invoice();
            NewInvoice.ShowDialog();
        }

        private void TBbtn_Click(object sender, RoutedEventArgs e)
        {
            Jounal Journal1 = new Jounal();
            Journal1.ShowDialog();
        }
    }
}
