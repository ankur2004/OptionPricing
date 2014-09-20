namespace OptionPricing.Engine.Base
{
    interface IGreeks
    {
        double Delta { get; }
        double Gamma { get; }
        double Vega();
        double Theta();
        double Rho();
    }
}
