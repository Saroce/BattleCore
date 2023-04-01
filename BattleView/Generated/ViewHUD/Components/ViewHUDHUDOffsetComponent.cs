//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewHUDEntity {

    public Battle.View.HUD.Component.HUDOffsetComponent hUDOffset { get { return (Battle.View.HUD.Component.HUDOffsetComponent)GetComponent(ViewHUDComponentsLookup.HUDOffset); } }
    public bool hasHUDOffset { get { return HasComponent(ViewHUDComponentsLookup.HUDOffset); } }

    public void AddHUDOffset(UnityEngine.Vector3 newValue) {
        var index = ViewHUDComponentsLookup.HUDOffset;
        var component = (Battle.View.HUD.Component.HUDOffsetComponent)CreateComponent(index, typeof(Battle.View.HUD.Component.HUDOffsetComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHUDOffset(UnityEngine.Vector3 newValue) {
        var index = ViewHUDComponentsLookup.HUDOffset;
        var component = (Battle.View.HUD.Component.HUDOffsetComponent)CreateComponent(index, typeof(Battle.View.HUD.Component.HUDOffsetComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHUDOffset() {
        RemoveComponent(ViewHUDComponentsLookup.HUDOffset);
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

    static Entitas.IMatcher<ViewHUDEntity> _matcherHUDOffset;

    public static Entitas.IMatcher<ViewHUDEntity> HUDOffset {
        get {
            if (_matcherHUDOffset == null) {
                var matcher = (Entitas.Matcher<ViewHUDEntity>)Entitas.Matcher<ViewHUDEntity>.AllOf(ViewHUDComponentsLookup.HUDOffset);
                matcher.componentNames = ViewHUDComponentsLookup.componentNames;
                _matcherHUDOffset = matcher;
            }

            return _matcherHUDOffset;
        }
    }
}
