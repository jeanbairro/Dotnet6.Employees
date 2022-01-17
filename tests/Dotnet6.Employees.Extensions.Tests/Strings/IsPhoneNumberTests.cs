using Dotnet6.Employees.Extensions.Strings;
using Xunit;

namespace Dotnet6.Employees.Extensions.Tests.Strings;

public class IsPhoneNumberTests
{
    [Theory(DisplayName = "Deve retornar que o telefone é inválido")]
    [InlineData("(047)99667-5252")]
    [InlineData("(0)99667-5252")]
    [InlineData("(47)996675252")]
    [InlineData("(47)996675-252")]
    [InlineData("(47) 99667-5252")]
    [InlineData("(47) 9667-5252")]
    [InlineData("ashiskdnaiuh")]
    [InlineData("")]
    [InlineData(null)]
    private void ShoudReturnThatTheEmailPhonrNumberIsInvalid(string email)
    {
        var result = email.IsPhoneNumber();
        Assert.False(result);
    }

    [Theory(DisplayName = "Deve retornar que o telefone é válido")]
    [InlineData("(47)99667-5252")]
    [InlineData("(47)9667-5252")]
    [InlineData("(11)3350-2121")]
    private void ShoudReturnThatThePhoneNumberIsValid(string phoneNumber)
    {
        var result = phoneNumber.IsPhoneNumber();
        Assert.True(result);
    }
}