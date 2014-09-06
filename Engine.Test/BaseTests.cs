using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionPricing.Engine.Base;
using OptionPricing.Engine.Core;
using OptionPricing.Engine.European;
using System;

namespace OptionPricing.Engine.Test
{
    [TestClass]
    public class BaseTests
    {
        private EuropeanOption testOption = new EuropeanOption(OptionType.Call)
        {
            Maturity = 0.5,
            Rate = 0.09,
            SpotPrice = 39.03,
            ExercisePrice = 40,
            Volatility = 0.3
        };

        [TestMethod]
        public void TestBlackScholesEuropeanCall()
        {

            IOptionPricer blackScholes = new BlackScholes(testOption);
            blackScholes.CalculateOptionPrice();

            Assert.AreEqual(3.67, blackScholes.Price, 0.01, "Option Price BS");
        }

        [TestMethod]
        public void TestMCEuropeanCall()
        {
            IOptionPricer mcPricer = new MonteCarlo(testOption);
            mcPricer.CalculateOptionPrice();

            Assert.AreEqual(3.67, mcPricer.Price, 0.5, "Option Price MC");
        }
    }
}
