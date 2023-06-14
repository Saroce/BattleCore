﻿//------------------------------------------------------------
//        File:  TSVectorExtension.cs
//       Brief:  TSVectorExtension
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-19
//============================================================

using UnityEngine;
using vFrame.Lockstep.Core;

namespace Battle.View.Base
{
    public static class TSVectorExtension
    {
        public static Vector3 ToUnityVector3(this TSVector vector) {
            return new Vector3((float)vector.z, (float)vector.y, (float)vector.z);
        }
        
        public static Vector2 ToUnityVector2(this TSVector vector) {
            return new Vector2((float)vector.z, (float)vector.y);
        }
    }
}