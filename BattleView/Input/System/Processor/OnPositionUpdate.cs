//------------------------------------------------------------
//        File:  OnPositionUpdate.cs
//       Brief:  OnPositionUpdate
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using Battle.Common.Context.Message.Thing;

namespace Battle.View.Input.System.Processor
{
    internal class OnPositionUpdate : MessageProcessor<ThingPositionMessage>
    {
        protected override void OnProcess(ThingPositionMessage message) {
            var entity = Contexts.viewThing.GetEntityWithId(message.Id);
            entity?.ReplacePosition(message.Position);
        }
    }
}