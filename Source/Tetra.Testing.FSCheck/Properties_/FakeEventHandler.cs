using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasFiredOnce
   (
      string           description,
      FakeEventHandler fakeEventHandler
   )
      => fakeEventHandler.NumberOfTimesFired() == 0
            ? False(TheFakeEventHandlerWasNotFiredWhenWeExpectedToHaveBeen(description))
            : fakeEventHandler.NumberOfTimesFired() != 1
               ? False(Failed.InTheAsserts(TheFakeEventHandlerWasFiredMoreThanOnce(description),
                                           Failed.Actual(fakeEventHandler.NumberOfTimesFired())))
               : True();

   /* ------------------------------------------------------------ */
}