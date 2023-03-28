//------------------------------------------------------------
//        File:  StateMachineException.cs
//       Brief:  StateMachineException
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

namespace Battle.Common.Exception
{
    public class StateAlreadyExistException : System.Exception
    {
        public StateAlreadyExistException(int stateId) : base($"State {stateId} already exist.") {
            
        }
    }

    public class StateNotExistException : System.Exception
    {
        public StateNotExistException(int stateId) : base($"State {stateId} not exist.") {
            
        }
    }
}