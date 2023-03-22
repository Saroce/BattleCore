//------------------------------------------------------------
//        File:  LogicInitializeSystem.cs
//       Brief:  LogicInitializeSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Entitas;

namespace Battle.Logic.Base.ECSExtension
{
    internal abstract class LogicInitializeSystem : LogicBaseSystem, IInitializeSystem, ITearDownSystem
    {
        protected LogicInitializeSystem(LogicContexts contexts) : base(contexts) {
        }

        public abstract void Initialize();

        public abstract void TearDown();
    }
}