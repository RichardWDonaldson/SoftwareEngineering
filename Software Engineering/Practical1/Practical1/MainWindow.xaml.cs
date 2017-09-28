using System;
using System.Collections.Generic;
using System.IO;
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

namespace Practical1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool backButtonWasClicked = false;
        private bool nextButtonWasClicked = false;
        int counter = 1;
        string[] readText;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            int age;
            string address = txtAddress.Text;

            if((string.IsNullOrWhiteSpace(txtName.Text)) || (string.IsNullOrWhiteSpace(txtAge.Text)) || (string.IsNullOrWhiteSpace(txtAddress.Text))) {
                MessageBox.Show("fields are empty, please try again");
                return;
            } else if (int.TryParse(txtAge.Text, out age))
            {
                age = int.Parse(txtAge.Text);
            } else
            {
                MessageBox.Show("Incorrect value for age field. Please try again");
                return;
            }

            String directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String path = directory + @"\test.txt";
            if (!File.Exists(path)) {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
                {
                   
                }

                

            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(name);
                sw.WriteLine(age);
                sw.WriteLine(address);
            }

            MessageBox.Show("Information has been saved");


           
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = System.String.Empty;
            txtAge.Text = System.String.Empty;
            txtName.Text = System.String.Empty;

            

        }
     

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            
            string line;

            String directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String path = directory + @"\test.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                 readText = File.ReadAllLines(path);

             

            
         
            }
        }


        /* var lineCount = File.ReadLines(@"C:\file.txt").Count(); */
        /* Fix this program so that it doesn't crash with IndexOutOfBounds */

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            counter--;
            backButtonWasClicked = true;

            txtName.Text = readText[counter];
            txtAge.Text = readText[counter + 1];
            txtAddress.Text = readText[counter + 2];
            
            

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            nextButtonWasClicked = true;

            txtName.Text = readText[counter];
            txtAge.Text = readText[counter + 1];
            txtAddress.Text = readText[counter + 2];
        }
    }
}
