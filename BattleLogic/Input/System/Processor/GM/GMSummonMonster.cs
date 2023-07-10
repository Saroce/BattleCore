//------------------------------------------------------------
//        File:  GMSummonMonster.cs
//       Brief:  GMSummonMonster
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-10
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Command.Request;
using Battle.Common.Context.Command.Respond;
using Battle.Common.Context.Create;
using Battle.Logic.Thing.Factory;

namespace Battle.Logic.Input.System.Processor.GM
{
    internal class GMSummonMonster : CommandProcessor<GMSummonMonsterRequest, DefaultRespond>
    {
        protected override void OnProcess(GMSummonMonsterRequest request, DefaultRespond respond) {
            var createContext = new MonsterCreateContext() {
                MonsterId = request.MonsterId,
                Position = request.Position,
                Rotation = request.Rotation,
                ThingFlag = ThingFlag.Dynamic,
                CampFlag = CampFlag.Camp_2
            };

            Contexts.CreateThing(createContext);
        }
    }
}