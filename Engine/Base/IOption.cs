using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OptionPricing.Engine.Base
{
    public interface IOption
    {
        OptionStyle OptionStyle { get; set; }
        OptionType OptionType { get; set; }
        double? Time { get; set; }
        double? Maturity { get; set; }
        double? Rate { get; set; }
        double? Volatility { get; set; }
        double? ExercisePrice { get; set; }
        double? SpotPrice { get; set; }
        double Price { get; set; }
        IOption Clone();
        IOption CloneWithBump(OptionInputs input, double amount);
    }
}
