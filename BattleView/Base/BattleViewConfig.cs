//------------------------------------------------------------
//        File:  BattleViewConfig.cs
//       Brief:  BattleViewConfig
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-18
//============================================================

using UnityEngine;

namespace Battle.View.Base
{
    /// <summary>
    /// 视图层Json配置文件反序列化得到
    /// </summary>
    public sealed class BattleViewConfig
    {
        public string AvatarDir;
        public string HUDDir;

        public string HUDHPPath;
        public string HUDHPEnemyPath;
        
        public float LerpSpeed; // Avatar位置插值速度
        
        public Vector3 HUDHPOffset;
        
        public Vector3 AvatarTop;
        public Vector3 AvatarCenter;
        public Vector3 AvatarBottom;
    }
}