//------------------------------------------------------------
//        File:  DestroyedComponent.cs
//       Brief:  DestroyedComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-23
//============================================================

using Entitas.CodeGeneration.Attributes;

namespace Battle.Logic.Base.CSExtension
{
    [Cleanup(CleanupMode.DestroyEntity)]
    public class DestroyedComponent : LogicComponent
    {
        
    }
}
