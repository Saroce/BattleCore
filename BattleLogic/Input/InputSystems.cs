//------------------------------------------------------------
//        File:  InputSystems.cs
//       Brief:  InputSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using Battle.Logic.Input.System;

namespace Battle.Logic.Input
{
    internal sealed class InputSystems : Feature
    {
        public InputSystems(LogicContexts contexts) {
            
            // TearDown System
            Add(new InputTearDownSystem(contexts));
        }
    }
}
