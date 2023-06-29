//------------------------------------------------------------
//        File:  FluxSkillEventData.cs
//       Brief:  FluxSkillEventData
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-17
//============================================================

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Lockstep.Math;

namespace Battle.Common.Context.Combat
{
    [Serializable]
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;
    }
    
    [Serializable]
    public class FluxSkillEventDataBase
    {
        public int StartFrame;
        public int EndFrame;
    }

    [Serializable]
    public class FluxSkillJudgeData : FluxSkillEventDataBase
    {
        public string JudgeId;
        public string HitSequencePath;
    }

    [Serializable]
    public class FluxSkillShootData : FluxSkillEventDataBase
    {
        public string BulletPrefabPath;
        public string BulletMoveTrackSequencePath;
        public int ReferenceType;
        public string ShootId;
        public Vector3 Offset;
        
        [NonSerialized] 
        public TSVector TSOffset;

        [OnDeserialized]
        private void OnAfterDeserialize(StreamingContext context) {
            TSOffset = TSVector.FromFloat(Offset.x, Offset.y, Offset.z);
        }
    }

    [Serializable]
    public class FluxSkillMoveTowardData : FluxSkillEventDataBase
    {
        public int MoveType;
        public float GravityX;
        public float GravityY;
        public float GravityZ;
        public float MoveSpeed;

        [NonSerialized]
        public FixedPoint TSGravityX;
        [NonSerialized]
        public FixedPoint TSGravityY;
        [NonSerialized]
        public FixedPoint TSGravityZ;
        [NonSerialized]
        public FixedPoint TSMoveSpeed;
        
        [OnDeserialized]
        private void OnAfterDeserialize(StreamingContext context) {
            TSGravityX = GravityX;
            TSGravityY = GravityY;
            TSGravityZ = GravityZ;
            TSMoveSpeed = MoveSpeed;
        }
    }
    
    [Serializable]
    public class FluxSkillEventData
    {
        public int FrameRate;
        public int Length;
        public List<FluxSkillJudgeData> Judges = new List<FluxSkillJudgeData>();
        public List<FluxSkillShootData> Shoots = new List<FluxSkillShootData>();
        public List<FluxSkillMoveTowardData> MoveTowards = new List<FluxSkillMoveTowardData>();
    }
}