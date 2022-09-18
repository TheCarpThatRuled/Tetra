namespace Tetra.Testing;

partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Actions
   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedAnUnexpectedNumberOfTimes(string description)
      => $"{description}: The {TheFakeAction()}  was invoked an unexpected number of times.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedMoreThanOnce<T>(string description)
      => $"{description}: The {TheFakeAction<T>()}  was invoked more than once.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWhenWeExpectedItNotToBe(string description)
      => $"{description}: The {TheFakeAction()} was invoked, when we expected it not to be.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWhenWeExpectedItNotToBe<T>(string description)
      => $"{description}: The {TheFakeAction<T>()} was invoked, when we expected it not to be.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWithAnUnexpectedArgument<T>(string description)
      => $"{description}: The {TheFakeAction<T>()} was invoked with an unexpected argument.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasNotInvokedWheWeExpectedToBe<T>(string description)
      => $"{description}: The {TheFakeAction<T>()}  was not invoked, when we expected it to be.";

   /* ------------------------------------------------------------ */
   // Private Actions
   /* ------------------------------------------------------------ */

   private static string TheFakeAction()
      => "FakeAction";

   /* ------------------------------------------------------------ */

   private static string TheFakeAction<T>()
      => $"FakeAction <{typeof(T).Name}>";

   /* ------------------------------------------------------------ */
}