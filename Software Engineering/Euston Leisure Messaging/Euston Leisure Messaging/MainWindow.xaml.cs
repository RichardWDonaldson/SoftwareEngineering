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
        




        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewMessage_Click(object sender, RoutedEventArgs e)
        {
            NewMessage newMessage = new NewMessage();
            newMessage.ShowDialog();

            if(newMessage.Confirm())
            {
                inputHeader = NewMessage.Header;
                inputBody = NewMessage.Body;
                txtblkMessage.Text = inputHeader + "\n" + inputBody;
            }
        }

        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {

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
