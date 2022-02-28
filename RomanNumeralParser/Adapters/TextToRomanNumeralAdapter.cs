using RomanNumeralParser.Models;

namespace RomanNumeralParser.Adapters;

/// <summary>
/// Postel's Law: we receive any text from the user (except anything)
/// but we are conservative on what we do with it
/// </summary>
public class TextToRomanNumeralAdapter : IRomanNumeralAdapter
{
    public IRomanNumeral ParseToRomanNumeral(string inputText)
    {
        if (string.IsNullOrWhiteSpace(inputText)) throw new ArgumentNullException(nameof(inputText));

        var characters = inputText.Split();
        var numerals = new List<RomanSymbol>();
        foreach (var character in characters)
        {
            numerals.Add(RomanSymbol.ParseString(character));
        }
        
        return new StandardRomanNumeral(numerals.ToArray());
    }
}

public interface IRomanNumeralAdapter
{
    IRomanNumeral ParseToRomanNumeral(string inputText);
}