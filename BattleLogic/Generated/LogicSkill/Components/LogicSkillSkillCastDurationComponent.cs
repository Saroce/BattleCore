//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicSkillEntity {

    public Battle.Logic.Skill.Component.Cast.SkillCastDurationComponent skillCastDuration { get { return (Battle.Logic.Skill.Component.Cast.SkillCastDurationComponent)GetComponent(LogicSkillComponentsLookup.SkillCastDuration); } }
    public bool hasSkillCastDuration { get { return HasComponent(LogicSkillComponentsLookup.SkillCastDuration); } }

    public void AddSkillCastDuration(vFrame.Lockstep.Core.FixedPoint newValue) {
        var index = LogicSkillComponentsLookup.SkillCastDuration;
        var component = (Battle.Logic.Skill.Component.Cast.SkillCastDurationComponent)CreateComponent(index, typeof(Battle.Logic.Skill.Component.Cast.SkillCastDurationComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSkillCastDuration(vFrame.Lockstep.Core.FixedPoint newValue) {
        var index = LogicSkillComponentsLookup.SkillCastDuration;
        var component = (Battle.Logic.Skill.Component.Cast.SkillCastDurationComponent)CreateComponent(index, typeof(Battle.Logic.Skill.Component.Cast.SkillCastDurationComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSkillCastDuration() {
        RemoveComponent(LogicSkillComponentsLookup.SkillCastDuration);
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
public sealed partial class LogicSkillMatcher {

    static Entitas.IMatcher<LogicSkillEntity> _matcherSkillCastDuration;

    public static Entitas.IMatcher<LogicSkillEntity> SkillCastDuration {
        get {
            if (_matcherSkillCastDuration == null) {
                var matcher = (Entitas.Matcher<LogicSkillEntity>)Entitas.Matcher<LogicSkillEntity>.AllOf(LogicSkillComponentsLookup.SkillCastDuration);
                matcher.componentNames = LogicSkillComponentsLookup.componentNames;
                _matcherSkillCastDuration = matcher;
            }

            return _matcherSkillCastDuration;
        }
    }
}
