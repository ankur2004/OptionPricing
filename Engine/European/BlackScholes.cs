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
        public double Put { get; protected set; }

        public double Call { get; protected set; }

        public void CalculatePrice(EuropeanOption option)
        {
            var d1 =  (Math.Log(option.StockPrice / option.ExercisePrice) + (option.Rate + (Math.Pow(option.StandardDeviation, 2)/ 2)) * option.Time) / (option.StandardDeviation*Math.Sqrt(option.Time));
            var d2 = d1 - option.StandardDeviation * Math.Sqrt(option.Time);
           
            Normal n = new Normal();
           
            Call = option.StockPrice * n.CumulativeDistribution(d1) - option.ExercisePrice * Math.Exp(-option.Rate * option.Time) * n.CumulativeDistribution(d2);

            Put = option.ExercisePrice * Math.Exp(-option.Rate * option.Time) * n.CumulativeDistribution(-d2) - option.StockPrice * n.CumulativeDistribution(d1);
            
        }


    }
}
