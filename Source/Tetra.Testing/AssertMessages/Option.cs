namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheOptionIsANone<T>()
      => TheIOption<T>()
       + IsANoneWhenWeExpectedItToBeASome;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsANone<T>(string description)
      => $"{description}: {TheIOption<T>()}{IsANoneWhenWeExpectedItToBeASome}";

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASomeButDoesNotContainTheExpectedContent<T>()
      => TheIOption<T>()
       + IsASomeButDoesNotContainTheExpectedContent;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(string description)
      => $"{description}: {TheIOption<T>()}{IsASomeButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASome<T>()
      => TheIOption<T>()
       + IsASomeWhenWeExpectedItToBeANone;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASome<T>(string description)
      => $"{description}: {TheIOption<T>()}{IsASomeWhenWeExpectedItToBeANone}";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string IsANoneWhenWeExpectedItToBeASome           = "is a none when we expected it to be a some";
   private const string IsASomeButDoesNotContainTheExpectedContent = "is a some but does not contain the expected content";
   private const string IsASomeWhenWeExpectedItToBeANone           = "is a some when we expected it to be a none";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheIOption<T>()
      => $@"The IOption<{typeof(T).Name}> ";

   /* ------------------------------------------------------------ */
}