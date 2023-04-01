//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    static readonly Battle.Logic.Thing.Component.Type.ThingComponent thingComponent = new Battle.Logic.Thing.Component.Type.ThingComponent();

    public bool isThing {
        get { return HasComponent(LogicThingComponentsLookup.Thing); }
        set {
            if (value != isThing) {
                var index = LogicThingComponentsLookup.Thing;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : thingComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<LogicThingEntity> _matcherThing;

    public static Entitas.IMatcher<LogicThingEntity> Thing {
        get {
            if (_matcherThing == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.Thing);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherThing = matcher;
            }

            return _matcherThing;
        }
    }
}