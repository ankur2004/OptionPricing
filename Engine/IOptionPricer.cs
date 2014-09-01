using OptionPricing.Engine.European;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Engine
{
    public interface IOptionPricer
    {
        double Put { get; set; }
        double Call { get; set; }

        void CalculatePrice(EuropeanOption option);
    }
}
