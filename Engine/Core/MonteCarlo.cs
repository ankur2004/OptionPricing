﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionPricing.Engine.Base;

namespace OptionPricing.Engine.Core
{
    public class MonteCarlo : IOptionPricer
    {
        private const int NUM_SIMULATIONS = 100000;
        private IOption option;
        private IOptionPricer pricer;

        public MonteCarlo(IOption option)
        {
            this.option = option;
            if (option.OptionStyle == OptionStyle.European)
            {
                pricer = new MonteCarloNonPathDependent(option, 10000);
            }
        }

        public double Price { get; private set; }
        public void CalculateOptionPrice()
        {
            pricer.CalculateOptionPrice();
            Price = pricer.Price;
        }
    }
}
