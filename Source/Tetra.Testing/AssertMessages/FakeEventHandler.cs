namespace Tetra.Testing;

partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheFakeEventHandlerWasFiredAnUnexpectedNumberOfTimes(string description)
      => $"{description}: {TheFakeEventHandler} {WasFiredAnUnexpectedNumberOfTimes}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeEventHandlerWasFiredMoreThanOnce(string description)
      => $"{description}: {TheFakeEventHandler} {WasFiredMoreThanOnce}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeEventHandlerWasFiredWhenWeExpectedItNotToBe(string description)
      => $"{description}: {TheFakeEventHandler} {WasFiredWhenWeExpectedItNotToHaveBeen}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeEventHandlerWasNotFiredWhenWeExpectedToHaveBeen(string description)
      => $"{description}: {TheFakeEventHandler} {WasNotFiredWhenWeExpectedItToHaveBeen}.";

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string TheFakeEventHandler = $"{The} FakeEventHandler>";

   /* ------------------------------------------------------------ */
}