using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {
      public sealed class ForDoWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> was_invoked_once_with
         (
            FakeExternalState externalState,
            FakeRight         expected
         )
            => the_whenRight.action.was_invoked_once_with<FakeExternalState, FakeRight, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>(externalState,
               expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenRight.action.was_not_invoked<FakeExternalState, FakeRight, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}