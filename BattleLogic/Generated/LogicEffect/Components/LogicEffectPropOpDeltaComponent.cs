//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicEffectEntity {

    public Battle.Logic.Effect.Component.PropOpDeltaComponent propOpDelta { get { return (Battle.Logic.Effect.Component.PropOpDeltaComponent)GetComponent(LogicEffectComponentsLookup.PropOpDelta); } }
    public bool hasPropOpDelta { get { return HasComponent(LogicEffectComponentsLookup.PropOpDelta); } }

    public void AddPropOpDelta(Core.Lockstep.Math.FixedPoint newValue) {
        var index = LogicEffectComponentsLookup.PropOpDelta;
        var component = (Battle.Logic.Effect.Component.PropOpDeltaComponent)CreateComponent(index, typeof(Battle.Logic.Effect.Component.PropOpDeltaComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePropOpDelta(Core.Lockstep.Math.FixedPoint newValue) {
        var index = LogicEffectComponentsLookup.PropOpDelta;
        var component = (Battle.Logic.Effect.Component.PropOpDeltaComponent)CreateComponent(index, typeof(Battle.Logic.Effect.Component.PropOpDeltaComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePropOpDelta() {
        RemoveComponent(LogicEffectComponentsLookup.PropOpDelta);
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

    static Entitas.IMatcher<LogicEffectEntity> _matcherPropOpDelta;

    public static Entitas.IMatcher<LogicEffectEntity> PropOpDelta {
        get {
            if (_matcherPropOpDelta == null) {
                var matcher = (Entitas.Matcher<LogicEffectEntity>)Entitas.Matcher<LogicEffectEntity>.AllOf(LogicEffectComponentsLookup.PropOpDelta);
                matcher.componentNames = LogicEffectComponentsLookup.componentNames;
                _matcherPropOpDelta = matcher;
            }

            return _matcherPropOpDelta;
        }
    }
}
