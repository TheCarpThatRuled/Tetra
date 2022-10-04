namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheErrorIsASomeButDoesNotContainTheExpectedContent(string description)
      => $"{description}: {TheError} {Is} {ASome} {ButDoesNotContain} {TheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheErrorIsANoneWhenWeExpectedItToBeASome(string description)
      => $"{description}: {TheError} {Is} {ANone} {WhenWeExpectedItToBe} {ASome}";

   /* ------------------------------------------------------------ */

   public static string TheErrorIsASomeWhenWeExpectedItToBeANone(string description)
      => $"{description}: {TheError} {Is} {ASome} {WhenWeExpectedItToBe} {ANone}";

   /* ------------------------------------------------------------ */

   public static string TheErrorIsUnrecognisedWhenWeExpectedItToBeANone(string description)
      => $"{description}: {TheError} {Is} {Unrecognised} {WhenWeExpectedItToBe} {ANone}";

   /* ------------------------------------------------------------ */

   public static string TheErrorIsUnrecognisedWhenWeExpectedItToBeASome(string description)
      => $"{description}: {TheError}{Is} {Unrecognised} {WhenWeExpectedItToBe} {ASome}";

   /* ------------------------------------------------------------ */
   // Internal Extensions
   /* ------------------------------------------------------------ */

   internal static string ToTestOutput(this Error.SomeError some)
      => $@"Some(""{some.Content}"")";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string TheError = "The Error ";

   /* ------------------------------------------------------------ */
}