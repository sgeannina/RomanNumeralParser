using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumeralParser.Models;

namespace RomanNumeralParser.UnitTests.Models;

[TestClass]
public class RomanNumeral
{
    [DataTestMethod]
    [ExpectedException(typeof(ArgumentException), "Not a valid Roman Symbol")]
    [DataRow(" ")]
    [DataRow("g")]
    [DataRow("*")]
    [DataRow("?")]
    public void GetRomanSymbol_WithInvalidSymbol_ThrowsException(string symbol)
    {
        RomanSymbol.ParseString(symbol);
    }
    
    [DataTestMethod]
    [DataRow("c")]
    [DataRow("L")]
    [DataRow("i")]
    [DataRow("M")]
    [DataRow(" D ")]
    public void GetRomanSymbol_WithValidSymbol_IsSuccess(string symbol)
    {
        var result = RomanSymbol.ParseString(symbol);
        Assert.IsNotNull(result);
        Assert.AreEqual(symbol.Trim().ToUpper(), result.Symbol);
        Assert.IsTrue(result.Value > 0);
    }
    
    /// <summary>
    /// I	V	X	L	C	D	M
    /// 1	5	10	50	100	500	1000
    /// </summary>
    /// <param name="input1">Represents a bigger value</param>
    /// <param name="input2">Represents a smaller value</param>
    [DataTestMethod]
    [DataRow("M", "D")]
    [DataRow("M", "i")]
    [DataRow("L", "V")]
    public void GetRomanSymbol_ValueComparison_IsGreaterThan(string input1, string input2)
    {
        var symbol1 = RomanSymbol.ParseString(input1);
        var symbol2 = RomanSymbol.ParseString(input2);

        Assert.AreEqual(1, symbol1.CompareTo(symbol2), $"{input1} is not greater than {input2}");
    }
    
    [DataTestMethod]
    [DataRow("I", "C")]
    [DataRow("C", "D")]
    [DataRow("L", "C")]
    public void GetRomanSymbol_ValueComparison_IsSmallerThan(string input1, string input2)
    {
        var symbol1 = RomanSymbol.ParseString(input1);
        var symbol2 = RomanSymbol.ParseString(input2);

        Assert.AreEqual(-1, symbol1.CompareTo(symbol2), $"{input1} is not smaller than {input2}");
    }
    
    [DataTestMethod]
    [DataRow("I", "i")]
    [DataRow(" C", "c ")]
    [DataRow("M", "M")]
    public void GetRomanSymbol_ValueComparison_IsEqualsTo(string input1, string input2)
    {
        var symbol1 = RomanSymbol.ParseString(input1);
        var symbol2 = RomanSymbol.ParseString(input2);

        Assert.AreEqual(0, symbol1.CompareTo(symbol2), $"{input1} is not equals to {input2}");
    }
}