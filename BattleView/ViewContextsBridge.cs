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
    public class ViewContextsBridge : BaseObject<ViewContexts>
    {
        protected ViewContexts Contexts { get; private set; }
        
        protected override void OnDestroy() {
            Contexts = null;
        }

        protected override void OnCreate(ViewContexts contexts) {
            Contexts = contexts;
        }
    }
}
