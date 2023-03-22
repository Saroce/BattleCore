//------------------------------------------------------------
//        File:  ScalableClock.cs
//       Brief:  ScalableClock
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using vFrame.Lockstep.Core;

namespace Battle.Logic.Base.Clock
{
    public class ScalableClock : Clock
    {
        public FixedPoint TimeScale { get; set; }
        
        protected override void UpdateClock() {
            TimeInSeconds += StepDelta * TimeScale;
        }

        public override FixedPoint GetDelta() {
            return StepDelta * TimeScale;
        }
    }
}