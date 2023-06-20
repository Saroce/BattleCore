//------------------------------------------------------------
//        File:  IdComponent.cs
//       Brief:  IdComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using Entitas.CodeGeneration.Attributes;

namespace Battle.Logic.Base.Component
{
    [LogicThing, LogicBuff, LogicSkill, LogicEffect]
    public class IdComponent : LogicComponent
    {
        [PrimaryEntityIndex]
        public ulong Value;
    }
}
