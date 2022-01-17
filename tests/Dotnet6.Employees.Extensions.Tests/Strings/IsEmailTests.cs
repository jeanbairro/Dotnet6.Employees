using Dotnet6.Employees.Extensions.Strings;
using Xunit;

namespace Dotnet6.Employees.Extensions.Tests.Strings;

public class IsEmailTests
{
    [Theory(DisplayName = "Deve retornar que o e-mail é inválido")]
    [InlineData("teste.com.br")]
    [InlineData("@teste.com.br")]
    [InlineData("126378")]
    [InlineData("teste@@gmail.com.br")]
    [InlineData("ashiskdnaiuh")]
    [InlineData("")]
    [InlineData(null)]
    private void ShoudReturnThatTheEmailIsInvalid(string email)
    {
        var result = email.IsEmail();
        Assert.False(result);
    }

    [Theory(DisplayName = "Deve retornar que o e-mail é válido")]
    [InlineData("teste@gmail.com.br")]
    [InlineData("teste.1@teste.com")]
    [InlineData("teste@teste.io")]
    [InlineData("teste_1@teste.io")]
    private void ShoudReturnThatTheEmailIsValid(string email)
    {
        var result = email.IsEmail();
        Assert.True(result);
    }
}