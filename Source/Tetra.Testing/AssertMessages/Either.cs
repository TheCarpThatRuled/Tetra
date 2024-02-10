namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string ALeft = $"{A} left";

   private const string ARight = $"{A} right";
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>
   (
      string description
   )
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {ARight} {ButDoesNotContain} {TheExpectedContent}.";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsARightWhenWeExpectedItToBeALeft<TLeft, TRight>
   (
      string description
   )
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {ARight} {WhenWeExpectedItToBe} {ALeft}.";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>
   (
      string description
   )
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {ALeft} {ButDoesNotContain} {TheExpectedContent}.";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsALeftWhenWeExpectedItToBeARight<TLeft, TRight>
   (
      string description
   )
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {ALeft} {WhenWeExpectedItToBe} {ARight}.";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsUnrecognisedWhenWeExpectedItToBeARight<TLeft, TRight>
   (
      string description
   )
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {ARight}.";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsUnrecognisedWhenWeExpectedItToBeALeft<TLeft, TRight>
   (
      string description
   )
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {ALeft}.";

   /* ------------------------------------------------------------ */
   // Internal Extensions
   /* ------------------------------------------------------------ */


   internal static string ToTestOutput<TLeft, TRight>
   (
      this Either<TLeft, TRight>.RightEither right
   )
      => $"""Right("{right.Content}")""";

   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<TLeft, TRight>
   (
      this Either<TLeft, TRight>.LeftEither left
   )
      => $"""Left("{left.Content}")""";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheEither<TLeft, TRight>()
      => $@"The Either<{typeof(TLeft).Name}, {typeof(TRight).Name}>";

   /* ------------------------------------------------------------ */
}