using CommonTestUtilities.Requests;
using MoneyControl.Application.UseCases.Expenses;
using MoneyControl.Application.UseCases.Expenses.Register;
using MoneyControl.Communication.Enums;
using MoneyControl.Communication.Requests;
using MoneyControl.Exception;

namespace Validators.Test.Expenses.Register;


public class RegisterExpensesValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        //Act
        var validation = validator.Validate(request);

        //Assert
        Assert.True(validation.IsValid);
        Assert.Empty(validation.Errors);
    }

    [Fact]
    public void Title_Empty()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = string.Empty;

        //Act
        var validation = validator.Validate(request);

        //Assert
        Assert.False(validation.IsValid);
        Assert.Single(validation.Errors);
        Assert.Equal(validation.Errors.First().ErrorMessage, ResourcesErrorMessages.TITLE_REQUIRED);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Amount_Invalid(decimal amount)
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;

        //Act
        var validation = validator.Validate(request);

        //Assert
        Assert.False(validation.IsValid);
        Assert.Single(validation.Errors);
        Assert.Equal(validation.Errors.First().ErrorMessage, ResourcesErrorMessages.AMOUNT_GREATHER_THAN_ZERO);
    }

    [Fact]
    public void Date_Invalid()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.Now.AddDays(2);

        //Act
        var validation = validator.Validate(request);

        //Assert
        Assert.False(validation.IsValid);
        Assert.Single(validation.Errors);
        Assert.Equal(validation.Errors.First().ErrorMessage, ResourcesErrorMessages.DATE_TODAY_BEFORE);
    }

    [Fact]
    public void Type_Invalid()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Type = (PaymentType)999;

        //Act
        var validation = validator.Validate(request);

        //Assert
        Assert.False(validation.IsValid);
        Assert.Single(validation.Errors);
        Assert.Equal(validation.Errors.First().ErrorMessage, ResourcesErrorMessages.INVALID_PAYMENT_TYPE);
    }
}
