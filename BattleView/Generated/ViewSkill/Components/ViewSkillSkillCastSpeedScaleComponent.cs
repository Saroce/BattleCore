//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewSkillEntity {

    public Battle.View.Skill.Component.SkillCastSpeedScaleComponent skillCastSpeedScale { get { return (Battle.View.Skill.Component.SkillCastSpeedScaleComponent)GetComponent(ViewSkillComponentsLookup.SkillCastSpeedScale); } }
    public bool hasSkillCastSpeedScale { get { return HasComponent(ViewSkillComponentsLookup.SkillCastSpeedScale); } }

    public void AddSkillCastSpeedScale(Core.Lockstep.Math.FixedPoint newValue) {
        var index = ViewSkillComponentsLookup.SkillCastSpeedScale;
        var component = (Battle.View.Skill.Component.SkillCastSpeedScaleComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillCastSpeedScaleComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSkillCastSpeedScale(Core.Lockstep.Math.FixedPoint newValue) {
        var index = ViewSkillComponentsLookup.SkillCastSpeedScale;
        var component = (Battle.View.Skill.Component.SkillCastSpeedScaleComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillCastSpeedScaleComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSkillCastSpeedScale() {
        RemoveComponent(ViewSkillComponentsLookup.SkillCastSpeedScale);
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

    static Entitas.IMatcher<ViewSkillEntity> _matcherSkillCastSpeedScale;

    public static Entitas.IMatcher<ViewSkillEntity> SkillCastSpeedScale {
        get {
            if (_matcherSkillCastSpeedScale == null) {
                var matcher = (Entitas.Matcher<ViewSkillEntity>)Entitas.Matcher<ViewSkillEntity>.AllOf(ViewSkillComponentsLookup.SkillCastSpeedScale);
                matcher.componentNames = ViewSkillComponentsLookup.componentNames;
                _matcherSkillCastSpeedScale = matcher;
            }

            return _matcherSkillCastSpeedScale;
        }
    }
}
