namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheOptionIsASomeButDoesNotContainTheExpectedContent<T>()
      => Option<T>()
       + IsASomeButDoesNotContainTheExpectedContent;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(string name)
      => Option<T>(name)
       + IsASomeButDoesNotContainTheExpectedContent;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsANone<T>()
      => Option<T>()
       + IsANoneWhenWeExpectedItToBeASome;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsANone<T>(string name)
      => Option<T>(name)
       + IsANoneWhenWeExpectedItToBeASome;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASome<T>()
      => Option<T>()
       + IsASomeWhenWeExpectedItToBeANone;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASome<T>(string name)
      => Option<T>(name)
       + IsASomeWhenWeExpectedItToBeANone;

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string IsANoneWhenWeExpectedItToBeASome           = "is a none when we expected it to be a some";
   private const string IsASomeButDoesNotContainTheExpectedContent = "is a some but does not contain the expected content";
   private const string IsASomeWhenWeExpectedItToBeANone           = "is a some when we expected it to be a none";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string Option<T>(string? name = null)
   {
      var result = $@"The Option<{typeof(T).Name}> ";

      if (name is not null)
      {
         result += $@"""{name}"" ";
      }

      return result;
   }

   /* ------------------------------------------------------------ */
}