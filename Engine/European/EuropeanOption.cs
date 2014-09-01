using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Engine.European
{
    public class EuropeanOption
    {
        public double Time { get; set; }

        public double Rate { get; set; }

        public double StandardDeviation { get; set; }

        public double ExercisePrice { get; set; }

        public double StockPrice { get; set; }
    }
}
