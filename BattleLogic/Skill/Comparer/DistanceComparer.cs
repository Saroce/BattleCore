//------------------------------------------------------------
//        File:  DistanceComparer.cs
//       Brief:  距离比较，优先距离近
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-14
//============================================================

using System.Collections.Generic;
using Battle.Logic.Thing.Extension;
using Core.Lite.Base;

namespace Battle.Logic.Skill.Comparer
{
    internal class DistanceComparer : BaseObject<LogicThingContext, LogicThingEntity>, IComparer<ulong>
    {
        private LogicThingContext _context;
        private LogicThingEntity _target;
        
        protected override void OnDestroy() {
            _context = null;
            _target = null;
        }

        protected override void OnCreate(LogicThingContext arg1, LogicThingEntity arg2) {
            _context = arg1;
            _target = arg2;
        }

        public int Compare(ulong x, ulong y) {
            var entityA = _context.GetEntityWithId(x);
            var entityB = _context.GetEntityWithId(y);
            
            if (null == entityA) {
                if (null == entityB) {
                    return 0;
                }
                return -1;
            }
            if (null == entityB) {
                return 1;
            }
            
            if (!entityA.hasPosition) {
                if (!entityB.hasPosition) {
                    return 0;
                }
                return -1;
            }
            if (!entityB.hasPosition) {
                return 1;
            }

            var disA = _target.GetDistance(entityA);
            var disB = _target.GetDistance(entityB);
            return disA.CompareTo(disB);
        }
    }
}
