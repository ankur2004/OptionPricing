using System;
using OptionPricing.Engine.Base;

namespace OptionPricing.Engine.European
{
    public class BlackScholes : IOptionPricer
    {

        public void CalculateOptionPrice(IOption option)
        {
            if (option.SpotPrice == null || option.ExercisePrice == null || option.Volatility == null ||
                option.Rate == null || option.Maturity == null) return;

            var d1 = (Math.Log(option.SpotPrice.Value / option.ExercisePrice.Value) + (option.Rate.Value + (Math.Pow(option.Volatility.Value, 2) / 2)) * option.Maturity.Value) / (option.Volatility.Value * Math.Sqrt(option.Maturity.Value));
            var d2 = d1 - option.Volatility.Value * Math.Sqrt(option.Maturity.Value);

            switch (option.OptionType)
            {
                case OptionType.Call:
                    option.Price = option.SpotPrice.Value * Utils.N(d1) - option.ExercisePrice.Value * Math.Exp(-option.Rate.Value * option.Maturity.Value) * Utils.N(d2);
                    break;

                case OptionType.Put:
                    option.Price = option.ExercisePrice.Value * Math.Exp(-option.Rate.Value * option.Maturity.Value) * Utils.N(-d2) - option.SpotPrice.Value * Utils.N(d1);
                    break;
            }
        }

        #region Greeks

        public double GetDelta(IOption option)
        {
            
            double result = 0;

            if (option.SpotPrice == null || option.ExercisePrice == null || option.Volatility == null ||
               option.Rate == null || option.Maturity == null) return result;

            var d1 = (Math.Log(option.SpotPrice.Value / option.ExercisePrice.Value) + (option.Rate.Value + (Math.Pow(option.Volatility.Value, 2) / 2)) * option.Maturity.Value) / (option.Volatility.Value * Math.Sqrt(option.Maturity.Value));

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


        public double GetGamma(IOption option)
        {

            if (option.SpotPrice == null || option.ExercisePrice == null || option.Volatility == null ||
              option.Rate == null || option.Maturity == null) return 0;

            var d1 = (Math.Log(option.SpotPrice.Value / option.ExercisePrice.Value) + (option.Rate.Value + (Math.Pow(option.Volatility.Value, 2) / 2)) * option.Maturity.Value) / (option.Volatility.Value * Math.Sqrt(option.Maturity.Value));

            return Utils.NInv(d1) / (option.SpotPrice.Value * option.Volatility.Value * Math.Sqrt(option.Maturity.Value));
        }

        public double GetVega(IOption option)
        {

            if (option.SpotPrice == null || option.ExercisePrice == null || option.Volatility == null ||
             option.Rate == null || option.Maturity == null) return 0;

            var d1 = (Math.Log(option.SpotPrice.Value / option.ExercisePrice.Value) + (option.Rate.Value + (Math.Pow(option.Volatility.Value, 2) / 2)) * option.Maturity.Value) / (option.Volatility.Value * Math.Sqrt(option.Maturity.Value));

            return Utils.NInv(d1) * option.SpotPrice.Value * Math.Sqrt(option.Maturity.Value);
        }

        public double GethTheta(IOption option)
        {
            double result = 0;

            if (option.SpotPrice == null || option.ExercisePrice == null || option.Volatility == null ||
              option.Rate == null || option.Maturity == null) return 0;

            var d1 = (Math.Log(option.SpotPrice.Value / option.ExercisePrice.Value) + (option.Rate.Value + (Math.Pow(option.Volatility.Value, 2) / 2)) * option.Maturity.Value) / (option.Volatility.Value * Math.Sqrt(option.Maturity.Value));
            var d2 = d1 - option.Volatility.Value * Math.Sqrt(option.Maturity.Value);

            switch (option.OptionType)
            {
                case OptionType.Call:
                    result = (-option.SpotPrice.Value * Utils.NInv(d1) * option.Volatility.Value) / (2 * Math.Sqrt(option.Maturity.Value)) -
                                option.ExercisePrice.Value * option.Rate.Value * Math.Exp(-option.Rate.Value * option.Maturity.Value) * Utils.N(d2);
                    break;
                case OptionType.Put:
                    result = (-option.SpotPrice.Value * Utils.NInv(d1) * option.Volatility.Value) / (2 * Math.Sqrt(option.Maturity.Value)) +
                                option.ExercisePrice.Value * option.Rate.Value * Math.Exp(-option.Rate.Value * option.Maturity.Value) * Utils.N(-d2);
                    break;
            }
            return result;
        }

        public double GetRho(IOption option)
        {
            double result = 0;

            if (option.SpotPrice == null || option.ExercisePrice == null || option.Volatility == null ||
             option.Rate == null || option.Maturity == null) return result;

            var d1 = (Math.Log(option.SpotPrice.Value / option.ExercisePrice.Value) + (option.Rate.Value + (Math.Pow(option.Volatility.Value, 2) / 2)) * option.Maturity.Value) / (option.Volatility.Value * Math.Sqrt(option.Maturity.Value));

            
            var d2 = d1 - option.Volatility.Value * Math.Sqrt(option.Maturity.Value);

            switch (option.OptionType)
            {
                case OptionType.Call:
                    result = option.ExercisePrice.Value * option.Maturity.Value * Math.Exp(-option.Rate.Value * option.Maturity.Value) * Utils.NInv(d2);
                    break;
                case OptionType.Put:
                    result = -option.ExercisePrice.Value * option.Maturity.Value * Math.Exp(-option.Rate.Value * option.Maturity.Value) * Utils.NInv(-d2);
                    break;
            }

            return result;
        }
        #endregion

    }
}
