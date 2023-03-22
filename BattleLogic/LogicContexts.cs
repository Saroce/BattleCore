//------------------------------------------------------------
//        File:  LogicContexts.cs
//       Brief:  LogicContexts
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.Logic
{
    public class LogicContexts : Contexts
    {
        private readonly LogicController _controller;

        public LogicContexts(LogicController controller) {
            _controller = controller;
        }
        
        
    }
}