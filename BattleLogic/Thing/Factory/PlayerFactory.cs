//------------------------------------------------------------
//        File:  PlayerFactory.cs
//       Brief:  PlayerFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using Battle.Common.Context.Combat;

namespace Battle.Logic.Thing.Factory
{
    internal static class PlayerFactory
    {
        /// <summary>
        /// 创建玩家实体Id
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="playerData"></param>
        /// <returns></returns>
        public static ulong CreatePlayer(this LogicContexts contexts, PlayerData playerData) {
            return 0;
        }
    }
}