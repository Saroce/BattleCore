//------------------------------------------------------------
//        File:  ViewBaseSystem.cs
//       Brief:  ViewBaseSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

namespace Battle.View.Base.System
{
    internal class ViewBaseSystem : ViewContextsBridge
    {
        protected ViewBaseSystem(ViewContexts contexts) {
            Create(contexts);
        }
    }
}
