using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Engine.European
{
    public class EuropeanOption : Option
    {

        public EuropeanOption(OptionType type)
        {
            Type = type;
        }

        public OptionType Type {get; protected set;}

        public override OptionStyle OptionStyle
        {
            get
            {
                return OptionStyle.European;
            }
        }
    }
}
