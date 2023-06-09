﻿//------------------------------------------------------------
//        File:  InputSystems.cs
//       Brief:  InputSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.View.Input.System;

namespace Battle.View.Input
{
    internal sealed class InputSystems : Feature
    {
        public InputSystems(ViewContexts contexts) {
            Add(new MessageSystem(contexts));
        }
    }
}