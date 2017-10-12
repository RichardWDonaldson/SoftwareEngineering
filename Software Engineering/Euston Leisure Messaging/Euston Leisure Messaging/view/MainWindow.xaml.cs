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
using System.Windows.Input;

namespace Euston_Leisure_Messaging
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String inputHeader, inputBody;
        private int i;
        private bool testMessage, readMessage;
        private Control controller;
        private MessageReader messageReader;




        public MainWindow()
        {
            InitializeComponent();
            Control crtl = new Control();
            testMessage = false;
            readMessage = false;
            i = 0;
        }

        private void btnNewMessage_Click(object sender, RoutedEventArgs e)
        {
            NewMessage newMessage = new NewMessage();
            newMessage.ShowDialog();

            if(newMessage.Confirm)
            {
                inputHeader = newMessage.Header;
                inputBody = newMessage.Body;

                txtblkMessage.Text = inputHeader + "\n" + inputBody;
            }
        }

        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            if(testMessage)
            {
                try
                {


                    controller.analyseMessage(inputHeader, inputBody);

                    txtblkMessage.Text = controller.FinalMessage.messageOut();
                } catch (System.ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.Message);
                }
            } else if (readMessage)
            {
                try
                {
                    controller.analyseMessage(inputHeader,inputBody);
                    txtblkMessage.Text = controller.FinalMessage.messageOut();
                }catch(System.ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.Message);
                }
            } else
            {
                MessageBox.Show("No message to display, please try again", "Error", MessageBoxButton.OK);
            }
        }

        private void btnShowTrending_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {

        }

        

     












    }
}
