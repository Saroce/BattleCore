//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewThingEntity {

    public Battle.View.Thing.Component.Avatar.AvatarRotateTweenComponent avatarRotateTween { get { return (Battle.View.Thing.Component.Avatar.AvatarRotateTweenComponent)GetComponent(ViewThingComponentsLookup.AvatarRotateTween); } }
    public bool hasAvatarRotateTween { get { return HasComponent(ViewThingComponentsLookup.AvatarRotateTween); } }

    public void AddAvatarRotateTween(ulong newTweenId) {
        var index = ViewThingComponentsLookup.AvatarRotateTween;
        var component = (Battle.View.Thing.Component.Avatar.AvatarRotateTweenComponent)CreateComponent(index, typeof(Battle.View.Thing.Component.Avatar.AvatarRotateTweenComponent));
        component.TweenId = newTweenId;
        AddComponent(index, component);
    }

    public void ReplaceAvatarRotateTween(ulong newTweenId) {
        var index = ViewThingComponentsLookup.AvatarRotateTween;
        var component = (Battle.View.Thing.Component.Avatar.AvatarRotateTweenComponent)CreateComponent(index, typeof(Battle.View.Thing.Component.Avatar.AvatarRotateTweenComponent));
        component.TweenId = newTweenId;
        ReplaceComponent(index, component);
    }

    public void RemoveAvatarRotateTween() {
        RemoveComponent(ViewThingComponentsLookup.AvatarRotateTween);
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
public sealed partial class ViewThingMatcher {

    static Entitas.IMatcher<ViewThingEntity> _matcherAvatarRotateTween;

    public static Entitas.IMatcher<ViewThingEntity> AvatarRotateTween {
        get {
            if (_matcherAvatarRotateTween == null) {
                var matcher = (Entitas.Matcher<ViewThingEntity>)Entitas.Matcher<ViewThingEntity>.AllOf(ViewThingComponentsLookup.AvatarRotateTween);
                matcher.componentNames = ViewThingComponentsLookup.componentNames;
                _matcherAvatarRotateTween = matcher;
            }

            return _matcherAvatarRotateTween;
        }
    }
}