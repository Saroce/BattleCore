//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewThingEntity {

    public Battle.View.Thing.Component.DefaultCastAbilityComponent defaultCastAbility { get { return (Battle.View.Thing.Component.DefaultCastAbilityComponent)GetComponent(ViewThingComponentsLookup.DefaultCastAbility); } }
    public bool hasDefaultCastAbility { get { return HasComponent(ViewThingComponentsLookup.DefaultCastAbility); } }

    public void AddDefaultCastAbility(Battle.Common.Context.Combat.SkillConfData newValue) {
        var index = ViewThingComponentsLookup.DefaultCastAbility;
        var component = (Battle.View.Thing.Component.DefaultCastAbilityComponent)CreateComponent(index, typeof(Battle.View.Thing.Component.DefaultCastAbilityComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDefaultCastAbility(Battle.Common.Context.Combat.SkillConfData newValue) {
        var index = ViewThingComponentsLookup.DefaultCastAbility;
        var component = (Battle.View.Thing.Component.DefaultCastAbilityComponent)CreateComponent(index, typeof(Battle.View.Thing.Component.DefaultCastAbilityComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDefaultCastAbility() {
        RemoveComponent(ViewThingComponentsLookup.DefaultCastAbility);
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
public sealed partial class ViewThingMatcher {

    static Entitas.IMatcher<ViewThingEntity> _matcherDefaultCastAbility;

    public static Entitas.IMatcher<ViewThingEntity> DefaultCastAbility {
        get {
            if (_matcherDefaultCastAbility == null) {
                var matcher = (Entitas.Matcher<ViewThingEntity>)Entitas.Matcher<ViewThingEntity>.AllOf(ViewThingComponentsLookup.DefaultCastAbility);
                matcher.componentNames = ViewThingComponentsLookup.componentNames;
                _matcherDefaultCastAbility = matcher;
            }

            return _matcherDefaultCastAbility;
        }
    }
}
