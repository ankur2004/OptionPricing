using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionPricing.Engine.Base;
using OptionPricing.Engine.European;

namespace OptionPricing.Engine
{
    public class Pricer : IOptionPricer
    {
        private IOptionPricer pricer;

        public Pricer(IOption option)
        {
            if (option.OptionStyle == OptionStyle.European)
            {
                pricer = new BlackScholes(option);
            }
        }

        public double Price
        {
            get { return pricer.Price; }
        }

        public void CalculateOptionPrice()
        {
            pricer.CalculateOptionPrice();
        }
    }
}
