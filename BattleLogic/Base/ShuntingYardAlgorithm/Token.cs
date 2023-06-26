using System;
using System.Collections.Generic;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Base.ShuntingYardAlgorithm
{
    public enum TokenType
    {
        None,
        Number,
        Function,
        FunctionArgSeparator,
        Operator,
        LeftParen,
        RightParen
    }

    public abstract class Token
    {
        protected static readonly Dictionary<string, TokenType> validTokens = new Dictionary<string, TokenType> {
            {"^", TokenType.Operator},
            {"*", TokenType.Operator},
            {"/", TokenType.Operator},
            {"+", TokenType.Operator},
            {"-", TokenType.Operator},
            {"#", TokenType.Operator},
            {"@", TokenType.Operator},
            {"&", TokenType.Operator},
            {"|", TokenType.Operator},
            {"(", TokenType.LeftParen},
            {")", TokenType.RightParen},
            {",", TokenType.FunctionArgSeparator},
            {"sin", TokenType.Function},
            {"cos", TokenType.Function},
            {"tan", TokenType.Function},
            {"abs", TokenType.Function},
            {"max", TokenType.Function},
            {"min", TokenType.Function},
            {"neg", TokenType.Function},
            {"avg", TokenType.Function},
            {"sqrt", TokenType.Function},
            {"vavg", TokenType.Function},
            {"lt", TokenType.Function},
            {"gt", TokenType.Function},
            {"le", TokenType.Function},
            {"ge", TokenType.Function},
        };

        public abstract TokenType GetTokenType();

        protected static readonly object _lock = new object();

        public static void AddCustomToken(string name, TokenType type) {
            lock (_lock) {
                if (validTokens.ContainsKey(name)) {
                    return;
                }
                validTokens.Add(name, type);
            }
        }
    }

    public class Token<T> : Token
    {
        public T Value { get; set; }

        public override TokenType GetTokenType() {
            if (typeof(T) == typeof(FixedPoint)) {
                return TokenType.Number;
            }

            if (typeof(T) == typeof(string)) {
                if (!(Value is string strValue)) {
                    throw new InvalidCastException();
                }

                lock (_lock) {
                    if (!validTokens.TryGetValue(strValue, out var tokenType)) // TODO may not actually be a number.
                        tokenType = TokenType.Number;
                    return tokenType;
                }
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}