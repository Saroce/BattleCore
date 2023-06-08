//------------------------------------------------------------
//        File:  InitializeGamerGroupSystem.cs
//       Brief:  InitializeGamerGroupSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using System.Collections.Generic;
using Battle.Common.Context.Combat;
using Battle.Common.Context.Create;
using Battle.Logic.Base;
using Battle.Logic.Base.System;
using Battle.Logic.Constant;
using Battle.Logic.Thing.Extension;
using Battle.Logic.Thing.Factory;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Thing.System.Gamer
{
    internal class InitializeGamerGroupSystem : LogicInitializeSystem
    {
        public InitializeGamerGroupSystem(LogicContexts contexts) : base(contexts) {
        }

        public override void Initialize() {
            var gamerIds = new List<ulong>();
            InitializeGamersData(gamerIds);
            InitializeGamersLogic(gamerIds);
        }

        public override void TearDown() {
            
        }

        /// <summary>
        /// 初始化玩家组数据
        /// </summary>
        private void InitializeGamersData(List<ulong> gamerIds) {
            var gamerGroup = Contexts.GetBattleContext().GamerGroup;
            foreach (var gamer in gamerGroup.Gamers) {
                gamerIds.Add(Contexts.CreateGamerData(gamer));
            }

            var gamerGroupEntity = Contexts.logicThing.CreateEntity();
            gamerGroupEntity.AddGamerIdGroup(gamerIds);
            gamerGroupEntity.isGamerGroup = true;
            gamerGroupEntity.isThing = true;
        }

        /// <summary>
        /// 初始化所有玩家逻辑实体
        /// </summary>
        /// <param name="gamerIds"></param>
        private void InitializeGamersLogic(List<ulong> gamerIds) {
            foreach (var gamerId in gamerIds) {
                var gamerDataEntity = Contexts.logicThing.GetEntityWithId(gamerId);
                if (gamerDataEntity == null) {
                    LogWarning(LogTagDef.ThingLogTag, $"Get gamer data entity failed gamerId: {gamerId}");
                    continue;
                }

                var gamerInfo = gamerDataEntity.gamerInfo.Value;
                var createContext = new GamerCreateContext() {
                    GeneralId = gamerInfo.GeneralId,
                    Position = gamerInfo.Position,
                    Rotation = gamerInfo.Rotation,
                    CombatValue = gamerDataEntity.hasGamerCombat
                        ? gamerDataEntity.gamerCombat.Value
                        : new CombatValue(),
                    DefSkill = gamerDataEntity.GetGamerDefSkill(),
                    UltSkill = gamerDataEntity.GetGamerUltSkill(),
                    AllSkills = gamerDataEntity.GetGamerAllSkills()
                };

                // 创建逻辑实体
                Contexts.CreateThing(createContext);
            }
        }
    }
}