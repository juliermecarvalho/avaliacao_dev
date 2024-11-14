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

    public InvestmentResult CalculateFinalValues()
    {
        // Calcula o valor bruto (antes dos impostos)
        var grossValue = InitialValue;
        for (int i = 0; i < TimeInMonths; i++)
        {
            grossValue *= (1 + Cdi * Tb);
        }

        // Calcula o rendimento
        var profit = grossValue - InitialValue;

        // Calcula o imposto sobre o rendimento
        var tax = profit * GetTaxPercentage();

        // Calcula o valor líquido (após impostos)
        var netValue = grossValue - tax;

        return new InvestmentResult
        {
            InitialValue = InitialValue,
            TimeInMonths = TimeInMonths,
            GrossValue = grossValue,
            NetValue = netValue
        };
    }
}