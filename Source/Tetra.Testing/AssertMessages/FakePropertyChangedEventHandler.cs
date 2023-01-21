namespace Tetra.Testing;

partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheFakePropertyChangedEventHandlerWasFiredAnUnexpectedNumberOfTimes(string description)
      => $"{description}: {TheFakePropertyChangedEventHandler} {WasFiredAnUnexpectedNumberOfTimes}.";

   /* ------------------------------------------------------------ */

   public static string TheFakePropertyChangedEventHandlerWasFiredMoreThanOnce(string description)
      => $"{description}: {TheFakePropertyChangedEventHandler} {WasFiredMoreThanOnce}.";

   /* ------------------------------------------------------------ */

   public static string TheFakePropertyChangedEventHandlerWasFiredWhenWeExpectedItNotToBe(string description)
      => $"{description}: {TheFakePropertyChangedEventHandler} {WasFiredWhenWeExpectedItNotToHaveBeen}.";

   /* ------------------------------------------------------------ */

   public static string TheFakePropertyChangedEventHandlerWasFiredWithAnUnexpectedArgument(string description)
      => $"{description}: {TheFakePropertyChangedEventHandler} {WasFiredWithAnUnexpectedArgument}.";

   /* ------------------------------------------------------------ */

   public static string TheFakePropertyChangedEventHandlerWasNotFiredWheWeExpectedToHaveBeen(string description)
      => $"{description}: {TheFakePropertyChangedEventHandler} {WasNotFiredWhenWeExpectedItToHaveBeen}.";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string TheFakePropertyChangedEventHandler = $"{The} FakePropertyChangedEventHandler>";

   /* ------------------------------------------------------------ */
}