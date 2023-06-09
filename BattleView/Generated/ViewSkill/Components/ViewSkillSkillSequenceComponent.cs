//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewSkillEntity {

    public Battle.View.Skill.Component.SkillSequenceComponent skillSequence { get { return (Battle.View.Skill.Component.SkillSequenceComponent)GetComponent(ViewSkillComponentsLookup.SkillSequence); } }
    public bool hasSkillSequence { get { return HasComponent(ViewSkillComponentsLookup.SkillSequence); } }

    public void AddSkillSequence(string newPath) {
        var index = ViewSkillComponentsLookup.SkillSequence;
        var component = (Battle.View.Skill.Component.SkillSequenceComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillSequenceComponent));
        component.Path = newPath;
        AddComponent(index, component);
    }

    public void ReplaceSkillSequence(string newPath) {
        var index = ViewSkillComponentsLookup.SkillSequence;
        var component = (Battle.View.Skill.Component.SkillSequenceComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillSequenceComponent));
        component.Path = newPath;
        ReplaceComponent(index, component);
    }

    public void RemoveSkillSequence() {
        RemoveComponent(ViewSkillComponentsLookup.SkillSequence);
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

    static Entitas.IMatcher<ViewSkillEntity> _matcherSkillSequence;

    public static Entitas.IMatcher<ViewSkillEntity> SkillSequence {
        get {
            if (_matcherSkillSequence == null) {
                var matcher = (Entitas.Matcher<ViewSkillEntity>)Entitas.Matcher<ViewSkillEntity>.AllOf(ViewSkillComponentsLookup.SkillSequence);
                matcher.componentNames = ViewSkillComponentsLookup.componentNames;
                _matcherSkillSequence = matcher;
            }

            return _matcherSkillSequence;
        }
    }
}
