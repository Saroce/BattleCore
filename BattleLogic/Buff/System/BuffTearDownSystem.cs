//------------------------------------------------------------
//        File:  BuffTearDownSystem.cs
//       Brief:  BuffTearDownSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using Battle.Logic.Base.CSExtension;

namespace Battle.Logic.Buff.System
{
    internal class BuffTearDownSystem : LogicTearDownSystem
    {
        public BuffTearDownSystem(LogicContexts contexts) : base(contexts) {
        }

        public override void TearDown() {
            foreach (var buffEntity in Contexts.logicBuff.GetEntities()) {
                buffEntity.Destroy();
            }
        }
    }
}