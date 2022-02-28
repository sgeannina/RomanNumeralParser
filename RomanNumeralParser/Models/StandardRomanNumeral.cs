using System.Linq;
using System.Text;

namespace RomanNumeralParser.Models
{
    /// <summary>
    /// Class for standard roman numerals, we implement a different one
    /// by using an interface or inheritance if it only extends the existing behavior
    /// </summary>
    public class StandardRomanNumeral : IRomanNumeral
    {
        
        public StandardRomanNumeral(RomanSymbol[] numerals)
        {
            Numerals = IsValidSequence(numerals) ? numerals : throw new ArgumentException("Not a valid sequence", nameof(numerals));
        }
        
        public RomanSymbol[] Numerals { get; }
        
        public double Value => CalculateValue();

        public bool IsValidSequence(RomanSymbol[] numerals)
        {
            if (!numerals.Any()) return false;
            
            // TODO: Add more validations to avoid invalid sequences, i,e ILIX
            return true;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder()
                .Append(String.Join(string.Empty, Numerals.Select(n => n.Symbol)))
                .AppendLine()
                .Append(Value);
            
            return strBuilder.ToString();
        }

        /// <summary>
        /// TODO: This calculations could be wrapped in another class
        /// </summary>
        /// <returns></returns>
        private double CalculateValue()
        {
            var stack = new Stack<RomanSymbol>(Numerals.Reverse());
            var total = 0.0;

            do
            {
                var currentSymbol = stack.Pop();
                if (!stack.Any()) return total + currentSymbol.Value;

                // Check next symbol before adding the value
                total += CalculateSymbolValue(currentSymbol, stack);
            } while (stack.Any());

            return total;
        }

        private double CalculateSymbolValue(RomanSymbol currentSymbol, Stack<RomanSymbol> stack)
        {
            stack.TryPeek(out var peekNext);
            var nextOperation = GetAnnotationType(currentSymbol, peekNext);

            if (nextOperation == AnnotationType.Subtractive)
            {
                // Subtract next value
                return  (stack.Pop().Value - currentSymbol.Value);
            }

            return currentSymbol.Value;
        }

        private AnnotationType GetAnnotationType(RomanSymbol current, RomanSymbol? next)
        {
            // next < current -> subtract
            return (current.CompareTo(next) < 0) ? AnnotationType.Subtractive : AnnotationType.Additive;
        }
    }

    public interface IRomanNumeral
    {
        public RomanSymbol[] Numerals { get; }
        
        public double Value { get; }

        bool IsValidSequence(RomanSymbol[] numerals);
    }

    public enum AnnotationType
    {
        Subtractive,
        Additive
    }
}