namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>()
      => TheEither<TLeft, TRight>()
       + IsALeftButDoesNotContainTheExpectedContent;

   /* ------------------------------------------------------------ */

   public static string TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(string description)
      => $"{description}: {TheEither<TLeft, TRight>()}{IsALeftButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsALeft<TLeft, TRight>()
      => TheEither<TLeft, TRight>()
       + IsALeftWhenWeExpectedItToBeARight;

   /* ------------------------------------------------------------ */

   public static string TheEitherIsALeft<TLeft, TRight>(string description)
      => $"{description}: {TheEither<TLeft, TRight>()}{IsALeftWhenWeExpectedItToBeARight}";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsARight<TLeft, TRight>()
      => TheEither<TLeft, TRight>()
       + IsARightWhenWeExpectedItToBeALeft;

   /* ------------------------------------------------------------ */

   public static string TheEitherIsARight<TLeft, TRight>(string description)
      => $"{description}: {TheEither<TLeft, TRight>()}{IsARightWhenWeExpectedItToBeALeft}";

   /* ------------------------------------------------------------ */

   public static string TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>()
      => TheEither<TLeft, TRight>()
       + IsARightButDoesNotContainTheExpectedContent;

   /* ------------------------------------------------------------ */

   public static string TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(string description)
      => $"{description}: {TheEither<TLeft, TRight>()}{IsARightButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string IsALeftButDoesNotContainTheExpectedContent  = "is a left but does not contain the expected content";
   private const string IsALeftWhenWeExpectedItToBeARight           = "is a left when we expected it to be a right";
   private const string IsARightButDoesNotContainTheExpectedContent = "is a right but does not contain the expected content";
   private const string IsARightWhenWeExpectedItToBeALeft           = "is a right when we expected it to be a left";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheEither<TLeft, TRight>()
      => $@"The Either<{typeof(TLeft).Name}, {typeof(TRight).Name}> ";

   /* ------------------------------------------------------------ */
}