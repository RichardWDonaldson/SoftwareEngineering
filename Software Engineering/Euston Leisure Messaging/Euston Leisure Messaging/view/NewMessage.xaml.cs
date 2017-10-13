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

namespace Euston_Leisure_Messaging
{
    /// <summary>
    /// Interaction logic for NewMessage.xaml
    /// </summary>
    public partial class NewMessage : Window
    {
        private String header, body;
        private bool confirm;

        #region getters and setters
        public String Header
        {
            get { return header; }
            set { header = value; }
        }

        public String Body
        {
            get { return body; }
            set { body = value; }
        }

        public bool Confirm
        {
            get { return confirm; }
            set { confirm = value; }
        }
    #endregion




        public NewMessage()
        {
            InitializeComponent();
        }


        #region button controls 
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtHeader.Text)) || (string.IsNullOrWhiteSpace(txtBody.Text))) {
                MessageBox.Show("Invalid Input - Please try again", "Error", MessageBoxButton.OK);

            } else {

                header = txtHeader.Text;
                body = txtBody.Text;

                confirm = true;
                this.Close();
            }
           
            
        } 

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            confirm = false;
            this.Close();
        }

#endregion











    }
}
