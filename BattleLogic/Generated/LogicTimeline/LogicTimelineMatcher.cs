//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class LogicTimelineMatcher {

    public static Entitas.IAllOfMatcher<LogicTimelineEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<LogicTimelineEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<LogicTimelineEntity> AllOf(params Entitas.IMatcher<LogicTimelineEntity>[] matchers) {
          return Entitas.Matcher<LogicTimelineEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<LogicTimelineEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<LogicTimelineEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<LogicTimelineEntity> AnyOf(params Entitas.IMatcher<LogicTimelineEntity>[] matchers) {
          return Entitas.Matcher<LogicTimelineEntity>.AnyOf(matchers);
    }
}
