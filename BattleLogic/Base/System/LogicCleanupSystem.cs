//------------------------------------------------------------
//        File:  LogicCleanupSystem.cs
//       Brief:  LogicCleanupSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Entitas;

namespace Battle.Logic.Base.System
{
    internal abstract class LogicCleanupSystem : LogicBaseSystem, ICleanupSystem
    {
        protected LogicCleanupSystem(LogicContexts contexts) : base(contexts) {
        }

        public abstract void Cleanup();
    }
}