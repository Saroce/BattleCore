//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    public Battle.Logic.Thing.Component.Gamer.GamerIdGroupComponent gamerIdGroup { get { return (Battle.Logic.Thing.Component.Gamer.GamerIdGroupComponent)GetComponent(LogicThingComponentsLookup.GamerIdGroup); } }
    public bool hasGamerIdGroup { get { return HasComponent(LogicThingComponentsLookup.GamerIdGroup); } }

    public void AddGamerIdGroup(System.Collections.Generic.List<ulong> newValue) {
        var index = LogicThingComponentsLookup.GamerIdGroup;
        var component = (Battle.Logic.Thing.Component.Gamer.GamerIdGroupComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Gamer.GamerIdGroupComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGamerIdGroup(System.Collections.Generic.List<ulong> newValue) {
        var index = LogicThingComponentsLookup.GamerIdGroup;
        var component = (Battle.Logic.Thing.Component.Gamer.GamerIdGroupComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Gamer.GamerIdGroupComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGamerIdGroup() {
        RemoveComponent(LogicThingComponentsLookup.GamerIdGroup);
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

    static Entitas.IMatcher<LogicThingEntity> _matcherGamerIdGroup;

    public static Entitas.IMatcher<LogicThingEntity> GamerIdGroup {
        get {
            if (_matcherGamerIdGroup == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.GamerIdGroup);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherGamerIdGroup = matcher;
            }

            return _matcherGamerIdGroup;
        }
    }
}
