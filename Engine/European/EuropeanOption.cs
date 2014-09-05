using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionPricing.Engine.Base;

namespace OptionPricing.Engine.European
{
    public class EuropeanOption : Option
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
    }
}
