namespace OptionPricing.Engine.Base
{
    public interface IOptionPricer
    {
        void CalculateOptionPrice(IOption option);
    }
}
