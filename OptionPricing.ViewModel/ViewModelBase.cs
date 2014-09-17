using System.ComponentModel;

namespace OptionPricing.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;  
    }
}
