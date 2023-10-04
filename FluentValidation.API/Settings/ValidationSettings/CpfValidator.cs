using FluentValidation.API.Extensions;

namespace FluentValidation.API.Settings.ValidationSettings;

public static class CpfValidator
{
    private const int CpfSize = 11;

    public static bool ValidateCpf(string document)
    {
        document = document.CleanCaracters();

        if (document.Length != CpfSize)
            return false;

        if(!HasValidDigits(document)) return false;

        return !HasRepeatedDigits(document);
    }

    private static bool HasRepeatedDigits(string value)
    {
        string[] invalidNumbers =
        {
                new string('0', CpfSize),
                new string('1', CpfSize),
                new string('2', CpfSize),
                new string('3', CpfSize),
                new string('4', CpfSize),
                new string('5', CpfSize),
                new string('6', CpfSize),
                new string('7', CpfSize),
                new string('8', CpfSize),
                new string('9', CpfSize),
        };

        return invalidNumbers.Contains(value);
    }

    private static bool HasValidDigits(string document)
    {
        var number = document.Substring(0, CpfSize - 2);

        var digitChecker = new DigitChecker(number)
            .WithMultipliersUpTo(2, 11)
            .Replacing("0", 10, 11);

        var firstDigit = digitChecker.CalculeteDigit();
        digitChecker.AddDigit(firstDigit);
        var secondDigit = digitChecker.CalculeteDigit();

        return string.Concat(firstDigit, secondDigit) == document.Substring(CpfSize - 2, 2);
    }
}
