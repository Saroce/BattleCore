//------------------------------------------------------------
//        File:  LogicTearDownSystem.cs
//       Brief:  LogicTearDownSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Entitas;

namespace Battle.Logic.Base.CSExtension
{
    internal abstract class LogicTearDownSystem : LogicBaseSystem, ITearDownSystem
    {
        protected LogicTearDownSystem(LogicContexts contexts) : base(contexts) {
        }

        public abstract void TearDown();
    }
}