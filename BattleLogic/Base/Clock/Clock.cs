//------------------------------------------------------------
//        File:  Clock.cs
//       Brief:  Clock
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using vFrame.Lockstep.Core;

namespace Battle.Logic.Base.Clock
{
    public abstract class Clock : IClock
    {
        public FixedPoint StepDelta { get; set; }
        
        protected FixedPoint TimeInSeconds { get; set; }
        
        public FixedPoint GetTime() {
            return TimeInSeconds;
        }

        public virtual FixedPoint GetDelta() {
            return StepDelta;
        }

        public void Step() {
            UpdateClock();
        }

        protected abstract void UpdateClock();
    }
}