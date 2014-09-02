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
        double Put { get;  }
        double Call { get; }

        void CalculatePrice(EuropeanOption option);
    }
}
