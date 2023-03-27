//------------------------------------------------------------
//        File:  PlayerGroup.cs
//       Brief:  PlayerGroup
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using System.Collections.Generic;
using System.Linq;

namespace Battle.Common.Context.Combat
{
    public class PlayerGroup
    {
        public List<PlayerData> PlayerDataList { get; set; }

        public PlayerGroup(IEnumerable<PlayerData> playerData) {
            PlayerDataList = playerData.ToList();
        }
        
        public PlayerData GetPlayerDataByUId(long uid) {
            return PlayerDataList.Find(v => v.UId == uid);
        }
    }
}