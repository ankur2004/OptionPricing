using System;
using MathNet.Numerics.Distributions;

namespace OptionPricing.Engine.Base
{
    public static class Utils
    {
        public static Func<double, double> N = (x) => Normal.CDF(0, 1, x);
        public static Func<double, double> NInv = (p) => Normal.InvCDF(0, 1, p); 
    }
}
