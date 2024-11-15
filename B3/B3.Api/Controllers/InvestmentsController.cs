using B3.Api.FilterAttribute;
using B3.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace B3.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InvestmentsController(IInvestment investment) : ControllerBase
{


    [HttpPost("calculate-final-value")]
    [ValidateModel<InvestmentModel>] // validador usando o FluentValidation
    public ActionResult<InvestmentResult> CalculateFinalValue([FromBody] InvestmentModel investmentModel)
    {
        try
        {
            var investmentResult = investment.CalculateFinalValues(investmentModel.InitialValue, investmentModel.TimeInMonths);
            return investmentResult;
        }
        catch (Exception)
        {
            // Log the exception (e.g., using ILogger)
            return StatusCode(500, "An error occurred while calculating the final value.");
        }
    }

}