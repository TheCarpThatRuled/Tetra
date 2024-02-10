using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasFiredOnce
   (
      string                          description,
      FakePropertyChangedEventHandler fakeEventHandler,
      string                          expected
   )
      => fakeEventHandler
        .Arguments()
        .Length()
      == 0
            ? False(TheFakePropertyChangedEventHandlerWasNotFiredWheWeExpectedToHaveBeen(description))
            : fakeEventHandler
             .Arguments()
             .Length()
           != 1
               ? False(Failed.InTheAsserts(TheFakePropertyChangedEventHandlerWasFiredMoreThanOnce(description),
                                           Failed.Actual(fakeEventHandler.Arguments()
                                                                         .Length())))
               : AreEqual(TheFakePropertyChangedEventHandlerWasFiredWithAnUnexpectedArgument(description),
                          expected,
                          fakeEventHandler.Arguments()[0]
                                          .PropertyName!);

   /* ------------------------------------------------------------ */

   public static Property WasNotFired
   (
      string                          description,
      FakePropertyChangedEventHandler fakeEventHandler
   )
      => AreEqual(TheFakePropertyChangedEventHandlerWasFiredWhenWeExpectedItNotToBe(description),
                  0,
                  fakeEventHandler.Arguments()
                                  .Length());

   /* ------------------------------------------------------------ */
}