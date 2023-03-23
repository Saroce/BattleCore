//------------------------------------------------------------
//        File:  ViewExecuteSystem.cs
//       Brief:  ViewExecuteSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Entitas;

namespace Battle.View.Base.CSExtension
{
    internal abstract class ViewExecuteSystem : ViewBaseSystem, IExecuteSystem
    {
        protected ViewExecuteSystem(ViewContexts contexts) : base(contexts) {
        }

        public abstract void Execute();
    }
}
