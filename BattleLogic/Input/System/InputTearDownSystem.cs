//------------------------------------------------------------
//        File:  InputTearDownSystem.cs
//       Brief:  InputTearDownSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using Battle.Logic.Base.CSExtension;

namespace Battle.Logic.Input.System
{
    internal class InputTearDownSystem : LogicTearDownSystem
    {
        public InputTearDownSystem(LogicContexts contexts) : base(contexts) {
        }

        public override void TearDown() {
            foreach (var inputEntity in Contexts.logicInput.GetEntities()) {
                inputEntity.Destroy();
            }
        }
    }
}
