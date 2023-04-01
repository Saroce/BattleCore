//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicThingEntity {

    public Battle.Logic.Thing.Behaviour.State.StateMachineComponent stateMachine { get { return (Battle.Logic.Thing.Behaviour.State.StateMachineComponent)GetComponent(LogicThingComponentsLookup.StateMachine); } }
    public bool hasStateMachine { get { return HasComponent(LogicThingComponentsLookup.StateMachine); } }

    public void AddStateMachine(Battle.Logic.Base.FSM.IStateMachine newFSM) {
        var index = LogicThingComponentsLookup.StateMachine;
        var component = (Battle.Logic.Thing.Behaviour.State.StateMachineComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Behaviour.State.StateMachineComponent));
        component.FSM = newFSM;
        AddComponent(index, component);
    }

    public void ReplaceStateMachine(Battle.Logic.Base.FSM.IStateMachine newFSM) {
        var index = LogicThingComponentsLookup.StateMachine;
        var component = (Battle.Logic.Thing.Behaviour.State.StateMachineComponent)CreateComponent(index, typeof(Battle.Logic.Thing.Behaviour.State.StateMachineComponent));
        component.FSM = newFSM;
        ReplaceComponent(index, component);
    }

    public void RemoveStateMachine() {
        RemoveComponent(LogicThingComponentsLookup.StateMachine);
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

    static Entitas.IMatcher<LogicThingEntity> _matcherStateMachine;

    public static Entitas.IMatcher<LogicThingEntity> StateMachine {
        get {
            if (_matcherStateMachine == null) {
                var matcher = (Entitas.Matcher<LogicThingEntity>)Entitas.Matcher<LogicThingEntity>.AllOf(LogicThingComponentsLookup.StateMachine);
                matcher.componentNames = LogicThingComponentsLookup.componentNames;
                _matcherStateMachine = matcher;
            }

            return _matcherStateMachine;
        }
    }
}