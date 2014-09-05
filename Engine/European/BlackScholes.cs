using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace OptionPricing.Engine.European
{
    public class BlackScholes : IOptionPricer
    {
        private Option option;
        double d1, d2;
        Normal normalDist;

        public BlackScholes(Option option)
        {
            this.option = option;
            d1 = (Math.Log(option.StockPrice / option.ExercisePrice) + (option.Rate + (Math.Pow(option.StandardDeviation, 2) / 2)) * option.Time) / (option.StandardDeviation * Math.Sqrt(option.Time));
            d2 = d1 - option.StandardDeviation * Math.Sqrt(option.Time);

            normalDist = new Normal();
        }

        public double Price { get; protected set; }

      
        public void CalculateOptionPrice()
        {
            switch (option.OptionType)
            {
                case OptionType.Call:
                    Price = option.StockPrice * normalDist.CumulativeDistribution(d1) - option.ExercisePrice * Math.Exp(-option.Rate * option.Time) * normalDist.CumulativeDistribution(d2);
                    break;
                case OptionType.Put:
                    Price = option.ExercisePrice * Math.Exp(-option.Rate * option.Time) * normalDist.CumulativeDistribution(-d2) - option.StockPrice * normalDist.CumulativeDistribution(d1);
                    break;
                default:
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
                    result = normalDist.CumulativeDistribution(d1);
                    break;
                case OptionType.Put:
                    result = normalDist.CumulativeDistribution(d1) - 1;
                    break;
                default:
                    break;
            }
            return result;

        }


        public double GetGamma()
        {
            return normalDist.InverseCumulativeDistribution(d1)/(option.StockPrice*option.StandardDeviation*Math.Sqrt(option.Time));
        }

        public double GetVega()
        {
            return normalDist.InverseCumulativeDistribution(d1) * option.StockPrice * Math.Sqrt(option.Time);
        }

        public double GethTheta()
        {
            double result = 0;

            switch (option.OptionType)
            {
                case OptionType.Call:
                    result = (-option.StockPrice * normalDist.InverseCumulativeDistribution(d1) * option.StandardDeviation) / (2 * Math.Sqrt(option.Time)) - 
                                option.ExercisePrice * option.Rate * Math.Exp(-option.Rate * option.Time) * normalDist.InverseCumulativeDistribution(d2);
                    break;
                case OptionType.Put:
                    result = (-option.StockPrice * normalDist.InverseCumulativeDistribution(d1) * option.StandardDeviation) / (2 * Math.Sqrt(option.Time)) +
                                option.ExercisePrice * option.Rate * Math.Exp(-option.Rate * option.Time) * normalDist.InverseCumulativeDistribution(-d2);
                    break;
                default:
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
                    result = option.ExercisePrice * option.Time * Math.Exp(-option.Rate * option.Time) * normalDist.InverseCumulativeDistribution(d2);
                    break;
                case OptionType.Put:
                    result = -option.ExercisePrice * option.Time * Math.Exp(-option.Rate * option.Time) * normalDist.InverseCumulativeDistribution(-d2);
                    break;
                default:
                    break;
            }

            return result;
        }
        #endregion

    }
}
