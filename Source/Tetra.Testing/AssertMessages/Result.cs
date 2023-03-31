namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureButDoesNotContainTheExpectedContent<TSuccess>(string description)
      => $"{description}: {TheResult<TSuccess>()} {Is} {AFailure} {ButDoesNotContain} {TheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureButDoesNotContainTheExpectedContent<TSuccess, TFailure>(string description)
      => $"{description}: {TheResult<TSuccess, TFailure>()} {Is} {AFailure} {ButDoesNotContain} {TheExpectedContent}.";

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureWhenWeExpectedItToBeASuccess<TSuccess>(string description)
      => $"{description}: {TheResult<TSuccess>()} {Is} {AFailure} {WhenWeExpectedItToBe} {ASuccess}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsAFailureWhenWeExpectedItToBeASuccess<TSuccess, TFailure>(string description)
      => $"{description}: {TheResult<TSuccess, TFailure>()} {Is} {AFailure} {WhenWeExpectedItToBe} {ASuccess}.";

   /* ------------------------------------------------------------ */

   public static string TheResultIsASuccessButDoesNotContainTheExpectedContent<TSuccess, TFailure>(string description)
      => $"{description}: {TheResult<TSuccess, TFailure>()} {Is} {ASuccess} {ButDoesNotContain} {TheExpectedContent}.";

   /* ------------------------------------------------------------ */

   public static string TheResultIsASuccessWhenWeExpectedItToBeAFailure<TSuccess>(string description)
      => $"{description}: {TheResult<TSuccess>()} {Is} {ASuccess} {WhenWeExpectedItToBe} {AFailure}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsASuccessWhenWeExpectedItToBeAFailure<TSuccess, TFailure>(string description)
      => $"{description}: {TheResult<TSuccess, TFailure>()} {Is} {ASuccess} {WhenWeExpectedItToBe} {AFailure}.";

   /* ------------------------------------------------------------ */

   public static string TheResultIsUnrecognisedWhenWeExpectedItToBeAFailure<TSuccess>(string description)
      => $"{description}: {TheResult<TSuccess>()}{Is} {Unrecognised} {WhenWeExpectedItToBe} {AFailure}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsUnrecognisedWhenWeExpectedItToBeAFailure<TSuccess, TFailure>(string description)
      => $"{description}: {TheResult<TSuccess, TFailure>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {AFailure}.";

   /* ------------------------------------------------------------ */

   public static string TheResultIsUnrecognisedWhenWeExpectedItToBeASuccess<TSuccess>(string description)
      => $"{description}: {TheResult<TSuccess>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {ASuccess}";

   /* ------------------------------------------------------------ */

   public static string TheResultIsUnrecognisedWhenWeExpectedItToBeASuccess<TSuccess, TFailure>(string description)
      => $"{description}: {TheResult<TSuccess, TFailure>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {ASuccess}.";

   /* ------------------------------------------------------------ */
   // Internal Extensions
   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<TSuccess>(this Result<TSuccess>.FailureResult failure)
      => $@"Failure(""{failure.Content}"")";

   /* ------------------------------------------------------------ */


   internal static string ToTestOutput<TSuccess, TFailure>(this Result<TSuccess,TFailure>.FailureResult failure)
      => $@"Failure(""{failure.Content}"")";

   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<TSuccess, TFailure>(this Result<TSuccess, TFailure>.SuccessResult success)
      => $@"Success(""{success.Content}"")";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string AFailure = $"{A} failure";
   private const string ASuccess = $"{A} success";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheResult<TSuccess>()
      => $"The Result<{typeof(TSuccess).Name}>";

   /* ------------------------------------------------------------ */

   private static string TheResult<TSuccess, TFailure>()
      => $@"{The} Result<{typeof(TSuccess).Name}, {typeof(TFailure).Name}> ";

   /* ------------------------------------------------------------ */
}