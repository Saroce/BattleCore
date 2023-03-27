//------------------------------------------------------------
//        File:  InitializeCardGroupSystem.cs
//       Brief:  InitializeCardGroupSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using System.Collections.Generic;
using Battle.Logic.Base.CSExtension;

namespace Battle.Logic.Thing.System.Player
{
    internal class InitializeCardGroupSystem : LogicInitializeSystem
    {
        public InitializeCardGroupSystem(LogicContexts contexts) : base(contexts) {
        }

        public override void Initialize() {
            InitializePlayerGroup();
        }

        public override void TearDown() {
            
        }

        private void InitializePlayerGroup() {
            var players = new List<ulong>();
            var playerGroup = Contexts.GetBattleContext().PlayerGroup;
            foreach (var playerData in playerGroup.PlayerDataList) {
                
            }
        }
    }
}