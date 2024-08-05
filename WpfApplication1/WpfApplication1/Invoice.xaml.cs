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
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
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



        string fileD = "C:\\Users\\Gome Gumbo\\Documents\\NLPsystem\\Track32.dll";

        public Invoice()
        {
            InitializeComponent();

            txDate.Text = DateTime.Now.ToShortDateString();

            BTtxt.Visibility = Visibility.Visible;
            Mic2.Visibility = Visibility.Visible;
            stop2.Visibility = Visibility.Visible; 

            Random Rand = new Random();
            txIvNo.Text = ("In" + "2022" + Rand.Next(1000));

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
                txtmas1.Text = null;
                txtmas2.Text = null;

            }
            else
            {
                txtmas.Text = null;
                txtmas1.Text = null;
                txtmas2.Text = null;
            }
        }

        public void Invoice_Load (object sender, EventArgs e)
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

          /*  Clist.Add(new string[] {" Refridgerator ", " Vehicle " ,"1","0", "2", "3", "4", "5", "6", "7", "8", "9",
                                    " Smartphone " , " Cement ", " Bag " , " Bags ", " sum "," House ", " Furniture "," Rice ",
                                    " Container ", " washing Machine "," Microwave " , " Maize "});  
            Grammar gr = new Grammar(new GrammarBuilder(Clist) ); */
            try
            {
                Listener.RequestRecognizerUpdate();
                // Listener.LoadGrammar(gr);  
                Listener.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines("C:\\Users\\Gome Gumbo\\Documents\\NLPsystem\\Gram.dll")))));
                Listener.SpeechRecognized += speech_recognized;
                Listener.SetInputToDefaultAudioDevice();
                Listener.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Set Your Microphone Properly");
            }
        }
        void speech_recognized(object sender, SpeechRecognizedEventArgs e)
        {
            runingtime = 0;

           txtmas.Text = e.Result.Text.ToString() + " ";

           txtmas1.Text = e.Result.Text.ToString();

           txtmas2.Text = e.Result.Text.ToString();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            DataInsert();
        }
        private void tx1by1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tx1by1.IsEnabled = false;
            tx2by1.IsEnabled = false;
            tx3by1.IsEnabled = false;
            tx4by1.IsEnabled = false;
            tx5by1.IsEnabled = false;
            tx1by2.IsEnabled = false;
            tx2by2.IsEnabled = false;
            tx3by2.IsEnabled = false;
            tx4by2.IsEnabled = false;
            tx5by2.IsEnabled = false;
            tx1by3.IsEnabled = false;
            tx2by3.IsEnabled = false;
            tx3by3.IsEnabled = false;
            tx4by3.IsEnabled = false;
            tx5by3.IsEnabled = false;
            Commenttx.IsEnabled = false;
            TextPos.Text = null;
            Mic.Visibility = Visibility.Visible;
            TextPos.Visibility = Visibility.Visible;
            stop.Visibility = Visibility.Visible;

          
        }

       public void DataInsert()
        {
            Listener.RecognizeAsyncStop();
            Mic.IsEnabled = true;
            stop.IsEnabled = false;
            LBlis.Opacity = 0;

            if (tx1by1.Text == "")
            { tx1by1.Text = TextPos.Text; }         
            else if(tx2by1.Text == "")
            { tx2by1.Text = TextPos.Text; }
            else if (tx3by1.Text == "")
            { tx3by1.Text = TextPos.Text; }
            else if (tx4by1.Text == "")
            { tx4by1.Text = TextPos.Text; }
            else if (tx5by1.Text == "")
            { tx5by1.Text = TextPos.Text; }
            else
            { Commenttx.Text = TextPos.Text; }
            
            tx1by1.IsEnabled = true;
            tx2by1.IsEnabled = true;
            tx3by1.IsEnabled = true;
            tx4by1.IsEnabled = true;
            tx5by1.IsEnabled = true;
            tx1by2.IsEnabled = true;
            tx2by2.IsEnabled = true;
            tx3by2.IsEnabled = true;
            tx4by2.IsEnabled = true;
            tx5by2.IsEnabled = true;
            tx1by3.IsEnabled = true;
            tx2by3.IsEnabled = true;
            tx3by3.IsEnabled = true;
            tx4by3.IsEnabled = true;
            tx5by3.IsEnabled = true;
            Commenttx.IsEnabled = true;
            Mic.Visibility = Visibility.Hidden;
            TextPos.Visibility = Visibility.Hidden;
            stop.Visibility = Visibility.Hidden;

            txtmas.Clear();
        }

        public void DataInsert2()
        {
            Listener.RecognizeAsyncStop();

            intMic.IsEnabled = true;
            intstop.IsEnabled = false;
            LBlis.Opacity = 0;

            if (tx1by2.Text == "")
            { tx1by2.Text = TextPos2.Text; }
            else if (tx1by3.Text == "")
            { tx1by3.Text = TextPos2.Text; }
            else if (tx2by2.Text == "")
            { tx2by2.Text = TextPos2.Text; }
            else if (tx2by3.Text == "")
            { tx2by3.Text = TextPos2.Text; }
            else if (tx3by2.Text == "")
            { tx3by2.Text = TextPos2.Text; }
            else if (tx3by3.Text == "")
            { tx3by3.Text = TextPos2.Text; }
            else if (tx4by2.Text == "")
            { tx4by2.Text = TextPos2.Text; }
            else if (tx4by3.Text == "")
            { tx4by3.Text = TextPos2.Text; }
            else if (tx5by2.Text == "")
            { tx5by2.Text = TextPos2.Text; }
            else
            { tx5by3.Text = TextPos2.Text; }

            tx1by1.IsEnabled = true;
            tx2by1.IsEnabled = true;
            tx3by1.IsEnabled = true;
            tx4by1.IsEnabled = true;
            tx5by1.IsEnabled = true;
            tx1by2.IsEnabled = true;
            tx2by2.IsEnabled = true;
            tx3by2.IsEnabled = true;
            tx4by2.IsEnabled = true;
            tx5by2.IsEnabled = true;
            tx1by3.IsEnabled = true;
            tx2by3.IsEnabled = true;
            tx3by3.IsEnabled = true;
            tx4by3.IsEnabled = true;
            tx5by3.IsEnabled = true;
            Commenttx.IsEnabled = true;
            intMic.Visibility = Visibility.Hidden;
            TextPos2.Visibility = Visibility.Hidden;
            intstop.Visibility = Visibility.Hidden;

            txtmas1.Clear();
        }

        public void Solutionz()
        {
            try
            {
             //   int Atax = Int32.Parse(tx1by2.Text);
                double Btax = Double.Parse(tx2by2.Text);
                double Ctax = Double.Parse(tx3by2.Text);
                double Dtax = Double.Parse(tx4by2.Text);
                double Etax = Double.Parse(tx5by2.Text);
                double Atax = Double.Parse(tx1by2.Text);

                double TaxSum = Atax + Btax + Ctax + Dtax + Etax;
                string TaxableValue = Convert.ToString(TaxSum);
                txTexble.Text = TaxableValue;

                double Ato = Double.Parse(tx1by3.Text);
                double Bto = Double.Parse(tx2by3.Text);
                double Cto = Double.Parse(tx3by3.Text);
                double Dto = Double.Parse(tx4by3.Text);
                double Eto = Double.Parse(tx5by3.Text);

                double subT = Ato + Bto + Cto + Dto + Eto;
                string SubtValue = Convert.ToString(subT);
                txSubT.Text = SubtValue;

                double TA = subT + TaxSum ;
                string TAvalue = Convert.ToString(TA);
                txtotam.Text = TAvalue;
            }
            catch (Exception count)
            {
                MessageBox.Show(" something went wrong, \n please Use numbers only in Tax and amount columns \n Or Contact the Admin for help");
            }
            
        }

        private void SubBtn_Click(object sender, RoutedEventArgs e)
        {
            Solutionz();

           sql = "Insert into `invoice`(`InvoiceID` , `EmpNo` , `OrderedDT` , `SubTotal` , `Taxable` , `TotalAmount` , `Comment` , `ClientName`) values " +
               "('" + txIvNo.Text + "' " + " , '" + txempID.Text + "' " + " , '" + txDate.Text + "' " + " , '"
               + txSubT.Text + "'" + " , '" + txTexble.Text + "'"  + " , '" + txtotam.Text + "'" + " , '" + Commenttx.Text + "'" + " , '" + lbname.Content + "')";
            myMethod2(sql, "Data was not stored something Went Wrong", "Data Has Been stored Successfully");

            sql = "Insert into `items`( `ProDesc`, `InvoiceID` , `Amount` , `Tax`) values " +
                  "('" + tx1by1.Text + "' " + " , '" + txIvNo.Text + "' " + " , '"
               + tx1by3.Text + "'" + " , '" + tx1by2.Text + "')";
            myMethod2(sql, "Data was not stored something Went Wrong", "First Item Stored Successfully");

            sql = "Insert into `items`( `ProDesc`, `InvoiceID` , `Amount` , `Tax`) values " +
                 "( '" + tx2by1.Text + "' " + " , '" + txIvNo.Text + "' " + " , '"
              + tx2by3.Text + "'" + " , '" + tx2by2.Text + "')";
            myMethod2(sql, "Data was not stored something Went Wrong", "Second Item Stored Successfully");

            sql = "Insert into `items`( `ProDesc`, `InvoiceID` , `Amount` , `Tax`) values " +
                 "('" + tx3by1.Text + "' " + " , '" + txIvNo.Text + "' " + " , '"
              + tx3by3.Text + "'" + " , '" + tx3by2.Text + "')";
            myMethod2(sql, "Data was not stored something Went Wrong", "Third Item Stored Successfully");

            sql = "Insert into `items`( `ProDesc`, `InvoiceID` , `Amount` , `Tax`) values " +
                 "('" + tx4by1.Text + "' " + " , '" + txIvNo.Text + "' " + " , '"
              + tx4by3.Text + "'" + " , '" + tx4by2.Text + "')";
            myMethod2(sql, "Data was not stored something Went Wrong", " Fourth Item Stored Successfully");

            sql = "Insert into `items`( `ProDesc`, `InvoiceID` , `Amount` , `Tax`) values " +
                 "('" + tx5by1.Text + "' " + " , '" + txIvNo.Text + "' " + " , '"
              + tx5by3.Text + "'" + " , '" + tx5by2.Text + "')";
            myMethod2(sql, "Data was not stored something Went Wrong", "Fifth Item Stored Successfully");

            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print,"Invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void Mic2_Click(object sender, RoutedEventArgs e)
        {
             Mic2.IsEnabled = false;
             stop2.IsEnabled = true;
             LBlis.Opacity = 0.6;

             Clist.Add(new string[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9","c","l","."});

             Grammar gr = new Grammar(new GrammarBuilder(Clist));
             try
             {
                 Listener.RequestRecognizerUpdate();
                 Listener.LoadGrammar(gr);
                 Listener.SpeechRecognized += speech_recognized;
                 Listener.SetInputToDefaultAudioDevice();
                 Listener.RecognizeAsync(RecognizeMode.Multiple);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Set Your Microphone Properly");
             }
        }

        private void stop2_Click(object sender, RoutedEventArgs e)
        {
            Listener.RecognizeAsyncStop();
            Mic2.IsEnabled = true;
            stop2.IsEnabled = false;
            LBlis.Opacity = 0;

            MySqlConnection conn = new MySqlConnection("server = localhost; userid = root; password = ; Database = mydatabase");
            MySqlCommand cmd1;

            try
            {
                conn.Open();
                cmd1 = new MySqlCommand("select ClientCode,ClientName,CompanyName,Address,PhoneNo,Email from clients where ClientCode = @CC", conn);
                cmd1.Parameters.AddWithValue("@CC", BTtxt.Text);
                MySqlDataReader Reader1;
                Reader1 = cmd1.ExecuteReader();

                if(Reader1.Read())
                {
                     lbname.Content = Reader1["ClientName"].ToString();
                     lbbtCname.Content = Reader1["CompanyName"].ToString();
                     lbbtAddr.Content = Reader1["Address"].ToString();
                     lbbtphone.Content = Reader1["PhoneNo"].ToString();
                     lbbtemail.Content = Reader1["Email"].ToString();
                    //lbname.Content = Reader1.GetString("ClientName");
                }
                else
                {
                    MessageBox.Show("Not found in Database");
                }

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("something went wrong");
            }

            BTtxt.Visibility = Visibility.Hidden;
            Mic2.Visibility = Visibility.Hidden;
            stop2.Visibility = Visibility.Hidden;
        }

        private void intMic_Click(object sender, RoutedEventArgs e)
        {
            intMic.IsEnabled = false;
            intstop.IsEnabled = true;
            LBlis.Opacity = 0.6;

            Clist.Add(new string[] {"1","0", "2", "3", "4", "5", "6", "7", "8", "9"});

            Grammar gr = new Grammar(new GrammarBuilder(Clist));
            try
            {
                Listener.RequestRecognizerUpdate();
                Listener.LoadGrammar(gr);
                Listener.SpeechRecognized += speech_recognized;
                Listener.SetInputToDefaultAudioDevice();
                Listener.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Set Your Microphone Properly");
            }
        }

        private void intstop_Click(object sender, RoutedEventArgs e)
        {
           DataInsert2();
        }

        private void tx2by1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tx1by1.IsEnabled = false;
            tx2by1.IsEnabled = false;
            tx3by1.IsEnabled = false;
            tx4by1.IsEnabled = false;
            tx5by1.IsEnabled = false;
            tx1by2.IsEnabled = false;
            tx2by2.IsEnabled = false;
            tx3by2.IsEnabled = false;
            tx4by2.IsEnabled = false;
            tx5by2.IsEnabled = false;
            tx1by3.IsEnabled = false;
            tx2by3.IsEnabled = false;
            tx3by3.IsEnabled = false;
            tx4by3.IsEnabled = false;
            tx5by3.IsEnabled = false;
            Commenttx.IsEnabled = false;
            TextPos2.Text = null;
            intMic.Visibility = Visibility.Visible;
            TextPos2.Visibility = Visibility.Visible;
            intstop.Visibility = Visibility.Visible;
        }

        private void txtmas_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextPos.Text += txtmas.Text.ToString();
        }

        private void txtmas1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextPos2.Text += txtmas1.Text.ToString();
        }

        private void txtmas2_TextChanged(object sender, TextChangedEventArgs e)
        {
            BTtxt.Text += txtmas2.Text.ToString();
        }
    }
    
}