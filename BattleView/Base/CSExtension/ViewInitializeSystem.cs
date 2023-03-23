//------------------------------------------------------------
//        File:  ViewInitializeSystem.cs
//       Brief:  ViewInitializeSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Entitas;

namespace Battle.View.Base.CSExtension
{
    internal abstract class ViewInitializeSystem : ViewBaseSystem, IInitializeSystem
    {
        protected ViewInitializeSystem(ViewContexts contexts) : base(contexts) {
        }

        public abstract void Initialize();
    }
}
