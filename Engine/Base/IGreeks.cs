using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Engine.Base
{
    interface IGreeks
    {
        double Delta();
        double Gamma();
        double Vega();
        double Theta();
        double Rho();
    }
}
