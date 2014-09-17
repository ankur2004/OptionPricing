namespace OptionPricing.Engine.Base
{
    public class Option : IOption
    {       
        public OptionStyle OptionStyle { get; set; }
        public OptionType OptionType { get; set; }
        public double? Time { get; set; }
        public double? Maturity { get; set; }
        public double? Rate { get; set; }
        public double? Volatility { get; set; }
        public double? ExercisePrice { get; set; }
        public double? SpotPrice { get; set; }
        public double Price { get; set; }

        public IOption Clone()
        {
            return new Option
            {
                ExercisePrice = this.ExercisePrice,
                Maturity = this.Maturity,
                OptionStyle = this.OptionStyle,
                OptionType = this.OptionType,
                Rate = this.Rate,
                SpotPrice = this.SpotPrice,
                Time = this.Time,
                Volatility = this.Volatility
            };
        }

        public IOption CloneWithBump(OptionInputs input, double amount)
        {
            var option = Clone();
            switch (input)
            {
                case OptionInputs.Maturity:
                    option.Maturity += amount;
                    break;
                case OptionInputs.Rate:
                    option.Rate += amount;
                    break;
                case OptionInputs.Spot:
                    option.SpotPrice += amount;
                    break;
                case OptionInputs.Strike:
                    option.ExercisePrice += amount;
                    break;
                case OptionInputs.Time:
                    option.Time += amount;
                    break;
                case OptionInputs.Volatility:
                    option.Volatility += amount;
                    break;
            }

            return option;
        }
    }
}
