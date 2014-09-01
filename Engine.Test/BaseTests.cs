using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            EuropeanOption testOption = new EuropeanOption() 
            {
                Time = 0.5,
                Rate = 0.09, 
                StockPrice = 39.03, 
                ExercisePrice = 40, 
                StandardDeviation = 0.3
            };

            BlackScholes blackScholes = new BlackScholes();
            blackScholes.CalculatePrice(testOption);

            Assert.AreEqual<double>(Math.Round(blackScholes.Call,2), 3.67);
        }
    }
}
