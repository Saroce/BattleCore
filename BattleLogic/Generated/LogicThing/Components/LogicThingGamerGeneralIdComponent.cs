//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    public Battle.Logic.Thing.Component.Gamer.GamerGeneralIdComponent gamerGeneralId { get { return (Battle.Logic.Thing.Component.Gamer.GamerGeneralIdComponent)GetComponent(LogicThingComponentsLookup.GamerGeneralId); } }
    public bool hasGamerGeneralId { get { return HasComponent(LogicThingComponentsLookup.GamerGeneralId); } }

    public void AddGamerGeneralId(int newValue) {
        var index = LogicThingComponentsLookup.GamerGeneralId;
        var component = (Battle.Logic.Thing.Component.Gamer.GamerGeneralIdComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Gamer.GamerGeneralIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGamerGeneralId(int newValue) {
        var index = LogicThingComponentsLookup.GamerGeneralId;
        var component = (Battle.Logic.Thing.Component.Gamer.GamerGeneralIdComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Gamer.GamerGeneralIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGamerGeneralId() {
        RemoveComponent(LogicThingComponentsLookup.GamerGeneralId);
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

    static Entitas.IMatcher<LogicThingEntity> _matcherGamerGeneralId;

    public static Entitas.IMatcher<LogicThingEntity> GamerGeneralId {
        get {
            if (_matcherGamerGeneralId == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.GamerGeneralId);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherGamerGeneralId = matcher;
            }

            return _matcherGamerGeneralId;
        }
    }
}