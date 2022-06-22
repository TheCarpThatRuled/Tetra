namespace Tetra.Testing
{
   public static partial class AssertMessages
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static string TheResultIsAFailureButDoesNotContainTheExpectedContent<T>()
         => Result<T>()
          + IsAFailureButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(string name)
         => Result<T>(name)
          + IsAFailureButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheResultIsASuccessButDoesNotContainTheExpectedContent<T>()
         => Result<T>()
          + IsASuccessButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(string name)
         => Result<T>(name)
          + IsASuccessButDoesNotContainTheExpectedContent;

      /* ------------------------------------------------------------ */

      public static string TheResultIsAFailure<T>()
         => Result<T>()
          + IsAFailureWhenWeExpectedItToBeASuccess;

      /* ------------------------------------------------------------ */

      public static string TheResultIsAFailure<T>(Message message)
         => Result<T>()
          + IsAFailureWhenWeExpectedItToBeASuccess
          + "\n"
          + "Actual message: "
          + message.Content();

      /* ------------------------------------------------------------ */

      public static string TheResultIsAFailure<T>(string name)
         => Result<T>(name)
          + IsAFailureWhenWeExpectedItToBeASuccess;

      /* ------------------------------------------------------------ */

      public static string TheResultIsAFailure<T>(string name,
                                                  Message message)
         => Result<T>(name)
          + IsAFailureWhenWeExpectedItToBeASuccess
          + "\n"
          + "Actual message: "
          + message.Content();

      /* ------------------------------------------------------------ */

      public static string TheResultIsASuccess<T>()
         => Result<T>()
          + IsASuccessWhenWeExpectedItToBeAFailure;

      /* ------------------------------------------------------------ */

      public static string TheResultIsASuccess<T>(string name)
         => Result<T>(name)
          + IsASuccessWhenWeExpectedItToBeAFailure;

      /* ------------------------------------------------------------ */
      // Private Constants
      /* ------------------------------------------------------------ */

      private const string IsAFailureButDoesNotContainTheExpectedContent = "is a failure but does not contain the expected content";
      private const string IsAFailureWhenWeExpectedItToBeASuccess        = "is a failure when we expected it to be a success";
      private const string IsASuccessButDoesNotContainTheExpectedContent = "is a success but does not contain the expected content";
      private const string IsASuccessWhenWeExpectedItToBeAFailure        = "is a success when we expected it to be a failure";

      /* ------------------------------------------------------------ */
      // Private Functions
      /* ------------------------------------------------------------ */

      private static string Result<T>(string? name = null)
      {
         var result = $@"The Result<{typeof(T).Name}> ";

         if (name is not null)
         {
            result += $@"""{name}"" ";
         }

         return result;
      }

      /* ------------------------------------------------------------ */
   }
}