using System.Text.RegularExpressions;

namespace RomanNumeralParser.Models
{
    /// <summary>
    /// Immutable reference type, using a record to add some value type features
    /// </summary>
    public record RomanSymbol : IComparable<RomanSymbol>
    {
        // Symbol could be a char or an enum but for now let's keep it as string
        public string Symbol { get; }
        
        // Using double to support different notations, i.e fractions
        public double Value { get; }
        
        /// We could use a different data structure and pattern for this list of symbols.
        /// Or come up with a hierarchy here and let each implementation define its own
        /// default set of symbols, but for the current requirement I'll just keep it here
        public static readonly RomanSymbol[] Symbols = new RomanSymbol[]
        {
            new RomanSymbol("I", 1), 
            new RomanSymbol("V", 5), 
            new RomanSymbol("X", 10), 
            new RomanSymbol("L", 50), 
            new RomanSymbol("C", 100), 
            new RomanSymbol("D", 500), 
            new RomanSymbol("M", 1000)
        };
        
        private RomanSymbol(string symbol, int value)
        {
            // TODO: could add better validations on this private constructor to make it more robust
            Symbol = symbol ?? throw new ArgumentException("Not a valid Roman Symbol", nameof(symbol));
            Value = value > 0 ? value : throw new ArgumentException("Not a valid value", nameof(value));
        }

        public static RomanSymbol ParseString(string symbol)
        {
            var symbolFound = Symbols.SingleOrDefault(s => s.Symbol.Equals(symbol.Trim(), StringComparison.InvariantCultureIgnoreCase));
            if (symbolFound == null) throw new ArgumentException("Not a valid Roman Symbol", nameof(symbol));
            return symbolFound;
        }

        public int CompareTo(RomanSymbol? other)
        {
            if (other == null)
                throw new ArgumentException($"Other is not a valid Roman Symbol");
            
            return this.Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return Symbol;
        }
    }
}