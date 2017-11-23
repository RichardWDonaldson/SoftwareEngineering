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
using Euston_Leisure_Messaging.control;
using Euston_Leisure_Messaging.view;
using System.Diagnostics;

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
            controller = new Control();
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
                
                testMessage = true;
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

                    txtblkMessage.Text = controller.Output.toString();
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else if (readMessage)
            {
                try
                {
                    controller.analyseMessage(inputHeader,inputBody);
                    txtblkMessage.Text = controller.Output.toString();
                }catch(System.ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("No message to display, please try again", "Error", MessageBoxButton.OK);
            }
        }

        private void btnShowTrending_Click(object sender, RoutedEventArgs e)
        {
            //declare new trending window
            Trending tr = new Trending();
            //show trending window
            tr.ShowDialog();
        }
    

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            //initilize message reader class
            messageReader = new MessageReader(txtbxPath.Text);
            try
            {
                //read messages from file
                messageReader.readMessage();
                //flip bool
                readMessage = true;
                //enable buttons to read through messages
                btnNext.IsEnabled = true;
                //display current message
                updateMessage();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Could not find file.");
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (i > 1)
            {
                //decrement message index
                i--;
            }
            else
            {
                i--;
                //disbale previous button if first index
                btnPrevious.IsEnabled = false;
            }
            //enable next button
            btnNext.IsEnabled = true;
            //display current message
            updateMessage();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //if not last message
            Debug.WriteLine("The last message is " + (messageReader.Messages.Count - 2));

            if (i < messageReader.Messages.Count - 2)
            {
                //increment message index
                i++;
            }
            else
            {
                //increment index
                i++;
                //disable next button
                btnNext.IsEnabled = false;
            }
            //enable previus button
            btnPrevious.IsEnabled = true;
            //display current message
            updateMessage();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            //create and show new trending window
            Trending tr = new Trending();
            tr.ShowDialog();
            //close window
            this.Close();
        }

        private void updateMessage()
        {
            //set header as first 10 chars of message
                 Debug.WriteLine("update Message " + i);
            Debug.WriteLine("message Reader" + messageReader.Messages[3]);
                inputHeader = messageReader.Messages[i].Substring(0, 10);
            Debug.WriteLine(inputHeader);
                //set body as message minus header /r/rn
                inputBody = messageReader.Messages[i].Remove(0, 12);
                //display message
                txtblkMessage.Text = "Unanalized Message:\n" + inputHeader + inputBody;
            
           
            
        }














    }
}
