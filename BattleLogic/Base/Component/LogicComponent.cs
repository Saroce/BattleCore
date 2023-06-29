//------------------------------------------------------------
//        File:  LogicComponent.cs
//       Brief:  LogicComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using System;
using Core.Lockstep.Math;
using Entitas;

namespace Battle.Logic.Base.Component
{
    public class LogicComponent : IComponent
    {
        private static readonly Random Random = new Random();

        private int Secret { get; } = Random.Next(0, int.MaxValue);
        
        // ReSharper disable once RedundantAssignment
        protected void SetValue(ref int variable, int newValue) {
            variable = newValue ^ Secret;
        }

        protected int GetValue(ref int variable) {
            return variable ^ Secret;
        }

        // ReSharper disable once RedundantAssignment
        protected void SetValue(ref ulong variable, ulong newValue) {
            variable = newValue ^ Convert.ToUInt64(Secret);
        }

        protected ulong GetValue(ref ulong variable) {
            return variable ^ Convert.ToUInt64(Secret);
        }

        // ReSharper disable once RedundantAssignment
        protected void SetValue(ref FixedPoint variable, FixedPoint newValue) {
            variable = FixedPoint.FromRaw(newValue.RawValue ^ Secret);
        }

        protected FixedPoint GetValue(ref FixedPoint variable) {
            var rawValue = variable.RawValue ^ Secret;
            var value = FixedPoint.FromRaw(rawValue);
            return value;
        }
    }

    public class EncryptedFixedPointValueLogicComponent : LogicComponent
    {
        private FixedPoint _value;

        public FixedPoint Value {
            set => SetValue(ref _value, value);
            get => GetValue(ref _value);
        }
    }

    public class EncryptedIntValueLogicComponent : LogicComponent
    {
        private int _value;

        public int Value {
            set => SetValue(ref _value, value);
            get => GetValue(ref _value);
        }
    }

    public class EncryptedUlongValueLogicComponent : LogicComponent
    {
        private ulong _value;

        public ulong Value {
            set => SetValue(ref _value, value);
            get => GetValue(ref _value);
        }
    }
}
