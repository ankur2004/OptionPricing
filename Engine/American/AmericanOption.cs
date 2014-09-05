using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Engine.American
{
    public class AmericanOption : Option
    {

        public override OptionType Type
        {
            get
            {
               return OptionType.American;
            }
        }
    }
}
