using System;
using OptionPricing.Engine.Base;

namespace OptionPricing.Engine.European
{
    public class BlackScholes : IOptionPricer
    {
        private IOption option;
        double d1, d2;

        public BlackScholes(IOption option)
        {
            // consistency check
            if (option.OptionStyle != OptionStyle.European)
            {
                throw new ArgumentException("Black-Scholes only supports European Options");
            }
            this.option = option;
            d1 = (Math.Log(option.SpotPrice / option.ExercisePrice) + (option.Rate + (Math.Pow(option.Volatility, 2) / 2)) * option.Maturity) / (option.Volatility * Math.Sqrt(option.Maturity));
            d2 = d1 - option.Volatility * Math.Sqrt(option.Maturity);
        }

        public double Price { get; protected set; }
      
        public void CalculateOptionPrice()
        {
            switch (option.OptionType)
            {
                case OptionType.Call:
                    Price = option.SpotPrice * Utils.N(d1) - option.ExercisePrice * Math.Exp(-option.Rate * option.Maturity) * Utils.N(d2);
                    break;

                case OptionType.Put:
                    Price = option.ExercisePrice * Math.Exp(-option.Rate * option.Maturity) * Utils.N(-d2) - option.SpotPrice * Utils.N(d1);
                    break;
            }
        }

        #region Greeks

        public double GetDelta()
        {

            double result = 0;
            switch (option.OptionType)
            {
                case OptionType.Call:
                    result = Utils.N(d1);
                    break;
                case OptionType.Put:
                    result = Utils.N(d1) - 1;
                    break;
            }
            return result;

        }


        public double GetGamma()
        {
            return Utils.NInv(d1) / (option.SpotPrice * option.Volatility * Math.Sqrt(option.Maturity));
        }

        public double GetVega()
        {
            return Utils.NInv(d1) * option.SpotPrice * Math.Sqrt(option.Maturity);
        }

        public double GethTheta()
        {
            double result = 0;

            switch (option.OptionType)
            {
                case OptionType.Call:
                    result = (-option.SpotPrice * Utils.NInv(d1) * option.Volatility) / (2 * Math.Sqrt(option.Maturity)) -
                                option.ExercisePrice * option.Rate * Math.Exp(-option.Rate * option.Maturity) * Utils.NInv(d2);
                    break;
                case OptionType.Put:
                    result = (-option.SpotPrice * Utils.NInv(d1) * option.Volatility) / (2 * Math.Sqrt(option.Maturity)) +
                                option.ExercisePrice * option.Rate * Math.Exp(-option.Rate * option.Maturity) * Utils.NInv(-d2);
                    break;
            }
            return result;
        }

        public double GetRho()
        {
            double result = 0;

            switch (option.OptionType)
            {
                case OptionType.Call:
                    result = option.ExercisePrice * option.Maturity * Math.Exp(-option.Rate * option.Maturity) * Utils.NInv(d2);
                    break;
                case OptionType.Put:
                    result = -option.ExercisePrice * option.Maturity * Math.Exp(-option.Rate * option.Maturity) * Utils.NInv(-d2);
                    break;
            }

            return result;
        }
        #endregion

    }
}
