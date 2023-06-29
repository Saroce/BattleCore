using System;
using System.Collections.Generic;
using Battle.Common.Exceptions;
using Core.Lockstep.Math;

namespace Battle.Logic.Base.ShuntingYardAlgorithm
{
    internal class Function
    {
        public delegate FixedPoint ZeroArgDelegate();
        public delegate FixedPoint OneArgDelegate(FixedPoint x);
        public delegate FixedPoint TwoArgsDelegate(FixedPoint x, FixedPoint y);

        private readonly Dictionary<string, ZeroArgDelegate> _registeredZeroArgDelegates
            = new Dictionary<string, ZeroArgDelegate>();

        private readonly Dictionary<string, OneArgDelegate> _registeredOneArgDelegates
            = new Dictionary<string, OneArgDelegate>();

        private readonly Dictionary<string, TwoArgsDelegate> _registeredTwoArgsDelegates
            = new Dictionary<string, TwoArgsDelegate>();

        public Function() {
            Reset();
        }

        public void Reset() {
            _registeredZeroArgDelegates.Clear();
            _registeredOneArgDelegates.Clear();
            _registeredTwoArgsDelegates.Clear();
        }

        /// <summary>
        /// 从后缀表达式栈里面取参数，调用相应的函数返回结果
        /// </summary>
        /// <param name="function"></param>
        /// <param name="argumentStack"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public FixedPoint Call(string function, Stack<Token> argumentStack) {
            switch (function) {
                case "sin":
                    return TSMath.Sin(GetArg(argumentStack));
                case "cos":
                    return TSMath.Cos(GetArg(argumentStack));
                case "tan":
                    return TSMath.Tan(GetArg(argumentStack));
                case "abs":
                    return TSMath.Abs(GetArg(argumentStack));
                case "max":
                    return TSMath.Max(GetArg(argumentStack), GetArg(argumentStack));
                case "min":
                    return TSMath.Min(GetArg(argumentStack), GetArg(argumentStack));
                case "neg":
                    return -GetArg(argumentStack);
                case "avg":
                    return (GetArg(argumentStack) + GetArg(argumentStack)) / 2;
                case "sqrt":
                    return TSMath.Sqrt(GetArg(argumentStack));
                case "lt": {
                    var arg1 = GetArg(argumentStack);
                    var arg2 = GetArg(argumentStack);
                    return arg2 < arg1 ? 1 : 0;
                }
                case "gt": {
                    var arg1 = GetArg(argumentStack);
                    var arg2 = GetArg(argumentStack);
                    return arg2 > arg1 ? 1 : 0;
                }
                case "le": {
                    var arg1 = GetArg(argumentStack);
                    var arg2 = GetArg(argumentStack);
                    return arg2 <= arg1 ? 1 : 0;
                }
                case "ge": {
                    var arg1 = GetArg(argumentStack);
                    var arg2 = GetArg(argumentStack);
                    return arg2 >= arg1 ? 1 : 0;
                }
                case "vavg":
                    var count = (int) GetArg(argumentStack);
                    FixedPoint sum = 0;
                    for (var i = 0; i < count; ++i)
                        sum += GetArg(argumentStack);

                    return sum / count;
                default:
                    if (_registeredZeroArgDelegates.ContainsKey(function)) {
                        return _registeredZeroArgDelegates[function]();
                    }
                    if (_registeredOneArgDelegates.ContainsKey(function)) {
                        return _registeredOneArgDelegates[function](GetArg(argumentStack));
                    }
                    if (_registeredTwoArgsDelegates.ContainsKey(function)) {
                        return _registeredTwoArgsDelegates[function](GetArg(argumentStack), GetArg(argumentStack));
                    }
                    break;
            }

            throw new ArgumentException($"Invalid function, {function}");
        }

        private FixedPoint GetArg(Stack<Token> argumentStack) {
            var arg = argumentStack.Pop();
            if (arg is Token<FixedPoint> fixedPointArg) {
                return fixedPointArg.Value;
            }
            throw new TypeMismatchException(typeof(Token<FixedPoint>), arg.GetType());
        }

        public void RegisterZeroArgsDelegate(string funcName, ZeroArgDelegate @delegate) {
            if (_registeredZeroArgDelegates.ContainsKey(funcName)) {
                throw new FunctionAlreadyRegisteredException(funcName);
            }
            _registeredZeroArgDelegates.Add(funcName, @delegate);
        }

        public void UnregisterZeroArgDelegate(string funcName) {
            if (!_registeredZeroArgDelegates.ContainsKey(funcName)) {
                return;
            }
            _registeredZeroArgDelegates.Remove(funcName);
        }

        public void RegisterOneArgsDelegate(string funcName, OneArgDelegate @delegate) {
            if (_registeredOneArgDelegates.ContainsKey(funcName)) {
                throw new FunctionAlreadyRegisteredException(funcName);
            }
            _registeredOneArgDelegates.Add(funcName, @delegate);
        }

        public void UnregisterOneArgsDelegate(string funcName) {
            if (!_registeredOneArgDelegates.ContainsKey(funcName)) {
                return;
            }
            _registeredOneArgDelegates.Remove(funcName);
        }

        public void RegisterTwoArgsDelegate(string funcName, TwoArgsDelegate @delegate) {
            if (_registeredTwoArgsDelegates.ContainsKey(funcName)) {
                throw new FunctionAlreadyRegisteredException(funcName);
            }
            _registeredTwoArgsDelegates.Add(funcName, @delegate);
        }

        public void UnregisterTwoArgsDelegate(string funcName) {
            if (!_registeredTwoArgsDelegates.ContainsKey(funcName)) {
                return;
            }
            _registeredTwoArgsDelegates.Remove(funcName);
        }

        private class FunctionAlreadyRegisteredException : Exception
        {
            public FunctionAlreadyRegisteredException(string function)
                : base("Function already register: " + function) {

            }
        }
    }
}