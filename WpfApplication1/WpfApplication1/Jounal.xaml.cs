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
using System.Speech;
using System.Speech.Recognition;
using System.Threading;
using System.Speech.Synthesis;
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows.Threading;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Jounal.xaml
    /// </summary>
    public partial class Jounal : Window
    {
        SpeechSynthesizer SS = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine Listener = new SpeechRecognitionEngine();
        Choices Clist = new Choices();

        MySqlConnection con = new MySqlConnection("server = localhost; userid = root; password = ; Database = mydatabase");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        string sql;
        int result;
        int runingtime;

        DispatcherTimer gametimer = new DispatcherTimer();

        string fileD = "C:\\Users\\Gome Gumbo\\Documents\\NLPsystem\\Track32.txt";

        public Jounal()
        {
            InitializeComponent();

            txDate.Text = DateTime.Now.ToShortDateString();

            Random Rand = new Random();
            txIvNo.Text = ("Jn" + "2022" + Rand.Next(1000));

            txpage.Text = "1";

            gametimer.Tick += GameTimerEvent;
            gametimer.Interval = TimeSpan.FromMilliseconds(50);
            gametimer.Start();

            txempID.Text = File.ReadAllText(fileD);
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (runingtime == 20)
            {
                txtmas.Text = null;

            }
            else
            {
                txtmas.Text = null;
            }
        }
        public void Jounal_Load(object sender, EventArgs e)
        {
            Listener.SetInputToDefaultAudioDevice();
            Listener.LoadGrammarAsync(new DictationGrammar());

        }

        private void myMethod2(string sql, string msg_false, string msg_true)
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
        private void Mic_Click(object sender, RoutedEventArgs e)
        {
            Mic.IsEnabled = false;
            stop.IsEnabled = true;
            LBlis.Opacity = 0.6;

           /* Clist.Add(new string[] { "Account", "Purchased", "Sold", "Sales", " Sum of", "Balance", "Profit", "Loss","Cash"});

            Grammar gr = new Grammar(Clist);*/
            try
            {
                Listener.RequestRecognizerUpdate();
                Listener.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines("C:\\Users\\Gome Gumbo\\Documents\\NLPsystem\\JnGram.txt")))));
               // Listener.LoadGrammar(gr);
                Listener.SpeechRecognized += speech_recognized;
                Listener.SetInputToDefaultAudioDevice();
                Listener.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Set Your Microphone Properly");
            }
        }


        void speech_recognized(object sender, SpeechRecognizedEventArgs e)
        {
            runingtime = 0;

            txtmas.Text = e.Result.Text.ToString();
        }
        private void tx1by2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tx1by1_Copy.IsEnabled = false;
            tx2by1_Copy.IsEnabled = false;
            tx3by1_Copy.IsEnabled = false;
            tx4by1_Copy.IsEnabled = false;
            tx5by1_Copy.IsEnabled = false;
            tx1by2_Copy.IsEnabled = false;
            tx2by2_Copy.IsEnabled = false;
            tx3by2_Copy.IsEnabled = false;
            tx4by2_Copy.IsEnabled = false;
            tx5by2_Copy.IsEnabled = false;
            tx1by3_Copy.IsEnabled = false;
            tx2by3_Copy.IsEnabled = false;
            tx3by3_Copy.IsEnabled = false;
            tx4by3_Copy.IsEnabled = false;
            tx5by3_Copy.IsEnabled = false;
            tx1by2_Copy2.IsEnabled = false;
            tx2by2_Copy2.IsEnabled = false;
            tx3by2_Copy2.IsEnabled = false;
            tx4by2_Copy2.IsEnabled = false;
            tx5by2_Copy2.IsEnabled = false;
            tx1by2_Copy3.IsEnabled = false;
            tx2by2_Copy3.IsEnabled = false;
            tx3by2_Copy3.IsEnabled = false;
            tx4by2_Copy3.IsEnabled = false;
            tx5by2_Copy3.IsEnabled = false;

            TextPos.Text = null;
            Mic.Visibility = Visibility.Visible;
            TextPos.Visibility = Visibility.Visible;
            stop.Visibility = Visibility.Visible;
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            DataInsert();
        }

        public void DataInsert()
        {
            Listener.RecognizeAsyncStop();
            Mic.IsEnabled = true;
            stop.IsEnabled = false;
            LBlis.Opacity = 0;

            if (tx1by1.Text == "")
            { tx1by1.Text = TextPos.Text; }
            else if (tx1by2.Text == "")
            { tx1by2.Text = TextPos.Text; }
            else
            { tx1by3.Text = TextPos.Text; }


            tx1by1_Copy.IsEnabled = true;
            tx2by1_Copy.IsEnabled = true;
            tx3by1_Copy.IsEnabled = true;
            tx4by1_Copy.IsEnabled = true;
            tx5by1_Copy.IsEnabled = true;
            tx1by2_Copy.IsEnabled = true;
            tx2by2_Copy.IsEnabled = true;
            tx3by2_Copy.IsEnabled = true;
            tx4by2_Copy.IsEnabled = true;
            tx5by2_Copy.IsEnabled = true;
            tx1by3_Copy.IsEnabled = true;
            tx2by3_Copy.IsEnabled = true;
            tx3by3_Copy.IsEnabled = true;
            tx4by3_Copy.IsEnabled = true;
            tx5by3_Copy.IsEnabled = true;
            tx1by2_Copy2.IsEnabled = true;
            tx2by2_Copy2.IsEnabled = true;
            tx3by2_Copy2.IsEnabled = true;
            tx4by2_Copy2.IsEnabled = true;
            tx5by2_Copy2.IsEnabled = true;
            tx1by2_Copy3.IsEnabled = true;
            tx2by2_Copy3.IsEnabled = true;
            tx3by2_Copy3.IsEnabled = true;
            tx4by2_Copy3.IsEnabled = true;
            tx5by2_Copy3.IsEnabled = true;
            Mic.Visibility = Visibility.Hidden;
            TextPos.Visibility = Visibility.Hidden;
            stop.Visibility = Visibility.Hidden;

            txtmas.Clear();

        }

        private void SubBtn_Click(object sender, RoutedEventArgs e)
        {
            /*  sql = "Insert into `invoice`(`InvoiceID` , `EmpNo` , `OrderedDT` , `SubTotal` , `Taxable` , `TaxRate` , `TaxDue`, `OtherCost` , `TotalAmount` , `Comment`) values " +
                 "('" + txIvNo.Text + "' " + " , '" + txempID.Text + "' " + " , '" + txDate.Text + "' " + " , '"
                 + txSubT.Text + "'" + " , '" + txTexble.Text + "'" + " , '" + txTaxRate.Text + "'" + " , '" + txTaxDue.Text + "'" + " , '" + txothercst.Text + "'" + " , '" + txtotam.Text + "'" + " , '" + Commenttx.Text + "')";
              myMethod2(sql, "Data was not stored something Went Wrong", "Data Has Been stored Successfully"); */

            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Jounal");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void txtmas_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextPos.Text += txtmas.Text.ToString();
        }
    }
}
