namespace B3.Api.Models;

public class Investment
{
    public decimal InitialValue { get; private set; }
    public int TimeInMonths { get; private set; }

    private const decimal Cdi = 0.009m;
    private const decimal Tb = 1.08m;

    public Investment(decimal initialValue, int timeInMonths)
    {
        if (timeInMonths < 1)
        {
            throw new ArgumentException("O mês deve ser maior que 0", nameof(timeInMonths));
        }

        if (initialValue <= 0)
        {
            throw new ArgumentException("O valor inicial deve ser maior que 0", nameof(initialValue));
        }

        InitialValue = initialValue;
        TimeInMonths = timeInMonths;
    }

    public decimal GetTaxPercentage()
    {
        return TimeInMonths switch
        {
            <= 6 => 0.225m,
            <= 12 => 0.2m,
            <= 24 => 0.175m,
            _ => 0.15m,
        };
    }

    public decimal CalculateFinalValue()
    {
        var finalValue = InitialValue;
        for (int i = 0; i < TimeInMonths; i++)
        {
            finalValue *= (1 + Cdi * Tb);
        }
        finalValue -= finalValue * GetTaxPercentage();

        return finalValue;
    }
}