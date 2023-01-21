namespace Tetra.Testing;

partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Actions
   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedAnUnexpectedNumberOfTimes(string description)
      => $"{description}: {TheFakeAction()} {WasInvokedAnUnexpectedNumberOfTimes}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedMoreThanOnce<T>(string description)
      => $"{description}: {TheFakeAction<T>()} {WasInvokedMoreThanOnce}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWhenWeExpectedItNotToBe(string description)
      => $"{description}: {TheFakeAction()} {WasInvokedWhenWeExpectedItNotToHaveBeen}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWhenWeExpectedItNotToBe<T>(string description)
      => $"{description}: {TheFakeAction<T>()} {WasInvokedWhenWeExpectedItNotToHaveBeen}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWithAnUnexpectedArgument<T>(string description)
      => $"{description}: {TheFakeAction<T>()} {WasInvokedWithAnUnexpectedArgument}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasNotInvokedWheWeExpectedToBe<T>(string description)
      => $"{description}: {TheFakeAction<T>()} {WasNotInvokedWhenWeExpectedItToHaveBeen}.";

   /* ------------------------------------------------------------ */
   // Private Actions
   /* ------------------------------------------------------------ */

   private static string TheFakeAction()
      => $"{The} FakeAction";

   /* ------------------------------------------------------------ */

   private static string TheFakeAction<T>()
      => $"{The} FakeAction <{typeof(T).Name}>";

   /* ------------------------------------------------------------ */
}