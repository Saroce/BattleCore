//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    public Battle.Logic.Thing.Component.Property.Base.PositionComponent position { get { return (Battle.Logic.Thing.Component.Property.Base.PositionComponent)GetComponent(LogicThingComponentsLookup.Position); } }
    public bool hasPosition { get { return HasComponent(LogicThingComponentsLookup.Position); } }

    public void AddPosition(vFrame.Lockstep.Core.TSVector newValue) {
        var index = LogicThingComponentsLookup.Position;
        var component = (Battle.Logic.Thing.Component.Property.Base.PositionComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Property.Base.PositionComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePosition(vFrame.Lockstep.Core.TSVector newValue) {
        var index = LogicThingComponentsLookup.Position;
        var component = (Battle.Logic.Thing.Component.Property.Base.PositionComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Property.Base.PositionComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePosition() {
        RemoveComponent(LogicThingComponentsLookup.Position);
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

    static Entitas.IMatcher<LogicThingEntity> _matcherPosition;

    public static Entitas.IMatcher<LogicThingEntity> Position {
        get {
            if (_matcherPosition == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.Position);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherPosition = matcher;
            }

            return _matcherPosition;
        }
    }
}
