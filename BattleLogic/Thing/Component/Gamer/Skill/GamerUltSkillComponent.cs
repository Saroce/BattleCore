//------------------------------------------------------------
//        File:  GamerUltSkillComponent.cs
//       Brief:  GamerUltSkillComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-08
//============================================================

using Battle.Logic.Base.Component;

namespace Battle.Logic.Thing.Component.Gamer.Skill
{
    [LogicThing]
    public class GamerUltSkillComponent : LogicComponent
    {
        /// <summary>
        /// 奥义技能数据GUID
        /// </summary>
        public string Value;
    }
}