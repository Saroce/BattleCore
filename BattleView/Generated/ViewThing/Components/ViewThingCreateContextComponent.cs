//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewThingEntity {

    public Battle.View.Thing.Component.CreateContextComponent createContext { get { return (Battle.View.Thing.Component.CreateContextComponent)GetComponent(ViewThingComponentsLookup.CreateContext); } }
    public bool hasCreateContext { get { return HasComponent(ViewThingComponentsLookup.CreateContext); } }

    public void AddCreateContext(Battle.Common.Context.Create.ThingCrateContext newValue) {
        var index = ViewThingComponentsLookup.CreateContext;
        var component = (Battle.View.Thing.Component.CreateContextComponent)CreateComponent(index, typeof(Battle.View.Thing.Component.CreateContextComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCreateContext(Battle.Common.Context.Create.ThingCrateContext newValue) {
        var index = ViewThingComponentsLookup.CreateContext;
        var component = (Battle.View.Thing.Component.CreateContextComponent)CreateComponent(index, typeof(Battle.View.Thing.Component.CreateContextComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCreateContext() {
        RemoveComponent(ViewThingComponentsLookup.CreateContext);
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

    static Entitas.IMatcher<ViewThingEntity> _matcherCreateContext;

    public static Entitas.IMatcher<ViewThingEntity> CreateContext {
        get {
            if (_matcherCreateContext == null) {
                var matcher = (Entitas.Matcher<ViewThingEntity>)Entitas.Matcher<ViewThingEntity>.AllOf(ViewThingComponentsLookup.CreateContext);
                matcher.componentNames = ViewThingComponentsLookup.componentNames;
                _matcherCreateContext = matcher;
            }

            return _matcherCreateContext;
        }
    }
}
