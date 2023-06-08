//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    public Battle.Logic.Thing.Component.Ability.UltimateAbilityComponent ultimateAbility { get { return (Battle.Logic.Thing.Component.Ability.UltimateAbilityComponent)GetComponent(LogicThingComponentsLookup.UltimateAbility); } }
    public bool hasUltimateAbility { get { return HasComponent(LogicThingComponentsLookup.UltimateAbility); } }

    public void AddUltimateAbility(Battle.Common.Context.Combat.SkillConfData newValue) {
        var index = LogicThingComponentsLookup.UltimateAbility;
        var component = (Battle.Logic.Thing.Component.Ability.UltimateAbilityComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Ability.UltimateAbilityComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUltimateAbility(Battle.Common.Context.Combat.SkillConfData newValue) {
        var index = LogicThingComponentsLookup.UltimateAbility;
        var component = (Battle.Logic.Thing.Component.Ability.UltimateAbilityComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Component.Ability.UltimateAbilityComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUltimateAbility() {
        RemoveComponent(LogicThingComponentsLookup.UltimateAbility);
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

    static Entitas.IMatcher<LogicThingEntity> _matcherUltimateAbility;

    public static Entitas.IMatcher<LogicThingEntity> UltimateAbility {
        get {
            if (_matcherUltimateAbility == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.UltimateAbility);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherUltimateAbility = matcher;
            }

            return _matcherUltimateAbility;
        }
    }
}
