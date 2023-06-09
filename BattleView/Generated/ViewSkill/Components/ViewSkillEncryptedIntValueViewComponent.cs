//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewSkillEntity {

    public Battle.View.Base.Component.ViewComponent.EncryptedIntValueViewComponent encryptedIntValueView { get { return (Battle.View.Base.Component.ViewComponent.EncryptedIntValueViewComponent)GetComponent(ViewSkillComponentsLookup.EncryptedIntValueView); } }
    public bool hasEncryptedIntValueView { get { return HasComponent(ViewSkillComponentsLookup.EncryptedIntValueView); } }

    public void AddEncryptedIntValueView(int newValue) {
        var index = ViewSkillComponentsLookup.EncryptedIntValueView;
        var component = (Battle.View.Base.Component.ViewComponent.EncryptedIntValueViewComponent)CreateComponent(index, typeof(Battle.View.Base.Component.ViewComponent.EncryptedIntValueViewComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEncryptedIntValueView(int newValue) {
        var index = ViewSkillComponentsLookup.EncryptedIntValueView;
        var component = (Battle.View.Base.Component.ViewComponent.EncryptedIntValueViewComponent)CreateComponent(index, typeof(Battle.View.Base.Component.ViewComponent.EncryptedIntValueViewComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEncryptedIntValueView() {
        RemoveComponent(ViewSkillComponentsLookup.EncryptedIntValueView);
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

    static Entitas.IMatcher<ViewSkillEntity> _matcherEncryptedIntValueView;

    public static Entitas.IMatcher<ViewSkillEntity> EncryptedIntValueView {
        get {
            if (_matcherEncryptedIntValueView == null) {
                var matcher = (Entitas.Matcher<ViewSkillEntity>)Entitas.Matcher<ViewSkillEntity>.AllOf(ViewSkillComponentsLookup.EncryptedIntValueView);
                matcher.componentNames = ViewSkillComponentsLookup.componentNames;
                _matcherEncryptedIntValueView = matcher;
            }

            return _matcherEncryptedIntValueView;
        }
    }
}
