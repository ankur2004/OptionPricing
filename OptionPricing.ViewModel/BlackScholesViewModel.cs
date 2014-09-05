using OptionPricing.Engine;
using OptionPricing.Engine.Base;
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
        ObservableCollection<OptionVM> options;
        public BlackScholesViewModel()
        {
            options = new ObservableCollection<OptionVM>()
            {
                new OptionVM() {
                    Maturity = 0.5,
                    Rate = 0.09, 
                    SpotPrice = 39.03, 
                    ExercisePrice = 40.0, 
                    Volatility = 0.3
                }
            };

        }

        public ObservableCollection<OptionVM> Options
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
                IOptionPricer pricer = new Pricer(option);
                pricer.CalculateOptionPrice();
                option.OptionPrice = pricer.Price;
            }
            return true;
        }

        public void CalculatePriceExecuted()
        {
        }
    }
}
