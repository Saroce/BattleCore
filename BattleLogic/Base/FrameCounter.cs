//------------------------------------------------------------
//        File:  FrameCounter.cs
//       Brief:  FrameCounter
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.Logic.Base
{
    public class FrameCounter
    {
        public int FrameIndex { get; private set; }

        public void EnterFrame() => ++FrameIndex;
    }
}