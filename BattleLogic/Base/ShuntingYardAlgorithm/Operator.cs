using System;
using System.Collections.Generic;
using Core.Lite.Base;
using Core.Lockstep.Math;

namespace Battle.Logic.Base.ShuntingYardAlgorithm
{
    internal class Operator : BaseObject<Token>
    {
        private static readonly object LockObject = new object();
        public delegate FixedPoint EvaluationDelegate(FixedPoint x, FixedPoint y);

        // Tuple<优先级，结合性，操作形式>
        private static readonly Dictionary<string, Tuple<int, string, EvaluationDelegate>> OperatorInfo =
            new Dictionary<string, Tuple<int, string, EvaluationDelegate>> {
                {"#", new Tuple<int, string, EvaluationDelegate>(5, "right", (x, y) => -x)},
                {"@", new Tuple<int, string, EvaluationDelegate>(5, "right", (x, y) => x)},
                {"^", new Tuple<int, string, EvaluationDelegate>(4, "right", TSMath.Pow)},
                {"*", new Tuple<int, string, EvaluationDelegate>(3, "left", (x, y) => x * y)},
                {"/", new Tuple<int, string, EvaluationDelegate>(3, "left", (x, y) => x / y)},
                {"+", new Tuple<int, string, EvaluationDelegate>(2, "left", (x, y) => x + y)},
                {"-", new Tuple<int, string, EvaluationDelegate>(2, "left", (x, y) => x - y)},
                {"&", new Tuple<int, string, EvaluationDelegate>(2, "left", (x, y) => FixedPoint.FromRaw(x.RawValue & y.RawValue))},
                {"|", new Tuple<int, string, EvaluationDelegate>(2, "left", (x, y) => FixedPoint.FromRaw(x.RawValue | y.RawValue))},
            };

        protected override void OnDestroy() {
            Op = null;
        }

        protected override void OnCreate(Token token) {
            Op = token;
        }

        public Token Op { get; set; }

        public int Precedence {
            get {
                Tuple<int, string, EvaluationDelegate> tuple;
                lock (LockObject) {
                    OperatorInfo.TryGetValue(((Token<string>)Op).Value, out tuple);
                }
                return tuple.Item1;
            }
        }

        public string Associativity {
            get {
                Tuple<int, string, EvaluationDelegate> tuple;
                lock (LockObject) {
                    OperatorInfo.TryGetValue(((Token<string>) Op).Value, out tuple);
                }
                return tuple.Item2;
            }
        }

        public EvaluationDelegate Operation {
            get {
                Tuple<int, string, EvaluationDelegate> tuple;
                lock (LockObject) {
                    OperatorInfo.TryGetValue(((Token<string>) Op).Value, out tuple);
                }
                return tuple.Item3;
            }
        }
    }
}