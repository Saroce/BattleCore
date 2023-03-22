//------------------------------------------------------------
//        File:  ViewTearDownSystem.cs
//       Brief:  ViewTearDownSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Entitas;

namespace Battle.View.Base.ECSExtension
{
    internal abstract class ViewTearDownSystem : ViewBaseSystem, ITearDownSystem
    {
        protected ViewTearDownSystem(ViewContexts contexts) : base(contexts) {
        }

        public abstract void TearDown();
    }
}
