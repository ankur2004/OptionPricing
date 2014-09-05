using OptionPricing.Engine.European;
using OptionPricing.ViewModel.Commands;
using OptionPricing.ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OptionPricing.ViewModel
{
    public class BlackScholesViewModel : ViewModelBase
    {
        ObservableCollection<Option> options;
        public BlackScholesViewModel()
        {
            options = new ObservableCollection<Option>()
            {
                new Option() {
                    TimeToMaturity = 0.5,
                    Rate = 0.09, 
                    StockPrice = 39.03, 
                    ExercisePrice = 40.0, 
                    Volatility = 0.3
                }
            };

        }

        public ObservableCollection<Option> Options
        {
            get
            {
                return options;
            }
            set
            {
                options = value;
                OnPropertyChanged("Options");
            }
        }

        private DelegateCommand calculatePriceCommand;

        public ICommand CalculatePriceCommand
        {
            get
            {
                if (calculatePriceCommand == null)
                    calculatePriceCommand = new DelegateCommand(new Action(CalculatePriceExecuted), new Func<bool>(CalculatePriceExecute));

                return calculatePriceCommand;
            }

        }

        public bool CalculatePriceExecute()
        {

            foreach (var option in Options)
            {
                
            }
            return true;
        }

        public void CalculatePriceExecuted()
        {
        }
    }
}
