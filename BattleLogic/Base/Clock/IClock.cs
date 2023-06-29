//------------------------------------------------------------
//        File:  IClock.cs
//       Brief:  IClock
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using Core.Lockstep.Math;

namespace Battle.Logic.Base.Clock
{
    public interface IClock
    {
        /// <summary>
        /// 时钟步进幅度
        /// </summary>
        FixedPoint StepDelta { set; get; }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        FixedPoint GetTime();

        /// <summary>
        /// 获取时钟步进间隔
        /// </summary>
        /// <returns></returns>
        FixedPoint GetDelta();

        /// <summary>
        /// 驱动步进
        /// </summary>
        void Step();
    }
}