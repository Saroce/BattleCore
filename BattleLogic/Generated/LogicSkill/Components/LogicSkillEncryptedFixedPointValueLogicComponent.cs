//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicSkillEntity {

    public Battle.Logic.Base.Component.EncryptedFixedPointValueLogicComponent encryptedFixedPointValueLogic { get { return (Battle.Logic.Base.Component.EncryptedFixedPointValueLogicComponent)GetComponent(LogicSkillComponentsLookup.EncryptedFixedPointValueLogic); } }
    public bool hasEncryptedFixedPointValueLogic { get { return HasComponent(LogicSkillComponentsLookup.EncryptedFixedPointValueLogic); } }

    public void AddEncryptedFixedPointValueLogic(Core.Lockstep.Math.FixedPoint newValue) {
        var index = LogicSkillComponentsLookup.EncryptedFixedPointValueLogic;
        var component = (Battle.Logic.Base.Component.EncryptedFixedPointValueLogicComponent)CreateComponent(index, typeof(Battle.Logic.Base.Component.EncryptedFixedPointValueLogicComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEncryptedFixedPointValueLogic(Core.Lockstep.Math.FixedPoint newValue) {
        var index = LogicSkillComponentsLookup.EncryptedFixedPointValueLogic;
        var component = (Battle.Logic.Base.Component.EncryptedFixedPointValueLogicComponent)CreateComponent(index, typeof(Battle.Logic.Base.Component.EncryptedFixedPointValueLogicComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEncryptedFixedPointValueLogic() {
        RemoveComponent(LogicSkillComponentsLookup.EncryptedFixedPointValueLogic);
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

    static Entitas.IMatcher<LogicSkillEntity> _matcherEncryptedFixedPointValueLogic;

    public static Entitas.IMatcher<LogicSkillEntity> EncryptedFixedPointValueLogic {
        get {
            if (_matcherEncryptedFixedPointValueLogic == null) {
                var matcher = (Entitas.Matcher<LogicSkillEntity>)Entitas.Matcher<LogicSkillEntity>.AllOf(LogicSkillComponentsLookup.EncryptedFixedPointValueLogic);
                matcher.componentNames = LogicSkillComponentsLookup.componentNames;
                _matcherEncryptedFixedPointValueLogic = matcher;
            }

            return _matcherEncryptedFixedPointValueLogic;
        }
    }
}
