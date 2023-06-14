//------------------------------------------------------------
//        File:  LessHealthPointComparer.cs
//       Brief:  HP比较，血量少的优先
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-14
//============================================================

using System.Collections.Generic;
using Core.Lite.Base;

namespace Battle.Logic.Skill.Comparer
{
    internal class LessHealthPointComparer : BaseObject<LogicThingContext>, IComparer<ulong>
    {
        private LogicThingContext _context;
        
        protected override void OnDestroy() {
            _context = null;
        }

        protected override void OnCreate(LogicThingContext arg1) {
            _context = arg1;
        }

        public int Compare(ulong x, ulong y) {
            var entityA = _context.GetEntityWithId(x);
            var entityB = _context.GetEntityWithId(y);

            if (entityA == null) {
                if (entityB == null) {
                    return 0;
                }

                return -1;
            }
            if (entityB == null) {
                return 1;
            }
            
            if (!entityA.hasHealPoint) {
                if (!entityB.hasHealPoint) {
                    return 0;
                }

                return -1;
            }
            if (!entityB.hasHealPoint) {
                return 1;
            }

            var hpX = entityA.healPoint.Current;
            var hpY = entityB.healPoint.Current;
            return hpX.CompareTo(hpY);
        }
    }
}
