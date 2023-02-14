using B3.Models;
using Microsoft.AspNetCore.Mvc;

namespace B3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestmentsController : ControllerBase
    {

        [HttpPost]
        [Route("calculate-final-value")]
        public decimal CalculateFinalValue(decimal initialValue, int timeInMonths)
        {
            decimal cdi = 0.009m;
            decimal tb = 1.08m;

            return new Investment(initialValue, timeInMonths).CalculateFinalValue(cdi, tb);

        }

    }
}