using B3.Api;
using B3.Api.FilterAttribute;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace B3.Test;

public class ValidateModelAttributeTests
{
    private class TestModel
    {
        public int Value { get; set; }
    }

    private class TestModelValidator : AbstractValidator<TestModel>
    {
        public TestModelValidator()
        {
            RuleFor(x => x.Value).GreaterThan(0).WithMessage("O valor deve ser maior que zero.");
        }
    }

    [Fact]
    public void OnActionExecuting_ModelIsValid_DoesNotSetResult()
    {
        // Arrange
        var model = new TestModel { Value = 1 };
        var validator = new TestModelValidator();
        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock.Setup(x => x.GetService(typeof(IValidator<TestModel>))).Returns(validator);

        var httpContext = new DefaultHttpContext
        {
            RequestServices = serviceProviderMock.Object
        };
        var routeData = new RouteData();
        var actionDescriptor = new ActionDescriptor();
        var actionContext = new ActionContext
        {
            HttpContext = httpContext,
            RouteData = routeData,
            ActionDescriptor = actionDescriptor
        };
        var actionExecutingContext = new ActionExecutingContext(
            actionContext,
            new List<IFilterMetadata>(),
            new Dictionary<string, object?> { { "model", model } },
            new Mock<Controller>().Object);

        var attribute = new ValidateModelAttribute<TestModel>();

        // Act
        attribute.OnActionExecuting(actionExecutingContext);

        // Assert
        Assert.Null(actionExecutingContext.Result);
    }


    [Fact]
    public void OnActionExecuting_ModelIsInvalid_SetsBadRequestResult()
    {
        // Arrange
        var model = new TestModel { Value = 0 };
        var validator = new TestModelValidator();
        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock.Setup(x => x.GetService(typeof(IValidator<TestModel>))).Returns(validator);
        var httpContext = new DefaultHttpContext
        {
            RequestServices = serviceProviderMock.Object
        };
        var routeData = new RouteData();
        var actionDescriptor = new ActionDescriptor();
        var actionContext = new ActionContext
        {
            HttpContext = httpContext,
            RouteData = routeData,
            ActionDescriptor = actionDescriptor
        };
        var actionExecutingContext = new ActionExecutingContext(
            actionContext,
            new List<IFilterMetadata>(),
            new Dictionary<string, object?> { { "model", model } },
            new Mock<Controller>().Object);

        var attribute = new ValidateModelAttribute<TestModel>();

        // Act
        attribute.OnActionExecuting(actionExecutingContext);

        // Assert
        Assert.NotNull(actionExecutingContext.Result);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionExecutingContext.Result);
        Assert.Equal("Erro: O valor deve ser maior que zero.", badRequestResult.Value);
    }
}