//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogicSkillEntity {

    public Battle.Logic.Base.CSExtension.EncryptedIntValueLogicComponent encryptedIntValueLogic { get { return (Battle.Logic.Base.CSExtension.EncryptedIntValueLogicComponent)GetComponent(LogicSkillComponentsLookup.EncryptedIntValueLogic); } }
    public bool hasEncryptedIntValueLogic { get { return HasComponent(LogicSkillComponentsLookup.EncryptedIntValueLogic); } }

    public void AddEncryptedIntValueLogic(int newValue) {
        var index = LogicSkillComponentsLookup.EncryptedIntValueLogic;
        var component = (Battle.Logic.Base.CSExtension.EncryptedIntValueLogicComponent)CreateComponent(index, typeof(Battle.Logic.Base.CSExtension.EncryptedIntValueLogicComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEncryptedIntValueLogic(int newValue) {
        var index = LogicSkillComponentsLookup.EncryptedIntValueLogic;
        var component = (Battle.Logic.Base.CSExtension.EncryptedIntValueLogicComponent)CreateComponent(index, typeof(Battle.Logic.Base.CSExtension.EncryptedIntValueLogicComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEncryptedIntValueLogic() {
        RemoveComponent(LogicSkillComponentsLookup.EncryptedIntValueLogic);
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

    static Entitas.IMatcher<LogicSkillEntity> _matcherEncryptedIntValueLogic;

    public static Entitas.IMatcher<LogicSkillEntity> EncryptedIntValueLogic {
        get {
            if (_matcherEncryptedIntValueLogic == null) {
                var matcher = (Entitas.Matcher<LogicSkillEntity>)Entitas.Matcher<LogicSkillEntity>.AllOf(LogicSkillComponentsLookup.EncryptedIntValueLogic);
                matcher.componentNames = LogicSkillComponentsLookup.componentNames;
                _matcherEncryptedIntValueLogic = matcher;
            }

            return _matcherEncryptedIntValueLogic;
        }
    }
}