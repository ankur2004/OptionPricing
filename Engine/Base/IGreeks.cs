namespace OptionPricing.Engine.Base
{
    interface IGreeks
    {
        double Delta { get; }
        double Gamma { get; }
        double Vega { get; }
        double Theta { get; }
        double Rho { get; }
    }
}
