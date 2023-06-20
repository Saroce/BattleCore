//------------------------------------------------------------
//        File:  EffectComponent.cs
//       Brief:  EffectComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using Battle.Logic.Base.Component;
using SkillModule.Runtime.Effect;

namespace Battle.Logic.Effect.Component
{
    [LogicEffect]
    public class EffectComponent : LogicComponent
    {
        public EffectData EffectData;
        public ulong SourceId;
        public ulong TargetId;
    }
}