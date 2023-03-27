//------------------------------------------------------------
//        File:  ISerializableData.cs
//       Brief:  ISerializableData
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

namespace Battle.Common.Context
{
    internal interface ISerializableData<T>
    {
        T ExportData();
    }
}