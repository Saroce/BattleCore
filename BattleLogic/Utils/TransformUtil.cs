//------------------------------------------------------------
//        File:  TransformUtil.cs
//       Brief:  TransformUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-14
//============================================================

using vFrame.Lockstep.Core;

namespace Battle.Logic.Utils
{
    public static class TransformUtil
    {
        /// <summary>
        /// 游戏世界的Vector3转成物理世界的Vector2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TSVector2 ToVector2(TSVector value) {
            return new TSVector2(value.x, value.z);
        }
    }
}