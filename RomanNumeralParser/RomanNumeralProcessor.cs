using RomanNumeralParser.Adapters;

namespace RomanNumeralParser;

/// <summary>
/// Entry point, call this class to parse a string
/// TODO: Add interface for DI
/// </summary>
public class RomanNumeralProcessor
{
    private readonly IRomanNumeralAdapter _romanNumeralAdapter;

    public RomanNumeralProcessor()
    {
        // TODO: Use DI
        _romanNumeralAdapter = new TextToRomanNumeralAdapter();
    }
    /// <summary>
    /// Postel's Law: be liberal in what you receive
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string? ProcessNumeral(string input)
    {
        var romanNumeral = _romanNumeralAdapter.ParseToRomanNumeral(input);
        return romanNumeral?.ToString();
    }
}