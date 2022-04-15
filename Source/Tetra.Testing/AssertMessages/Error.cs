namespace Tetra.Testing
{
   public static partial class AssertMessages
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static string TheErrorIsASomeButDoesNotContainTheExpectedContent()
         => Error()
          + IsASomeButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheErrorIsASomeButDoesNotContainTheExpectedContent(string name)
         => Error(name)
          + IsASomeButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheErrorIsANone()
         => Error()
          + IsANoneWhenWeExpectedItToBeASome;

      /* ------------------------------------------------------------ */

      public static string TheErrorIsANone(string name)
         => Error(name)
          + IsANoneWhenWeExpectedItToBeASome;

      /* ------------------------------------------------------------ */

      public static string TheErrorIsASome()
         => Error()
          + IsASomeWhenWeExpectedItToBeANone;

      /* ------------------------------------------------------------ */

      public static string TheErrorIsASome(string name)
         => Error(name)
          + IsASomeWhenWeExpectedItToBeANone;

      /* ------------------------------------------------------------ */
      // Private Functions
      /* ------------------------------------------------------------ */

      private static string Error(string? name = null)
      {
         var result = $@"The Error ";

         if (name is not null)
         {
            result += $@"""{name}"" ";
         }

         return result;
      }

      /* ------------------------------------------------------------ */
   }
}