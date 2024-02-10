using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasInvoked
   (
      string     description,
      FakeAction action,
      int        numberOfInvocations
   )
      => AsProperty(() => action.Invocations() == numberOfInvocations)
        .Label(Failed.InTheAsserts(TheFakeActionWasInvokedAnUnexpectedNumberOfTimes(description),
                                   Failed.Expected(numberOfInvocations),
                                   Failed.Actual(action.Invocations())));

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce
   (
      string     description,
      FakeAction action
   )
      => WasInvoked(description,
                    action,
                    1);

   /* ------------------------------------------------------------ */

   public static Property WasNotInvoked
   (
      string     description,
      FakeAction action
   )
      => AsProperty(() => action.Invocations() == 0)
        .Label(TheFakeActionWasInvokedWhenWeExpectedItNotToBe(description));

   /* ------------------------------------------------------------ */
}