//------------------------------------------------------------
//        File:  ThingBehaviourExtension.cs
//       Brief:  ThingBehaviourExtension
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

namespace Battle.Logic.Thing.Extension
{
    internal static class ThingBehaviourExtension
    {
        public static bool IsIdlable(this LogicThingEntity thingEntity) {
            return thingEntity.hasIdlableRef && thingEntity.idlableRef.Value > 0;
        }
        
        public static bool IsMovable(this LogicThingEntity thingEntity) {
            return thingEntity.hasMovableRef && thingEntity.movableRef.Value > 0;
        }
        
    }
}