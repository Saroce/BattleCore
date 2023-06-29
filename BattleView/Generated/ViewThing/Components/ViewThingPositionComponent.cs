//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewThingEntity {

    public Battle.View.Base.Component.PositionComponent position { get { return (Battle.View.Base.Component.PositionComponent)GetComponent(ViewThingComponentsLookup.Position); } }
    public bool hasPosition { get { return HasComponent(ViewThingComponentsLookup.Position); } }

    public void AddPosition(Core.Lockstep.Math.TSVector newValue) {
        var index = ViewThingComponentsLookup.Position;
        var component = (Battle.View.Base.Component.PositionComponent)CreateComponent(index, typeof(Battle.View.Base.Component.PositionComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePosition(Core.Lockstep.Math.TSVector newValue) {
        var index = ViewThingComponentsLookup.Position;
        var component = (Battle.View.Base.Component.PositionComponent)CreateComponent(index, typeof(Battle.View.Base.Component.PositionComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePosition() {
        RemoveComponent(ViewThingComponentsLookup.Position);
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

    static Entitas.IMatcher<ViewThingEntity> _matcherPosition;

    public static Entitas.IMatcher<ViewThingEntity> Position {
        get {
            if (_matcherPosition == null) {
                var matcher = (Entitas.Matcher<ViewThingEntity>)Entitas.Matcher<ViewThingEntity>.AllOf(ViewThingComponentsLookup.Position);
                matcher.componentNames = ViewThingComponentsLookup.componentNames;
                _matcherPosition = matcher;
            }

            return _matcherPosition;
        }
    }
}
