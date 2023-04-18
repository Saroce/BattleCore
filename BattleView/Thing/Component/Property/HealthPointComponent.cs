//------------------------------------------------------------
//        File:  HealthPointComponent.cs
//       Brief:  HealthPointComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-18
//============================================================

using Battle.View.Base.Component;

namespace Battle.View.Thing.Component.Property
{
    [ViewThing]
    public class HealthPointComponent : ViewComponent
    {
        public int Current;
        public int Maximun;
    }
}