namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(string description)
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {ALeft} {ButDoesNotContain} {TheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsALeftWheWeExpectItToBeARight<TLeft, TRight>(string description)
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {ALeft} {WhenWeExpectedItToBe} {ARight}";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(string description)
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {ALeft} {WhenWeExpectedItToBe} {ARight}";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsARightWhenWeExpectItToBeALeft<TLeft, TRight>(string description)
      => $"{description}: {TheEither<TLeft, TRight>()} {Is} {ARight} {ButDoesNotContain} {TheExpectedContent}";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string ALeft = $"{A} left";
   private const string ARight = $"{A} right";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheEither<TLeft, TRight>()
      => $@"The Either<{typeof(TLeft).Name}, {typeof(TRight).Name}>";

   /* ------------------------------------------------------------ */
}