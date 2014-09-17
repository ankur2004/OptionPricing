using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionPricing.Engine.Base;
using OptionPricing.Engine.European;

namespace OptionPricing.Engine.Core
{
    class MonteCarloNonPathDependent : IOptionPricer
    {
        private IOption option;
        private Func<double, double, double> CalculatePayoff { get; set; }
        private int numberSimulations;

        public MonteCarloNonPathDependent(IOption option, int numberSimulations)
        {
            this.option = option;
            this.numberSimulations = numberSimulations;
        }

        public double FwdValue { get; private set; }

        #region IOptionPricer
        public double Price { get; private set; }
        public void CalculateOptionPrice(IOption option)
        {
            switch (option.OptionType)
            {
                    case OptionType.Call:
                    CalculatePayoff = Payoffs.Call;
                    break;
                case OptionType.Put:
                    CalculatePayoff = Payoffs.Put;
                    break;
            }

            double price = 0;
            for (int i = 0; i < numberSimulations; i++)
            {
                FwdValue = CalculateTerminalValue();
                var simPrice = CalculatePayoff(FwdValue, option.ExercisePrice.Value);
                price += simPrice;
            }

            Price = price/numberSimulations;
        }        

        #endregion

        private double CalculateTerminalValue()
        {
            var rnd = Random.GetRandomNumber();
            var drift = (option.Rate.Value - 0.5*Math.Pow(option.Volatility.Value, 2))*option.Maturity.Value;
            var diffusion = option.Volatility.Value*Math.Sqrt(option.Maturity.Value);

            return option.SpotPrice.Value*Math.Exp(drift + diffusion* Random.GetStdNormalRandomNumber());
        }
    }
}
