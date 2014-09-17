using System.Linq;
using OptionPricing.Engine;
using OptionPricing.Engine.Base;
using OptionPricing.ViewModel.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OptionPricing.ViewModel
{
    public class BlackScholesViewModel : ViewModelBase
    {
        ObservableCollection<OptionViewModel> options;
        

        public BlackScholesViewModel()
        {
            options = new ObservableCollection<OptionViewModel>
                      {
                new OptionViewModel(new Option
                {
                    Maturity = 0.5,
                    Rate = 0.09, 
                    SpotPrice = 39.03, 
                    ExercisePrice = 40.0, 
                    Volatility = 0.3
                })
            };

        }

        public ObservableCollection<OptionViewModel> Options
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
            get {
                return calculatePriceCommand ??
                       (calculatePriceCommand =
                           new DelegateCommand(CalculatePriceExecuted, CalculatePriceExecute));
            }
        }

        public bool CalculatePriceExecute()
        {
            return true;
        }

        public void CalculatePriceExecuted()
        {
            foreach (var option in Options.Where(option => option.IsSelected))
            {
                option.PriceOption();
            }
            
        }
    }
}
