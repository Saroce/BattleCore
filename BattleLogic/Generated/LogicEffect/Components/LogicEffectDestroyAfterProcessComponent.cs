//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicEffectEntity {

    static readonly Battle.Logic.Effect.Component.DestroyAfterProcessComponent destroyAfterProcessComponent = new Battle.Logic.Effect.Component.DestroyAfterProcessComponent();

    public bool isDestroyAfterProcess {
        get { return HasComponent(LogicEffectComponentsLookup.DestroyAfterProcess); }
        set {
            if (value != isDestroyAfterProcess) {
                var index = LogicEffectComponentsLookup.DestroyAfterProcess;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : destroyAfterProcessComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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
public sealed partial class LogicEffectMatcher {

    static Entitas.IMatcher<LogicEffectEntity> _matcherDestroyAfterProcess;

    public static Entitas.IMatcher<LogicEffectEntity> DestroyAfterProcess {
        get {
            if (_matcherDestroyAfterProcess == null) {
                var matcher = (Entitas.Matcher<LogicEffectEntity>)Entitas.Matcher<LogicEffectEntity>.AllOf(LogicEffectComponentsLookup.DestroyAfterProcess);
                matcher.componentNames = LogicEffectComponentsLookup.componentNames;
                _matcherDestroyAfterProcess = matcher;
            }

            return _matcherDestroyAfterProcess;
        }
    }
}
