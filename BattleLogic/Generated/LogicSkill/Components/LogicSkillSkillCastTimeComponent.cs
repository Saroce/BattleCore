//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicSkillEntity {

    public Battle.Logic.Skill.Component.Cast.SkillCastTimeComponent skillCastTime { get { return (Battle.Logic.Skill.Component.Cast.SkillCastTimeComponent)GetComponent(LogicSkillComponentsLookup.SkillCastTime); } }
    public bool hasSkillCastTime { get { return HasComponent(LogicSkillComponentsLookup.SkillCastTime); } }

    public void AddSkillCastTime(vFrame.Lockstep.Core.FixedPoint newValue) {
        var index = LogicSkillComponentsLookup.SkillCastTime;
        var component = (Battle.Logic.Skill.Component.Cast.SkillCastTimeComponent)CreateComponent(index, typeof(Battle.Logic.Skill.Component.Cast.SkillCastTimeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSkillCastTime(vFrame.Lockstep.Core.FixedPoint newValue) {
        var index = LogicSkillComponentsLookup.SkillCastTime;
        var component = (Battle.Logic.Skill.Component.Cast.SkillCastTimeComponent)CreateComponent(index, typeof(Battle.Logic.Skill.Component.Cast.SkillCastTimeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSkillCastTime() {
        RemoveComponent(LogicSkillComponentsLookup.SkillCastTime);
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

    static Entitas.IMatcher<LogicSkillEntity> _matcherSkillCastTime;

    public static Entitas.IMatcher<LogicSkillEntity> SkillCastTime {
        get {
            if (_matcherSkillCastTime == null) {
                var matcher = (Entitas.Matcher<LogicSkillEntity>)Entitas.Matcher<LogicSkillEntity>.AllOf(LogicSkillComponentsLookup.SkillCastTime);
                matcher.componentNames = LogicSkillComponentsLookup.componentNames;
                _matcherSkillCastTime = matcher;
            }

            return _matcherSkillCastTime;
        }
    }
}
