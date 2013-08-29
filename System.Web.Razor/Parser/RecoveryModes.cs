namespace System.Web.Razor.Parser {
    // REVIEW: Should these be more granular?
    [Flags]
    public enum RecoveryModes {
        Markup = 1,
        Code = 2,
        Transition = 4,
        Any = Markup | Code | Transition
    }
}