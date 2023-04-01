//------------------------------------------------------------
//        File:  OnCreateThing.cs
//       Brief:  OnCreateThing
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Context.Message.Thing;
using Battle.View.Thing.Factory;


namespace Battle.View.Input.System.Processor
{
    internal class OnCreateThing : MessageProcessor<ThingCreateMessage>
    {
        protected override void OnProcess(ThingCreateMessage message) {
            Contexts.CreateThing(message);
        }
    }
}
