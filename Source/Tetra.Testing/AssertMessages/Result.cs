namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureButDoesNotContainTheExpectedContent<T>()
      => TheResult<T>()
       + IsAFailureButDoesNotContainTheExpectedContent;

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(string description)
      => $"{description}: {TheResult<T>()}{IsAFailureButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsASuccessButDoesNotContainTheExpectedContent<T>()
      => TheResult<T>()
       + IsASuccessButDoesNotContainTheExpectedContent;

   /* ------------------------------------------------------------ */

   public static string TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(string description)
      => $"{description}: {TheResult<T>()}{IsASuccessButDoesNotContainTheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailure<T>()
      => TheResult<T>()
       + IsAFailureWhenWeExpectedItToBeASuccess;

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailure<T>(Message message)
      => TheResult<T>()
       + IsAFailureWhenWeExpectedItToBeASuccess
       + "\n"
       + "Actual message: "
       + message.Content();

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailure<T>(string description)
      => $"{description}: {TheResult<T>()}{IsAFailureWhenWeExpectedItToBeASuccess}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailure<T>(string  description,
                                               Message message)
      => $"{description}: {TheResult<T>()}{IsAFailureWhenWeExpectedItToBeASuccess}\n Actual message:{message.Content()}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsASuccess<T>()
      => TheResult<T>()
       + IsASuccessWhenWeExpectedItToBeAFailure;

   /* ------------------------------------------------------------ */

   public static string TheResultIsASuccess<T>(string description)
      => $"{description}: {TheResult<T>()}{IsASuccessWhenWeExpectedItToBeAFailure}";

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

   private static string TheResult<T>()
      => $@"The Result<{typeof(T).Name}> ";

   /* ------------------------------------------------------------ */
}