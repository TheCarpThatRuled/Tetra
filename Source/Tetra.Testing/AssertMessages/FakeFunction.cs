namespace Tetra.Testing;

partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedAnUnexpectedNumberOfTimes<TReturn>(string description)
      => $"{description}: The {TheFakeFunction<TReturn>()}  was invoked an unexpected number of times.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedMoreThanOnce<T, TReturn>(string description)
      => $"{description}: The {TheFakeFunction<T, TReturn>()}  was invoked more than once.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<TReturn>(string description)
      => $"{description}: The {TheFakeFunction<TReturn>()} was invoked, when we expected it not to be.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<T, TReturn>(string description)
      => $"{description}: The {TheFakeFunction<T, TReturn>()} was invoked, when we expected it not to be.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWithAnUnexpectedArgument<T, TReturn>(string description)
      => $"{description}: The {TheFakeFunction<T, TReturn>()} was invoked with an unexpected argument.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasNotInvokedWheWeExpectedToBe<T, TReturn>(string description)
      => $"{description}: The {TheFakeFunction<T, TReturn>()}  was not invoked, when we expected it to be.";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheFakeFunction<TReturn>()
      => $"FakeFunction <{typeof(TReturn).Name}>";

   /* ------------------------------------------------------------ */

   private static string TheFakeFunction<T, TReturn>()
      => $"FakeFunction <{typeof(T).Name},{typeof(TReturn).Name}>";

   /* ------------------------------------------------------------ */
}