//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewHUDEntity {

    public Battle.View.HUD.Component.HUDBindPointComponent hUDBindPoint { get { return (Battle.View.HUD.Component.HUDBindPointComponent)GetComponent(ViewHUDComponentsLookup.HUDBindPoint); } }
    public bool hasHUDBindPoint { get { return HasComponent(ViewHUDComponentsLookup.HUDBindPoint); } }

    public void AddHUDBindPoint(Battle.View.Constant.AvatarBindPointType newValue) {
        var index = ViewHUDComponentsLookup.HUDBindPoint;
        var component = (Battle.View.HUD.Component.HUDBindPointComponent)CreateComponent(index, typeof(Battle.View.HUD.Component.HUDBindPointComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHUDBindPoint(Battle.View.Constant.AvatarBindPointType newValue) {
        var index = ViewHUDComponentsLookup.HUDBindPoint;
        var component = (Battle.View.HUD.Component.HUDBindPointComponent)CreateComponent(index, typeof(Battle.View.HUD.Component.HUDBindPointComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHUDBindPoint() {
        RemoveComponent(ViewHUDComponentsLookup.HUDBindPoint);
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
public sealed partial class ViewHUDMatcher {

    static Entitas.IMatcher<ViewHUDEntity> _matcherHUDBindPoint;

    public static Entitas.IMatcher<ViewHUDEntity> HUDBindPoint {
        get {
            if (_matcherHUDBindPoint == null) {
                var matcher = (Entitas.Matcher<ViewHUDEntity>)Entitas.Matcher<ViewHUDEntity>.AllOf(ViewHUDComponentsLookup.HUDBindPoint);
                matcher.componentNames = ViewHUDComponentsLookup.componentNames;
                _matcherHUDBindPoint = matcher;
            }

            return _matcherHUDBindPoint;
        }
    }
}
