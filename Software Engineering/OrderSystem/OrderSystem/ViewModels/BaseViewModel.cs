using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace OrderSystem.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }
}
