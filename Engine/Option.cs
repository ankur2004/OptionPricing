using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Engine
{
    public abstract class Option
    {
        public abstract OptionType Type { get; } 

        public double Time { get; set; }

        public double Rate { get; set; }

        public double StandardDeviation { get; set; }

        public double ExercisePrice { get; set; }

        public double StockPrice { get; set; }
    }
}
