//------------------------------------------------------------
//        File:  GamerCreateContext.cs
//       Brief:  GamerCreateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Battle.Common.Constant;

namespace Battle.Common.Context.Create
{
    public class GamerCreateContext : CreatureCreateContext
    {
        public int HeroId;
        
        // TODO 技能配置数据

        public GamerCreateContext() {
            ThingType = ThingType.Gamer;
        }
    }
}