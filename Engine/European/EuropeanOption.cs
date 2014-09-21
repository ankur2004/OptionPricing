using System;
using MathNet.Numerics.Distributions;
using OptionPricing.Engine.Base;

namespace OptionPricing.Engine.European
{
    public class EuropeanOption : Option, IGreeks
    {

        public EuropeanOption(OptionType type)
        {
            OptionType = type;
        }

        public new OptionStyle OptionStyle
        {
            get
            {
                return OptionStyle.European;
            }
        }

        public double Delta
        {
            get
            {
                double result = 0;

                if (SpotPrice == null || ExercisePrice == null || Volatility == null ||
                   Rate == null || Maturity == null) return result;

                var d1 = (Math.Log(SpotPrice.Value / ExercisePrice.Value) + (Rate.Value + (Math.Pow(Volatility.Value, 2) / 2)) * Maturity.Value) / (Volatility.Value * Math.Sqrt(Maturity.Value));

                switch (OptionType)
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
        }

        public double Gamma
        {
            get
            {
                if (SpotPrice == null || ExercisePrice == null || Volatility == null || Rate == null || Maturity == null) return 0;

                var d1 = (Math.Log(SpotPrice.Value / ExercisePrice.Value) + (Rate.Value + (Math.Pow(Volatility.Value, 2) / 2)) * Maturity.Value) / (Volatility.Value * Math.Sqrt(Maturity.Value));

                return Utils.NInv(d1) / (SpotPrice.Value * Volatility.Value * Math.Sqrt(Maturity.Value));
            }
           
        }

        public double Vega
        {
            get
            {
                if (SpotPrice == null || ExercisePrice == null || Volatility == null || Rate == null || Maturity == null) return 0;

                var d1 = (Math.Log(SpotPrice.Value / ExercisePrice.Value) + (Rate.Value + (Math.Pow(Volatility.Value, 2) / 2)) * Maturity.Value) / (Volatility.Value * Math.Sqrt(Maturity.Value));

                return Utils.NInv(d1) * SpotPrice.Value * Math.Sqrt(Maturity.Value);
            }
           
        }

        public double Theta
        {
            get
            {

                double result = 0;

                if (SpotPrice == null || ExercisePrice == null || Volatility == null || Rate == null || Maturity == null) return 0;

                var d1 = (Math.Log(SpotPrice.Value / ExercisePrice.Value) + (Rate.Value + (Math.Pow(Volatility.Value, 2) / 2)) * Maturity.Value) / (Volatility.Value * Math.Sqrt(Maturity.Value));
                var d2 = d1 - Volatility.Value * Math.Sqrt(Maturity.Value);

                switch (OptionType)
                {
                    case OptionType.Call:
                        result = (-SpotPrice.Value * Utils.NInv(d1) * Volatility.Value) / (2 * Math.Sqrt(Maturity.Value)) -
                                    ExercisePrice.Value * Rate.Value * Math.Exp(-Rate.Value * Maturity.Value) * Utils.N(d2);
                        break;
                    case OptionType.Put:
                        result = (-SpotPrice.Value * Utils.NInv(d1) * Volatility.Value) / (2 * Math.Sqrt(Maturity.Value)) +
                                    ExercisePrice.Value * Rate.Value * Math.Exp(-Rate.Value * Maturity.Value) * Utils.N(-d2);
                        break;
                }
                return result;
            }
        }

        public double Rho
        {
            get
            {
                double result = 0;

                if (SpotPrice == null || ExercisePrice == null || Volatility == null || Rate == null || Maturity == null) return result;

                var d1 = (Math.Log(SpotPrice.Value / ExercisePrice.Value) + (Rate.Value + (Math.Pow(Volatility.Value, 2) / 2)) * Maturity.Value) / (Volatility.Value * Math.Sqrt(Maturity.Value));


                var d2 = d1 - Volatility.Value * Math.Sqrt(Maturity.Value);
                switch (OptionType)
                {
                    case OptionType.Call:
                        result = ExercisePrice.Value * Maturity.Value * Math.Exp(-Rate.Value * Maturity.Value) * Utils.N(d2);
                        break;
                    case OptionType.Put:
                        result = -ExercisePrice.Value * Maturity.Value * Math.Exp(-Rate.Value * Maturity.Value) * Utils.N(-d2);
                        break;
                }

                return result;
            }
        }
    }
}
