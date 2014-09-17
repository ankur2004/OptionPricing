using OptionPricing.Engine.Base;

namespace OptionPricing.Engine.Core
{
    public class MonteCarlo : IOptionPricer
    {
        private const int NUM_SIMULATIONS = 100000;
        private IOption option;
        private IOptionPricer pricer;


        public void CalculateOptionPrice(IOption option)
        {
            if (option.OptionStyle == OptionStyle.European)
            {
                pricer = new MonteCarloNonPathDependent(option, 10000);
            }
            pricer.CalculateOptionPrice(option);
        }
    }
}
