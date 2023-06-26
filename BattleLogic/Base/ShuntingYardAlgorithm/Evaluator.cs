using System.Collections.Generic;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Base.ShuntingYardAlgorithm
{
    internal sealed class Evaluator
    {
        private readonly Queue<Token> _postfixExpression;
        private readonly Function _functions;
        private readonly LogicContexts _contexts;

        public Evaluator(LogicContexts contexts, Queue<Token> postfixExpression, Function functions) {
            _contexts = contexts;
            _postfixExpression = postfixExpression;
            _functions = functions;
        }

        /// <summary>
        /// 后缀表达式求值
        /// </summary>
        /// <returns></returns>
        public FixedPoint Evaluate() {
            var evaluationStack = _contexts.StackPool<Token>().Get();
            foreach (var token in _postfixExpression)
                switch (token.GetTokenType()) {
                    case TokenType.Number: {
                        evaluationStack.Push(token);
                        break;
                    }
                    case TokenType.Operator: {
                        FixedPoint result;
                        var temp = evaluationStack.Pop();
                        var op = _contexts.RefPool<Operator>().Get();
                        op.Create(token);
                        if (((Token<string>) op.Op).Value == "#" || ((Token<string>) op.Op).Value == "@") {
                            result = op.Operation(((Token<FixedPoint>) temp).Value, 0f);
                        }
                        else {
                            result = op.Operation(
                                ((Token<FixedPoint>) evaluationStack.Pop()).Value,
                                ((Token<FixedPoint>) temp).Value);
                        }
                        op.Destroy();
                        _contexts.RefPool<Operator>().Return(op);

                        var tok = _contexts.RefPool<Token<FixedPoint>>().Get();
                        tok.Value = result;
                        evaluationStack.Push(tok);
                        break;
                    }
                    case TokenType.Function: {
                        var funcName = ((Token<string>) token).Value;
                        var result = _functions.Call(funcName, evaluationStack);
                        var tok = _contexts.RefPool<Token<FixedPoint>>().Get();
                        tok.Value = result;
                        evaluationStack.Push(tok);
                        break;
                    }
                }

            var ret = ((Token<FixedPoint>) evaluationStack.Pop()).Value;
            foreach (var token in evaluationStack) {
                _contexts.RefPoolManager().TryReturn(token);
            }
            _contexts.StackPool<Token>().Return(evaluationStack);
            
            return ret;
        }
    }
}