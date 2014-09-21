using System.Linq;
using OptionPricing.Engine.Base;
using OptionPricing.Engine.European;
using OptionPricing.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OptionPricing.ViewModel
{
    public class BlackScholesViewModel : ViewModelBase
    {
        ObservableCollection<OptionViewModel> options;
        private bool isSelected;

        public BlackScholesViewModel()
        {
            options = new ObservableCollection<OptionViewModel>
                      {
                new OptionViewModel(new EuropeanOption(OptionType.Call)
                {
                    Maturity = 0.5,
                    Rate = 0.09, 
                    SpotPrice = 39.03, 
                    ExercisePrice = 40.0, 
                    Volatility = 0.3
                })
            };

        }

        public bool IsSelected
        {
            get
            {
                isSelected = options.Where(x => x.IsSelected).Select(x => x.IsSelected).FirstOrDefault();
                return isSelected;
            }
            set
            {
                isSelected = value; 
                OnPropertyChanged("IsSelected");
            }
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
        private DelegateCommand isCheckedCommand;

        public ICommand IsCheckedCommand
        {
            get
            {
                return isCheckedCommand ??
                       (isCheckedCommand =
                           new DelegateCommand(IsCheckedExecuted, IsCheckedExecute));
            }
        }

        private bool IsCheckedExecute()
        {
            return true;
        }

        private void IsCheckedExecuted()
        {
            IsSelected = options.Where(x => x.IsSelected).Select(x => x.IsSelected).FirstOrDefault();
        }


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
