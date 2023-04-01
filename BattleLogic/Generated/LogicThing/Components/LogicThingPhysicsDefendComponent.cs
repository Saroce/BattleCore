//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    public Battle.Logic.Thing.Component.Property.PhysicsDefendComponent physicsDefend { get { return (Battle.Logic.Thing.Component.Property.PhysicsDefendComponent)GetComponent(LogicThingComponentsLookup.PhysicsDefend); } }
    public bool hasPhysicsDefend { get { return HasComponent(LogicThingComponentsLookup.PhysicsDefend); } }

    public void AddPhysicsDefend(vFrame.Lockstep.Core.FixedPoint newValue) {
        var index = LogicThingComponentsLookup.PhysicsDefend;
        var component = (Battle.Logic.Thing.Component.Property.PhysicsDefendComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Property.PhysicsDefendComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePhysicsDefend(vFrame.Lockstep.Core.FixedPoint newValue) {
        var index = LogicThingComponentsLookup.PhysicsDefend;
        var component = (Battle.Logic.Thing.Component.Property.PhysicsDefendComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Property.PhysicsDefendComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePhysicsDefend() {
        RemoveComponent(LogicThingComponentsLookup.PhysicsDefend);
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

    static Entitas.IMatcher<LogicThingEntity> _matcherPhysicsDefend;

    public static Entitas.IMatcher<LogicThingEntity> PhysicsDefend {
        get {
            if (_matcherPhysicsDefend == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.PhysicsDefend);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherPhysicsDefend = matcher;
            }

            return _matcherPhysicsDefend;
        }
    }
}