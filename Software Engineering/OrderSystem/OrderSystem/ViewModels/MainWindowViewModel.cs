using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using OrderSystem.Views;

namespace OrderSystem.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Button Content

        public string AddOrderButtonContent { get; private set; }
        public string ViewOrderButtonContent { get; private set; }
        #endregion
        #region Button Command
        public ICommand AddOrderButtonCommand { get; private set; }
        public ICommand ViewOrderButtonCommand { get; private set; }
        #endregion
        
        public UserControl ContentControlBinding { get; private set; }

        public MainWindowViewModel()
        {
            AddOrderButtonContent = "Add Order";
            ViewOrderButtonContent = "View Order";

            AddOrderButtonCommand = new RelayCommand(AddOrderButtonClick);
            ViewOrderButtonCommand = new RelayCommand(ViewOrderButtonClick);

            ContentControlBinding = new DefaultView();

        }









        #region Private Click Helpers



        private void AddOrderButtonClick()
        {
            ContentControlBinding = new AddOrderView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void ViewOrderButtonClick()
        {
        }


        
        
        #endregion







    }
}
