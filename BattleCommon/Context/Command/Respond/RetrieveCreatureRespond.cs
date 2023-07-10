//------------------------------------------------------------
//        File:  RetrieveCreatureRespond.cs
//       Brief:  RetrieveCreatureRespond
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-08
//============================================================

using Battle.Common.Context.Combat;
using Core.Lockstep.Math;

namespace Battle.Common.Context.Command.Respond
{
    public class RetrieveCreatureRespond : BattleRespond
    {
        public ulong Id; // 实体id

        public TSVector Position; // 位置

        public TSQuaternion Rotation; // 旋转

        public CombatValue CombatValue; // 战斗数据

        /// <summary>
        /// 调试用
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return $"Entity id: {Id} Position: {Position} Rotation: {Rotation} CombatValue:{CombatValue}";
        }
    }
}
