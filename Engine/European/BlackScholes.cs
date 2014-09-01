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
        private double put, call;

        public double Put
        {
            get
            {
                return put;
            }
            set
            {
                put = value;
            }
        }

        public double Call
        {
            get
            {
                return call;
            }
            set
            {
                call = value;
            }
        }

        public void CalculatePrice(EuropeanOption option)
        {
            var d1 =  (Math.Log(option.StockPrice / option.ExercisePrice) + (option.Rate + (Math.Pow(option.StandardDeviation, 2)/ 2)) * option.Time) / (option.StandardDeviation*Math.Sqrt(option.Time));
            var d2 = d1 - option.StandardDeviation * Math.Sqrt(option.Time);
           
            Normal n = new Normal();
            var ND1 = n.CumulativeDistribution(d1);
            var ND2 = n.CumulativeDistribution(d2);

            call = option.StockPrice * n.CumulativeDistribution(d1) - option.ExercisePrice * Math.Exp(-option.Rate * option.Time) * n.CumulativeDistribution(d2);

            put = option.ExercisePrice * Math.Exp(-option.Rate * option.Time) * n.CumulativeDistribution(-d2) - option.StockPrice * n.CumulativeDistribution(d1);
            
        }


    }
}
