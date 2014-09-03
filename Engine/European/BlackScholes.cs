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

        public double Put { get; protected set; }

        public double Call { get; protected set; }

        public void CalculateOptionPrice()
        {

            Call = option.StockPrice * normalDist.CumulativeDistribution(d1) - option.ExercisePrice * Math.Exp(-option.Rate * option.Time) * normalDist.CumulativeDistribution(d2);

            Put = option.ExercisePrice * Math.Exp(-option.Rate * option.Time) * normalDist.CumulativeDistribution(-d2) - option.StockPrice * normalDist.CumulativeDistribution(d1);
        }

        public double GetDelta()
        {
            return normalDist.CumulativeDistribution(d1);
        }


    }
}
