//------------------------------------------------------------
//        File:  GamerDataFactory.cs
//       Brief:  GamerDataFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using Battle.Common.Context.Combat;

namespace Battle.Logic.Thing.Factory
{
    internal static class GamerDataFactory
    {
        /// <summary>
        /// 创建玩家数据实体
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="gamerData"></param>
        /// <returns>玩家Id</returns>
        public static ulong CreateGamerDataEntity(this LogicContexts contexts, GamerData gamerData) {
            var entity = contexts.logicThing.CreateEntity();
            entity.AddId(gamerData.Id);
            entity.AddGamerInfo(gamerData);
            entity.AddGamerHeroId(gamerData.HeroId);
            entity.AddGamerCombat(gamerData.CombatValue);
            
            // TODO 技能配置
            
            entity.isThing = entity.isGamer = true;

            return entity.id.Value;
        }
    }
}