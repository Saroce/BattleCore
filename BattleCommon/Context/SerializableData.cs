//------------------------------------------------------------
//        File:  SerializableData.cs
//       Brief:  SerializableData
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

namespace Battle.Common.Context
{
    internal abstract class SerializableData<T> : ISerializableData<T>
    {
        public T ExportData() {
            return default;
        }
    }
}