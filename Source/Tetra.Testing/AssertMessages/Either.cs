namespace Tetra.Testing
{
   public static partial class AssertMessages
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static string TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>()
         => Either<TLeft, TRight>()
          + IsALeftButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(string name)
         => Either<TLeft, TRight>(name)
          + IsALeftButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>()
         => Either<TLeft, TRight>()
          + IsARightButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(string name)
         => Either<TLeft, TRight>(name)
          + IsARightButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheEitherIsALeft<TLeft, TRight>()
         => Either<TLeft, TRight>()
          + IsALeftWhenWeExpectedItToBeARight;

      /* ------------------------------------------------------------ */

      public static string TheEitherIsALeft<TLeft, TRight>(string name)
         => Either<TLeft, TRight>(name)
          + IsALeftWhenWeExpectedItToBeARight;

      /* ------------------------------------------------------------ */

      public static string TheEitherIsARight<TLeft, TRight>()
         => Either<TLeft, TRight>()
          + IsARightWhenWeExpectedItToBeALeft;

      /* ------------------------------------------------------------ */

      public static string TheEitherIsARight<TLeft, TRight>(string name)
         => Either<TLeft, TRight>(name)
          + IsARightWhenWeExpectedItToBeALeft;

      /* ------------------------------------------------------------ */
      // Private Constants
      /* ------------------------------------------------------------ */

      private const string IsALeftButDoesNotContainTheExpectedContent = "is a left but does not contain the expected content";
      private const string IsALeftWhenWeExpectedItToBeARight        = "is a left when we expected it to be a right";
      private const string IsARightButDoesNotContainTheExpectedContent = "is a right but does not contain the expected content";
      private const string IsARightWhenWeExpectedItToBeALeft        = "is a right when we expected it to be a left";

      /* ------------------------------------------------------------ */
      // Private Functions
      /* ------------------------------------------------------------ */

      private static string Either<TLeft, TRight>(string? name = null)
      {
         var result = $@"The Either<{typeof(TLeft).Name}, {typeof(TRight).Name}> ";

         if (name is not null)
         {
            result += $@"""{name}"" ";
         }

         return result;
      }

      /* ------------------------------------------------------------ */
   }
}