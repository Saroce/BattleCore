//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class ViewSkillComponentsLookup {

    public const int Destroyed = 0;
    public const int Id = 1;
    public const int View = 2;
    public const int EncryptedFixedPointValueView = 3;
    public const int EncryptedIntValueView = 4;
    public const int EncryptedUlongValueView = 5;
    public const int SkillCastContext = 6;
    public const int SkillCasterId = 7;
    public const int SkillCastSpeedScale = 8;
    public const int SkillContinuousSequence = 9;
    public const int SkillEndingSequence = 10;
    public const int SkillSequence = 11;

    public const int TotalComponents = 12;

    public static readonly string[] componentNames = {
        "Destroyed",
        "Id",
        "View",
        "EncryptedFixedPointValueView",
        "EncryptedIntValueView",
        "EncryptedUlongValueView",
        "SkillCastContext",
        "SkillCasterId",
        "SkillCastSpeedScale",
        "SkillContinuousSequence",
        "SkillEndingSequence",
        "SkillSequence"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Battle.View.Base.Component.DestroyedComponent),
        typeof(Battle.View.Base.Component.IdComponent),
        typeof(Battle.View.Base.Component.ViewComponent),
        typeof(Battle.View.Base.Component.ViewComponent.EncryptedFixedPointValueViewComponent),
        typeof(Battle.View.Base.Component.ViewComponent.EncryptedIntValueViewComponent),
        typeof(Battle.View.Base.Component.ViewComponent.EncryptedUlongValueViewComponent),
        typeof(Battle.View.Skill.Component.SkillCastContextComponent),
        typeof(Battle.View.Skill.Component.SkillCasterIdComponent),
        typeof(Battle.View.Skill.Component.SkillCastSpeedScaleComponent),
        typeof(Battle.View.Skill.Component.SkillContinuousSequenceComponent),
        typeof(Battle.View.Skill.Component.SkillEndingSequenceComponent),
        typeof(Battle.View.Skill.Component.SkillSequenceComponent)
    };
}
