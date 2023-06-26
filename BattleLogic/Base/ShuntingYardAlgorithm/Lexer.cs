using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Base.ShuntingYardAlgorithm
{
    internal static class Lexer
    {
        private static readonly object LockObject = new object();
        private static readonly Dictionary<string, Queue<Token>> InfixTokenCache = new Dictionary<string, Queue<Token>>(128);
        private const string Pattern = @"(\+|-|\*|/|\^|\(|\)|,|\&|\|)";

        public static Queue<Token> Tokenize(LogicContexts contexts, string expression) {
            Queue<Token> tokens;
            lock (LockObject) {
                if (InfixTokenCache.TryGetValue(expression, out tokens)) {
                    return tokens;
                }

                tokens = new Queue<Token>();

                var normalized = expression;
                normalized = normalized.Replace("pi", Math.PI.ToString());
                normalized = normalized.Replace(" ", "");
                // 正则形式分割公式，得到Tokens列表
                foreach (var tok in Regex.Split(normalized, Pattern)) {
                    if (tok == "")
                        continue;

                    try {
                        var value = float.Parse(tok);
                        var token = contexts.RefPool<Token<FixedPoint>>().Get();
                        token.Value = value;
                        tokens.Enqueue(token);
                    }
                    catch {
                        var token = contexts.RefPool<Token<string>>().Get();
                        token.Value = tok;
                        tokens.Enqueue(token);
                    }
                }

                InfixTokenCache.Add(expression, tokens);
            }
            return tokens;
        }
    }
}