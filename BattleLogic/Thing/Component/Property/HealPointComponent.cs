//------------------------------------------------------------
//        File:  HealPointComponent.cs
//       Brief:  HealPointComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.Component;
using Battle.Logic.Base.CSExtension;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Thing.Component.Property
{
    [LogicThing]
    public class HealPointComponent : LogicComponent
    {
        private FixedPoint _current;
        private FixedPoint _maximum;

        public FixedPoint Current {
            get => GetValue(ref _current);
            set => SetValue(ref _current, value);
        }
        
        public FixedPoint Maximum {
            get => GetValue(ref _maximum);
            set => SetValue(ref _maximum, value);
        }
    }
}
