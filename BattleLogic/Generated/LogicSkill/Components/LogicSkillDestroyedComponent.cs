//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicSkillEntity {

    static readonly Battle.Logic.Base.Component.DestroyedComponent destroyedComponent = new Battle.Logic.Base.Component.DestroyedComponent();

    public bool isDestroyed {
        get { return HasComponent(LogicSkillComponentsLookup.Destroyed); }
        set {
            if (value != isDestroyed) {
                var index = LogicSkillComponentsLookup.Destroyed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : destroyedComponent;

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
public sealed partial class LogicSkillMatcher {

    static Entitas.IMatcher<LogicSkillEntity> _matcherDestroyed;

    public static Entitas.IMatcher<LogicSkillEntity> Destroyed {
        get {
            if (_matcherDestroyed == null) {
                var matcher = (Entitas.Matcher<LogicSkillEntity>)Entitas.Matcher<LogicSkillEntity>.AllOf(LogicSkillComponentsLookup.Destroyed);
                matcher.componentNames = LogicSkillComponentsLookup.componentNames;
                _matcherDestroyed = matcher;
            }

            return _matcherDestroyed;
        }
    }
}
