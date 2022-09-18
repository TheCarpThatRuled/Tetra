namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheErrorIsASomeButDoesNotContainTheExpectedContent(string description)
      => $"{description}: {TheError} {Is} {ASome} {ButDoesNotContain} {TheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheErrorIsANone(string description)
      => $"{description}: {TheError} {Is} {ANone} {WhenWeExpectedItToBe} {ASome}";

   /* ------------------------------------------------------------ */

   public static string TheErrorIsASome(string description)
      => $"{description}: {TheError} {Is} {ASome} {WhenWeExpectedItToBe} {ANone}";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */


   private const string TheError = "The Error ";

   /* ------------------------------------------------------------ */
}