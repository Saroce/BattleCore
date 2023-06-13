//------------------------------------------------------------
//        File:  OnRotationUpdate.cs
//       Brief:  OnRotationUpdate
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using Battle.Common.Context.Message.Thing;

namespace Battle.View.Input.System.Processor
{
    internal class OnRotationUpdate : MessageProcessor<ThingRotationMessage>
    {
        protected override void OnProcess(ThingRotationMessage message) {
            var entity = Contexts.viewThing.GetEntityWithId(message.Id);
            entity?.ReplaceRotation(message.Rotation);
        }
    }
}