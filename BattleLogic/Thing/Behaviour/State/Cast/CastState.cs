//------------------------------------------------------------
//        File:  CastState.cs
//       Brief:  CastState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.FSM;
using Battle.Logic.Thing.Extension;
using Entitas;

namespace Battle.Logic.Thing.Behaviour.State.Cast
{
    internal class CastState : Base.FSM.State
    {
        public CastState(IStateMachine fsm) : base(fsm) {
            
        }

        public override bool CanTransit(IEntity entity, IStateContext context = null) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return false;
            }

            if (context == null) {
                return false;
            }

            var castContext = (CastStateContext) context;
            // 正在施法中
            if (StateContext != null) {
                var curContext = ((CastStateContext) StateContext).Ability;
                // 相同技能id不能重复施法
                if (curContext.Guid == castContext.Ability.Guid) {
                    return false;
                }

                // 当前施法不能被替换
                if (!curContext.ActiveSkillData.BaseData.CanReplace) {
                    return false;
                }
            }
            
            return thingEntity.IsCastable();
        }

        public override void OnEnter(IEntity entity) {
            
        }

        public override void OnExit(IEntity entity) {
            
        }

        public override void OnUpdate(IEntity entity) {
            
        }
    }
}