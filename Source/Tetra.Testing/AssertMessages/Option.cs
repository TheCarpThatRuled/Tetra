namespace Tetra.Testing
{
   public static partial class AssertMessages
   {
      /* -------------------------------------------------- */
      // Functions
      /* -------------------------------------------------- */

      public static string TheOptionDoesNotContainTheExpectedValue<T>()
         => $"The Option<{typeof(T).Name}> does not contain the expected value";

      /* -------------------------------------------------- */

      public static string TheOptionDoesNotContainTheExpectedValue<T>(string name)
         => $@"The Option<{typeof(T).Name}> ""{name}"" does not contain the expected value";

      /* -------------------------------------------------- */

      public static string TheOptionIsNone<T>()
         => $"The Option<{typeof(T).Name}> is none when we expected it to be some";

      /* -------------------------------------------------- */

      public static string TheOptionIsNone<T>(string name)
         => $@"The Option<{typeof(T).Name}> ""{name}"" is none when we expected it to be some";

      /* -------------------------------------------------- */

      public static string TheOptionIsSome<T>()
         => $"The Option<{typeof(T).Name}> is some when we expected it to be none";

      /* -------------------------------------------------- */

      public static string TheOptionIsSome<T>(string name)
         => $@"The Option<{typeof(T).Name}> ""{name}"" is some when we expected it to be none";

      /* -------------------------------------------------- */
   }
}