//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicEffectEntity {

    public Battle.Logic.Effect.Component.FormulaIdComponent formulaId { get { return (Battle.Logic.Effect.Component.FormulaIdComponent)GetComponent(LogicEffectComponentsLookup.FormulaId); } }
    public bool hasFormulaId { get { return HasComponent(LogicEffectComponentsLookup.FormulaId); } }

    public void AddFormulaId(string newValue) {
        var index = LogicEffectComponentsLookup.FormulaId;
        var component = (Battle.Logic.Effect.Component.FormulaIdComponent)CreateComponent(index, typeof(Battle.Logic.Effect.Component.FormulaIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFormulaId(string newValue) {
        var index = LogicEffectComponentsLookup.FormulaId;
        var component = (Battle.Logic.Effect.Component.FormulaIdComponent)CreateComponent(index, typeof(Battle.Logic.Effect.Component.FormulaIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFormulaId() {
        RemoveComponent(LogicEffectComponentsLookup.FormulaId);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class LogicEffectMatcher {

    static Entitas.IMatcher<LogicEffectEntity> _matcherFormulaId;

    public static Entitas.IMatcher<LogicEffectEntity> FormulaId {
        get {
            if (_matcherFormulaId == null) {
                var matcher = (Entitas.Matcher<LogicEffectEntity>)Entitas.Matcher<LogicEffectEntity>.AllOf(LogicEffectComponentsLookup.FormulaId);
                matcher.componentNames = LogicEffectComponentsLookup.componentNames;
                _matcherFormulaId = matcher;
            }

            return _matcherFormulaId;
        }
    }
}
