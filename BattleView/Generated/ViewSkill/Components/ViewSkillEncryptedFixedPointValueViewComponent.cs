//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewSkillEntity {

    public Battle.View.Base.CSExtension.ViewComponent.EncryptedFixedPointValueViewComponent encryptedFixedPointValueView { get { return (Battle.View.Base.CSExtension.ViewComponent.EncryptedFixedPointValueViewComponent)GetComponent(ViewSkillComponentsLookup.EncryptedFixedPointValueView); } }
    public bool hasEncryptedFixedPointValueView { get { return HasComponent(ViewSkillComponentsLookup.EncryptedFixedPointValueView); } }

    public void AddEncryptedFixedPointValueView(vFrame.Lockstep.Core.FixedPoint newValue) {
        var index = ViewSkillComponentsLookup.EncryptedFixedPointValueView;
        var component = (Battle.View.Base.CSExtension.ViewComponent.EncryptedFixedPointValueViewComponent)CreateComponent(index, typeof(Battle.View.Base.CSExtension.ViewComponent.EncryptedFixedPointValueViewComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEncryptedFixedPointValueView(vFrame.Lockstep.Core.FixedPoint newValue) {
        var index = ViewSkillComponentsLookup.EncryptedFixedPointValueView;
        var component = (Battle.View.Base.CSExtension.ViewComponent.EncryptedFixedPointValueViewComponent)CreateComponent(index, typeof(Battle.View.Base.CSExtension.ViewComponent.EncryptedFixedPointValueViewComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEncryptedFixedPointValueView() {
        RemoveComponent(ViewSkillComponentsLookup.EncryptedFixedPointValueView);
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

    static Entitas.IMatcher<ViewSkillEntity> _matcherEncryptedFixedPointValueView;

    public static Entitas.IMatcher<ViewSkillEntity> EncryptedFixedPointValueView {
        get {
            if (_matcherEncryptedFixedPointValueView == null) {
                var matcher = (Entitas.Matcher<ViewSkillEntity>)Entitas.Matcher<ViewSkillEntity>.AllOf(ViewSkillComponentsLookup.EncryptedFixedPointValueView);
                matcher.componentNames = ViewSkillComponentsLookup.componentNames;
                _matcherEncryptedFixedPointValueView = matcher;
            }

            return _matcherEncryptedFixedPointValueView;
        }
    }
}