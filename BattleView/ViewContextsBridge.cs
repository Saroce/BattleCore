//------------------------------------------------------------
//        File:  ViewContextsBridge.cs
//       Brief:  ViewContextsBridge
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Core.Lite.Base;

namespace Battle.View
{
    internal class ViewContextsBridge : BaseObject<ViewContexts>
    {
        protected ViewContexts Contexts { get; private set; }

        protected override void OnCreate(ViewContexts contexts) {
            Contexts = contexts;
        }
        
        protected override void OnDestroy() {
            Contexts = null;
        }
    }
}
