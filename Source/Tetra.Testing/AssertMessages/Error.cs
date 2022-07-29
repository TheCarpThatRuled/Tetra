namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheErrorIsASomeButDoesNotContainTheExpectedContent()
      => TheError
       + IsASomeButDoesNotContainTheExpectedContent;

   /* ------------------------------------------------------------ */

   public static string TheErrorIsASomeButDoesNotContainTheExpectedContent(string description)
      => $"{description}: {TheError}{IsASomeButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheErrorIsANone()
      => TheError
       + IsANoneWhenWeExpectedItToBeASome;

   /* ------------------------------------------------------------ */

   public static string TheErrorIsANone(string description)
      => $"{description}: {TheError}{IsANoneWhenWeExpectedItToBeASome}";

   /* ------------------------------------------------------------ */

   public static string TheErrorIsASome()
      => TheError
       + IsASomeWhenWeExpectedItToBeANone;

   /* ------------------------------------------------------------ */

   public static string TheErrorIsASome(string description)
      => $"{description}: {TheError}{IsASomeWhenWeExpectedItToBeANone}";

   /* ------------------------------------------------------------ */

   public static string TheErrorIsASome(string description,
                                        Message actual)
      => $"{description}: {TheError}{IsASomeWhenWeExpectedItToBeANone}\nActual message: {actual.Content()}";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */


   private const string TheError = "The Error ";

   /* ------------------------------------------------------------ */
}