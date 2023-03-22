//------------------------------------------------------------
//        File:  LogicBaseSystem.cs
//       Brief:  逻辑系统基类
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

namespace Battle.Logic.Base.ECSExtension
{
    internal class LogicBaseSystem : LogicContextsBridge
    {
        public LogicBaseSystem(LogicContexts contexts) {
            Create(contexts);
        }
    }
}