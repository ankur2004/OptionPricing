namespace OptionPricing.Engine.Base
{
    public class Option : IOption
    {       
        public OptionStyle OptionStyle { get; set; }
        public OptionType OptionType { get; set; }
        public double Time { get; set; }
        public double Maturity { get; set; }
        public double Rate { get; set; }
        public double Volatility { get; set; }
        public double ExercisePrice { get; set; }
        public double SpotPrice { get; set; }
    }
}
