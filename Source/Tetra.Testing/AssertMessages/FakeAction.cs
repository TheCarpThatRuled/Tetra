namespace Tetra.Testing;

partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Actions
   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedAnUnexpectedNumberOfTimes(string description)
      => $"{description}: {TheFakeAction()} {WasInvokedAnUnexpectedNumberOfTimes}";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedMoreThanOnce<T>(string description)
      => $"{description}: {TheFakeAction<T>()} {WasInvokedMoreThanOnce}";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedMoreThanOnce<T0, T1>(string description)
      => $"{description}: {TheFakeAction<T0, T1>()} {WasInvokedMoreThanOnce}";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWhenWeExpectedItNotToBe(string description)
      => $"{description}: {TheFakeAction()} {WasInvokedWhenWeExpectedItNotToHaveBeen}";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWhenWeExpectedItNotToBe<T>(string description)
      => $"{description}: {TheFakeAction<T>()} {WasInvokedWhenWeExpectedItNotToHaveBeen}";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWhenWeExpectedItNotToBe<T0, T1>(string description)
      => $"{description}: {TheFakeAction<T0, T1>()} {WasInvokedWhenWeExpectedItNotToHaveBeen}";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWithAnUnexpectedArgument<T>(string description)
      => $"{description}: {TheFakeAction<T>()} {WasInvokedWithAnUnexpectedArgument}";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasInvokedWithAnUnexpectedArgument<T0, T1>(string description)
      => $"{description}: {TheFakeAction<T0, T1>()} {WasInvokedWithAnUnexpectedArgument}";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasNotInvokedWheWeExpectedToBe<T>(string description)
      => $"{description}: {TheFakeAction<T>()} {WasNotInvokedWhenWeExpectedItToHaveBeen}";

   /* ------------------------------------------------------------ */

   public static string TheFakeActionWasNotInvokedWheWeExpectedToBe<T0, T1>(string description)
      => $"{description}: {TheFakeAction<T0, T1>()} {WasNotInvokedWhenWeExpectedItToHaveBeen}";

   /* ------------------------------------------------------------ */
   // Private Actions
   /* ------------------------------------------------------------ */

   private static string TheFakeAction()
      => $"{The} FakeAction";

   /* ------------------------------------------------------------ */

   private static string TheFakeAction<T>()
      => $"{The} FakeAction <{typeof(T).Name}>";

   /* ------------------------------------------------------------ */

   private static string TheFakeAction<T0, T1>()
      => $"{The} FakeAction <{typeof(T0).Name}, {typeof(T1).Name}>";

   /* ------------------------------------------------------------ */
}