//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewSkillEntity {

    public Battle.View.Skill.Component.SkillViewComponent skillView { get { return (Battle.View.Skill.Component.SkillViewComponent)GetComponent(ViewSkillComponentsLookup.SkillView); } }
    public bool hasSkillView { get { return HasComponent(ViewSkillComponentsLookup.SkillView); } }

    public void AddSkillView(UnityEngine.GameObject newValue) {
        var index = ViewSkillComponentsLookup.SkillView;
        var component = (Battle.View.Skill.Component.SkillViewComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillViewComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSkillView(UnityEngine.GameObject newValue) {
        var index = ViewSkillComponentsLookup.SkillView;
        var component = (Battle.View.Skill.Component.SkillViewComponent)CreateComponent(index, typeof(Battle.View.Skill.Component.SkillViewComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSkillView() {
        RemoveComponent(ViewSkillComponentsLookup.SkillView);
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

    static Entitas.IMatcher<ViewSkillEntity> _matcherSkillView;

    public static Entitas.IMatcher<ViewSkillEntity> SkillView {
        get {
            if (_matcherSkillView == null) {
                var matcher = (Entitas.Matcher<ViewSkillEntity>)Entitas.Matcher<ViewSkillEntity>.AllOf(ViewSkillComponentsLookup.SkillView);
                matcher.componentNames = ViewSkillComponentsLookup.componentNames;
                _matcherSkillView = matcher;
            }

            return _matcherSkillView;
        }
    }
}
