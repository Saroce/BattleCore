//------------------------------------------------------------
//        File:  ThingEnterCastMessage.cs
//       Brief:  ThingEnterCastMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.Common.Context.Combat;
using vFrame.Lockstep.Core;

namespace Battle.Common.Context.Message.Thing
{
    public class ThingEnterCastMessage : ThingMessageBase
    {
        public ulong TargetId { get; set; }
        public SkillConfData Ability { get; set; }
        public FixedPoint CastSpeed { get; set; }
    }
}