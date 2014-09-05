using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionPricing.Engine.Base;
using OptionPricing.Engine.European;
using System;

namespace OptionPricing.Engine.Test
{
    [TestClass]
    public class BaseTests
    {
        [TestMethod]
        public void TestBlackScholesEuropeanCall()
        {
            EuropeanOption testOption = new EuropeanOption(OptionType.Call) 
            {
                Maturity = 0.5,
                Rate = 0.09, 
                SpotPrice = 39.03, 
                ExercisePrice = 40, 
                Volatility = 0.3
            };

            IOptionPricer blackScholes = new BlackScholes(testOption);
            blackScholes.CalculateOptionPrice();

            Assert.AreEqual(3.67, blackScholes.Price, 0.01, "Option Price");            
        }
    }
}
