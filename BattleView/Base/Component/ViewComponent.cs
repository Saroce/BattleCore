//------------------------------------------------------------
//        File:  ViewComponent.cs
//       Brief:  ViewComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-23
//============================================================

using System;
using Entitas;
using Core.Lockstep.Math;

namespace Battle.View.Base.Component
{
    public class ViewComponent : IComponent
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
            return FixedPoint.FromRaw(rawValue);
        }
        
        public class EncryptedFixedPointValueViewComponent : ViewComponent
        {
            private FixedPoint _value;

            public FixedPoint Value {
                set => SetValue(ref _value, value);
                get => GetValue(ref _value);
            }
        }
        
        public class EncryptedIntValueViewComponent : ViewComponent
        {
            private int _value;

            public int Value {
                get => GetValue(ref _value);
                set => SetValue(ref value, value);
            }
        }
        
        public class EncryptedUlongValueViewComponent : ViewComponent
        {
            private ulong _value;

            public ulong Value {
                get => GetValue(ref _value);
                set => SetValue(ref value, value);
            }
        }
    }
}
