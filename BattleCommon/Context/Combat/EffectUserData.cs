//------------------------------------------------------------
//        File:  EffectUserData.cs
//       Brief:  EffectUserData
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using Core.Lockstep.Math;

namespace Battle.Common.Context.Combat
{
    public struct EffectUserData
    {
        public SkillConfData SkillConfData;
        public ulong SkillCasterId;
        public ulong SkillEntityId;

        public FixedPoint Duration;
    }
}