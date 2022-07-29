namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheOptionIsANone<T>()
      => TheOption<T>()
       + IsANoneWhenWeExpectedItToBeASome;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsANone<T>(string description)
      => $"{description}: {TheOption<T>()}{IsANoneWhenWeExpectedItToBeASome}";

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASomeButDoesNotContainTheExpectedContent<T>()
      => TheOption<T>()
       + IsASomeButDoesNotContainTheExpectedContent;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(string description)
      => $"{description}: {TheOption<T>()}{IsASomeButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASome<T>()
      => TheOption<T>()
       + IsASomeWhenWeExpectedItToBeANone;

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASome<T>(string description)
      => $"{description}: {TheOption<T>()}{IsASomeWhenWeExpectedItToBeANone}";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string IsANoneWhenWeExpectedItToBeASome           = "is a none when we expected it to be a some";
   private const string IsASomeButDoesNotContainTheExpectedContent = "is a some but does not contain the expected content";
   private const string IsASomeWhenWeExpectedItToBeANone           = "is a some when we expected it to be a none";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheOption<T>()
      => $@"The Option<{typeof(T).Name}> ";

   /* ------------------------------------------------------------ */
}