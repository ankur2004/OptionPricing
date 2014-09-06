using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Engine.European
{
    internal class Payoffs
    {
        public static Func<double, double, double> Call = (S_T, K) => Math.Max(S_T - K, 0);
        public static Func<double, double, double> Put = (S_T, K) => Math.Max(K - S_T, 0);
    }
}
