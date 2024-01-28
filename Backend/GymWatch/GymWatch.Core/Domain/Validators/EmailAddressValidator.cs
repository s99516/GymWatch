using System.Text.RegularExpressions;

namespace GymWatch.Core.Domain.Validators;

public class EmailAddressValidator
{
    private static readonly string _regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|pl|be)$";

    public static bool IsValid(string email)
    {
        return Regex.IsMatch(email, _regex, RegexOptions.IgnoreCase);
    }
}