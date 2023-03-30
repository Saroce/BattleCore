//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    public Battle.Logic.Thing.Behaviour.State.Idle.Component.IdlableRefComponent idlableRef { get { return (Battle.Logic.Thing.Behaviour.State.Idle.Component.IdlableRefComponent)GetComponent(LogicThingComponentsLookup.IdlableRef); } }
    public bool hasIdlableRef { get { return HasComponent(LogicThingComponentsLookup.IdlableRef); } }

    public void AddIdlableRef(int newValue) {
        var index = LogicThingComponentsLookup.IdlableRef;
        var component = (Battle.Logic.Thing.Behaviour.State.Idle.Component.IdlableRefComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Behaviour.State.Idle.Component.IdlableRefComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceIdlableRef(int newValue) {
        var index = LogicThingComponentsLookup.IdlableRef;
        var component = (Battle.Logic.Thing.Behaviour.State.Idle.Component.IdlableRefComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Behaviour.State.Idle.Component.IdlableRefComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveIdlableRef() {
        RemoveComponent(LogicThingComponentsLookup.IdlableRef);
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
public sealed partial class LogicThingMatcher {

    static Entitas.IMatcher<LogicThingEntity> _matcherIdlableRef;

    public static Entitas.IMatcher<LogicThingEntity> IdlableRef {
        get {
            if (_matcherIdlableRef == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.IdlableRef);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherIdlableRef = matcher;
            }

            return _matcherIdlableRef;
        }
    }
}
