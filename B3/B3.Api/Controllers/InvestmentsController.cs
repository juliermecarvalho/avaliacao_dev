using B3.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace B3.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InvestmentsController : ControllerBase
{

    [HttpPost("calculate-final-value")]
    [ValidateModel<InvestmentModel>] // validador usando o FluentValidation
    public ActionResult<InvestmentResult> CalculateFinalValue([FromBody] InvestmentModel investmentModel)
    {
        try
        {
            //poderia usar mapper para mapear o model para a entidade
            var investmentService = new Investment(investmentModel.InitialValue, investmentModel.TimeInMonths);
            var investmentResult = investmentService.CalculateFinalValues();
            return investmentResult;
        }
        catch (Exception)
        {
            // Log the exception (e.g., using ILogger)
            return StatusCode(500, "An error occurred while calculating the final value.");
        }
    }

}