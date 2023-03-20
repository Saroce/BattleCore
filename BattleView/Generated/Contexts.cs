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

    public ViewAudioContext viewAudio { get; set; }
    public ViewBattleStateContext viewBattleState { get; set; }
    public ViewBuffContext viewBuff { get; set; }
    public ViewFieldContext viewField { get; set; }
    public ViewHUDContext viewHUD { get; set; }
    public ViewInputContext viewInput { get; set; }
    public ViewSkillContext viewSkill { get; set; }
    public ViewThingContext viewThing { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { viewAudio, viewBattleState, viewBuff, viewField, viewHUD, viewInput, viewSkill, viewThing }; } }

    public Contexts() {
        viewAudio = new ViewAudioContext();
        viewBattleState = new ViewBattleStateContext();
        viewBuff = new ViewBuffContext();
        viewField = new ViewFieldContext();
        viewHUD = new ViewHUDContext();
        viewInput = new ViewInputContext();
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
            CreateContextObserver(viewAudio);
            CreateContextObserver(viewBattleState);
            CreateContextObserver(viewBuff);
            CreateContextObserver(viewField);
            CreateContextObserver(viewHUD);
            CreateContextObserver(viewInput);
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
