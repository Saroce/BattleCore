//------------------------------------------------------------
//        File:  LoadFormulaDataSystem.cs
//       Brief:  LoadFormulaDataSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-27
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Battle.Logic.Base.System;
using Battle.Logic.Constant;
using SkillModule.Runtime.Formula;

namespace Battle.Logic.Effect.System
{
    internal class LoadFormulaDataSystem : LogicInitializeSystem
    {
        public LoadFormulaDataSystem(LogicContexts contexts) : base(contexts) {
        }

        /// <summary>
        /// 读取公式配置文件，创建对应公式相关实体
        /// </summary>
        public override void Initialize() {
            var dataReader = Contexts.GetDataReader();
            var formulaDataList = dataReader.ReadData<FormulaDataList>(EffectDef.FormulaDataFilePath);
            if (formulaDataList == null) {
                LogError(LogTagDef.EffectLogTag, $"Load formula data failed, path: {EffectDef.FormulaDataFilePath}");
                return;
            }

            foreach (var formulaData in formulaDataList) {
                CreateFormulaEntity(formulaData);
            }
        }

        private void CreateFormulaEntity(FormulaData formulaData) {
            var formulaEntity = Contexts.logicEffect.CreateEntity();
            formulaEntity.AddId(Contexts.GetIndependentId());
            formulaEntity.AddFormulaId(formulaData.Guid);
            formulaEntity.AddFormulaData(formulaData);
        }
        
        public override void TearDown() {
            
        }
    }
}