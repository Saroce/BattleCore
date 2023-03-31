//------------------------------------------------------------
//        File:  ViewCleanupSystem.cs
//       Brief:  ViewCleanupSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Entitas;

namespace Battle.View.Base.System
{
    internal abstract class ViewCleanupSystem : ViewBaseSystem, ICleanupSystem
    {
        protected ViewCleanupSystem(ViewContexts contexts) : base(contexts) {
        }

        public abstract void Cleanup();
    }
}
