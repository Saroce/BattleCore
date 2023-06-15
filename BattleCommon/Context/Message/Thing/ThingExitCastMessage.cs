//------------------------------------------------------------
//        File:  ThingExitCastMessage.cs
//       Brief:  ThingExitCastMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.Common.Context.Combat;

namespace Battle.Common.Context.Message.Thing
{
    public class ThingExitCastMessage : ThingMessageBase
    {
        public SkillConfData Ability { get; set; }
    }
}