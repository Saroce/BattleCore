﻿//------------------------------------------------------------
//        File:  GamerGroup.cs
//       Brief:  GamerGroup
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using System.Collections.Generic;
using System.Linq;

namespace Battle.Common.Context.Combat
{
    public class GamerGroup
    {
        public List<GamerData> Gamers { get; set; }

        public GamerGroup(IEnumerable<GamerData> gamers) {
            Gamers = gamers.ToList();
        }
        
        public GamerData GetGamerDataById(ulong uid) {
            return Gamers.Find(v => v.Id == uid);
        }
    }
}