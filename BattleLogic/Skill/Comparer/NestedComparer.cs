using System;
using System.Collections.Generic;
using Core.Lite.Base;

namespace Battle.Logic.Skill.Comparer
{
    internal class NestedComparer : BaseObject<LogicContexts>, IComparer<ulong>
    {
        private List<IComparer<ulong>> _comparers;
        private LogicContexts _contexts;
        
        protected override void OnCreate(LogicContexts contexts) {
            _contexts = contexts;
            _comparers = contexts.ListPool<IComparer<ulong>>().Get();
        }

        public void AddComparer(IComparer<ulong> comparer) {
            _comparers.Add(comparer);
        }
        
        public int Compare(ulong x, ulong y) {
            var ret = 0;
            foreach (var comparer in _comparers) {
                ret = comparer.Compare(x, y);
                if (ret == 0) {
                    continue;
                }
                break;
            }
            return ret;
        }
        
        protected override void OnDestroy() {
            foreach (var comparer in _comparers) {
                if (!(comparer is IDestroy baseObject)) {
                    continue;
                }
                baseObject.Destroy();

                switch (baseObject) {
                    case LessHealthPointComparer lessHealthPointComparer:
                        _contexts.RefPool<LessHealthPointComparer>().Return(lessHealthPointComparer);
                        break;
                    case DistanceComparer distanceComparer:
                        _contexts.RefPool<DistanceComparer>().Return(distanceComparer);
                        break;
                    default:
                        throw new IndexOutOfRangeException($"Unhandled comparer type: {baseObject.GetType().FullName}");
                }
                
                _contexts.ListPool<IComparer<ulong>>().Return(_comparers);
                _comparers = null;
            }
        }
    }
}