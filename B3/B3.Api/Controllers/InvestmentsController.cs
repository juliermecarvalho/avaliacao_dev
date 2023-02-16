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
            return new Investment(initialValue, timeInMonths).CalculateFinalValue();

        }

    }
}