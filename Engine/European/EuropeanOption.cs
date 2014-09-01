﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Engine.European
{
    public class EuropeanOption : Option
    {

        public override OptionType Type
        {
            get
            {
               return OptionType.European;
            }
        }
    }
}
