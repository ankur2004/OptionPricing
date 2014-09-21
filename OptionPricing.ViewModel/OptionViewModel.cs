﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using OptionPricing.Engine.Base;
using OptionPricing.Engine.European;
using OptionPricing.ViewModel.Commands;

namespace OptionPricing.ViewModel
{
    public class OptionViewModel : ViewModelBase, IDataErrorInfo
    {
        private double optionPrice;

        bool isSelected;
        double? timeToMaturity, rate, volatility, exercisePrice, spotPrice;
        private double price, delta, gamma, rho, theta, vega;
        EuropeanOption option; 
        BlackScholes blackScholes;

        public OptionViewModel ()
        {
            isSelected = false;
            blackScholes = new BlackScholes();
            option = new EuropeanOption(OptionType.Call);
        }

        public OptionViewModel(EuropeanOption option)
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

        public double Delta
        {
            get { return delta; }

            set
            {
                delta = value;
                OnPropertyChanged("Delta");
            }
        }

        public double Gamma
        {
            get { return gamma; }

            set
            {
                gamma = value;
                OnPropertyChanged("Gamma");
            }
        }

        public double Rho
        {
            get { return rho; }

            set
            {
                rho = value;
                OnPropertyChanged("Rho");
            }
        }

        public double Theta
        {
            get { return theta; }

            set
            {
                theta = value;
                OnPropertyChanged("Theta");
            }
        }

        public double Vega
        {
            get { return vega; }

            set
            {
                vega = value;
                OnPropertyChanged("Vega");
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
            Delta = option.Delta;
            Rho = option.Rho;
            Theta = option.Theta;
            Vega = option.Vega;
        }

        private DelegateCommand showGreeksCommand;

        public ICommand ShowGreeksCommand
        {
            get
            {
                return showGreeksCommand ??
                       (showGreeksCommand =
                           new DelegateCommand(ShowGreeksExecuted, ShowGreeksExecute));
            }
        }

        private bool ShowGreeksExecute()
        {
            return true;
        }

        private void ShowGreeksExecuted()
        {
            string result = "Test";
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
               var result = string.Empty;
               switch (columnName)
               {
                   case "Rate":
                       if (Rate == null)
                       {
                           result = "Rate is required";
                       }
                       break;
                   case "Volatility":
                       if (Volatility == null)
                       {
                           result = "Volatility is required";
                       }
                       break;
                   case "ExercisePrice":
                       if (ExercisePrice == null)
                       {
                           result = "Exercise Price is required";
                       } 
                       break;
                   case "SpotPrice":
                       if (SpotPrice == null)
                       {
                           result = "Spot Price is required";
                       }
                       break;
                   case "TimeToMaturity":
                       if (TimeToMaturity == null)
                       {
                           result = "Time To Maturity is required";
                       }
                       break;
               };
                return result;
            }
        }
    }
}
