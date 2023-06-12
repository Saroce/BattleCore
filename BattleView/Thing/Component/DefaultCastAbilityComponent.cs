//------------------------------------------------------------
//        File:  DefaultCastAbilityComponent.cs
//       Brief:  DefaultCastAbilityComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-12
//============================================================

using Battle.Common.Context.Combat;
using Battle.View.Base.Component;

namespace Battle.View.Thing.Component
{
    [ViewThing]
    public class DefaultCastAbilityComponent : ViewComponent
    {
        public SkillConfData Value;
    }
}