//------------------------------------------------------------
//        File:  ViewContexts.cs
//       Brief:  ViewContexts
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

namespace Battle.View
{
    public class ViewContexts : Contexts
    {
        private readonly ViewController _controller;
        
        public ViewContexts(ViewController controller) {
            _controller = controller;
        }
    }
}