//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public ViewBuffContext viewBuff { get; set; }
    public ViewHUDContext viewHUD { get; set; }
    public ViewSkillContext viewSkill { get; set; }
    public ViewThingContext viewThing { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { viewBuff, viewHUD, viewSkill, viewThing }; } }

    public Contexts() {
        viewBuff = new ViewBuffContext();
        viewHUD = new ViewHUDContext();
        viewSkill = new ViewSkillContext();
        viewThing = new ViewThingContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string HUDOwner = "HUDOwner";
    public const string Id = "Id";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        viewHUD.AddEntityIndex(new Entitas.EntityIndex<ViewHUDEntity, ulong>(
            HUDOwner,
            viewHUD.GetGroup(ViewHUDMatcher.HUDOwner),
            (e, c) => ((Battle.View.HUD.Component.HUDOwnerComponent)c).Id));

        viewBuff.AddEntityIndex(new Entitas.PrimaryEntityIndex<ViewBuffEntity, ulong>(
            Id,
            viewBuff.GetGroup(ViewBuffMatcher.Id),
            (e, c) => ((Battle.View.Base.Component.IdComponent)c).Value));
        viewSkill.AddEntityIndex(new Entitas.PrimaryEntityIndex<ViewSkillEntity, ulong>(
            Id,
            viewSkill.GetGroup(ViewSkillMatcher.Id),
            (e, c) => ((Battle.View.Base.Component.IdComponent)c).Value));
        viewThing.AddEntityIndex(new Entitas.PrimaryEntityIndex<ViewThingEntity, ulong>(
            Id,
            viewThing.GetGroup(ViewThingMatcher.Id),
            (e, c) => ((Battle.View.Base.Component.IdComponent)c).Value));
    }
}

public static class ContextsExtensions {

    public static System.Collections.Generic.HashSet<ViewHUDEntity> GetEntitiesWithHUDOwner(this ViewHUDContext context, ulong Id) {
        return ((Entitas.EntityIndex<ViewHUDEntity, ulong>)context.GetEntityIndex(Contexts.HUDOwner)).GetEntities(Id);
    }

    public static ViewBuffEntity GetEntityWithId(this ViewBuffContext context, ulong Value) {
        return ((Entitas.PrimaryEntityIndex<ViewBuffEntity, ulong>)context.GetEntityIndex(Contexts.Id)).GetEntity(Value);
    }

    public static ViewSkillEntity GetEntityWithId(this ViewSkillContext context, ulong Value) {
        return ((Entitas.PrimaryEntityIndex<ViewSkillEntity, ulong>)context.GetEntityIndex(Contexts.Id)).GetEntity(Value);
    }

    public static ViewThingEntity GetEntityWithId(this ViewThingContext context, ulong Value) {
        return ((Entitas.PrimaryEntityIndex<ViewThingEntity, ulong>)context.GetEntityIndex(Contexts.Id)).GetEntity(Value);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContextObservers() {
        try {
            CreateContextObserver(viewBuff);
            CreateContextObserver(viewHUD);
            CreateContextObserver(viewSkill);
            CreateContextObserver(viewThing);
        } catch(System.Exception) {
        }
    }

    public void CreateContextObserver(Entitas.IContext context) {
        if (UnityEngine.Application.isPlaying) {
            var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
    }

#endif
}
