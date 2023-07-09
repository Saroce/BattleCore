//------------------------------------------------------------
//        File:  RetrieveGamerByGeneralId.cs
//       Brief:  RetrieveGamerByGeneralId
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-08
//============================================================

using Battle.Common.Context.Command.Request;
using Battle.Common.Context.Command.Respond;
using Battle.Common.Context.Create;
using Battle.Logic.Constant;
using Battle.Logic.Thing.Extension;
using Core.Lockstep.Math;

namespace Battle.Logic.Input.System.Processor
{
    internal class RetrieveGamerByGeneralId
        : CommandProcessor<RetrieveGamerByGeneralIdRequest, RetrieveGamerByGeneralIdRespond>
    {
        protected override void OnProcess(RetrieveGamerByGeneralIdRequest request,
            RetrieveGamerByGeneralIdRespond respond) {

            if (!RetrieveEntityByGeneralId(request.GeneralId, out var thingEntity)) {
                Fail($"Retrieve gamer failed, no entity with general id: {request.GeneralId}");
                return;
            }

            respond.Id = thingEntity.id.Value;
            respond.Position = thingEntity.position.Value;
            respond.Rotation = thingEntity.hasRotation ? thingEntity.rotation.Value : TSQuaternion.identity;
            respond.CombatValue = thingEntity.CollectCombatValue(Contexts);
            
            Succeed();
        }

        private bool RetrieveEntityByGeneralId(int generalId, out LogicThingEntity thingEntity) {
            var group = Contexts.logicThing.GetGroup(LogicThingDef.GamerMatchers);
            foreach (var entity in group.GetEntities()) {
                if (entity.thingCreateContext.Value is GamerCreateContext createContext) {
                    if (createContext.GeneralId == generalId) {
                        thingEntity = entity;
                        return true;
                    }
                }
            }

            thingEntity = null;
            return false;
        }
    }
}