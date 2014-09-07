using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionPricing.Engine.Base;

namespace OptionPricing.Engine.European
{
    public class EuropeanOption : Option, IGreeks
    {

        public EuropeanOption(OptionType type)
        {
            OptionType = type;
        }

        public new OptionStyle OptionStyle
        {
            get
            {
                return OptionStyle.European;
            }
        }

        public double Delta()
        {
            throw new NotImplementedException();
        }

        public double Gamma()
        {
            throw new NotImplementedException();
        }

        public double Vega()
        {
            throw new NotImplementedException();
        }

        public double Theta()
        {
            throw new NotImplementedException();
        }

        public double Rho()
        {
            throw new NotImplementedException();
        }
    }
}
