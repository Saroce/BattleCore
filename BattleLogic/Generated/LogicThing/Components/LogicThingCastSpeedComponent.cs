//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    public Battle.Logic.Thing.Component.Property.CastSpeedComponent castSpeed { get { return (Battle.Logic.Thing.Component.Property.CastSpeedComponent)GetComponent(LogicThingComponentsLookup.CastSpeed); } }
    public bool hasCastSpeed { get { return HasComponent(LogicThingComponentsLookup.CastSpeed); } }

    public void AddCastSpeed(Core.Lockstep.Math.FixedPoint newValue) {
        var index = LogicThingComponentsLookup.CastSpeed;
        var component = (Battle.Logic.Thing.Component.Property.CastSpeedComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Property.CastSpeedComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCastSpeed(Core.Lockstep.Math.FixedPoint newValue) {
        var index = LogicThingComponentsLookup.CastSpeed;
        var component = (Battle.Logic.Thing.Component.Property.CastSpeedComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Property.CastSpeedComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCastSpeed() {
        RemoveComponent(LogicThingComponentsLookup.CastSpeed);
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
public sealed partial class LogicThingMatcher {

    static Entitas.IMatcher<LogicThingEntity> _matcherCastSpeed;

    public static Entitas.IMatcher<LogicThingEntity> CastSpeed {
        get {
            if (_matcherCastSpeed == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.CastSpeed);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherCastSpeed = matcher;
            }

            return _matcherCastSpeed;
        }
    }
}
