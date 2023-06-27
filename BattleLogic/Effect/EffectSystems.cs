//------------------------------------------------------------
//        File:  EffectSystems.cs
//       Brief:  EffectSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using Battle.Logic.Effect.System;

namespace Battle.Logic.Effect
{
    internal sealed class EffectSystems : Feature
    {
        public EffectSystems(LogicContexts contexts) {
            // Initialize Systems
            Add(new LoadFormulaDataSystem(contexts));
            
            // Reactivate Systems
            Add(new AddEffectSystem(contexts));
        }
    }
}