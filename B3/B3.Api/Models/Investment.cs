namespace B3.Api.Models;

public class Investment : IInvestment
{
    private const decimal Cdi = 0.009m;
    private const decimal Tb = 1.08m;

    public decimal GetTaxPercentage(int timeInMonths)
    {
        return timeInMonths switch
        {
            <= 6 => 0.225m,
            <= 12 => 0.2m,
            <= 24 => 0.175m,
            _ => 0.15m,
        };
    }

    public InvestmentResult CalculateFinalValues(decimal initialValue, int timeInMonths)
    {
        if (timeInMonths < 1)
        {
            throw new ArgumentException("O mês deve ser maior que 1", nameof(timeInMonths));
        }

        if (initialValue <= 0)
        {
            throw new ArgumentException("O valor inicial deve ser maior que 0", nameof(initialValue));
        }

        // Calcula o valor bruto (antes dos impostos)
        var grossValue = initialValue;
        for (int i = 0; i < timeInMonths; i++)
        {
            grossValue *= (1 + Cdi * Tb);
        }

        // Calcula o rendimento
        var profit = grossValue - initialValue;

        // Calcula o imposto sobre o rendimento
        var tax = profit * GetTaxPercentage(timeInMonths);

        // Calcula o valor líquido (após impostos)
        var netValue = grossValue - tax;

        return new InvestmentResult
        {
            InitialValue = initialValue,
            TimeInMonths = timeInMonths,
            GrossValue = grossValue,
            NetValue = netValue
        };
    }
}