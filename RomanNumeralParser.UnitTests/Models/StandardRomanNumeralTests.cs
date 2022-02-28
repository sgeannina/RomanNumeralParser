using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumeralParser.Models;

namespace RomanNumeralParser.UnitTests.Models;

/// <summary>
/// TODO: needs more testing specially for validations and exceptions.
/// </summary>
[TestClass]
public class StandardRomanNumeralTests
{
    [TestMethod]
    public void GetValue_WithSimpleNumeral_IsSuccess()
    {
        var input = new RomanSymbol[]
        {
            RomanSymbol.ParseString("C"),
            RomanSymbol.ParseString("C")
        };

        var romanNumeral = new StandardRomanNumeral(input);
        Assert.IsNotNull(romanNumeral);
        Assert.AreEqual(200, romanNumeral.Value);
    }
    
    [TestMethod]
    public void GetValue_WithValidSimpleSubtractive_IsSuccess()
    {
        var input = new RomanSymbol[]
        {
            RomanSymbol.ParseString("I"),
            RomanSymbol.ParseString("V")
        };

        var romanNumeral = new StandardRomanNumeral(input);
        Assert.IsNotNull(romanNumeral);
        Assert.AreEqual(4, romanNumeral.Value);
    }
    
    [TestMethod]
    public void GetValue_WithValidEvenNumerals_IsSuccess()
    {
        var input = new RomanSymbol[]
        {
            RomanSymbol.ParseString("C"), 
            RomanSymbol.ParseString("I"), 
            RomanSymbol.ParseString("X")
        };

        var romanNumeral = new StandardRomanNumeral(input);
        Assert.IsNotNull(romanNumeral);
        Assert.AreEqual(109, romanNumeral.Value);
    }
    
    [TestMethod]
    public void GetValue_WithValidClockNumerals_IsSuccess()
    {
        var input = new RomanSymbol[]
        {
            RomanSymbol.ParseString("X"), 
            RomanSymbol.ParseString("I"), 
            RomanSymbol.ParseString("I"),
            RomanSymbol.ParseString("I"),
            RomanSymbol.ParseString("I")
        };

        var romanNumeral = new StandardRomanNumeral(input);
        Assert.IsNotNull(romanNumeral);
        Assert.AreEqual(14, romanNumeral.Value);
    }
    
    [TestMethod]
    public void GetValue_WithLongValidNumerals_IsSuccess()
    {
        //MCMXCIX
        var input = new RomanSymbol[]
        {
            RomanSymbol.ParseString("M"), 
            RomanSymbol.ParseString("C"), 
            RomanSymbol.ParseString("M"),
            RomanSymbol.ParseString("X"),
            RomanSymbol.ParseString("C"),
            RomanSymbol.ParseString("I"),
            RomanSymbol.ParseString("X")
        };

        var romanNumeral = new StandardRomanNumeral(input);
        Assert.IsNotNull(romanNumeral);
        Assert.AreEqual(1999, romanNumeral.Value);
    }
    
    [TestMethod]
    public void ToString_WithValidSimpleSubtractive_IsSuccess()
    {
        var input = new RomanSymbol[]
        {
            RomanSymbol.ParseString("I"),
            RomanSymbol.ParseString("V")
        };

        var romanNumeral = new StandardRomanNumeral(input);
        var output = romanNumeral?.ToString();
        Assert.IsNotNull(output);
        
        var expected = new StringBuilder("IV").AppendLine().Append("4").ToString();
        Assert.AreEqual(expected, output);
    }
}