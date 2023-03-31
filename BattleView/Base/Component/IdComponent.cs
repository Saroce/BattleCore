//------------------------------------------------------------
//        File:  IdComponent.cs
//       Brief:  IdComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.View.Base.System;
using Entitas.CodeGeneration.Attributes;

namespace Battle.View.Base.Component
{
    [ViewBuff, ViewSkill, ViewThing]
    public class IdComponent : ViewComponent
    {
        [PrimaryEntityIndex]
        public ulong Value;
    }
}