namespace Tetra.Testing
{
   public static partial class AssertMessages
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static string TheErrorDoesNotContainTheExpectedValue()
         => $"The Error does not contain the expected value";

      /* ------------------------------------------------------------ */

      public static string TheErrorDoesNotContainTheExpectedValue(string name)
         => $@"The Error ""{name}"" does not contain the expected value";

      /* ------------------------------------------------------------ */

      public static string TheErrorIsNone()
         => $"The Error is none when we expected it to be some";

      /* ------------------------------------------------------------ */

      public static string TheErrorIsNone(string name)
         => $@"The Error ""{name}"" is none when we expected it to be some";

      /* ------------------------------------------------------------ */

      public static string TheErrorIsSome()
         => $"The Error is some when we expected it to be none";

      /* ------------------------------------------------------------ */

      public static string TheErrorIsSome(string name)
         => $@"The Error ""{name}"" is some when we expected it to be none";

      /* ------------------------------------------------------------ */
   }
}