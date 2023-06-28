//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewHUDEntity {

    public Battle.View.HUD.Component.HUDDamageValueComponent hUDDamageValue { get { return (Battle.View.HUD.Component.HUDDamageValueComponent)GetComponent(ViewHUDComponentsLookup.HUDDamageValue); } }
    public bool hasHUDDamageValue { get { return HasComponent(ViewHUDComponentsLookup.HUDDamageValue); } }

    public void AddHUDDamageValue(int newValue) {
        var index = ViewHUDComponentsLookup.HUDDamageValue;
        var component = (Battle.View.HUD.Component.HUDDamageValueComponent)CreateComponent(index, typeof(Battle.View.HUD.Component.HUDDamageValueComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHUDDamageValue(int newValue) {
        var index = ViewHUDComponentsLookup.HUDDamageValue;
        var component = (Battle.View.HUD.Component.HUDDamageValueComponent)CreateComponent(index, typeof(Battle.View.HUD.Component.HUDDamageValueComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHUDDamageValue() {
        RemoveComponent(ViewHUDComponentsLookup.HUDDamageValue);
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

    static Entitas.IMatcher<ViewHUDEntity> _matcherHUDDamageValue;

    public static Entitas.IMatcher<ViewHUDEntity> HUDDamageValue {
        get {
            if (_matcherHUDDamageValue == null) {
                var matcher = (Entitas.Matcher<ViewHUDEntity>)Entitas.Matcher<ViewHUDEntity>.AllOf(ViewHUDComponentsLookup.HUDDamageValue);
                matcher.componentNames = ViewHUDComponentsLookup.componentNames;
                _matcherHUDDamageValue = matcher;
            }

            return _matcherHUDDamageValue;
        }
    }
}