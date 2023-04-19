//------------------------------------------------------------
//        File:  TSQuaternionExtension.cs
//       Brief:  TSQuaternionExtension
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-19
//============================================================

using UnityEngine;
using vFrame.Lockstep.Core;

namespace Battle.View.Base
{
    public static class TSQuaternionExtension
    {
        public static Quaternion ToUnityQuaternion(this TSQuaternion quaternion) {
            return new Quaternion((float) quaternion.x, (float) quaternion.y, (float) quaternion.z,
                (float) quaternion.w);
        }
    }
}
