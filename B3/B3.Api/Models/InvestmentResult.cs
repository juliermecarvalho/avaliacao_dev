namespace B3.Api.Models
{
    public class InvestmentResult
    {
        public decimal InitialValue { get; set; }
        public int TimeInMonths { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
    }
}