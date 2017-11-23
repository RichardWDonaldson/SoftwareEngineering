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

namespace Euston_Leisure_Messaging.view
{
    /// <summary>
    /// Interaction logic for Trending.xaml
    /// </summary>
    public partial class Trending : Window
    {
        public Trending()
        {
            InitializeComponent();
            //get keys from each dictionary
            var hashList = Control.Dictionary_HashTag.Keys.ToList();
            var mentionList = Control.Dictionary_Mention.Keys.ToList();
            var sirList = Control.Dictionary_SIR.Keys.ToList();


            //sort keys
            hashList.Sort();
            mentionList.Sort();
            sirList.Sort();
            //display dictionarys in alphabetical order
            foreach (var key in hashList)
            {
                lstTrending.Items.Add(Control.Dictionary_HashTag[key] + ": " + key);
            }
            foreach (var key in mentionList)
            {
                lstMention.Items.Add(Control.Dictionary_Mention[key] + ": " + key);
            }
            foreach (var key in sirList)
            {
                lstSir.Items.Add(Control.Dictionary_SIR[key] + ": " + key);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
