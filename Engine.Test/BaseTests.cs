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

            IOptionPricer blackScholes = new BlackScholes();
            blackScholes.CalculateOptionPrice(testOption);

            Assert.AreEqual(3.67, testOption.Price, 0.01, "Option Price BS");
        }

        /// <summary>
        /// Calculate and validate delta using Finite Differences
        /// http://en.wikipedia.org/wiki/Finite_difference 
        /// </summary>
        [TestMethod]
        public void TestBlackScholesEuropeanCallDelta()
        {
            var blackScholes = new BlackScholes();
            blackScholes.CalculateOptionPrice(testOption);

            var p1 = testOption.Price;
            var testOption2 = testOption.CloneWithBump(OptionInputs.Spot, 0.01);

            IOptionPricer blackScholes2 = new BlackScholes();
            blackScholes2.CalculateOptionPrice(testOption2);
            var p2 = testOption2.Price;

            var deltaBS = blackScholes.GetDelta(testOption2);
            var thetaBS = blackScholes.GethTheta(testOption2);
            var deltaFD = (p2 - p1) / 0.01;

            Assert.AreEqual(deltaBS, deltaFD, 0.01, "Delta");
        }


        [TestMethod]
        public void TestMCEuropeanCall()
        {
            IOptionPricer mcPricer = new MonteCarlo();
            mcPricer.CalculateOptionPrice(testOption);

            Assert.AreEqual(3.67, testOption.Price, 0.5, "Option Price MC");
        }
    }
}
