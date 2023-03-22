//------------------------------------------------------------
//        File:  LogicExecuteSystem.cs
//       Brief:  LogicExecuteSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Entitas;

namespace Battle.Logic.Base.ECSExtension
{
    internal abstract class LogicExecuteSystem : LogicBaseSystem, IExecuteSystem
    {
        protected LogicExecuteSystem(LogicContexts contexts) : base(contexts) {
            
        }

        public abstract void Execute();
    }
}