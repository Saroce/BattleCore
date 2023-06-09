//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicEffectEntity {

    public Battle.Logic.Effect.Component.EffectUserDataComponent effectUserData { get { return (Battle.Logic.Effect.Component.EffectUserDataComponent)GetComponent(LogicEffectComponentsLookup.EffectUserData); } }
    public bool hasEffectUserData { get { return HasComponent(LogicEffectComponentsLookup.EffectUserData); } }

    public void AddEffectUserData(Battle.Common.Context.Combat.EffectUserData newValue) {
        var index = LogicEffectComponentsLookup.EffectUserData;
        var component = (Battle.Logic.Effect.Component.EffectUserDataComponent)CreateComponent(index, typeof(Battle.Logic.Effect.Component.EffectUserDataComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEffectUserData(Battle.Common.Context.Combat.EffectUserData newValue) {
        var index = LogicEffectComponentsLookup.EffectUserData;
        var component = (Battle.Logic.Effect.Component.EffectUserDataComponent)CreateComponent(index, typeof(Battle.Logic.Effect.Component.EffectUserDataComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEffectUserData() {
        RemoveComponent(LogicEffectComponentsLookup.EffectUserData);
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

    static Entitas.IMatcher<LogicEffectEntity> _matcherEffectUserData;

    public static Entitas.IMatcher<LogicEffectEntity> EffectUserData {
        get {
            if (_matcherEffectUserData == null) {
                var matcher = (Entitas.Matcher<LogicEffectEntity>)Entitas.Matcher<LogicEffectEntity>.AllOf(LogicEffectComponentsLookup.EffectUserData);
                matcher.componentNames = LogicEffectComponentsLookup.componentNames;
                _matcherEffectUserData = matcher;
            }

            return _matcherEffectUserData;
        }
    }
}
