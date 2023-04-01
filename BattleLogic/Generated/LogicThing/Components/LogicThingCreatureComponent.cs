//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    static readonly Battle.Logic.Thing.Component.Type.CreatureComponent creatureComponent = new Battle.Logic.Thing.Component.Type.CreatureComponent();

    public bool isCreature {
        get { return HasComponent(LogicThingComponentsLookup.Creature); }
        set {
            if (value != isCreature) {
                var index = LogicThingComponentsLookup.Creature;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : creatureComponent;

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

    static Entitas.IMatcher<LogicThingEntity> _matcherCreature;

    public static Entitas.IMatcher<LogicThingEntity> Creature {
        get {
            if (_matcherCreature == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.Creature);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherCreature = matcher;
            }

            return _matcherCreature;
        }
    }
}