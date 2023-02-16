namespace B3.Models
{
    public class Investment
    {
        private decimal InitialValue { get; set; }
        private int TimeInMonths { get; set; }


        private readonly decimal _cdi = 0.009m;
        private readonly decimal _tb = 1.08m;

        public Investment(decimal initialValue, int timeInMonths)
        {
            if (timeInMonths < 1)
            {
                Exception exception = new Exception("Error the month must be greater than 0");
                throw exception;
            }

            if (initialValue <= 0)
            {
                Exception exception = new Exception("Error initial value must be greater than 0");
                throw exception;
            }

            InitialValue = initialValue;
            TimeInMonths = timeInMonths;
        }

        public decimal GetTaxPercentage()
        {
            decimal taxPercentage;
            if (TimeInMonths <= 6)
            {
                taxPercentage = 0.225m;
            }
            else if (TimeInMonths <= 12)
            {
                taxPercentage = 0.2m;
            }
            else if (TimeInMonths <= 24)
            {
                taxPercentage = 0.175m;
            }
            else
            {
                taxPercentage = 0.15m;
            }

            return taxPercentage;
        }

        public decimal CalculateFinalValue()
        {
            var finalValue = InitialValue * (1 + _cdi * _tb);
            finalValue -= finalValue * GetTaxPercentage();

            return finalValue;
        }
    }
}