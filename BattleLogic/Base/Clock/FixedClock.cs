//------------------------------------------------------------
//        File:  FixedClock.cs
//       Brief:  FixedClock
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.Logic.Base.Clock
{
    public class FixedClock : Clock
    {
        protected override void UpdateClock() {
            TimeInSeconds += StepDelta;
        }
    }
}