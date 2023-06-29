//------------------------------------------------------------
//        File:  ThingRotationMessage.cs
//       Brief:  ThingRotationMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using Core.Lockstep.Math;

namespace Battle.Common.Context.Message.Thing
{
    public class ThingRotationMessage : ThingMessageBase<ThingEnterCastMessage>
    {
        public TSQuaternion Rotation;
    }
}