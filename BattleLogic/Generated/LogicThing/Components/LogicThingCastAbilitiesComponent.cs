//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    public Battle.Logic.Thing.Component.Ability.CastAbilitiesComponent castAbilities { get { return (Battle.Logic.Thing.Component.Ability.CastAbilitiesComponent)GetComponent(LogicThingComponentsLookup.CastAbilities); } }
    public bool hasCastAbilities { get { return HasComponent(LogicThingComponentsLookup.CastAbilities); } }

    public void AddCastAbilities(System.Collections.Generic.List<Battle.Common.Context.Combat.SkillConfData> newValue) {
        var index = LogicThingComponentsLookup.CastAbilities;
        var component = (Battle.Logic.Thing.Component.Ability.CastAbilitiesComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Ability.CastAbilitiesComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCastAbilities(System.Collections.Generic.List<Battle.Common.Context.Combat.SkillConfData> newValue) {
        var index = LogicThingComponentsLookup.CastAbilities;
        var component = (Battle.Logic.Thing.Component.Ability.CastAbilitiesComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Ability.CastAbilitiesComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCastAbilities() {
        RemoveComponent(LogicThingComponentsLookup.CastAbilities);
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

    static Entitas.IMatcher<LogicThingEntity> _matcherCastAbilities;

    public static Entitas.IMatcher<LogicThingEntity> CastAbilities {
        get {
            if (_matcherCastAbilities == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.CastAbilities);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherCastAbilities = matcher;
            }

            return _matcherCastAbilities;
        }
    }
}