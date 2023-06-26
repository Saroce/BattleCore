using System.Collections.Generic;

namespace Battle.Logic.Base.ShuntingYardAlgorithm
{
    /// <summary>
    ///  http://en.wikipedia.org/wiki/Shunting-yard_algorithm
    /// </summary>
    internal sealed class ShuntingYard
    {
        private readonly Queue<Token> _infixTokens;

        public ShuntingYard(LogicContexts contexts, Queue<Token> infixTokens) {
            _contexts = contexts;
            _infixTokens = infixTokens;
        }

        public Queue<Token> PostfixTokens => InfixToPostfix();

        private readonly LogicContexts _contexts;

        private Queue<Token> CloneQueue(Queue<Token> queue) {
            var clonedQueue = _contexts.QueuePool<Token>().Get();
            foreach (var item in queue)
                clonedQueue.Enqueue(item);
            return clonedQueue;
        }

        /// <summary>
        /// 调度场算法：中缀转后缀表达式，分析已拆分公式的Tokens列表
        /// </summary>
        /// <returns></returns>
        private Queue<Token> InfixToPostfix() {
            var infixTokensCopy = CloneQueue(_infixTokens); // mutate separate queue
            var outputQueue = _contexts.QueuePool<Token>().Get();
            var operatorStack = _contexts.StackPool<Token>().Get();
            var lastTokenType = TokenType.None;

            while (infixTokensCopy.Count > 0) {
                var token = infixTokensCopy.Dequeue();

                switch (token.GetTokenType()) {
                    case TokenType.Number:
                        outputQueue.Enqueue(token);
                        break;
                    case TokenType.Function:
                        operatorStack.Push(token);
                        break;
                    case TokenType.FunctionArgSeparator: {
                        while (operatorStack.Peek().GetTokenType() != TokenType.LeftParen)
                            outputQueue.Enqueue(operatorStack.Pop());
                        break;
                    }
                    case TokenType.Operator: {
                        if (operatorStack.Count == 0 && outputQueue.Count == 0 ||
                            lastTokenType == TokenType.Operator ||
                            lastTokenType == TokenType.LeftParen ||
                            lastTokenType == TokenType.FunctionArgSeparator) { // this is a unary operator

                            if (((Token<string>) token).Value == "-") {
                                var tok = _contexts.RefPool<Token<string>>().Get();
                                tok.Value = "#";
                                token = tok; // unary minus operator
                            }
                            else if (((Token<string>) token).Value == "+") {
                                var tok = _contexts.RefPool<Token<string>>().Get();
                                tok.Value = "@";
                                token = tok;
                            }
                        }

                        var operator1 = _contexts.RefPool<Operator>().Get();
                        operator1.Create(token);
                        while (operatorStack.Count > 0 && operatorStack.Peek().GetTokenType() == TokenType.Operator) {
                            var operator2 = _contexts.RefPool<Operator>().Get();
                            operator2.Create(operatorStack.Peek());

                            if (operator1.Associativity == "left" && operator1.Precedence <= operator2.Precedence ||
                                operator1.Associativity == "right" && operator1.Precedence < operator2.Precedence) {
                                operatorStack.Pop();
                                outputQueue.Enqueue(operator2.Op);
                                _contexts.RefPool<Operator>().Return(operator2);
                            }
                            else {
                                _contexts.RefPool<Operator>().Return(operator2);
                                break;
                            }
                        }

                        operatorStack.Push(operator1.Op);
                        _contexts.RefPool<Operator>().Return(operator1);
                        break;
                    }
                    case TokenType.LeftParen:
                        operatorStack.Push(token);
                        break;
                    case TokenType.RightParen: {
                        while (operatorStack.Peek().GetTokenType() != TokenType.LeftParen)
                            outputQueue.Enqueue(operatorStack.Pop());

                        operatorStack.Pop(); // discard left parenthesis

                        if (operatorStack.Count > 0 && operatorStack.Peek().GetTokenType() == TokenType.Function)
                            outputQueue.Enqueue(operatorStack.Pop());
                        break;
                    }
                }

                lastTokenType = token.GetTokenType();
            }

            while (operatorStack.Count > 0)
                outputQueue.Enqueue(operatorStack.Pop());

            _contexts.QueuePool<Token>().Return(infixTokensCopy);
            _contexts.StackPool<Token>().Return(operatorStack);

            return outputQueue;
        }
    }
}