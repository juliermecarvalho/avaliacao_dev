namespace B3.Api.Models
{
    public interface IInvestment
    {
        decimal GetTaxPercentage(int timeInMonths);
        decimal CalculateGrossValue(decimal initialValue, int timeInMonths);
        InvestmentResult CalculateFinalValues(decimal initialValue, int timeInMonths);
    }
}