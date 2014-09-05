using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionPricing.Engine.Base;

namespace OptionPricing.Engine.American
{
    public class AmericanOption : Option
    {

        public new OptionStyle OptionStyle
        {
            get { return OptionStyle.American; }
        }
    }
}
