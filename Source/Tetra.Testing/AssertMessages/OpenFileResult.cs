namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedButDoesNotContainTheExpectedContent<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsALocked} {ButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedButDoesNotContainTheExpectedMessage<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsALocked} {ButDoesNotContainTheExpectedMessage}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedButDoesNotContainTheExpectedPath<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsALocked} {ButDoesNotContainTheExpectedPath}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsALocked} {WhenWeExpectedItToBeAMissing}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsALocked} {WhenWeExpectedItToBeAnOpen}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingButDoesNotContainTheExpectedContent<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsAMissing} {ButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingButDoesNotContainTheExpectedMessage<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsAMissing} {ButDoesNotContainTheExpectedMessage}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingButDoesNotContainTheExpectedPath<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsAMissing} {ButDoesNotContainTheExpectedPath}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsAMissing} {WhenWeExpectedItToBeALocked}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsAMissing} {WhenWeExpectedItToBeAnOpen}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAnOpenButDoesNotContainTheExpectedContent<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsAnOpen} {ButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsAnOpen} {WhenWeExpectedItToBeALocked}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsAnOpen} {WhenWeExpectedItToBeAMissing}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsUnrecognised} {WhenWeExpectedItToBeALocked}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsUnrecognised} {WhenWeExpectedItToBeAMissing}";

   /* ------------------------------------------------------------ */

   public static string TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(string description)
      => $"{description}: {TheOpenFileResult<T>()} {IsUnrecognised} {WhenWeExpectedItToBeAnOpen}";

   /* ------------------------------------------------------------ */
   // Internal Extension
   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<T>(this LockedResult<T> locked)
      => $@"Locked(Path: {locked.Content.Path()}, Message: ""{locked.Content.Message()}""";

   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<T>(this MissingResult<T> missing)
      => $@"Missing(Path: {missing.Content.Path()}, Message: ""{missing.Content.Message()}""";

   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<T>(this OpenResult<T> open)
      => $"Open({open.Content}";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string ButDoesNotContainTheExpectedContent = "but does not contain the expected content";
   private const string ButDoesNotContainTheExpectedMessage = "but does not contain the expected message";
   private const string ButDoesNotContainTheExpectedPath    = "but does not contain the expected path";
   private const string IsALocked                           = "is a locked";
   private const string IsAMissing                          = "is a missing";
   private const string IsAnOpen                            = "is an open";
   private const string IsUnrecognised                      = "is unrecognised";
   private const string WhenWeExpectedItToBeALocked         = "when we expected it to be a locked";
   private const string WhenWeExpectedItToBeAMissing        = "when we expected it to be a missing";
   private const string WhenWeExpectedItToBeAnOpen          = "when we expected it to be an open";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheOpenFileResult<T>()
      => $@"The OpenFileResult<{typeof(T).Name}>";

   /* ------------------------------------------------------------ */
}