using System.Text.RegularExpressions;

namespace Dotnet6.Employees.Extensions.Strings
{
    public static class PhoneNumberExtension
    {
        public static bool IsPhoneNumber(this string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;

            var regexPhoneNumber = new Regex(@"\([0-9]{2}\)[0-9]?[0-9]{4}-[0-9]{4}$");
            return regexPhoneNumber.IsMatch(texto);
        }
    }
}