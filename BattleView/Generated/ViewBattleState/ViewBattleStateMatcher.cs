//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ViewBattleStateMatcher {

    public static Entitas.IAllOfMatcher<ViewBattleStateEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<ViewBattleStateEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<ViewBattleStateEntity> AllOf(params Entitas.IMatcher<ViewBattleStateEntity>[] matchers) {
          return Entitas.Matcher<ViewBattleStateEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<ViewBattleStateEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<ViewBattleStateEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<ViewBattleStateEntity> AnyOf(params Entitas.IMatcher<ViewBattleStateEntity>[] matchers) {
          return Entitas.Matcher<ViewBattleStateEntity>.AnyOf(matchers);
    }
}
