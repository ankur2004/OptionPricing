using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OptionPricing.Engine.Base;
using OptionPricing.Engine.European;
using OptionPricing.ViewModel.Annotations;

namespace OptionPricing.ViewModel
{
    public class OptionViewModel : ViewModelBase, IDataErrorInfo
    {
        private double optionPrice;

        bool isSelected;
        double? timeToMaturity, rate, volatility, exercisePrice, spotPrice;
        private double price;
        Option option; 
        BlackScholes blackScholes;

        public OptionViewModel ()
        {
            isSelected = false;
            blackScholes = new BlackScholes();
            option = new EuropeanOption(OptionType.Call);
        }

        public OptionViewModel(Option option)
        {
            isSelected = false;
            this.option = option;
            blackScholes = new BlackScholes();
        }

        public double? TimeToMaturity
        {
            get
            {
                return option.Maturity ?? timeToMaturity;
            }
            set
            {

                if (option.Maturity == null)
                {
                    option.Maturity = value;
                }

                timeToMaturity = option.Maturity;
                
                OnPropertyChanged("TimeToMaturity");
            }
        }

        public double? Rate
        {
            get
            {
                return option.Rate ?? rate;
            }
            set
            {

                if (option.Rate == null)
                {
                    option.Rate = value;
                }

                rate = option.Rate;

                OnPropertyChanged("Rate");
            }
        }

        public double? Volatility
        {
            get
            {
                return option.Volatility ?? volatility;
            }
            set
            {
                if (option.Volatility == null)
                {
                    option.Volatility = value;
                }

                volatility = option.Volatility;

                OnPropertyChanged("Volatility");
            }

        }

        public double? ExercisePrice
        {
            get
            {
                return option.ExercisePrice ?? exercisePrice;
            }
            set
            {
                if (option.ExercisePrice == null)
                {
                    option.ExercisePrice = value;
                }

                exercisePrice = option.ExercisePrice;

                OnPropertyChanged("ExercisePrice");
            }
        }

        public double? SpotPrice
        {
            get
            {
                return option.SpotPrice ?? spotPrice;
            }
            set
            {
                if (option.SpotPrice == null)
                {
                    option.SpotPrice = value;
                }

                spotPrice = option.SpotPrice;

                OnPropertyChanged("SpotPrice");
            }
        }

        public double Price
        {
            get { return price; }

            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

       

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public void PriceOption()
        {

            blackScholes.CalculateOptionPrice(option);
            Price = option.Price;
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
