using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.ViewModel.Models
{
    public class Option : INotifyPropertyChanged
    {
        private double timeToMaturity, volatility, rate, exercisePrice, stockPrice, optionPrice;
 

        public double TimeToMaturity
        { 
            get
            {

                return timeToMaturity;
            }
            set
            {
                timeToMaturity = value;
                OnPropertyChanged("TimeToMaturity");
            }
        }

        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }

        public double Volatility
        {
            get
            {
                return volatility;
            }
            set
            {
                volatility = value;
                OnPropertyChanged("Volatility");
            }

        }

        public double ExercisePrice
        { 
            get
            {
                return exercisePrice;
            }
            set
            {
                exercisePrice = value;
                OnPropertyChanged("ExercisePrice");
            }
        }

        public double StockPrice 
        { 
            get
            {
                return stockPrice;
            }
            set
            {
                stockPrice = value;
                OnPropertyChanged("StockPrice");
            }
        }

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

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
