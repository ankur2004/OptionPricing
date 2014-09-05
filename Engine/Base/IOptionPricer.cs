namespace OptionPricing.Engine.Base
{
    public interface IOptionPricer
    {
        double Price { get;  }

        void CalculateOptionPrice();
    }
}
