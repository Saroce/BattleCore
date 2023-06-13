﻿//------------------------------------------------------------
//        File:  CastSkill.cs
//       Brief:  处理施法命令
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using Battle.Common.Context.Command.Request;
using Battle.Common.Context.Command.Respond;

namespace Battle.Logic.Input.System.Processor
{
    internal class CastSkill : CommandProcessor<CastSkillRequest, DefaultRespond>
    {
        protected override void OnProcess(CastSkillRequest request, DefaultRespond respond) {
            var entity = Contexts.logicThing.GetEntityWithId(request.Id);
            if (entity == null) {
                Fail($"Cast failed, entity not found: {request.Id}");
                return;
            }

            if (!entity.hasUltimateAbility) {
                Fail("Entity does not have ultimate cast ability.");
                return;
            }

            var ability = entity.ultimateAbility.Value;
            
        }
    }
}