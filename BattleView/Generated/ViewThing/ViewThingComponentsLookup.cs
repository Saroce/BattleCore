//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class ViewThingComponentsLookup {

    public const int Destroyed = 0;
    public const int Id = 1;
    public const int Position = 2;
    public const int Rotation = 3;
    public const int Velocity = 4;
    public const int AvatarAsset = 5;
    public const int AvatarMotion = 6;
    public const int CreateContext = 7;
    public const int ThingType = 8;

    public const int TotalComponents = 9;

    public static readonly string[] componentNames = {
        "Destroyed",
        "Id",
        "Position",
        "Rotation",
        "Velocity",
        "AvatarAsset",
        "AvatarMotion",
        "CreateContext",
        "ThingType"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Battle.View.Base.Component.DestroyedComponent),
        typeof(Battle.View.Base.Component.IdComponent),
        typeof(Battle.View.Base.Component.PositionComponent),
        typeof(Battle.View.Base.Component.RotationComponent),
        typeof(Battle.View.Base.Component.VelocityComponent),
        typeof(Battle.View.Thing.Component.Avatar.AvatarAssetComponent),
        typeof(Battle.View.Thing.Component.Avatar.AvatarMotionComponent),
        typeof(Battle.View.Thing.Component.CreateContextComponent),
        typeof(Battle.View.Thing.Component.ThingTypeComponent)
    };
}
