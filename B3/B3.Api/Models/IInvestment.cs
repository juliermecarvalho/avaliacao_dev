namespace B3.Api.Models
{
    public interface IInvestment
    {
        decimal GetTaxPercentage(int timeInMonths);
        InvestmentResult CalculateFinalValues(decimal initialValue, int timeInMonths);
    }
}