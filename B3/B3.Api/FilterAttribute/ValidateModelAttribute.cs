using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace B3.Api.FilterAttribute;

/// <summary>
/// Filtro de ação personalizado para validar um modelo usando FluentValidation.
/// Caso o modelo seja inválido, retorna um BadRequestObjectResult com as mensagens de erro de validação.
/// </summary>
/// <typeparam name="T">O tipo do modelo a ser validado.</typeparam>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class ValidateModelAttribute<T> : ActionFilterAttribute where T : class
{
    /// <summary>
    /// Chamado antes da execução do método da ação. Valida o modelo do tipo T utilizando o FluentValidation.
    /// </summary>
    /// <param name="context">O contexto da execução da ação contendo o modelo e as dependências.</param>
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var model = context.ActionArguments.Values.OfType<T>().FirstOrDefault();

        if (model is not null)
        {
            var validatorType = typeof(IValidator<T>);
            var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator<T>;

            if (validator is not null)
            {
                var validationContext = new ValidationContext<T>(model);
                var validationResult = validator.Validate(validationContext);

                if (!validationResult.IsValid)
                {
                    var erros = new List<string>();
                    foreach (var erro in validationResult.Errors)
                    {
                        erros.Add($"Erro: {erro.ErrorMessage}");
                    }

                    context.Result = new BadRequestObjectResult(string.Join(", \n", erros));
                }
            }
        }

        base.OnActionExecuting(context);
    }
}