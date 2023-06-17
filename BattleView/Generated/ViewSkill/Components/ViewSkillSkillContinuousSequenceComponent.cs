//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewSkillEntity {

    public Battle.View.Skill.Component.SkillContinuousSequenceComponent skillContinuousSequence { get { return (Battle.View.Skill.Component.SkillContinuousSequenceComponent)GetComponent(ViewSkillComponentsLookup.SkillContinuousSequence); } }
    public bool hasSkillContinuousSequence { get { return HasComponent(ViewSkillComponentsLookup.SkillContinuousSequence); } }

    public void AddSkillContinuousSequence(string newPath, float newDuration, bool newLoop) {
        var index = ViewSkillComponentsLookup.SkillContinuousSequence;
        var component = (Battle.View.Skill.Component.SkillContinuousSequenceComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillContinuousSequenceComponent));
        component.Path = newPath;
        component.Duration = newDuration;
        component.Loop = newLoop;
        AddComponent(index, component);
    }

    public void ReplaceSkillContinuousSequence(string newPath, float newDuration, bool newLoop) {
        var index = ViewSkillComponentsLookup.SkillContinuousSequence;
        var component = (Battle.View.Skill.Component.SkillContinuousSequenceComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillContinuousSequenceComponent));
        component.Path = newPath;
        component.Duration = newDuration;
        component.Loop = newLoop;
        ReplaceComponent(index, component);
    }

    public void RemoveSkillContinuousSequence() {
        RemoveComponent(ViewSkillComponentsLookup.SkillContinuousSequence);
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

    static Entitas.IMatcher<ViewSkillEntity> _matcherSkillContinuousSequence;

    public static Entitas.IMatcher<ViewSkillEntity> SkillContinuousSequence {
        get {
            if (_matcherSkillContinuousSequence == null) {
                var matcher = (Entitas.Matcher<ViewSkillEntity>)Entitas.Matcher<ViewSkillEntity>.AllOf(ViewSkillComponentsLookup.SkillContinuousSequence);
                matcher.componentNames = ViewSkillComponentsLookup.componentNames;
                _matcherSkillContinuousSequence = matcher;
            }

            return _matcherSkillContinuousSequence;
        }
    }
}