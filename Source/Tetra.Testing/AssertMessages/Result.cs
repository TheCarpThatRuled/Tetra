namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureButDoesNotContainTheExpectedMessage<T>(string description)
      => $"{description}: {TheResult<T>()} {Is} {AFailure} {ButDoesNotContain} {TheExpectedMessage}.";

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureButDoesNotContainTheExpectedMessage<T>(string  description,
                                                                                  Message message)
      => $"{description}: {TheResult<T>()} {Is} {AFailure} {ButDoesNotContain} {TheExpectedMessage}\n Actual message:{message.Content()}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(string description)
      => $"{description}: {TheResult<T>()} {Is} {ASuccess} {ButDoesNotContain} {TheExpectedContent}.";

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureWhenWeExpectedItToBeASuccess<T>(string description)
      => $"{description}: {TheResult<T>()} {Is} {AFailure} {WhenWeExpectedItToBe} {ASuccess}.";

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureWhenWeExpectedItToBeASuccess<T>(string  description,
                                                                           Message message)
      => $"{description}: {TheResult<T>()} {Is} {AFailure} {WhenWeExpectedItToBe} {ASuccess}\n Actual message:{message.Content()}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsASuccessWhenWeExpectedItToBeAFailure<T>(string description)
      => $"{description}: {TheResult<T>()} {Is} {ASuccess} {WhenWeExpectedItToBe} {AFailure}.";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string AFailure = $"{A} failure";
   private const string ASuccess = $"{A} success";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheResult<T>()
      => $@"{The} Result<{typeof(T).Name}> ";

   /* ------------------------------------------------------------ */
}