//------------------------------------------------------------
//        File:  BuffSystems.cs
//       Brief:  BuffSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using Battle.Logic.Buff.System;

namespace Battle.Logic.Buff
{
    internal sealed class BuffSystems : Feature
    {
        public BuffSystems(LogicContexts contexts) {

            // TearDown System
            Add(new BuffTearDownSystem(contexts));
        }
    }
}
