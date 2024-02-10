namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string ALocked  = $"{A} locked";
   private const string AMissing = $"{A} missing";

   private const string AnOpen = $"{An} open";
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedButDoesNotContainTheExpectedContent<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {ALocked} {ButDoesNotContain} {TheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedButDoesNotContainTheExpectedMessage<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {ALocked} {ButDoesNotContain} {TheExpectedMessage}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedButDoesNotContainTheExpectedPath<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {ALocked} {ButDoesNotContain} {TheExpectedPath}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {ALocked} {WhenWeExpectedItToBe} {AMissing}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {ALocked} {WhenWeExpectedItToBe} {AnOpen}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingButDoesNotContainTheExpectedContent<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {AMissing} {ButDoesNotContain} {TheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingButDoesNotContainTheExpectedMessage<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {AMissing} {ButDoesNotContain} {TheExpectedMessage}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingButDoesNotContainTheExpectedPath<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {AMissing} {ButDoesNotContain} {TheExpectedPath}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {AMissing} {WhenWeExpectedItToBe} {ALocked}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {AMissing} {WhenWeExpectedItToBe} {AnOpen}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAnOpenButDoesNotContainTheExpectedContent<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {AnOpen} {ButDoesNotContain} {TheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {AnOpen} {WhenWeExpectedItToBe} {ALocked}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {AnOpen} {WhenWeExpectedItToBe} {AMissing}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {ALocked}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {AMissing}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>
   (
      string description
   )
      => $"{description}: {TheOpenFileResult<T>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {AnOpen}";

   /* ------------------------------------------------------------ */
   // Internal Extensions
   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<T>
   (
      this LockedResult<T> locked
   )
      => $"""Locked(Path: {locked.Content.Path()}, Message: "{locked.Content.Message()}")""";

   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<T>
   (
      this MissingResult<T> missing
   )
      => $"""Missing(Path: {missing.Content.Path()}, Message: "{missing.Content.Message()}")""";

   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<T>
   (
      this OpenResult<T> open
   )
      => $"Open({open.Content})";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheOpenFileResult<T>()
      => $@"{The} OpenFileResult<{typeof(T).Name}>";

   /* ------------------------------------------------------------ */
}