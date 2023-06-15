//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewSkillEntity {

    public Battle.View.Skill.Component.SkillCastContextComponent skillCastContext { get { return (Battle.View.Skill.Component.SkillCastContextComponent)GetComponent(ViewSkillComponentsLookup.SkillCastContext); } }
    public bool hasSkillCastContext { get { return HasComponent(ViewSkillComponentsLookup.SkillCastContext); } }

    public void AddSkillCastContext(ulong newOwnerId, ulong newTargetId, Battle.Common.Context.Combat.SkillConfData newAbility) {
        var index = ViewSkillComponentsLookup.SkillCastContext;
        var component = (Battle.View.Skill.Component.SkillCastContextComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillCastContextComponent));
        component.OwnerId = newOwnerId;
        component.TargetId = newTargetId;
        component.Ability = newAbility;
        AddComponent(index, component);
    }

    public void ReplaceSkillCastContext(ulong newOwnerId, ulong newTargetId, Battle.Common.Context.Combat.SkillConfData newAbility) {
        var index = ViewSkillComponentsLookup.SkillCastContext;
        var component = (Battle.View.Skill.Component.SkillCastContextComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillCastContextComponent));
        component.OwnerId = newOwnerId;
        component.TargetId = newTargetId;
        component.Ability = newAbility;
        ReplaceComponent(index, component);
    }

    public void RemoveSkillCastContext() {
        RemoveComponent(ViewSkillComponentsLookup.SkillCastContext);
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
public sealed partial class ViewSkillMatcher {

    static Entitas.IMatcher<ViewSkillEntity> _matcherSkillCastContext;

    public static Entitas.IMatcher<ViewSkillEntity> SkillCastContext {
        get {
            if (_matcherSkillCastContext == null) {
                var matcher = (Entitas.Matcher<ViewSkillEntity>)Entitas.Matcher<ViewSkillEntity>.AllOf(ViewSkillComponentsLookup.SkillCastContext);
                matcher.componentNames = ViewSkillComponentsLookup.componentNames;
                _matcherSkillCastContext = matcher;
            }

            return _matcherSkillCastContext;
        }
    }
}
