using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using OrderSystem.Commands;
using System.Windows;
using OrderSystem.Models;
using OrderSystem.Database;

namespace OrderSystem.ViewModels
{
    public class AddOrderViewModel : BaseViewModel
    {
        #region TextBlock Content
        public string ItemNameTextBlock { get; private set; }
        public string ItemPriceTextBlock { get; private set; }
        public string ItemPaidTextBlock { get; private set; }
        #endregion

        #region TextBox Content
        public string ItemNameTextBox { get; set; }
        public string ItemPriceTextBox { get; set; }
        
        #endregion


        #region Paid CheckBox
        public bool IsPaid { get; set; }
        #endregion

        #region Add Button Content/Command
        public string AddButtonText { get; private set; }

        public ICommand AddButtonCommand { get; private set; }
        #endregion

        #region Contructor
        public AddOrderViewModel()
        {
            ItemNameTextBlock = "Item Name:";
            ItemPriceTextBlock = "Item Price:";
            ItemPaidTextBlock = "Paid";

            ItemNameTextBox = string.Empty;
            ItemPriceTextBox = string.Empty;

            IsPaid = true;

            AddButtonText = "Add Order";

            AddButtonCommand = new RelayCommand(AddButtonClick);


        }
        #endregion

        #region Private Click Helpers
        private void AddButtonClick()
        {
            if(string.IsNullOrWhiteSpace(ItemNameTextBox) || string.IsNullOrWhiteSpace(ItemPriceTextBox))
            {
                MessageBox.Show("Please enter all values");
                return;
            }

            Order order = new Order()
            {
                Name = ItemNameTextBox,
                Price = Convert.ToDecimal(ItemPriceTextBox),
                IsPaid = IsPaid
            };

            SaveToFile save = new SaveToFile();

            if(!save.ToCsv(order))
            {
                MessageBox.Show("Error while saving\n" + save.ErrorCode);
            }
            else
            {
                MessageBox.Show("Order Saved");
                save = null;
            }





        }

        #endregion 


    }
}
