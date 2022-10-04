namespace Tetra.Testing;

partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedAnUnexpectedNumberOfTimes<TReturn>(string description)
      => $"{description}: {TheFakeFunction<TReturn>()} {WasInvokedAnUnexpectedNumberOfTimes}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedMoreThanOnce<T, TReturn>(string description)
      => $"{description}: {TheFakeFunction<T, TReturn>()} {WasInvokedMoreThanOnce}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<TReturn>(string description)
      => $"{description}: {TheFakeFunction<TReturn>()} {WasInvokedWhenWeExpectedItNotToBe}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<T, TReturn>(string description)
      => $"{description}: {TheFakeFunction<T, TReturn>()} {WasInvokedWhenWeExpectedItNotToBe}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWithAnUnexpectedArgument<T, TReturn>(string description)
      => $"{description}: {TheFakeFunction<T, TReturn>()} {WasInvokedWithAnUnexpectedArgument}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasNotInvokedWheWeExpectedToBe<T, TReturn>(string description)
      => $"{description}: {TheFakeFunction<T, TReturn>()} {WasNotInvokedWhenWeExpectedItToBe}.";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheFakeFunction<TReturn>()
      => $"{The} FakeFunction <{typeof(TReturn).Name}>";

   /* ------------------------------------------------------------ */

   private static string TheFakeFunction<T, TReturn>()
      => $"{The} FakeFunction <{typeof(T).Name},{typeof(TReturn).Name}>";

   /* ------------------------------------------------------------ */
}