//------------------------------------------------------------
//        File:  BattleRespond.cs
//       Brief:  BattleRespond
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using System.Collections;

namespace Battle.Common.Context.Command
{
    public abstract class BattleRespond : IBattleRespond
    {
        private class YieldInstruction : IEnumerator
        {
            public bool KeepWaiting { get; set; } = true;

            public bool MoveNext() => KeepWaiting;

            public void Reset() {
                KeepWaiting = false;
            }

            public object Current { get; } = null;
        }

        private readonly YieldInstruction _iter;

        public BattleRespond() {
            _iter = new YieldInstruction();
        }

        public void Send() {
            _iter.KeepWaiting = false;
        }
        
        public IEnumerator Receive() => _iter;

        public bool Result { get; set; }
        
        public string ErrorMessage { get; set; }
    }
}