using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OptionPricing.Engine.Base;
using OptionPricing.ViewModel.Annotations;

namespace OptionPricing.ViewModel.Models
{
    public class OptionVM : Option, INotifyPropertyChanged
    {
        private double optionPrice;

        public double OptionPrice
        {
            get
            {
                return optionPrice;
            }
            set
            {
                optionPrice = value;
                OnPropertyChanged("OptionPrice");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
