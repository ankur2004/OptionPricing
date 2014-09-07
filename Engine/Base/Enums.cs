namespace OptionPricing.Engine.Base
{
    public enum OptionStyle
    {
        European,
        American
    }

    public enum OptionType
    {
        Call,
        Put
    }

    public enum OptionInputs
    {
        Spot,
        Strike,
        Maturity,
        Time,
        Rate,
        Volatility
    }
}
